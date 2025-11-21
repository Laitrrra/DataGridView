using DataGridView.Models;
using System;
using System.Windows.Forms;

namespace DataGridView
{
    /// <summary>
    /// Главная форма приложения для управления турами
    /// </summary>
    public partial class MainForm : Form
    {
        private TourManager tours = new TourManager();
        private BindingSource bindingSource = new BindingSource();

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MainForm" />
        /// </summary>
        public MainForm()
        {
            var testTours = new[]
            {
                new Tour
                {
                    Direction = Direction.Turkey,
                    DepartureDate = DateTime.Now.AddDays(7),
                    Nights = 10,
                    PricePerPerson = 45000,
                    NumberOfPeople = 2,
                    HasWiFi = true,
                    Surcharges = 5000
                },
                new Tour
                {
                    Direction = Direction.Spain,
                    DepartureDate = DateTime.Now.AddDays(14),
                    Nights = 7,
                    PricePerPerson = 65000,
                    NumberOfPeople = 3,
                    HasWiFi = true,
                    Surcharges = 8000
                },
                new Tour
                {
                    Direction = Direction.Italy,
                    DepartureDate = DateTime.Now.AddDays(21),
                    Nights = 8,
                    PricePerPerson = 55000,
                    NumberOfPeople = 2,
                    HasWiFi = false,
                    Surcharges = 3000
                },
                new Tour
                {
                    Direction = Direction.France,
                    DepartureDate = DateTime.Now.AddDays(30),
                    Nights = 6,
                    PricePerPerson = 70000,
                    NumberOfPeople = 4,
                    HasWiFi = true,
                    Surcharges = 12000
                },
                new Tour
                {
                    Direction = Direction.Shushary,
                    DepartureDate = DateTime.Now.AddDays(2),
                    Nights = 2,
                    PricePerPerson = 5000,
                    NumberOfPeople = 1,
                    HasWiFi = false,
                    Surcharges = 0
                }
            };


            foreach (var tour in testTours)
            {
                tours.Add(tour);
            }

            InitializeComponent();
            SetupGrid();
            RefreshStats();
        }

        private void RefreshData()
        {
            bindingSource.ResetBindings(false);
            RefreshStats();
        }

        private void SetupGrid()
        {
            bindingSource.DataSource = tours.Tours;
            dataGridViewTours.DataSource = bindingSource;

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
                tours.Add(form.Tour);
                RefreshData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current == null)
            {
                MessageBox.Show("Выберите тур для редактирования", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tour = (Tour)bindingSource.Current;
            var form = new TourForm(tour.Clone());
            if (form.ShowDialog() == DialogResult.OK)
            {
                tours.Update(form.Tour);
                RefreshData(); 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current == null)
            {
                MessageBox.Show("Выберите тур для удаления", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tour = (Tour)bindingSource.Current;
            var result = MessageBox.Show($"Удалить тур в {tour.Direction}?", "Подтверждение удаления",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                tours.Remove(tour.Id);
                RefreshData();
            }
        }

        private void RefreshStats()
        {
            labelTotalTours.Text = $"Всего туров: {tours.TotalTours}";
            labelTotalCost.Text = $"Общая сумма: {tours.TotalCost:C}";
            labelToursWithSurcharges.Text = $"Туров с доплатами: {tours.ToursWithSurcharges}";
            labelTotalSurcharges.Text = $"Общая сумма доплат: {tours.TotalSurcharges:C}";
        }
    }
}