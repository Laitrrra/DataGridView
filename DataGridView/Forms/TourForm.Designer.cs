namespace DataGridView
{
    partial class TourForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxDirection;
        private System.Windows.Forms.DateTimePicker dtpDeparture;
        private System.Windows.Forms.NumericUpDown numNights;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numPeople;
        private System.Windows.Forms.CheckBox chkWiFi;
        private System.Windows.Forms.NumericUpDown numSurcharges;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            comboBoxDirection = new ComboBox();
            dtpDeparture = new DateTimePicker();
            numNights = new NumericUpDown();
            numPrice = new NumericUpDown();
            numPeople = new NumericUpDown();
            chkWiFi = new CheckBox();
            numSurcharges = new NumericUpDown();
            btnOK = new Button();
            btnCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)numNights).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPeople).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSurcharges).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxDirection
            // 
            comboBoxDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDirection.FormattingEnabled = true;
            comboBoxDirection.Location = new Point(150, 20);
            comboBoxDirection.Name = "comboBoxDirection";
            comboBoxDirection.Size = new Size(174, 23);
            comboBoxDirection.TabIndex = 0;
            // 
            // dtpDeparture
            // 
            dtpDeparture.Location = new Point(149, 56);
            dtpDeparture.Name = "dtpDeparture";
            dtpDeparture.Size = new Size(176, 23);
            dtpDeparture.TabIndex = 1;
            // 
            // numNights
            // 
            numNights.Location = new Point(149, 94);
            numNights.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNights.Name = "numNights";
            numNights.Size = new Size(175, 23);
            numNights.TabIndex = 2;
            numNights.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(149, 131);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(175, 23);
            numPrice.TabIndex = 3;
            numPrice.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // numPeople
            // 
            numPeople.Location = new Point(149, 169);
            numPeople.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPeople.Name = "numPeople";
            numPeople.Size = new Size(175, 23);
            numPeople.TabIndex = 4;
            numPeople.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // chkWiFi
            // 
            chkWiFi.AutoSize = true;
            chkWiFi.Location = new Point(149, 206);
            chkWiFi.Name = "chkWiFi";
            chkWiFi.Size = new Size(15, 14);
            chkWiFi.TabIndex = 5;
            chkWiFi.UseVisualStyleBackColor = true;
            // 
            // numSurcharges
            // 
            numSurcharges.DecimalPlaces = 2;
            numSurcharges.Location = new Point(149, 244);
            numSurcharges.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numSurcharges.Name = "numSurcharges";
            numSurcharges.Size = new Size(175, 23);
            numSurcharges.TabIndex = 6;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(26, 291);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(116, 28);
            btnOK.TabIndex = 7;
            btnOK.Text = "Сохранить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(202, 291);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(122, 28);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 22);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 9;
            label1.Text = "Направление:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 61);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 10;
            label2.Text = "Дата вылета:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 96);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 11;
            label3.Text = "Количество ночей:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 133);
            label4.Name = "label4";
            label4.Size = new Size(88, 30);
            label4.TabIndex = 12;
            label4.Text = "Стоимость за\r\nотдыхающего:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 171);
            label5.Name = "label5";
            label5.Size = new Size(83, 30);
            label5.TabIndex = 13;
            label5.Text = "Количество\r\nотдыхающих:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 206);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 14;
            label6.Text = "Wi-Fi:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 246);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 15;
            label7.Text = "Доплаты:";
            // 
            // TourForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(347, 340);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(numSurcharges);
            Controls.Add(chkWiFi);
            Controls.Add(numPeople);
            Controls.Add(numPrice);
            Controls.Add(numNights);
            Controls.Add(dtpDeparture);
            Controls.Add(comboBoxDirection);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TourForm";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)numNights).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPeople).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSurcharges).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}