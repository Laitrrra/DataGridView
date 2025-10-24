using System;
using System.Windows.Forms;
using DataGridView.Models;
using DataGridView;
using DataGridView.Infrastructure; 

namespace DataGridView
{
    public partial class TourForm : Form
    {
        private Tour tours;

        public Tour Tour => tours;

        public TourForm(Tour tour, bool isNew)
        {
            tours = tour;

            InitializeComponent();

            var directions = Enum.GetValues(typeof(Direction));
            var validDirections = new System.Collections.ArrayList();

            foreach (Direction direction in directions)
            {
                if (direction != Direction.Unknown)
                {
                    validDirections.Add(direction);
                }
            }

            comboBoxDirection.DataSource = validDirections;

            if (tours.Direction != Direction.Unknown)
            {
                comboBoxDirection.SelectedItem = tours.Direction;
            }
            else
            {
                comboBoxDirection.SelectedIndex = 0;
            }

            InitializeBindings();
            UpdateSaveButtonState();

            this.Text = isNew ? "Добавление тура" : "Редактирование тура";
        }

        private void InitializeBindings()
        {
            comboBoxDirection.AddBinding(x => x.SelectedItem,tours,
                x => x.Direction, errorProvider1, UpdateSaveButtonState);

            dtpDeparture.AddBinding(x => x.Value,tours, x => x.DepartureDate, errorProvider1, UpdateSaveButtonState);

            numNights.AddBinding(x => x.Value, tours, x => x.Nights, errorProvider1, UpdateSaveButtonState);

            numPrice.AddBinding( x => x.Value, tours, x => x.PricePerPerson, errorProvider1, UpdateSaveButtonState);

            numPeople.AddBinding( x => x.Value, tours, x => x.NumberOfPeople, errorProvider1, UpdateSaveButtonState);

            chkWiFi.AddBinding( x => x.Checked, tours, x => x.HasWiFi, errorProvider1, UpdateSaveButtonState);

            numSurcharges.AddBinding( x => x.Value, tours, x => x.Surcharges, errorProvider1, UpdateSaveButtonState);
        }

        private void UpdateSaveButtonState()
        {
            btnOK.Enabled = tours.IsValid();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!tours.IsValid())
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