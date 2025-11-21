using DataGridView.Entities;
using DataGridView.Services;
using System.Windows.Forms;

namespace DataGridView.App
{
    public partial class MainForm : Form
    {
        private readonly ITourService _tourService;
        private readonly BindingSource _bindingSource = new BindingSource();

        public MainForm(ITourService tourService)
        {
            _tourService = tourService;
            InitializeComponent();
            SetupGrid();
            RefreshStats();
        }

        private void RefreshData()
        {
            _bindingSource.ResetBindings(false);
            RefreshStats();
        }

        private void SetupGrid()
        {
            _bindingSource.DataSource = _tourService.GetAllTours();  
            dataGridViewTours.DataSource = _bindingSource; 

            dataGridViewTours.AutoGenerateColumns = true;

            dataGridViewTours.Columns["Id"].Visible = false;
            dataGridViewTours.Columns["Direction"].HeaderText = "Направление";
            dataGridViewTours.Columns["DepartureDate"].HeaderText = "Дата вылета";
            dataGridViewTours.Columns["Nights"].HeaderText = "Ночей";
            dataGridViewTours.Columns["PricePerPerson"].HeaderText = "Стоимость за отдыхающего";
            dataGridViewTours.Columns["NumberOfPeople"].HeaderText = "Количество отдыхающих";
            dataGridViewTours.Columns["HasWiFi"].HeaderText = "Wi-Fi";
            dataGridViewTours.Columns["Surcharges"].HeaderText = "Доплаты";

            dataGridViewTours.Columns["DepartureDate"].DefaultCellStyle.Format = "dd.MM.yyyy";

            var totalCostColumn = new DataGridViewTextBoxColumn()
            {
                Name = "TotalCost",
                HeaderText = "Общая стоимость",
                Width = 120
            };
            dataGridViewTours.Columns.Add(totalCostColumn);

            dataGridViewTours.DataError += DataGridViewTours_DataError;
        }

        private void DataGridViewTours_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                e.ThrowException = false;
                e.Cancel = true;
            }
        }

        private void dataGridViewTours_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridViewTours.Columns[e.ColumnIndex];
            var row = dataGridViewTours.Rows[e.RowIndex];

            if (row.DataBoundItem is not Tour tour) return;

            if (col.DataPropertyName == nameof(Tour.Direction))
            {
                e.Value = tour.Direction switch
                {
                    Direction.Turkey => "Турция",
                    Direction.Spain => "Испания",
                    Direction.Italy => "Италия",
                    Direction.France => "Франция",
                    Direction.Shushary => "Шушары",
                    _ => tour.Direction.ToString()
                };
                e.FormattingApplied = true;
            }
            else if (col.DataPropertyName == nameof(Tour.PricePerPerson) ||
                     col.DataPropertyName == nameof(Tour.Surcharges))
            {
                if (e.Value is decimal decimalValue)
                {
                    e.Value = decimalValue.ToString("C0");
                    e.FormattingApplied = true;
                }
            }
            else if (col.Name == "TotalCost")
            {
                decimal totalCost = (tour.PricePerPerson * tour.NumberOfPeople) + tour.Surcharges;
                e.Value = totalCost.ToString("C0");
                e.FormattingApplied = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new TourForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _tourService.AddTour(form.Tour);  
                RefreshData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null) 
            {
                MessageBox.Show("Выберите тур для редактирования", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tour = (Tour)_bindingSource.Current;  
            var form = new TourForm(tour.Clone());
            if (form.ShowDialog() == DialogResult.OK)
            {
                _tourService.UpdateTour(form.Tour);  
                RefreshData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null) 
            {
                MessageBox.Show("Выберите тур для удаления", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tour = (Tour)_bindingSource.Current;  
            var result = MessageBox.Show($"Удалить тур в {tour.Direction}?", "Подтверждение удаления",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _tourService.DeleteTour(tour.Id); 
                RefreshData();
            }
        }

        private void RefreshStats()
        {
            labelTotalTours.Text = $"Всего туров: {_tourService.GetTotalTours()}"; 
            labelTotalCost.Text = $"Общая сумма: {_tourService.GetTotalCost():C}";  
            labelToursWithSurcharges.Text = $"Туров с доплатами: {_tourService.GetToursWithSurcharges()}";  
            labelTotalSurcharges.Text = $"Общая сумма доплат: {_tourService.GetTotalSurcharges():C}"; 
        }
    }
}