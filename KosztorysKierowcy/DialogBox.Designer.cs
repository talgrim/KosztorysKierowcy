namespace KosztorysKierowcy
{
    public partial class DialogBox
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pAddRoute = new System.Windows.Forms.Panel();
            this.tRouteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tDistance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pAddCar = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cOwner = new System.Windows.Forms.ComboBox();
            this.tCarName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tConsumption = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pAddPerson = new System.Windows.Forms.Panel();
            this.cbDriver = new System.Windows.Forms.CheckBox();
            this.tPersonName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tPersonSurname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pSettings = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.tUid = new System.Windows.Forms.TextBox();
            this.bExport = new System.Windows.Forms.Button();
            this.bImport = new System.Windows.Forms.Button();
            this.tPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pDelete = new System.Windows.Forms.Panel();
            this.lChoice = new System.Windows.Forms.Label();
            this.cDelete = new System.Windows.Forms.ComboBox();
            this.pEditPerson = new System.Windows.Forms.Panel();
            this.cPerson = new System.Windows.Forms.ComboBox();
            this.cbEditDriver = new System.Windows.Forms.CheckBox();
            this.tEditName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tEditSurname = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pMain = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pEditRoute = new System.Windows.Forms.Panel();
            this.cRoute = new System.Windows.Forms.ComboBox();
            this.tEditRouteName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tEditDistance = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pEditCar = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cEditOwner = new System.Windows.Forms.ComboBox();
            this.cCar = new System.Windows.Forms.ComboBox();
            this.tEditCarName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tEditConsumption = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pAddRoute.SuspendLayout();
            this.pAddCar.SuspendLayout();
            this.pAddPerson.SuspendLayout();
            this.pSettings.SuspendLayout();
            this.pDelete.SuspendLayout();
            this.pEditPerson.SuspendLayout();
            this.pMain.SuspendLayout();
            this.pEditRoute.SuspendLayout();
            this.pEditCar.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Anuluj";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pAddRoute
            // 
            this.pAddRoute.Controls.Add(this.tRouteName);
            this.pAddRoute.Controls.Add(this.label1);
            this.pAddRoute.Controls.Add(this.tDistance);
            this.pAddRoute.Controls.Add(this.label2);
            this.pAddRoute.Location = new System.Drawing.Point(292, 161);
            this.pAddRoute.Name = "pAddRoute";
            this.pAddRoute.Size = new System.Drawing.Size(253, 119);
            this.pAddRoute.TabIndex = 8;
            // 
            // tRouteName
            // 
            this.tRouteName.Location = new System.Drawing.Point(3, 22);
            this.tRouteName.Name = "tRouteName";
            this.tRouteName.Size = new System.Drawing.Size(247, 20);
            this.tRouteName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nazwa trasy";
            // 
            // tDistance
            // 
            this.tDistance.Location = new System.Drawing.Point(4, 61);
            this.tDistance.Name = "tDistance";
            this.tDistance.Size = new System.Drawing.Size(246, 20);
            this.tDistance.TabIndex = 5;
            this.tDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pragmaCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dystans";
            // 
            // pAddCar
            // 
            this.pAddCar.Controls.Add(this.label5);
            this.pAddCar.Controls.Add(this.cOwner);
            this.pAddCar.Controls.Add(this.tCarName);
            this.pAddCar.Controls.Add(this.label3);
            this.pAddCar.Controls.Add(this.tConsumption);
            this.pAddCar.Controls.Add(this.label4);
            this.pAddCar.Location = new System.Drawing.Point(293, 322);
            this.pAddCar.Name = "pAddCar";
            this.pAddCar.Size = new System.Drawing.Size(253, 123);
            this.pAddCar.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Właściciel";
            // 
            // cOwner
            // 
            this.cOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cOwner.FormattingEnabled = true;
            this.cOwner.Location = new System.Drawing.Point(4, 98);
            this.cOwner.Name = "cOwner";
            this.cOwner.Size = new System.Drawing.Size(246, 21);
            this.cOwner.TabIndex = 6;
            // 
            // tCarName
            // 
            this.tCarName.Location = new System.Drawing.Point(3, 22);
            this.tCarName.Name = "tCarName";
            this.tCarName.Size = new System.Drawing.Size(247, 20);
            this.tCarName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Marka";
            // 
            // tConsumption
            // 
            this.tConsumption.Location = new System.Drawing.Point(4, 61);
            this.tConsumption.Name = "tConsumption";
            this.tConsumption.Size = new System.Drawing.Size(246, 20);
            this.tConsumption.TabIndex = 5;
            this.tConsumption.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pragmaCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Spalanie";
            // 
            // pAddPerson
            // 
            this.pAddPerson.Controls.Add(this.cbDriver);
            this.pAddPerson.Controls.Add(this.tPersonName);
            this.pAddPerson.Controls.Add(this.label6);
            this.pAddPerson.Controls.Add(this.tPersonSurname);
            this.pAddPerson.Controls.Add(this.label7);
            this.pAddPerson.Location = new System.Drawing.Point(292, 11);
            this.pAddPerson.Name = "pAddPerson";
            this.pAddPerson.Size = new System.Drawing.Size(253, 119);
            this.pAddPerson.TabIndex = 8;
            // 
            // cbDriver
            // 
            this.cbDriver.AutoSize = true;
            this.cbDriver.Location = new System.Drawing.Point(111, 96);
            this.cbDriver.Name = "cbDriver";
            this.cbDriver.Size = new System.Drawing.Size(70, 17);
            this.cbDriver.TabIndex = 7;
            this.cbDriver.Text = "Kierowca";
            this.cbDriver.UseVisualStyleBackColor = true;
            // 
            // tPersonName
            // 
            this.tPersonName.Location = new System.Drawing.Point(3, 22);
            this.tPersonName.Name = "tPersonName";
            this.tPersonName.Size = new System.Drawing.Size(247, 20);
            this.tPersonName.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Imię";
            // 
            // tPersonSurname
            // 
            this.tPersonSurname.Location = new System.Drawing.Point(4, 61);
            this.tPersonSurname.Name = "tPersonSurname";
            this.tPersonSurname.Size = new System.Drawing.Size(246, 20);
            this.tPersonSurname.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nazwisko";
            // 
            // pSettings
            // 
            this.pSettings.Controls.Add(this.label9);
            this.pSettings.Controls.Add(this.label10);
            this.pSettings.Controls.Add(this.tPassword);
            this.pSettings.Controls.Add(this.tUid);
            this.pSettings.Controls.Add(this.bExport);
            this.pSettings.Controls.Add(this.bImport);
            this.pSettings.Controls.Add(this.tPath);
            this.pSettings.Controls.Add(this.label8);
            this.pSettings.Location = new System.Drawing.Point(12, 196);
            this.pSettings.Name = "pSettings";
            this.pSettings.Size = new System.Drawing.Size(253, 119);
            this.pSettings.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Nazwa użytkownika";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(166, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Hasło";
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(128, 59);
            this.tPassword.Name = "tPassword";
            this.tPassword.PasswordChar = '*';
            this.tPassword.Size = new System.Drawing.Size(121, 20);
            this.tPassword.TabIndex = 7;
            this.tPassword.UseSystemPasswordChar = true;
            // 
            // tUid
            // 
            this.tUid.Location = new System.Drawing.Point(4, 59);
            this.tUid.Name = "tUid";
            this.tUid.Size = new System.Drawing.Size(118, 20);
            this.tUid.TabIndex = 6;
            // 
            // bExport
            // 
            this.bExport.Location = new System.Drawing.Point(159, 83);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(75, 23);
            this.bExport.TabIndex = 5;
            this.bExport.Text = "Eksportuj";
            this.bExport.UseVisualStyleBackColor = true;
            // 
            // bImport
            // 
            this.bImport.Location = new System.Drawing.Point(36, 83);
            this.bImport.Name = "bImport";
            this.bImport.Size = new System.Drawing.Size(75, 23);
            this.bImport.TabIndex = 4;
            this.bImport.Text = "Importuj";
            this.bImport.UseVisualStyleBackColor = true;
            // 
            // tPath
            // 
            this.tPath.Location = new System.Drawing.Point(3, 22);
            this.tPath.Name = "tPath";
            this.tPath.Size = new System.Drawing.Size(247, 20);
            this.tPath.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Ścieżka do folderu mysql";
            // 
            // pDelete
            // 
            this.pDelete.Controls.Add(this.lChoice);
            this.pDelete.Controls.Add(this.cDelete);
            this.pDelete.Location = new System.Drawing.Point(12, 321);
            this.pDelete.Name = "pDelete";
            this.pDelete.Size = new System.Drawing.Size(253, 123);
            this.pDelete.TabIndex = 9;
            // 
            // lChoice
            // 
            this.lChoice.AutoSize = true;
            this.lChoice.Location = new System.Drawing.Point(97, 30);
            this.lChoice.Name = "lChoice";
            this.lChoice.Size = new System.Drawing.Size(45, 13);
            this.lChoice.TabIndex = 7;
            this.lChoice.Text = "Wybierz";
            // 
            // cDelete
            // 
            this.cDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cDelete.FormattingEnabled = true;
            this.cDelete.Location = new System.Drawing.Point(4, 52);
            this.cDelete.Name = "cDelete";
            this.cDelete.Size = new System.Drawing.Size(246, 21);
            this.cDelete.TabIndex = 6;
            // 
            // pEditPerson
            // 
            this.pEditPerson.Controls.Add(this.cPerson);
            this.pEditPerson.Controls.Add(this.cbEditDriver);
            this.pEditPerson.Controls.Add(this.tEditName);
            this.pEditPerson.Controls.Add(this.label14);
            this.pEditPerson.Controls.Add(this.tEditSurname);
            this.pEditPerson.Controls.Add(this.label15);
            this.pEditPerson.Location = new System.Drawing.Point(556, 11);
            this.pEditPerson.Name = "pEditPerson";
            this.pEditPerson.Size = new System.Drawing.Size(253, 144);
            this.pEditPerson.TabIndex = 9;
            // 
            // cPerson
            // 
            this.cPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cPerson.FormattingEnabled = true;
            this.cPerson.Location = new System.Drawing.Point(4, 5);
            this.cPerson.Name = "cPerson";
            this.cPerson.Size = new System.Drawing.Size(246, 21);
            this.cPerson.TabIndex = 8;
            // 
            // cbEditDriver
            // 
            this.cbEditDriver.AutoSize = true;
            this.cbEditDriver.Location = new System.Drawing.Point(111, 119);
            this.cbEditDriver.Name = "cbEditDriver";
            this.cbEditDriver.Size = new System.Drawing.Size(70, 17);
            this.cbEditDriver.TabIndex = 7;
            this.cbEditDriver.Text = "Kierowca";
            this.cbEditDriver.UseVisualStyleBackColor = true;
            // 
            // tEditName
            // 
            this.tEditName.Location = new System.Drawing.Point(3, 45);
            this.tEditName.Name = "tEditName";
            this.tEditName.Size = new System.Drawing.Size(247, 20);
            this.tEditName.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(108, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Imię";
            // 
            // tEditSurname
            // 
            this.tEditSurname.Location = new System.Drawing.Point(4, 84);
            this.tEditSurname.Name = "tEditSurname";
            this.tEditSurname.Size = new System.Drawing.Size(246, 20);
            this.tEditSurname.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(97, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Nazwisko";
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.label16);
            this.pMain.Controls.Add(this.label17);
            this.pMain.Location = new System.Drawing.Point(12, 3);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(253, 144);
            this.pMain.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(108, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Main";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(97, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Panel";
            // 
            // pEditRoute
            // 
            this.pEditRoute.Controls.Add(this.cRoute);
            this.pEditRoute.Controls.Add(this.tEditRouteName);
            this.pEditRoute.Controls.Add(this.label18);
            this.pEditRoute.Controls.Add(this.tEditDistance);
            this.pEditRoute.Controls.Add(this.label19);
            this.pEditRoute.Location = new System.Drawing.Point(556, 161);
            this.pEditRoute.Name = "pEditRoute";
            this.pEditRoute.Size = new System.Drawing.Size(253, 144);
            this.pEditRoute.TabIndex = 10;
            // 
            // cRoute
            // 
            this.cRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cRoute.FormattingEnabled = true;
            this.cRoute.Location = new System.Drawing.Point(4, 5);
            this.cRoute.Name = "cRoute";
            this.cRoute.Size = new System.Drawing.Size(246, 21);
            this.cRoute.TabIndex = 8;
            // 
            // tEditRouteName
            // 
            this.tEditRouteName.Location = new System.Drawing.Point(3, 45);
            this.tEditRouteName.Name = "tEditRouteName";
            this.tEditRouteName.Size = new System.Drawing.Size(247, 20);
            this.tEditRouteName.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(89, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "Nazwa trasy";
            // 
            // tEditDistance
            // 
            this.tEditDistance.Location = new System.Drawing.Point(4, 84);
            this.tEditDistance.Name = "tEditDistance";
            this.tEditDistance.Size = new System.Drawing.Size(246, 20);
            this.tEditDistance.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(97, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Dystans";
            // 
            // pEditCar
            // 
            this.pEditCar.Controls.Add(this.label13);
            this.pEditCar.Controls.Add(this.cEditOwner);
            this.pEditCar.Controls.Add(this.cCar);
            this.pEditCar.Controls.Add(this.tEditCarName);
            this.pEditCar.Controls.Add(this.label11);
            this.pEditCar.Controls.Add(this.tEditConsumption);
            this.pEditCar.Controls.Add(this.label12);
            this.pEditCar.Location = new System.Drawing.Point(556, 321);
            this.pEditCar.Name = "pEditCar";
            this.pEditCar.Size = new System.Drawing.Size(253, 144);
            this.pEditCar.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(97, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Właściciel";
            // 
            // cEditOwner
            // 
            this.cEditOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cEditOwner.FormattingEnabled = true;
            this.cEditOwner.Location = new System.Drawing.Point(4, 120);
            this.cEditOwner.Name = "cEditOwner";
            this.cEditOwner.Size = new System.Drawing.Size(246, 21);
            this.cEditOwner.TabIndex = 8;
            // 
            // cCar
            // 
            this.cCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cCar.FormattingEnabled = true;
            this.cCar.Location = new System.Drawing.Point(4, 5);
            this.cCar.Name = "cCar";
            this.cCar.Size = new System.Drawing.Size(246, 21);
            this.cCar.TabIndex = 8;
            // 
            // tEditCarName
            // 
            this.tEditCarName.Location = new System.Drawing.Point(3, 45);
            this.tEditCarName.Name = "tEditCarName";
            this.tEditCarName.Size = new System.Drawing.Size(247, 20);
            this.tEditCarName.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(103, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Marka";
            // 
            // tEditConsumption
            // 
            this.tEditConsumption.Location = new System.Drawing.Point(4, 84);
            this.tEditConsumption.Name = "tEditConsumption";
            this.tEditConsumption.Size = new System.Drawing.Size(246, 20);
            this.tEditConsumption.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(101, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Spalanie";
            // 
            // DialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 193);
            this.ControlBox = false;
            this.Controls.Add(this.pEditCar);
            this.Controls.Add(this.pEditRoute);
            this.Controls.Add(this.pEditPerson);
            this.Controls.Add(this.pDelete);
            this.Controls.Add(this.pSettings);
            this.Controls.Add(this.pAddPerson);
            this.Controls.Add(this.pAddCar);
            this.Controls.Add(this.pAddRoute);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formularz";
            this.pAddRoute.ResumeLayout(false);
            this.pAddRoute.PerformLayout();
            this.pAddCar.ResumeLayout(false);
            this.pAddCar.PerformLayout();
            this.pAddPerson.ResumeLayout(false);
            this.pAddPerson.PerformLayout();
            this.pSettings.ResumeLayout(false);
            this.pSettings.PerformLayout();
            this.pDelete.ResumeLayout(false);
            this.pDelete.PerformLayout();
            this.pEditPerson.ResumeLayout(false);
            this.pEditPerson.PerformLayout();
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            this.pEditRoute.ResumeLayout(false);
            this.pEditRoute.PerformLayout();
            this.pEditCar.ResumeLayout(false);
            this.pEditCar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pAddRoute;
        public System.Windows.Forms.TextBox tRouteName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tDistance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pAddCar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cOwner;
        public System.Windows.Forms.TextBox tCarName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tConsumption;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pAddPerson;
        private System.Windows.Forms.CheckBox cbDriver;
        public System.Windows.Forms.TextBox tPersonName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tPersonSurname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pSettings;
        public System.Windows.Forms.TextBox tPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bExport;
        private System.Windows.Forms.Button bImport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox tPassword;
        public System.Windows.Forms.TextBox tUid;
        private System.Windows.Forms.Panel pDelete;
        private System.Windows.Forms.Label lChoice;
        private System.Windows.Forms.ComboBox cDelete;
        private System.Windows.Forms.Panel pEditPerson;
        private System.Windows.Forms.ComboBox cPerson;
        private System.Windows.Forms.CheckBox cbEditDriver;
        public System.Windows.Forms.TextBox tEditName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tEditSurname;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel pEditRoute;
        private System.Windows.Forms.ComboBox cRoute;
        public System.Windows.Forms.TextBox tEditRouteName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tEditDistance;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel pEditCar;
        private System.Windows.Forms.ComboBox cCar;
        public System.Windows.Forms.TextBox tEditCarName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tEditConsumption;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cEditOwner;
    }
}