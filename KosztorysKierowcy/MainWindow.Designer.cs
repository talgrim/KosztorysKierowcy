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
            this.bDebts = new System.Windows.Forms.Button();
            this.tTo = new System.Windows.Forms.TextBox();
            this.lTo = new System.Windows.Forms.Label();
            this.tFrom = new System.Windows.Forms.TextBox();
            this.lFrom = new System.Windows.Forms.Label();
            this.cbPeriod = new System.Windows.Forms.CheckBox();
            this.bExit = new System.Windows.Forms.Button();
            this.bRetry = new System.Windows.Forms.Button();
            this.rbPassenger = new System.Windows.Forms.RadioButton();
            this.bSettings = new System.Windows.Forms.Button();
            this.rbDriver = new System.Windows.Forms.RadioButton();
            this.cbAddDriver = new System.Windows.Forms.CheckBox();
            this.bDeleteRoute = new System.Windows.Forms.Button();
            this.bDeleteCar = new System.Windows.Forms.Button();
            this.bDeletePerson = new System.Windows.Forms.Button();
            this.cbNotGrouped = new System.Windows.Forms.CheckBox();
            this.bCheckTransits = new System.Windows.Forms.Button();
            this.bAddTransit = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.tPassengersCost = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tPassengersCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bEditRoute = new System.Windows.Forms.Button();
            this.bEditPerson = new System.Windows.Forms.Button();
            this.lPassengers = new System.Windows.Forms.ListBox();
            this.bAddRoute = new System.Windows.Forms.Button();
            this.bEditCar = new System.Windows.Forms.Button();
            this.bAddCar = new System.Windows.Forms.Button();
            this.bAddPerson = new System.Windows.Forms.Button();
            this.gTransits = new System.Windows.Forms.DataGridView();
            this.pMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTransits)).BeginInit();
            this.SuspendLayout();
            // 
            // cDrivers
            // 
            this.cDrivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cDrivers.FormattingEnabled = true;
            this.cDrivers.Location = new System.Drawing.Point(9, 36);
            this.cDrivers.Name = "cDrivers";
            this.cDrivers.Size = new System.Drawing.Size(121, 21);
            this.cDrivers.TabIndex = 2;
            this.cDrivers.SelectedIndexChanged += new System.EventHandler(this.cDrivers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kierowcy";
            // 
            // cCars
            // 
            this.cCars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cCars.FormattingEnabled = true;
            this.cCars.Location = new System.Drawing.Point(136, 36);
            this.cCars.Name = "cCars";
            this.cCars.Size = new System.Drawing.Size(149, 21);
            this.cCars.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Auto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Trasa";
            // 
            // cRoutes
            // 
            this.cRoutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cRoutes.FormattingEnabled = true;
            this.cRoutes.Location = new System.Drawing.Point(291, 36);
            this.cRoutes.Name = "cRoutes";
            this.cRoutes.Size = new System.Drawing.Size(211, 21);
            this.cRoutes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Aktualna cena paliwa";
            // 
            // tPetroleum
            // 
            this.tPetroleum.Location = new System.Drawing.Point(15, 137);
            this.tPetroleum.Name = "tPetroleum";
            this.tPetroleum.Size = new System.Drawing.Size(100, 20);
            this.tPetroleum.TabIndex = 9;
            this.tPetroleum.Text = "5,00";
            this.tPetroleum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pragmaNumericDecimal);
            // 
            // tRouteCost
            // 
            this.tRouteCost.Location = new System.Drawing.Point(184, 137);
            this.tRouteCost.Name = "tRouteCost";
            this.tRouteCost.ReadOnly = true;
            this.tRouteCost.Size = new System.Drawing.Size(100, 20);
            this.tRouteCost.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Obliczony koszt trasy";
            // 
            // pMainPanel
            // 
            this.pMainPanel.Controls.Add(this.bDebts);
            this.pMainPanel.Controls.Add(this.tTo);
            this.pMainPanel.Controls.Add(this.lTo);
            this.pMainPanel.Controls.Add(this.tFrom);
            this.pMainPanel.Controls.Add(this.lFrom);
            this.pMainPanel.Controls.Add(this.cbPeriod);
            this.pMainPanel.Controls.Add(this.bExit);
            this.pMainPanel.Controls.Add(this.bRetry);
            this.pMainPanel.Controls.Add(this.rbPassenger);
            this.pMainPanel.Controls.Add(this.bSettings);
            this.pMainPanel.Controls.Add(this.rbDriver);
            this.pMainPanel.Controls.Add(this.cbAddDriver);
            this.pMainPanel.Controls.Add(this.bDeleteRoute);
            this.pMainPanel.Controls.Add(this.bDeleteCar);
            this.pMainPanel.Controls.Add(this.bDeletePerson);
            this.pMainPanel.Controls.Add(this.cbNotGrouped);
            this.pMainPanel.Controls.Add(this.bCheckTransits);
            this.pMainPanel.Controls.Add(this.bAddTransit);
            this.pMainPanel.Controls.Add(this.label12);
            this.pMainPanel.Controls.Add(this.tPassengersCost);
            this.pMainPanel.Controls.Add(this.label11);
            this.pMainPanel.Controls.Add(this.tPassengersCount);
            this.pMainPanel.Controls.Add(this.label10);
            this.pMainPanel.Controls.Add(this.bEditRoute);
            this.pMainPanel.Controls.Add(this.bEditPerson);
            this.pMainPanel.Controls.Add(this.lPassengers);
            this.pMainPanel.Controls.Add(this.bAddRoute);
            this.pMainPanel.Controls.Add(this.bEditCar);
            this.pMainPanel.Controls.Add(this.bAddCar);
            this.pMainPanel.Controls.Add(this.bAddPerson);
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
            this.pMainPanel.Location = new System.Drawing.Point(12, 12);
            this.pMainPanel.Name = "pMainPanel";
            this.pMainPanel.Size = new System.Drawing.Size(1108, 226);
            this.pMainPanel.TabIndex = 12;
            // 
            // bDebts
            // 
            this.bDebts.Location = new System.Drawing.Point(862, 192);
            this.bDebts.Name = "bDebts";
            this.bDebts.Size = new System.Drawing.Size(118, 23);
            this.bDebts.TabIndex = 38;
            this.bDebts.Text = "Sprawdź długi";
            this.bDebts.UseVisualStyleBackColor = true;
            // 
            // tTo
            // 
            this.tTo.Location = new System.Drawing.Point(650, 172);
            this.tTo.Name = "tTo";
            this.tTo.Size = new System.Drawing.Size(100, 20);
            this.tTo.TabIndex = 37;
            this.tTo.Visible = false;
            this.tTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pragmaDate);
            // 
            // lTo
            // 
            this.lTo.AutoSize = true;
            this.lTo.Location = new System.Drawing.Point(626, 175);
            this.lTo.Name = "lTo";
            this.lTo.Size = new System.Drawing.Size(22, 13);
            this.lTo.TabIndex = 36;
            this.lTo.Text = "do:";
            this.lTo.Visible = false;
            // 
            // tFrom
            // 
            this.tFrom.Location = new System.Drawing.Point(524, 172);
            this.tFrom.Name = "tFrom";
            this.tFrom.Size = new System.Drawing.Size(100, 20);
            this.tFrom.TabIndex = 14;
            this.tFrom.Visible = false;
            this.tFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pragmaDate);
            // 
            // lFrom
            // 
            this.lFrom.AutoSize = true;
            this.lFrom.Location = new System.Drawing.Point(500, 175);
            this.lFrom.Name = "lFrom";
            this.lFrom.Size = new System.Drawing.Size(22, 13);
            this.lFrom.TabIndex = 35;
            this.lFrom.Text = "od:";
            this.lFrom.Visible = false;
            // 
            // cbPeriod
            // 
            this.cbPeriod.AutoSize = true;
            this.cbPeriod.Location = new System.Drawing.Point(451, 174);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(57, 17);
            this.cbPeriod.TabIndex = 34;
            this.cbPeriod.Text = "Okres:";
            this.cbPeriod.UseVisualStyleBackColor = true;
            this.cbPeriod.CheckedChanged += new System.EventHandler(this.cbPeriod_CheckedChanged);
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(969, 2);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(139, 23);
            this.bExit.TabIndex = 16;
            this.bExit.Text = "Wyjdź";
            this.bExit.UseVisualStyleBackColor = true;
            // 
            // bRetry
            // 
            this.bRetry.Location = new System.Drawing.Point(702, 2);
            this.bRetry.Name = "bRetry";
            this.bRetry.Size = new System.Drawing.Size(116, 23);
            this.bRetry.TabIndex = 15;
            this.bRetry.Text = "Ponów połączenie";
            this.bRetry.UseVisualStyleBackColor = true;
            this.bRetry.Click += new System.EventHandler(this.bRetry_Click);
            // 
            // rbPassenger
            // 
            this.rbPassenger.AutoSize = true;
            this.rbPassenger.Location = new System.Drawing.Point(354, 201);
            this.rbPassenger.Name = "rbPassenger";
            this.rbPassenger.Size = new System.Drawing.Size(90, 17);
            this.rbPassenger.TabIndex = 16;
            this.rbPassenger.Text = "Pasażer/owie";
            this.rbPassenger.UseVisualStyleBackColor = true;
            this.rbPassenger.CheckedChanged += new System.EventHandler(this.enableCheckboxes);
            // 
            // bSettings
            // 
            this.bSettings.Location = new System.Drawing.Point(824, 2);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(139, 23);
            this.bSettings.TabIndex = 14;
            this.bSettings.Text = "Ustawienia";
            this.bSettings.UseVisualStyleBackColor = true;
            // 
            // rbDriver
            // 
            this.rbDriver.AutoSize = true;
            this.rbDriver.Checked = true;
            this.rbDriver.Location = new System.Drawing.Point(354, 174);
            this.rbDriver.Name = "rbDriver";
            this.rbDriver.Size = new System.Drawing.Size(69, 17);
            this.rbDriver.TabIndex = 33;
            this.rbDriver.TabStop = true;
            this.rbDriver.Text = "Kierowca";
            this.rbDriver.UseVisualStyleBackColor = true;
            // 
            // cbAddDriver
            // 
            this.cbAddDriver.AutoSize = true;
            this.cbAddDriver.Enabled = false;
            this.cbAddDriver.Location = new System.Drawing.Point(451, 201);
            this.cbAddDriver.Name = "cbAddDriver";
            this.cbAddDriver.Size = new System.Drawing.Size(100, 17);
            this.cbAddDriver.TabIndex = 32;
            this.cbAddDriver.Text = "Dodaj kierowcę";
            this.cbAddDriver.UseVisualStyleBackColor = true;
            this.cbAddDriver.CheckedChanged += new System.EventHandler(this.cbAddDriver_CheckedChanged);
            // 
            // bDeleteRoute
            // 
            this.bDeleteRoute.Location = new System.Drawing.Point(986, 94);
            this.bDeleteRoute.Name = "bDeleteRoute";
            this.bDeleteRoute.Size = new System.Drawing.Size(119, 23);
            this.bDeleteRoute.TabIndex = 31;
            this.bDeleteRoute.Text = "Usuń trasę";
            this.bDeleteRoute.UseVisualStyleBackColor = true;
            // 
            // bDeleteCar
            // 
            this.bDeleteCar.Location = new System.Drawing.Point(986, 65);
            this.bDeleteCar.Name = "bDeleteCar";
            this.bDeleteCar.Size = new System.Drawing.Size(119, 23);
            this.bDeleteCar.TabIndex = 30;
            this.bDeleteCar.Text = "Usuń auto";
            this.bDeleteCar.UseVisualStyleBackColor = true;
            // 
            // bDeletePerson
            // 
            this.bDeletePerson.Location = new System.Drawing.Point(986, 36);
            this.bDeletePerson.Name = "bDeletePerson";
            this.bDeletePerson.Size = new System.Drawing.Size(119, 23);
            this.bDeletePerson.TabIndex = 29;
            this.bDeletePerson.Text = "Usuń osobę";
            this.bDeletePerson.UseVisualStyleBackColor = true;
            // 
            // cbNotGrouped
            // 
            this.cbNotGrouped.AutoSize = true;
            this.cbNotGrouped.Enabled = false;
            this.cbNotGrouped.Location = new System.Drawing.Point(557, 201);
            this.cbNotGrouped.Name = "cbNotGrouped";
            this.cbNotGrouped.Size = new System.Drawing.Size(74, 17);
            this.cbNotGrouped.TabIndex = 28;
            this.cbNotGrouped.Text = "Nie grupuj";
            this.cbNotGrouped.UseVisualStyleBackColor = true;
            // 
            // bCheckTransits
            // 
            this.bCheckTransits.Location = new System.Drawing.Point(208, 192);
            this.bCheckTransits.Name = "bCheckTransits";
            this.bCheckTransits.Size = new System.Drawing.Size(125, 23);
            this.bCheckTransits.TabIndex = 25;
            this.bCheckTransits.Text = "Sprawdź przejazdy";
            this.bCheckTransits.UseVisualStyleBackColor = true;
            this.bCheckTransits.Click += new System.EventHandler(this.bCheckTransits_Click);
            // 
            // bAddTransit
            // 
            this.bAddTransit.Location = new System.Drawing.Point(208, 163);
            this.bAddTransit.Name = "bAddTransit";
            this.bAddTransit.Size = new System.Drawing.Size(125, 23);
            this.bAddTransit.TabIndex = 24;
            this.bAddTransit.Text = "Dodaj przejazd";
            this.bAddTransit.UseVisualStyleBackColor = true;
            this.bAddTransit.Click += new System.EventHandler(this.bAddTransit_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(399, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Koszt na pasażera";
            // 
            // tPassengersCost
            // 
            this.tPassengersCost.Location = new System.Drawing.Point(402, 137);
            this.tPassengersCost.Name = "tPassengersCost";
            this.tPassengersCost.ReadOnly = true;
            this.tPassengersCost.Size = new System.Drawing.Size(100, 20);
            this.tPassengersCost.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(293, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Liczba pasażerów";
            // 
            // tPassengersCount
            // 
            this.tPassengersCount.Location = new System.Drawing.Point(296, 137);
            this.tPassengersCount.Name = "tPassengersCount";
            this.tPassengersCount.ReadOnly = true;
            this.tPassengersCount.Size = new System.Drawing.Size(100, 20);
            this.tPassengersCount.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(574, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Pasażerowie";
            // 
            // bEditRoute
            // 
            this.bEditRoute.Location = new System.Drawing.Point(862, 94);
            this.bEditRoute.Name = "bEditRoute";
            this.bEditRoute.Size = new System.Drawing.Size(118, 23);
            this.bEditRoute.TabIndex = 17;
            this.bEditRoute.Text = "Edytuj trasę";
            this.bEditRoute.UseVisualStyleBackColor = true;
            // 
            // bEditPerson
            // 
            this.bEditPerson.Location = new System.Drawing.Point(862, 36);
            this.bEditPerson.Name = "bEditPerson";
            this.bEditPerson.Size = new System.Drawing.Size(118, 23);
            this.bEditPerson.TabIndex = 13;
            this.bEditPerson.Text = "Edytuj osobę";
            this.bEditPerson.UseVisualStyleBackColor = true;
            // 
            // lPassengers
            // 
            this.lPassengers.FormattingEnabled = true;
            this.lPassengers.Location = new System.Drawing.Point(508, 36);
            this.lPassengers.Name = "lPassengers";
            this.lPassengers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lPassengers.Size = new System.Drawing.Size(224, 121);
            this.lPassengers.TabIndex = 18;
            this.lPassengers.SelectedIndexChanged += new System.EventHandler(this.lPassengers_SelectedIndexChanged);
            // 
            // bAddRoute
            // 
            this.bAddRoute.Location = new System.Drawing.Point(738, 94);
            this.bAddRoute.Name = "bAddRoute";
            this.bAddRoute.Size = new System.Drawing.Size(118, 23);
            this.bAddRoute.TabIndex = 16;
            this.bAddRoute.Text = "Dodaj trasę";
            this.bAddRoute.UseVisualStyleBackColor = true;
            // 
            // bEditCar
            // 
            this.bEditCar.Location = new System.Drawing.Point(862, 65);
            this.bEditCar.Name = "bEditCar";
            this.bEditCar.Size = new System.Drawing.Size(118, 23);
            this.bEditCar.TabIndex = 15;
            this.bEditCar.Text = "Edytuj auto";
            this.bEditCar.UseVisualStyleBackColor = true;
            // 
            // bAddCar
            // 
            this.bAddCar.Location = new System.Drawing.Point(738, 65);
            this.bAddCar.Name = "bAddCar";
            this.bAddCar.Size = new System.Drawing.Size(118, 23);
            this.bAddCar.TabIndex = 14;
            this.bAddCar.Text = "Dodaj auto";
            this.bAddCar.UseVisualStyleBackColor = true;
            // 
            // bAddPerson
            // 
            this.bAddPerson.Location = new System.Drawing.Point(738, 36);
            this.bAddPerson.Name = "bAddPerson";
            this.bAddPerson.Size = new System.Drawing.Size(118, 23);
            this.bAddPerson.TabIndex = 12;
            this.bAddPerson.Text = "Dodaj osobę";
            this.bAddPerson.UseVisualStyleBackColor = true;
            // 
            // gTransits
            // 
            this.gTransits.AllowUserToAddRows = false;
            this.gTransits.AllowUserToDeleteRows = false;
            this.gTransits.AllowUserToOrderColumns = true;
            this.gTransits.AllowUserToResizeColumns = false;
            this.gTransits.AllowUserToResizeRows = false;
            this.gTransits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gTransits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTransits.Location = new System.Drawing.Point(12, 244);
            this.gTransits.Name = "gTransits";
            this.gTransits.ReadOnly = true;
            this.gTransits.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gTransits.Size = new System.Drawing.Size(1105, 295);
            this.gTransits.TabIndex = 13;
            this.gTransits.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gTransits_ColumnHeaderMouseClick);
            this.gTransits.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gTransits_DataBindingComplete);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 549);
            this.Controls.Add(this.gTransits);
            this.Controls.Add(this.pMainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Kosztorys kierowcy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pMainPanel.ResumeLayout(false);
            this.pMainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTransits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Button bEditRoute;
        private System.Windows.Forms.Button bAddRoute;
        private System.Windows.Forms.Button bEditCar;
        private System.Windows.Forms.Button bAddCar;
        private System.Windows.Forms.Button bEditPerson;
        private System.Windows.Forms.Button bAddPerson;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lPassengers;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tPassengersCost;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tPassengersCount;
        private System.Windows.Forms.Button bAddTransit;
        private System.Windows.Forms.Button bCheckTransits;
        private System.Windows.Forms.DataGridView gTransits;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.CheckBox cbNotGrouped;
        private System.Windows.Forms.Button bRetry;
        private System.Windows.Forms.Button bDeletePerson;
        private System.Windows.Forms.Button bDeleteRoute;
        private System.Windows.Forms.Button bDeleteCar;
        private System.Windows.Forms.CheckBox cbAddDriver;
        private System.Windows.Forms.RadioButton rbPassenger;
        private System.Windows.Forms.RadioButton rbDriver;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.TextBox tTo;
        private System.Windows.Forms.Label lTo;
        private System.Windows.Forms.TextBox tFrom;
        private System.Windows.Forms.Label lFrom;
        private System.Windows.Forms.CheckBox cbPeriod;
        private System.Windows.Forms.Button bDebts;
    }
}

