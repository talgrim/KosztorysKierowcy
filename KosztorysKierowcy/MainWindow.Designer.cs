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
            this.bEditPerson = new System.Windows.Forms.Button();
            this.bAddPerson = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tPassengersCount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tPassengersCost = new System.Windows.Forms.TextBox();
            this.bAddTransit = new System.Windows.Forms.Button();
            this.bCheckTransits = new System.Windows.Forms.Button();
            this.gTransits = new System.Windows.Forms.DataGridView();
            this.pMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTransits)).BeginInit();
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
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Aktualna cena paliwa";
            // 
            // tPetroleum
            // 
            this.tPetroleum.Location = new System.Drawing.Point(15, 169);
            this.tPetroleum.Name = "tPetroleum";
            this.tPetroleum.Size = new System.Drawing.Size(100, 20);
            this.tPetroleum.TabIndex = 9;
            this.tPetroleum.Text = "5,00";
            this.tPetroleum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tPetroleum_KeyPress);
            // 
            // tRouteCost
            // 
            this.tRouteCost.Location = new System.Drawing.Point(184, 169);
            this.tRouteCost.Name = "tRouteCost";
            this.tRouteCost.ReadOnly = true;
            this.tRouteCost.Size = new System.Drawing.Size(100, 20);
            this.tRouteCost.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Obliczony koszt trasy";
            // 
            // pMainPanel
            // 
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
            this.pMainPanel.Location = new System.Drawing.Point(12, 74);
            this.pMainPanel.Name = "pMainPanel";
            this.pMainPanel.Size = new System.Drawing.Size(1017, 265);
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
            this.bEditRoute.Location = new System.Drawing.Point(862, 126);
            this.bEditRoute.Name = "bEditRoute";
            this.bEditRoute.Size = new System.Drawing.Size(118, 23);
            this.bEditRoute.TabIndex = 17;
            this.bEditRoute.Text = "Edytuj trasę";
            this.bEditRoute.UseVisualStyleBackColor = true;
            // 
            // bAddRoute
            // 
            this.bAddRoute.Location = new System.Drawing.Point(738, 126);
            this.bAddRoute.Name = "bAddRoute";
            this.bAddRoute.Size = new System.Drawing.Size(118, 23);
            this.bAddRoute.TabIndex = 16;
            this.bAddRoute.Text = "Dodaj trasę";
            this.bAddRoute.UseVisualStyleBackColor = true;
            // 
            // bEditCar
            // 
            this.bEditCar.Location = new System.Drawing.Point(862, 97);
            this.bEditCar.Name = "bEditCar";
            this.bEditCar.Size = new System.Drawing.Size(118, 23);
            this.bEditCar.TabIndex = 15;
            this.bEditCar.Text = "Edytuj auto";
            this.bEditCar.UseVisualStyleBackColor = true;
            // 
            // bAddCar
            // 
            this.bAddCar.Location = new System.Drawing.Point(738, 97);
            this.bAddCar.Name = "bAddCar";
            this.bAddCar.Size = new System.Drawing.Size(118, 23);
            this.bAddCar.TabIndex = 14;
            this.bAddCar.Text = "Dodaj auto";
            this.bAddCar.UseVisualStyleBackColor = true;
            // 
            // bEditPerson
            // 
            this.bEditPerson.Location = new System.Drawing.Point(862, 68);
            this.bEditPerson.Name = "bEditPerson";
            this.bEditPerson.Size = new System.Drawing.Size(118, 23);
            this.bEditPerson.TabIndex = 13;
            this.bEditPerson.Text = "Edytuj osobę";
            this.bEditPerson.UseVisualStyleBackColor = true;
            // 
            // bAddPerson
            // 
            this.bAddPerson.Location = new System.Drawing.Point(738, 68);
            this.bAddPerson.Name = "bAddPerson";
            this.bAddPerson.Size = new System.Drawing.Size(118, 23);
            this.bAddPerson.TabIndex = 12;
            this.bAddPerson.Text = "Dodaj osobę";
            this.bAddPerson.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(293, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Liczba pasażerów";
            // 
            // tPassengersCount
            // 
            this.tPassengersCount.Location = new System.Drawing.Point(296, 169);
            this.tPassengersCount.Name = "tPassengersCount";
            this.tPassengersCount.ReadOnly = true;
            this.tPassengersCount.Size = new System.Drawing.Size(100, 20);
            this.tPassengersCount.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(399, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Koszt na pasażera";
            // 
            // tPassengersCost
            // 
            this.tPassengersCost.Location = new System.Drawing.Point(402, 169);
            this.tPassengersCost.Name = "tPassengersCost";
            this.tPassengersCost.ReadOnly = true;
            this.tPassengersCost.Size = new System.Drawing.Size(100, 20);
            this.tPassengersCost.TabIndex = 22;
            // 
            // bAddTransit
            // 
            this.bAddTransit.Location = new System.Drawing.Point(208, 195);
            this.bAddTransit.Name = "bAddTransit";
            this.bAddTransit.Size = new System.Drawing.Size(125, 23);
            this.bAddTransit.TabIndex = 24;
            this.bAddTransit.Text = "Dodaj przejazd";
            this.bAddTransit.UseVisualStyleBackColor = true;
            this.bAddTransit.Click += new System.EventHandler(this.bAddTransit_Click);
            // 
            // bCheckTransits
            // 
            this.bCheckTransits.Location = new System.Drawing.Point(184, 224);
            this.bCheckTransits.Name = "bCheckTransits";
            this.bCheckTransits.Size = new System.Drawing.Size(177, 23);
            this.bCheckTransits.TabIndex = 25;
            this.bCheckTransits.Text = "Sprawdź przejazdy kierowcy";
            this.bCheckTransits.UseVisualStyleBackColor = true;
            this.bCheckTransits.Click += new System.EventHandler(this.button1_Click);
            // 
            // gTransits
            // 
            this.gTransits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTransits.Location = new System.Drawing.Point(12, 345);
            this.gTransits.Name = "gTransits";
            this.gTransits.ReadOnly = true;
            this.gTransits.Size = new System.Drawing.Size(1017, 295);
            this.gTransits.TabIndex = 13;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 652);
            this.Controls.Add(this.gTransits);
            this.Controls.Add(this.pMainPanel);
            this.Controls.Add(this.bRestore);
            this.Controls.Add(this.bBackup);
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
    }
}

