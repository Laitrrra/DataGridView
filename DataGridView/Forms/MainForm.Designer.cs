namespace DataGridView
{
    partial class MainForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dataGridViewTours = new System.Windows.Forms.DataGridView();
            toolStrip1 = new ToolStrip();
            AddButton = new ToolStripButton();
            EditButton = new ToolStripButton();
            DeleteButton = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            labelTotalCost = new ToolStripStatusLabel();
            labelToursWithSurcharges = new ToolStripStatusLabel();
            labelTotalSurcharges = new ToolStripStatusLabel();
            labelTotalTours = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTours).BeginInit();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewTours
            // 
            dataGridViewTours.AllowUserToAddRows = false;
            dataGridViewTours.AllowUserToDeleteRows = false;
            dataGridViewTours.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTours.Location = new Point(0, 28);
            dataGridViewTours.Name = "dataGridViewTours";
            dataGridViewTours.ReadOnly = true;
            dataGridViewTours.Size = new Size(800, 422);
            dataGridViewTours.TabIndex = 0;
            dataGridViewTours.CellFormatting += dataGridViewTours_CellFormatting;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { AddButton, EditButton, DeleteButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // AddButton
            // 
            AddButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            AddButton.Image = (Image)resources.GetObject("AddButton.Image");
            AddButton.ImageTransparentColor = Color.Magenta;
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(84, 22);
            AddButton.Text = "Добавить тур";
            AddButton.Click += btnAdd_Click;
            // 
            // EditButton
            // 
            EditButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            EditButton.Image = (Image)resources.GetObject("EditButton.Image");
            EditButton.ImageTransparentColor = Color.Magenta;
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(86, 22);
            EditButton.Text = "Изменить тур";
            EditButton.Click += btnEdit_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DeleteButton.Image = (Image)resources.GetObject("DeleteButton.Image");
            DeleteButton.ImageTransparentColor = Color.Magenta;
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(76, 22);
            DeleteButton.Text = "Удалить тур";
            DeleteButton.Click += btnDelete_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { labelTotalCost, labelToursWithSurcharges, labelTotalSurcharges, labelTotalTours });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // labelTotalCost
            // 
            labelTotalCost.Name = "labelTotalCost";
            labelTotalCost.Size = new Size(0, 17);
            // 
            // labelToursWithSurcharges
            // 
            labelToursWithSurcharges.Name = "labelToursWithSurcharges";
            labelToursWithSurcharges.Size = new Size(0, 17);
            // 
            // labelTotalSurcharges
            // 
            labelTotalSurcharges.Name = "labelTotalSurcharges";
            labelTotalSurcharges.Size = new Size(0, 17);
            // 
            // labelTotalTours
            // 
            labelTotalTours.Name = "labelTotalTours";
            labelTotalTours.Size = new Size(0, 17);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(dataGridViewTours);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Горящие туры";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTours).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTours;
        private ToolStrip toolStrip1;
        private ToolStripButton AddButton;
        private ToolStripButton EditButton;
        private ToolStripButton DeleteButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labelTotalCost;
        private ToolStripStatusLabel labelToursWithSurcharges;
        private ToolStripStatusLabel labelTotalSurcharges;
        private ToolStripStatusLabel labelTotalTours;
    }
}
