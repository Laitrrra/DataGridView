using DataGridView.Entities;
using DataGridView.Entities.Models;
using DataGridView.Services.Contracts;
using System.ComponentModel;

namespace DataGridView.App.Forms
{
    /// <summary>
    /// Главная форма приложения для управления турами
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MainForm" />
        /// </summary>
        private readonly ITourService _tourService;
        private BindingSource _bindingSource = new BindingSource();

        public MainForm(ITourService tourService)
        {
            _tourService = tourService;
            InitializeComponent();
            _ = SetupGrid(); 
            _ = RefreshStats();
        }

        private void RefreshData()
        {
            bindingSource.ResetBindings(false);
            RefreshStats();
        }

        private void SetupGrid()
        {
            var tours = await _tourService.GetAllTours();
            _bindingSource.DataSource = tours.ToList();
            dataGridViewTours.DataSource = _bindingSource;

            dataGridViewTours.Columns["Id"].Visible = false;
            dataGridViewTours.Columns["Direction"].HeaderText = "Направление";
            dataGridViewTours.Columns["DepartureDate"].HeaderText = "Дата вылета";
            dataGridViewTours.Columns["Nights"].HeaderText = "Ночей";
            dataGridViewTours.Columns["PricePerPerson"].HeaderText = "Стоимость за человека";
            dataGridViewTours.Columns["NumberOfPeople"].HeaderText = "Количество людей";
            dataGridViewTours.Columns["HasWiFi"].HeaderText = "Wi-Fi";
            dataGridViewTours.Columns["Surcharges"].HeaderText = "Доплаты";
        }

        private async Task RefreshStatsAsync()
        {
            var stats = await _tourService.GetStatistics();
            labelTotalTours.Text = $"Всего туров: {stats.TourCount}";
            labelTotalCost.Text = $"Общая сумма: {stats.TotalCost:C}";
            labelToursWithSurcharges.Text = $"Туров с доплатами: {stats.ToursWithSurcharges}";
            labelTotalSurcharges.Text = $"Общая сумма доплат: {stats.TotalSurcharges:C}";
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new TourForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await _tourService.AddTour(form.Tour);
                await RefreshDataAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null) return;

            var tour = (Tour)_bindingSource.Current;
            var form = new TourForm(tour.Clone());
            if (form.ShowDialog() == DialogResult.OK)
            {
                await _tourService.UpdateTour(form.Tour);
                await RefreshDataAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null) return;

            var tour = (Tour)_bindingSource.Current;
            var result = MessageBox.Show($"Удалить тур в {tour.Direction}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await _tourService.DeleteTour(tour.Id);
                await RefreshDataAsync();
            }
        }

        private async Task RefreshDataAsync()
        {
            await SetupGridAsync();
            await RefreshStatsAsync();
        }

        private void dataGridViewTours_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridViewTours.Columns[e.ColumnIndex];
            var row = dataGridViewTours.Rows[e.RowIndex];

            if (row.DataBoundItem is not Tour tour) return;

            if (col.DataPropertyName == "Direction")
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
        }
    }
}