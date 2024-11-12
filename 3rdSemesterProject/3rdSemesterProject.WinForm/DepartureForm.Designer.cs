namespace _3rdSemesterProject.WinForm
{
    partial class DepartureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlList = new Panel();
            lstDepartures = new ListBox();
            grpItem = new GroupBox();
            btnUpdate = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            cmbRoute = new ComboBox();
            cmbBoat = new ComboBox();
            lblRoute = new Label();
            lblBoat = new Label();
            txtAvailableSeats = new TextBox();
            chkAllInclusive = new CheckBox();
            lblAvailSeats = new Label();
            txtPrice = new TextBox();
            lblPrice = new Label();
            lblDepTime = new Label();
            dtpDepTime = new DateTimePicker();
            btnCreate = new Button();
            btnDelete = new Button();
            pnlList.SuspendLayout();
            grpItem.SuspendLayout();
            SuspendLayout();
            // 
            // pnlList
            // 
            pnlList.Controls.Add(lstDepartures);
            pnlList.Location = new Point(1, 12);
            pnlList.Name = "pnlList";
            pnlList.Size = new Size(200, 426);
            pnlList.TabIndex = 0;
            // 
            // lstDepartures
            // 
            lstDepartures.FormattingEnabled = true;
            lstDepartures.ItemHeight = 15;
            lstDepartures.Location = new Point(0, 0);
            lstDepartures.Name = "lstDepartures";
            lstDepartures.Size = new Size(200, 424);
            lstDepartures.TabIndex = 0;
            lstDepartures.SelectedIndexChanged += lstDepartures_SelectedIndexChanged;
            // 
            // grpItem
            // 
            grpItem.Controls.Add(btnDelete);
            grpItem.Controls.Add(btnCreate);
            grpItem.Controls.Add(btnUpdate);
            grpItem.Controls.Add(txtDescription);
            grpItem.Controls.Add(lblDescription);
            grpItem.Controls.Add(cmbRoute);
            grpItem.Controls.Add(cmbBoat);
            grpItem.Controls.Add(lblRoute);
            grpItem.Controls.Add(lblBoat);
            grpItem.Controls.Add(txtAvailableSeats);
            grpItem.Controls.Add(chkAllInclusive);
            grpItem.Controls.Add(lblAvailSeats);
            grpItem.Controls.Add(txtPrice);
            grpItem.Controls.Add(lblPrice);
            grpItem.Controls.Add(lblDepTime);
            grpItem.Controls.Add(dtpDepTime);
            grpItem.Location = new Point(207, 12);
            grpItem.Name = "grpItem";
            grpItem.Size = new Size(367, 426);
            grpItem.TabIndex = 1;
            grpItem.TabStop = false;
            grpItem.Text = "Selected Item";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(155, 397);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(130, 244);
            txtDescription.MaxLength = 300;
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 96);
            txtDescription.TabIndex = 6;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(6, 244);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 11;
            lblDescription.Text = "Description";
            // 
            // cmbRoute
            // 
            cmbRoute.FormattingEnabled = true;
            cmbRoute.Location = new Point(130, 200);
            cmbRoute.Name = "cmbRoute";
            cmbRoute.Size = new Size(100, 23);
            cmbRoute.TabIndex = 15;
            // 
            // cmbBoat
            // 
            cmbBoat.FormattingEnabled = true;
            cmbBoat.Location = new Point(130, 158);
            cmbBoat.Name = "cmbBoat";
            cmbBoat.Size = new Size(100, 23);
            cmbBoat.TabIndex = 4;
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Location = new Point(6, 203);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(38, 15);
            lblRoute.TabIndex = 8;
            lblRoute.Text = "Route";
            // 
            // lblBoat
            // 
            lblBoat.AutoSize = true;
            lblBoat.Location = new Point(6, 161);
            lblBoat.Name = "lblBoat";
            lblBoat.Size = new Size(31, 15);
            lblBoat.TabIndex = 7;
            lblBoat.Text = "Boat";
            // 
            // txtAvailableSeats
            // 
            txtAvailableSeats.Location = new Point(130, 115);
            txtAvailableSeats.Name = "txtAvailableSeats";
            txtAvailableSeats.ReadOnly = true;
            txtAvailableSeats.Size = new Size(100, 23);
            txtAvailableSeats.TabIndex = 6;
            // 
            // chkAllInclusive
            // 
            chkAllInclusive.AutoSize = true;
            chkAllInclusive.Location = new Point(241, 80);
            chkAllInclusive.Name = "chkAllInclusive";
            chkAllInclusive.Size = new Size(89, 19);
            chkAllInclusive.TabIndex = 3;
            chkAllInclusive.Text = "All Inclusive";
            chkAllInclusive.UseVisualStyleBackColor = true;
            // 
            // lblAvailSeats
            // 
            lblAvailSeats.AutoSize = true;
            lblAvailSeats.Location = new Point(6, 118);
            lblAvailSeats.Name = "lblAvailSeats";
            lblAvailSeats.Size = new Size(85, 15);
            lblAvailSeats.TabIndex = 4;
            lblAvailSeats.Text = "Available Seats";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(130, 76);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 2;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(6, 76);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(33, 15);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Price";
            // 
            // lblDepTime
            // 
            lblDepTime.AutoSize = true;
            lblDepTime.Location = new Point(6, 28);
            lblDepTime.Name = "lblDepTime";
            lblDepTime.Size = new Size(88, 15);
            lblDepTime.TabIndex = 1;
            lblDepTime.Text = "Departure Time";
            // 
            // dtpDepTime
            // 
            dtpDepTime.CustomFormat = "HH':'mm dd'/'MM'/'yyyy";
            dtpDepTime.Location = new Point(130, 22);
            dtpDepTime.Name = "dtpDepTime";
            dtpDepTime.Size = new Size(209, 23);
            dtpDepTime.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(6, 397);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 16;
            btnCreate.Text = "Create new";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(286, 397);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // DepartureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpItem);
            Controls.Add(pnlList);
            Name = "DepartureForm";
            Text = "Form2";
            pnlList.ResumeLayout(false);
            grpItem.ResumeLayout(false);
            grpItem.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlList;
        private GroupBox grpItem;
        private ListBox lstDepartures;
        private Label lblDepTime;
        private DateTimePicker dtpDepTime;
        private Label lblPrice;
        private TextBox txtPrice;
        private CheckBox chkAllInclusive;
        private Label lblAvailSeats;
        private TextBox txtAvailableSeats;
        private Label lblBoat;
        private ComboBox cmbRoute;
        private ComboBox cmbBoat;
        private Label lblRoute;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnCreate;
    }
}