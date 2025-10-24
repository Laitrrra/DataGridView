using DataGridView.Models;
using System;
using System.Windows.Forms;

namespace DataGridView
{
    public partial class MainForm : Form
    {
        private TourModel tours = new TourModel();
        private BindingSource bindingSource = new BindingSource();

        public MainForm()
        {
            tours.Tours.AddRange(new[]
            {
                new Tour
                {
                    Id = 1,
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
                    Id = 2,
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
                    Id = 3,
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
                    Id = 4,
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
                    Id = 5,
                    Direction = Direction.Shushary,
                    DepartureDate = DateTime.Now.AddDays(2),
                    Nights = 2,
                    PricePerPerson = 5000,
                    NumberOfPeople = 1,
                    HasWiFi = false,
                    Surcharges = 0
                }
            });

            InitializeComponent();
            SetupGrid();
            RefreshStats();
        }

        private void SetupGrid()
        {
            bindingSource.DataSource = tours.Tours;
            dataGridViewTours.DataSource = bindingSource;

            dataGridViewTours.Columns["Id"].Visible = false;
            dataGridViewTours.Columns["Direction"].HeaderText = "Направление";
            dataGridViewTours.Columns["DepartureDate"].HeaderText = "Дата вылета";
            dataGridViewTours.Columns["Nights"].HeaderText = "Ночей";
            dataGridViewTours.Columns["PricePerPerson"].HeaderText = "Стоимость за отдыхающего";
            dataGridViewTours.Columns["NumberOfPeople"].HeaderText = "Количество отдыхающих";
            dataGridViewTours.Columns["HasWiFi"].HeaderText = "Wi-Fi";
            dataGridViewTours.Columns["Surcharges"].HeaderText = "Доплаты";
            dataGridViewTours.Columns["TotalCost"].HeaderText = "Общая стоимость";

            dataGridViewTours.Columns["PricePerPerson"].DefaultCellStyle.Format = "C0";
            dataGridViewTours.Columns["Surcharges"].DefaultCellStyle.Format = "C0";
            dataGridViewTours.Columns["TotalCost"].DefaultCellStyle.Format = "C0";
            dataGridViewTours.Columns["DepartureDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
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
                    Direction.Unknown => "Неизвестно",
                    _ => "Неизвестно"
                };
                e.FormattingApplied = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new TourForm(new Tour(), true);
            if (form.ShowDialog() == DialogResult.OK)
            {
                tours.Add(form.Tour);
                bindingSource.ResetBindings(false);
                RefreshStats();
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
            var form = new TourForm(tour.Clone(), false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                tours.Update(form.Tour);
                bindingSource.ResetBindings(false);
                RefreshStats();
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
                bindingSource.ResetBindings(false);
                RefreshStats();
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