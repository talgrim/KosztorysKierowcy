namespace KosztorysKierowcy
{
    partial class MainWindow
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
            this.bBackup = new System.Windows.Forms.Button();
            this.bRestore = new System.Windows.Forms.Button();
            this.cDrivers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cCars = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cRoutes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tPetroleum = new System.Windows.Forms.TextBox();
            this.tRouteCost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pMainPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lPassengers = new System.Windows.Forms.ListBox();
            this.bEditRoute = new System.Windows.Forms.Button();
            this.bAddRoute = new System.Windows.Forms.Button();
            this.bEditCar = new System.Windows.Forms.Button();
            this.bAddCar = new System.Windows.Forms.Button();
            this.bEditDriver = new System.Windows.Forms.Button();
            this.bAddDriver = new System.Windows.Forms.Button();
            this.pDriverPanel = new System.Windows.Forms.Panel();
            this.bDriver = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tPassengersCount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tPassengersCost = new System.Windows.Forms.TextBox();
            this.pMainPanel.SuspendLayout();
            this.pDriverPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bBackup
            // 
            this.bBackup.Location = new System.Drawing.Point(201, 12);
            this.bBackup.Name = "bBackup";
            this.bBackup.Size = new System.Drawing.Size(159, 23);
            this.bBackup.TabIndex = 0;
            this.bBackup.Text = "Backup database";
            this.bBackup.UseVisualStyleBackColor = true;
            this.bBackup.Click += new System.EventHandler(this.bBackup_Click);
            // 
            // bRestore
            // 
            this.bRestore.Location = new System.Drawing.Point(379, 12);
            this.bRestore.Name = "bRestore";
            this.bRestore.Size = new System.Drawing.Size(145, 23);
            this.bRestore.TabIndex = 1;
            this.bRestore.Text = "Restore database";
            this.bRestore.UseVisualStyleBackColor = true;
            this.bRestore.Click += new System.EventHandler(this.bRestore_Click);
            // 
            // cDrivers
            // 
            this.cDrivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cDrivers.FormattingEnabled = true;
            this.cDrivers.Location = new System.Drawing.Point(30, 68);
            this.cDrivers.Name = "cDrivers";
            this.cDrivers.Size = new System.Drawing.Size(121, 21);
            this.cDrivers.TabIndex = 2;
            this.cDrivers.SelectedIndexChanged += new System.EventHandler(this.cDrivers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kierowcy";
            // 
            // cCars
            // 
            this.cCars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cCars.FormattingEnabled = true;
            this.cCars.Location = new System.Drawing.Point(164, 68);
            this.cCars.Name = "cCars";
            this.cCars.Size = new System.Drawing.Size(121, 21);
            this.cCars.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Auto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Trasa";
            // 
            // cRoutes
            // 
            this.cRoutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cRoutes.FormattingEnabled = true;
            this.cRoutes.Location = new System.Drawing.Point(291, 68);
            this.cRoutes.Name = "cRoutes";
            this.cRoutes.Size = new System.Drawing.Size(211, 21);
            this.cRoutes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Aktualna cena paliwa";
            // 
            // tPetroleum
            // 
            this.tPetroleum.Location = new System.Drawing.Point(30, 214);
            this.tPetroleum.Name = "tPetroleum";
            this.tPetroleum.Size = new System.Drawing.Size(100, 20);
            this.tPetroleum.TabIndex = 9;
            this.tPetroleum.Text = "5,00";
            this.tPetroleum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tPetroleum_KeyPress);
            // 
            // tRouteCost
            // 
            this.tRouteCost.Location = new System.Drawing.Point(199, 214);
            this.tRouteCost.Name = "tRouteCost";
            this.tRouteCost.ReadOnly = true;
            this.tRouteCost.Size = new System.Drawing.Size(100, 20);
            this.tRouteCost.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Obliczony koszt trasy";
            // 
            // pMainPanel
            // 
            this.pMainPanel.Controls.Add(this.label12);
            this.pMainPanel.Controls.Add(this.tPassengersCost);
            this.pMainPanel.Controls.Add(this.label11);
            this.pMainPanel.Controls.Add(this.tPassengersCount);
            this.pMainPanel.Controls.Add(this.label10);
            this.pMainPanel.Controls.Add(this.lPassengers);
            this.pMainPanel.Controls.Add(this.bEditRoute);
            this.pMainPanel.Controls.Add(this.bAddRoute);
            this.pMainPanel.Controls.Add(this.bEditCar);
            this.pMainPanel.Controls.Add(this.bAddCar);
            this.pMainPanel.Controls.Add(this.bEditDriver);
            this.pMainPanel.Controls.Add(this.bAddDriver);
            this.pMainPanel.Controls.Add(this.cRoutes);
            this.pMainPanel.Controls.Add(this.label5);
            this.pMainPanel.Controls.Add(this.cDrivers);
            this.pMainPanel.Controls.Add(this.tRouteCost);
            this.pMainPanel.Controls.Add(this.label1);
            this.pMainPanel.Controls.Add(this.tPetroleum);
            this.pMainPanel.Controls.Add(this.cCars);
            this.pMainPanel.Controls.Add(this.label4);
            this.pMainPanel.Controls.Add(this.label2);
            this.pMainPanel.Controls.Add(this.label3);
            this.pMainPanel.Location = new System.Drawing.Point(12, 74);
            this.pMainPanel.Name = "pMainPanel";
            this.pMainPanel.Size = new System.Drawing.Size(735, 294);
            this.pMainPanel.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(574, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Pasażerowie";
            // 
            // lPassengers
            // 
            this.lPassengers.FormattingEnabled = true;
            this.lPassengers.Location = new System.Drawing.Point(508, 68);
            this.lPassengers.Name = "lPassengers";
            this.lPassengers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lPassengers.Size = new System.Drawing.Size(224, 121);
            this.lPassengers.TabIndex = 18;
            this.lPassengers.SelectedIndexChanged += new System.EventHandler(this.lPassengers_SelectedIndexChanged);
            // 
            // bEditRoute
            // 
            this.bEditRoute.Location = new System.Drawing.Point(291, 124);
            this.bEditRoute.Name = "bEditRoute";
            this.bEditRoute.Size = new System.Drawing.Size(211, 23);
            this.bEditRoute.TabIndex = 17;
            this.bEditRoute.Text = "Edytuj trasę";
            this.bEditRoute.UseVisualStyleBackColor = true;
            // 
            // bAddRoute
            // 
            this.bAddRoute.Location = new System.Drawing.Point(291, 95);
            this.bAddRoute.Name = "bAddRoute";
            this.bAddRoute.Size = new System.Drawing.Size(211, 23);
            this.bAddRoute.TabIndex = 16;
            this.bAddRoute.Text = "Dodaj trasę";
            this.bAddRoute.UseVisualStyleBackColor = true;
            // 
            // bEditCar
            // 
            this.bEditCar.Location = new System.Drawing.Point(164, 124);
            this.bEditCar.Name = "bEditCar";
            this.bEditCar.Size = new System.Drawing.Size(121, 23);
            this.bEditCar.TabIndex = 15;
            this.bEditCar.Text = "Edytuj auto";
            this.bEditCar.UseVisualStyleBackColor = true;
            // 
            // bAddCar
            // 
            this.bAddCar.Location = new System.Drawing.Point(164, 95);
            this.bAddCar.Name = "bAddCar";
            this.bAddCar.Size = new System.Drawing.Size(121, 23);
            this.bAddCar.TabIndex = 14;
            this.bAddCar.Text = "Dodaj auto";
            this.bAddCar.UseVisualStyleBackColor = true;
            // 
            // bEditDriver
            // 
            this.bEditDriver.Location = new System.Drawing.Point(33, 124);
            this.bEditDriver.Name = "bEditDriver";
            this.bEditDriver.Size = new System.Drawing.Size(118, 23);
            this.bEditDriver.TabIndex = 13;
            this.bEditDriver.Text = "Edytuj kierowcę";
            this.bEditDriver.UseVisualStyleBackColor = true;
            // 
            // bAddDriver
            // 
            this.bAddDriver.Location = new System.Drawing.Point(33, 95);
            this.bAddDriver.Name = "bAddDriver";
            this.bAddDriver.Size = new System.Drawing.Size(118, 23);
            this.bAddDriver.TabIndex = 12;
            this.bAddDriver.Text = "Dodaj kierowcę";
            this.bAddDriver.UseVisualStyleBackColor = true;
            // 
            // pDriverPanel
            // 
            this.pDriverPanel.Controls.Add(this.bDriver);
            this.pDriverPanel.Controls.Add(this.textBox2);
            this.pDriverPanel.Controls.Add(this.textBox1);
            this.pDriverPanel.Controls.Add(this.label7);
            this.pDriverPanel.Controls.Add(this.label6);
            this.pDriverPanel.Location = new System.Drawing.Point(173, 466);
            this.pDriverPanel.Name = "pDriverPanel";
            this.pDriverPanel.Size = new System.Drawing.Size(465, 172);
            this.pDriverPanel.TabIndex = 13;
            // 
            // bDriver
            // 
            this.bDriver.Location = new System.Drawing.Point(140, 124);
            this.bDriver.Name = "bDriver";
            this.bDriver.Size = new System.Drawing.Size(104, 23);
            this.bDriver.TabIndex = 4;
            this.bDriver.Text = "Dodaj kierowcę";
            this.bDriver.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(206, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(248, 20);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Nazwisko";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Imię";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(644, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 172);
            this.panel1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Dodaj kierowcę";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(206, 77);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(248, 20);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(26, 77);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(137, 20);
            this.textBox4.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(314, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Nazwisko";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Imię";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(308, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Liczba pasażerów";
            // 
            // tPassengersCount
            // 
            this.tPassengersCount.Location = new System.Drawing.Point(311, 214);
            this.tPassengersCount.Name = "tPassengersCount";
            this.tPassengersCount.ReadOnly = true;
            this.tPassengersCount.Size = new System.Drawing.Size(100, 20);
            this.tPassengersCount.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(414, 198);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Koszt na pasażera";
            // 
            // tPassengersCost
            // 
            this.tPassengersCost.Location = new System.Drawing.Point(417, 214);
            this.tPassengersCost.Name = "tPassengersCost";
            this.tPassengersCost.ReadOnly = true;
            this.tPassengersCost.Size = new System.Drawing.Size(100, 20);
            this.tPassengersCost.TabIndex = 22;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pDriverPanel);
            this.Controls.Add(this.pMainPanel);
            this.Controls.Add(this.bRestore);
            this.Controls.Add(this.bBackup);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Kosztorys kierowcy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pMainPanel.ResumeLayout(false);
            this.pMainPanel.PerformLayout();
            this.pDriverPanel.ResumeLayout(false);
            this.pDriverPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bBackup;
        private System.Windows.Forms.Button bRestore;
        private System.Windows.Forms.ComboBox cDrivers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cCars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cRoutes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tPetroleum;
        private System.Windows.Forms.TextBox tRouteCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pMainPanel;
        private System.Windows.Forms.Panel pDriverPanel;
        private System.Windows.Forms.Button bEditRoute;
        private System.Windows.Forms.Button bAddRoute;
        private System.Windows.Forms.Button bEditCar;
        private System.Windows.Forms.Button bAddCar;
        private System.Windows.Forms.Button bEditDriver;
        private System.Windows.Forms.Button bAddDriver;
        private System.Windows.Forms.Button bDriver;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lPassengers;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tPassengersCost;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tPassengersCount;
    }
}

