namespace AirplaneSeating
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxSeatType = new System.Windows.Forms.ComboBox();
            this.cabinPanel = new System.Windows.Forms.Panel();
            this.radioBtnFirstClass = new System.Windows.Forms.RadioButton();
            this.radioBtnEconomyClass = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.partySizeCBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.airplaneSeatPanel = new System.Windows.Forms.Panel();
            this.btnSerialize = new System.Windows.Forms.Button();
            this.btnDeserialize = new System.Windows.Forms.Button();
            this.btnSortByPassenger = new System.Windows.Forms.Button();
            this.btnSortBySeat = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.cabinPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cBoxSeatType);
            this.groupBox1.Controls.Add(this.cabinPanel);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.partySizeCBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(733, 238);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(294, 316);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seat Availability Search";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Seat Type:";
            // 
            // cBoxSeatType
            // 
            this.cBoxSeatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxSeatType.FormattingEnabled = true;
            this.cBoxSeatType.Location = new System.Drawing.Point(101, 166);
            this.cBoxSeatType.Name = "cBoxSeatType";
            this.cBoxSeatType.Size = new System.Drawing.Size(121, 21);
            this.cBoxSeatType.TabIndex = 8;
            // 
            // cabinPanel
            // 
            this.cabinPanel.Controls.Add(this.radioBtnFirstClass);
            this.cabinPanel.Controls.Add(this.radioBtnEconomyClass);
            this.cabinPanel.Location = new System.Drawing.Point(76, 83);
            this.cabinPanel.Name = "cabinPanel";
            this.cabinPanel.Size = new System.Drawing.Size(200, 23);
            this.cabinPanel.TabIndex = 7;
            // 
            // radioBtnFirstClass
            // 
            this.radioBtnFirstClass.AutoSize = true;
            this.radioBtnFirstClass.Location = new System.Drawing.Point(25, 3);
            this.radioBtnFirstClass.Name = "radioBtnFirstClass";
            this.radioBtnFirstClass.Size = new System.Drawing.Size(44, 17);
            this.radioBtnFirstClass.TabIndex = 2;
            this.radioBtnFirstClass.Text = "First";
            this.radioBtnFirstClass.UseVisualStyleBackColor = true;
            this.radioBtnFirstClass.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioBtnEconomyClass
            // 
            this.radioBtnEconomyClass.AutoSize = true;
            this.radioBtnEconomyClass.Location = new System.Drawing.Point(128, 3);
            this.radioBtnEconomyClass.Name = "radioBtnEconomyClass";
            this.radioBtnEconomyClass.Size = new System.Drawing.Size(69, 17);
            this.radioBtnEconomyClass.TabIndex = 3;
            this.radioBtnEconomyClass.TabStop = true;
            this.radioBtnEconomyClass.Text = "Economy";
            this.radioBtnEconomyClass.UseVisualStyleBackColor = true;
            this.radioBtnEconomyClass.CheckedChanged += new System.EventHandler(this.radioBtnEconomyClass_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(101, 214);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(172, 38);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search Seating";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // partySizeCBox
            // 
            this.partySizeCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partySizeCBox.FormattingEnabled = true;
            this.partySizeCBox.Location = new System.Drawing.Point(101, 125);
            this.partySizeCBox.Name = "partySizeCBox";
            this.partySizeCBox.Size = new System.Drawing.Size(44, 21);
            this.partySizeCBox.TabIndex = 4;
            this.partySizeCBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cabin Class:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Party Size:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(11, 238);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(718, 318);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seating Manifest";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 15);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(714, 301);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // airplaneSeatPanel
            // 
            this.airplaneSeatPanel.BackColor = System.Drawing.Color.White;
            this.airplaneSeatPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("airplaneSeatPanel.BackgroundImage")));
            this.airplaneSeatPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.airplaneSeatPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.airplaneSeatPanel.Location = new System.Drawing.Point(9, 10);
            this.airplaneSeatPanel.Margin = new System.Windows.Forms.Padding(0);
            this.airplaneSeatPanel.Name = "airplaneSeatPanel";
            this.airplaneSeatPanel.Size = new System.Drawing.Size(1020, 216);
            this.airplaneSeatPanel.TabIndex = 4;
            this.airplaneSeatPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSerialize
            // 
            this.btnSerialize.Location = new System.Drawing.Point(6, 19);
            this.btnSerialize.Name = "btnSerialize";
            this.btnSerialize.Size = new System.Drawing.Size(75, 54);
            this.btnSerialize.TabIndex = 5;
            this.btnSerialize.Text = "Serialize";
            this.btnSerialize.UseVisualStyleBackColor = true;
            this.btnSerialize.Click += new System.EventHandler(this.btnSerialize_Click);
            // 
            // btnDeserialize
            // 
            this.btnDeserialize.Location = new System.Drawing.Point(87, 19);
            this.btnDeserialize.Name = "btnDeserialize";
            this.btnDeserialize.Size = new System.Drawing.Size(75, 54);
            this.btnDeserialize.TabIndex = 6;
            this.btnDeserialize.Text = "Deserialize";
            this.btnDeserialize.UseVisualStyleBackColor = true;
            this.btnDeserialize.Click += new System.EventHandler(this.btnDeserialize_Click);
            // 
            // btnSortByPassenger
            // 
            this.btnSortByPassenger.Location = new System.Drawing.Point(100, 19);
            this.btnSortByPassenger.Name = "btnSortByPassenger";
            this.btnSortByPassenger.Size = new System.Drawing.Size(130, 54);
            this.btnSortByPassenger.TabIndex = 7;
            this.btnSortByPassenger.Text = "Sort By Passenger";
            this.btnSortByPassenger.UseVisualStyleBackColor = true;
            this.btnSortByPassenger.Click += new System.EventHandler(this.btnSortByPassenger_Click);
            // 
            // btnSortBySeat
            // 
            this.btnSortBySeat.Location = new System.Drawing.Point(6, 19);
            this.btnSortBySeat.Name = "btnSortBySeat";
            this.btnSortBySeat.Size = new System.Drawing.Size(88, 54);
            this.btnSortBySeat.TabIndex = 8;
            this.btnSortBySeat.Text = "Sort By Seat #";
            this.btnSortBySeat.UseVisualStyleBackColor = true;
            this.btnSortBySeat.Click += new System.EventHandler(this.btnSortBySeat_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(834, 633);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(172, 54);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSerialize);
            this.groupBox3.Controls.Add(this.btnDeserialize);
            this.groupBox3.Location = new System.Drawing.Point(109, 614);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 83);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save/Load Passenger Manifest";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSortBySeat);
            this.groupBox4.Controls.Add(this.btnSortByPassenger);
            this.groupBox4.Location = new System.Drawing.Point(382, 614);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 83);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sort";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 779);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.airplaneSeatPanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1053, 818);
            this.Name = "MainForm";
            this.Text = "Airplane Seater";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cabinPanel.ResumeLayout(false);
            this.cabinPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioBtnFirstClass;
        private System.Windows.Forms.RadioButton radioBtnEconomyClass;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox partySizeCBox;
        private System.Windows.Forms.Panel cabinPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxSeatType;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Panel airplaneSeatPanel;
        private System.Windows.Forms.Button btnSerialize;
        private System.Windows.Forms.Button btnDeserialize;
        private System.Windows.Forms.Button btnSortByPassenger;
        private System.Windows.Forms.Button btnSortBySeat;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

