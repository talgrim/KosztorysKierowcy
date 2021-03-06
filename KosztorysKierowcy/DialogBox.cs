﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KosztorysKierowcy
{
    public partial class DialogBox : Form
    {
        private DBManager dbm;
        public List<Debt> Debts { get; private set; }
        public DialogBox(string command)
        {
            InitializeComponent();
            dbm = new DBManager();
            Debts = new List<Debt>();
            this.Text = command;
            switch (command)
            {
                case "Dodaj osobę":
                    AddPerson();
                    break;
                case "Dodaj auto":
                    AddCar();
                    break;
                case "Dodaj trasę":
                    AddRoute();
                    break;
                case "Edytuj osobę":
                    EditPerson();
                    break;
                case "Edytuj auto":
                    EditCar();
                    break;
                case "Edytuj trasę":
                    EditRoute();
                    break;
                case "Usuń osobę":
                    DeletePerson();
                    break;
                case "Usuń auto":
                    DeleteCar();
                    break;
                case "Usuń trasę":
                    DeleteRoute();
                    break;
                case "Ustawienia":
                    Settings();
                    break;
                case "Sprawdź długi":
                    CheckDebts();
                    break;
            }
            pMain.Visible = false;
            button2.Click += (s, e) => { this.Close(); };
        }

        private void AddPerson()
        {
            pAddPerson.Location = pMain.Location;
            tPersonSurname.KeyPress += new KeyPressEventHandler(pragmaTextSurname);
            tPersonName.KeyPress += new KeyPressEventHandler(pragmaTextName);
            button1.Click += (s, e) =>
            {
                string name = tPersonName.Text;
                string surname = tPersonSurname.Text;
                if (name.Trim().Length == 0 || surname.Trim().Length == 0)
                {
                    MessageBox.Show("Nie może być puste", "Bład", MessageBoxButtons.OK);
                    return;
                }

                if (dbm.checkPerson(name,surname))
                {
                    MessageBox.Show("Osoba już istnieje. Może dodaj pseudonim do imienia?", "Bład", MessageBoxButtons.OK);
                    return;
                }
                int driver = cbDriver.Checked ? 1 : 0;
                dbm.addPerson(name, surname, driver);
                dbm.addDebtor(name, surname);

                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        private void AddCar()
        {
            pAddCar.Location = pMain.Location;
            tCarName.KeyPress += new KeyPressEventHandler(pragmaCarName);
            tConsumption.KeyPress += new KeyPressEventHandler(pragmaConsumption);
            cOwner.DisplayMember = "FullName";
            cOwner.DataSource = dbm.getDrivers();

            button1.Click += (s, e) =>
            {
                string name = tCarName.Text;
                short consumption;
                if (name.Trim().Length == 0)
                {
                    MessageBox.Show("Nazwa samochodu nie może być pusta", "Bład", MessageBoxButtons.OK);
                    return;
                }

                if (!Int16.TryParse(tConsumption.Text,out consumption))
                {
                    MessageBox.Show("Spalanie nie może być puste", "Bład", MessageBoxButtons.OK);
                    return;
                }

                if (consumption==0)
                {
                    MessageBox.Show("Spalanie nie może wynosić 0", "Bład", MessageBoxButtons.OK);
                    return;
                }



                int ownerid = (cOwner.SelectedValue as Person).Id;
                dbm.addCar(name, consumption, ownerid);

                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }

        private void AddRoute()
        {
            pAddRoute.Location = pMain.Location;
            tDistance.KeyPress += new KeyPressEventHandler(pragmaDistance);
            tRouteName.KeyPress += new KeyPressEventHandler(pragmaRouteName);
            button1.Click += (s, e) =>
            {
               
                string name = tRouteName.Text;
                short distance;
                if (name.Trim().Length == 0)
                {
                    MessageBox.Show("Nazwa trasy nie może być pusta", "Bład", MessageBoxButtons.OK);
                    return;
                }

                if (!Int16.TryParse(tConsumption.Text, out distance))
                {
                    MessageBox.Show("Długość trasy nie może być pusta", "Bład", MessageBoxButtons.OK);
                    return;
                }

                if (distance == 0)
                {
                    MessageBox.Show("Długość traasy nie może wynosić 0", "Bład", MessageBoxButtons.OK);
                    return;
                }



                dbm.addRoute(name, distance);
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            };
        }

        private void EditPerson()
        {
            
            pEditPerson.Location = pMain.Location;
            tEditSurname.KeyPress += new KeyPressEventHandler(pragmaTextSurname);
            tEditName.KeyPress += new KeyPressEventHandler(pragmaTextName);
            cPerson.DisplayMember = "FullName";
            cPerson.DataSource = dbm.getPassengersWithoutDriver(0);
            Person start = cPerson.SelectedValue as Person;
            tEditName.Text = start.Name;
            tEditSurname.Text = start.Surname;
            cbEditDriver.Checked = start.Driver;

            cPerson.SelectedValueChanged += (s, e) =>
            {
                Person person = cPerson.SelectedValue as Person;
                tEditName.Text = person.Name;
                tEditSurname.Text = person.Surname;
                cbEditDriver.Checked = person.Driver;
            };
            button1.Click += (s, e) =>
            {
                Person person = cPerson.SelectedValue as Person;

                if (tEditName.Text.Trim().Length == 0 || tEditSurname.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Nie może być puste", "Bład", MessageBoxButtons.OK);
                    return;
                }

                if (dbm.checkPerson(tEditName.Text, tEditSurname.Text))
                {
                    MessageBox.Show("Osoba już istnieje. Może dodaj pseudonim do imienia?", "Bład", MessageBoxButtons.OK);
                    return;
                }


                if (tEditName.Text.Trim().Length != 0 && tEditSurname.Text.Trim().Length != 0)
                {
                    string name = tEditName.Text;
                    string surname = tEditSurname.Text;
                    int driver = cbEditDriver.Checked ? 1 : 0;
                    dbm.editPerson(person.Id, name, surname, driver);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        private void EditCar()
        {
            pEditCar.Location = pMain.Location;
            tEditCarName.KeyPress += new KeyPressEventHandler(pragmaCarName);
            tEditConsumption.KeyPress += new KeyPressEventHandler(pragmaConsumption);
            cCar.DisplayMember = "Information";
            cCar.DataSource = dbm.getCars();
            cEditOwner.DisplayMember = "FullName";
            cEditOwner.DataSource = dbm.getDrivers();
            Car start = cCar.SelectedValue as Car;
            tEditCarName.Text = start.Name;
            tEditConsumption.Text = start.Consumption.ToString();

            cCar.SelectedValueChanged += (s, e) =>
            {
                Car car = cCar.SelectedValue as Car;
                tEditCarName.Text = car.Name;
                tEditConsumption.Text = car.Consumption.ToString();
            };

            button1.Click += (s, e) =>
            {
                string name = tEditCarName.Text;
                short consumption;

                if (name.Trim().Length == 0)
                {
                    MessageBox.Show("Nazwa samochodu nie może być pusta", "Bład", MessageBoxButtons.OK);
                    return;
                }

                if (!Int16.TryParse(tConsumption.Text, out consumption))
                {
                    MessageBox.Show("Spalanie nie może być puste", "Bład", MessageBoxButtons.OK);
                    return;
                }

                if (consumption == 0)
                {
                    MessageBox.Show("Spalanie nie może wynosić 0", "Bład", MessageBoxButtons.OK);
                    return;
                }


                
                int ownerid = (cEditOwner.SelectedValue as Person).Id;
                dbm.editCar((cCar.SelectedValue as Car).Id, name, consumption, ownerid);

                this.DialogResult = DialogResult.OK;
                this.Close();

            };
        }

        private void EditRoute()
        {
            pEditRoute.Location = pMain.Location;
            tEditDistance.KeyPress += new KeyPressEventHandler(pragmaDistance);
            tEditRouteName.KeyPress += new KeyPressEventHandler(pragmaRouteName);
            cRoute.DisplayMember = "Information";
            cRoute.DataSource = dbm.getRoutes();
            Route start = cRoute.SelectedValue as Route;
            tEditRouteName.Text = start.Name;
            tEditDistance.Text = start.Distance.ToString();

            cRoute.SelectedValueChanged += (s, e) =>
            {
                Route route = cRoute.SelectedValue as Route;
                tEditRouteName.Text = route.Name;
                tEditDistance.Text = route.Distance.ToString();
            };

            button1.Click += (s, e) =>
            {

                string name = tRouteName.Text;
                short distance;
                if (name.Trim().Length == 0)
                {
                    MessageBox.Show("Nazwa trasy nie może być pusta", "Bład", MessageBoxButtons.OK);
                    return;
                }

                if (!Int16.TryParse(tConsumption.Text, out distance))
                {
                    MessageBox.Show("Długość trasy nie może być pusta", "Bład", MessageBoxButtons.OK);
                    return;
                }

                if (distance == 0)
                {
                    MessageBox.Show("Długość traasy nie może wynosić 0", "Bład", MessageBoxButtons.OK);
                    return;
                }


                dbm.editRoute((cRoute.SelectedValue as Route).Id, name, distance);

                this.DialogResult = DialogResult.OK;
                this.Close();
                
            };
        }

        private void DeletePerson()
        {
            pDelete.Location = pMain.Location;
            lChoice.Text = "Wybierz osobę";
            cDelete.DisplayMember = "FullName";
            cDelete.DataSource = dbm.getPassengersWithoutDriver(0);
            button1.Click += (s, e) =>
            {
                Person person = cDelete.SelectedValue as Person;
                string text = "Czy na pewno chcesz usunąć osobę: " + person.FullName + "?";
                DialogResult dialogResult = MessageBox.Show(text, "Potwierdź", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    dbm.deletePerson(person.Id);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        private void DeleteCar()
        {
            pDelete.Location = pMain.Location;
            lChoice.Text = "Wybierz auto";
            cDelete.DisplayMember = "Information";
            cDelete.DataSource = dbm.getCars();
            button1.Click += (s, e) =>
            {
                Car car = cDelete.SelectedValue as Car;
                string text = "Czy na pewno chcesz usunąć auto: " + car.Name + "?";
                DialogResult dialogResult = MessageBox.Show(text, "Potwierdź", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    dbm.deleteCar(car.Id);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        private void DeleteRoute()
        {
            pDelete.Location = pMain.Location;
            lChoice.Text = "Wybierz trasę";
            cDelete.DisplayMember = "Information";
            cDelete.DataSource = dbm.getRoutes();
            button1.Click += (s, e) =>
            {
                Route route = cDelete.SelectedValue as Route;
                string text = "Czy na pewno chcesz usunąć trasę: " + route.Name + "?";
                DialogResult dialogResult = MessageBox.Show(text, "Potwierdź", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    dbm.deleteRoute(route.Id);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        private void Settings()
        {
            pSettings.Location = pMain.Location;
            tPath.Text = DBManager.mysqlpath;
            tUid.Text = DBManager.uid;
            tPassword.Text = DBManager.password;
            tDatabase.Text = DBManager.database;
            tServer.Text = DBManager.server;
            button1.Click += (s, e) =>
            {
                DBManager.mysqlpath = tPath.Text;
                DBManager.uid = tUid.Text;
                DBManager.password = tPassword.Text;
                DBManager.database = tDatabase.Text;
                DBManager.server = tServer.Text;

                string output = 
                "mysqlpath=" + tPath.Text + 
                "\nuid=" + tUid.Text +
                "\npassword=" + tPassword.Text + 
                "\ndatabase=" + tDatabase.Text + 
                "\nserver=" + tServer.Text;
                StreamWriter file = new StreamWriter("config.ini");
                file.WriteLine(output);
                file.Close();

                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            bImport.Click += (s, e) =>
            {
                DBManager.database = tDatabase.Text;
                string path = tPath.Text;
                if (DBManager.mysqlpath != path)
                    DBManager.mysqlpath = path;
                dbm.Import();
            };
            bExport.Click += (s, e) =>
            {
                DBManager.database = tDatabase.Text;
                string path = tPath.Text;
                if (DBManager.mysqlpath != path)
                    DBManager.mysqlpath = path;
                dbm.Export();
            };
            bCreate.Click += (s, e) =>
            {
                DBManager.uid = tUid.Text;
                DBManager.password = tPassword.Text;
                DBManager.database = tDatabase.Text;
                DBManager.server = tServer.Text;

                string connectionString;
                connectionString = "SERVER=" + DBManager.server + ";" + 
                "UID=" + DBManager.uid + ";" + "PASSWORD=" + DBManager.password + ";";
                string query = "CREATE DATABASE " + DBManager.database;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        cmd.ExecuteNonQuery();
                    connection.Close();
                }
            };
        }

        private void CheckDebts()
        {
            pChoice.Location = pMain.Location;
            cChoice.DisplayMember = "FullName";
            cChoice.DataSource = dbm.getDebtpersons();
            button1.Click += (s, e) =>
            {
                int id = (cChoice.SelectedValue as Person).Id;
                if (cbPeriod.Checked)
                {
                    string from = tFrom.Text;
                    string to = tTo.Text;
                    if (from.Trim().Length > 0 && to.Trim().Length > 0)
                    {
                        DateTime From = DateTime.Parse(from);
                        DateTime To = DateTime.Parse(to);
                        To = To.AddDays(1);
                        if (DateTime.Compare(From, To) <= 0)
                        {
                            if (rbCreditor.Checked)
                                Debts = dbm.getDebtsByCreditor(id, From.ToString("yyyy-MM-dd"), To.ToString("yyyy-MM-dd"));
                            else
                                Debts = dbm.getDebtsByDebtor(id, From.ToString("yyyy-MM-dd"), To.ToString("yyyy-MM-dd"));
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    if (rbCreditor.Checked)
                        Debts = dbm.getDebtsByCreditor(id);
                    else
                        Debts = dbm.getDebtsByDebtor(id);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        private void pragmaNumericInteger(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void pragmaTextSurname(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
                (e.KeyChar != '-'))
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Niepoprawny znak! Tylko litery i jeden myślnik!", TB, 0, TB.Height, VisibleTime);

                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Tylko jeden myślnik!", TB, 0, TB.Height, VisibleTime);

                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') == -1) && (sender as TextBox).Text.Length==0)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Myślnik nie może być na początku", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;

            }
            if (!char.IsControl(e.KeyChar) && (sender as TextBox).Text.Length > 49)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("To pole może mieć maksymalnie 50 znaków", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;

            }
        }

        private void pragmaTextName(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
                (e.KeyChar != '"') &&
                (e.KeyChar != ' '))
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("W tym polu możesz wpisać tylko litery", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;
            }
                

            if ((e.KeyChar == '"') && ((sender as TextBox).Text.IndexOf('"') != (sender as TextBox).Text.LastIndexOf('"')))
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Nie może być więcej niż 2 cudzysłowiów", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;
            }

            if ((e.KeyChar == ' ') && ((sender as TextBox).Text.IndexOf(' ') != (sender as TextBox).Text.LastIndexOf(' ')))
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Nie może być więcej niż 2 spacje", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;
            }


            //if ((e.KeyChar == ' ') && ((sender as TextBox).Text.IndexOf('"') > -1) && ((sender as TextBox).Text.IndexOf('"') == (sender as TextBox).Text.LastIndexOf('"'))
            //    && !((sender as TextBox).Text.IndexOf(' ') > -1))
            //{
            //    TextBox TB = sender as TextBox;
            //    int VisibleTime = 1000;

            //    ToolTip tt = new ToolTip();
            //    tt.Show("W pseudonimie nie powinno być spacji", TB, 0, TB.Height, VisibleTime);
            //    e.Handled = true;
            //}

            //if ((e.KeyChar == ' ') && ((sender as TextBox).Text.IndexOf(' ') > -1) && ((sender as TextBox).Text.IndexOf(' ')+1 == (sender as TextBox).Text.LastIndexOf(' ')))
            //{
            //    TextBox TB = sender as TextBox;
            //    int VisibleTime = 1000;

            //    ToolTip tt = new ToolTip();
            //    tt.Show("Może być tylko jedna spacja", TB, 0, TB.Height, VisibleTime);
            //    e.Handled = true;
            //}
            if ((e.KeyChar == '"') && ((sender as TextBox).Text.IndexOf('"') == -1) && (sender as TextBox).Text.Length == 0)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Cudzysłów nie może być pierwszy", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;

            }

            if ((e.KeyChar == ' ') && ((sender as TextBox).Text.IndexOf(' ') == -1) && (sender as TextBox).Text.Length == 0)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Spacja nie może być pierwsza", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;

            }
            if (!char.IsControl(e.KeyChar) && (sender as TextBox).Text.Length > 49)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("To pole może mieć maksymalnie 50 znaków", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;

            }
        }

        private void pragmaCarName(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
                (e.KeyChar != '-') && 
                (e.KeyChar != ' '))
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Niepoprawny znak! Tylko litery i jeden myślnik!", TB, 0, TB.Height, VisibleTime);

                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Tylko jeden myślnik!", TB, 0, TB.Height, VisibleTime);

                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') == -1) && (sender as TextBox).Text.Length == 0)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Myślnik nie może być na początku", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;

            }



            //if ((e.KeyChar == ' ') && ((sender as TextBox).Text.IndexOf(' ') > -1))
            //{
            //    TextBox TB = sender as TextBox;
            //    int VisibleTime = 1000;

            //    ToolTip tt = new ToolTip();
            //    tt.Show("Może być tylko jedna spacja", TB, 0, TB.Height, VisibleTime);
            //    e.Handled = true;
            //}

            if ((e.KeyChar == ' ') && ((sender as TextBox).Text.IndexOf(' ') == -1) && (sender as TextBox).Text.Length == 0)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Spacja nie może być pierwsza", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;

            }
            if (!char.IsControl(e.KeyChar) && (sender as TextBox).Text.Length > 49)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("To pole może mieć maksymalnie 50 znaków", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;

            }

        }

        private void pragmaConsumption(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("W tym polu możesz wpisać tylko liczbę", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && (sender as TextBox).Text.Length>1)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Liczba może być maksymalnie dwucyfrowa", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;
            }

        }

        private void pragmaDistance(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("W tym polu możesz wpisać tylko liczbę", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar) && (sender as TextBox).Text.Length > 3)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("Maksymalna wartość to 9999", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;

            }
        }

        private void pragmaRouteName(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (sender as TextBox).Text.Length > 99)
            {
                TextBox TB = sender as TextBox;
                int VisibleTime = 1000;

                ToolTip tt = new ToolTip();
                tt.Show("To pole może mieć maksymalnie 100 znaków", TB, 0, TB.Height, VisibleTime);
                e.Handled = true;

            }
        }

        private void cbPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPeriod.Checked)
            {
                lFrom.Visible = true;
                tFrom.Visible = true;
                lTo.Visible = true;
                tTo.Visible = true;
            }
            else
            {
                lFrom.Visible = false;
                tFrom.Visible = false;
                lTo.Visible = false;
                tTo.Visible = false;
            }
        }

        private void pragmaData(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') != (sender as TextBox).Text.LastIndexOf('-')))
            {
                e.Handled = true;
            }
        }
    }
}
