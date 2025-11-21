using System;
using System.Windows.Forms;
using DataGridView.Entities.Models;
using DataGridView.Infrastructure;

namespace DataGridView
{
    /// <summary>
    /// Форма для добавления и редактирования туров
    /// </summary>
    public partial class TourForm : Form
    {
        private Tour tour;

        /// <summary>
        /// Получает тур, созданный или отредактированный в форме
        /// </summary>
        public Tour Tour => tour;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="TourForm" />
        /// </summary>
        /// <param name="tour">Тур для редактирования. Если null - создается новый тур</param>
        public TourForm(Tour? tour = null)
        {
            this.tour = tour ?? new Tour();

            InitializeComponent();

            comboBoxDirection.DataSource = Enum.GetValues(typeof(Direction));

            comboBoxDirection.SelectedItem = this.tour.Direction;

            InitializeBindings();
            UpdateSaveButtonState();

            this.Text = tour == null ? "Добавление тура" : "Редактирование тура";
        }

        private void InitializeBindings()
        {
            comboBoxDirection.AddBinding(x => x.SelectedItem, tour, x => x.Direction, errorProvider1, UpdateSaveButtonState);

            dtpDeparture.AddBinding(x => x.Value, tour, x => x.DepartureDate, errorProvider1, UpdateSaveButtonState);

            numNights.AddBinding(x => x.Value, tour, x => x.Nights, errorProvider1, UpdateSaveButtonState);

            numPrice.AddBinding(x => x.Value, tour, x => x.PricePerPerson, errorProvider1, UpdateSaveButtonState);

            numPeople.AddBinding(x => x.Value, tour, x => x.NumberOfPeople, errorProvider1, UpdateSaveButtonState); 

            chkWiFi.AddBinding(x => x.Checked, tour, x => x.HasWiFi, null, UpdateSaveButtonState); 

            numSurcharges.AddBinding(x => x.Value, tour, x => x.Surcharges, errorProvider1, UpdateSaveButtonState);
        }

        private void UpdateSaveButtonState()
        {
            btnOK.Enabled = tour.IsValid();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!tour.IsValid())
            {
                MessageBox.Show("Исправьте ошибки в форме", "Ошибка валидации",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}