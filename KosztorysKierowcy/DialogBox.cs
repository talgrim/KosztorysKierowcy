using MySql.Data.MySqlClient;
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
            button1.Click += (s, e) =>
            {
                if (tPersonName.Text.Trim().Length != 0 && tPersonSurname.Text.Trim().Length != 0)
                {
                    string name = tPersonName.Text;
                    string surname = tPersonSurname.Text;
                    int driver = cbDriver.Checked ? 1 : 0;
                    dbm.addPerson(name, surname, driver);
                    dbm.addDebtor(name, surname);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        private void AddCar()
        {
            pAddCar.Location = pMain.Location;
            cOwner.DisplayMember = "FullName";
            cOwner.DataSource = dbm.getDrivers();

            button1.Click += (s, e) =>
            {
                if (tCarName.Text.Trim().Length != 0 && Int16.Parse(tConsumption.Text) > 0)
                {
                    string name = tCarName.Text;
                    int consumption = Int16.Parse(tConsumption.Text);
                    int ownerid = (cOwner.SelectedValue as Person).Id;
                    dbm.addCar(name, consumption, ownerid);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        private void AddRoute()
        {
            pAddRoute.Location = pMain.Location;
            button1.Click += (s, e) =>
            {
                if (tRouteName.Text.Trim().Length != 0 && Int16.Parse(tDistance.Text) > 0)
                {
                    string name = tRouteName.Text;
                    int distance = Int16.Parse(tDistance.Text);
                    dbm.addRoute(name, distance);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        private void EditPerson()
        {
            pEditPerson.Location = pMain.Location;
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
                if (tEditCarName.Text.Trim().Length != 0 && Int16.Parse(tEditConsumption.Text) > 0)
                {
                    string name = tEditCarName.Text;
                    int consumption = Int16.Parse(tEditConsumption.Text);
                    int ownerid = (cEditOwner.SelectedValue as Person).Id;
                    dbm.editCar((cCar.SelectedValue as Car).Id, name, consumption, ownerid);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        private void EditRoute()
        {
            pEditRoute.Location = pMain.Location;
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
                if (tEditRouteName.Text.Trim().Length != 0 && Int16.Parse(tEditDistance.Text) > 0)
                {
                    string name = tEditRouteName.Text;
                    int consumption = Int16.Parse(tEditDistance.Text);
                    dbm.editRoute((cRoute.SelectedValue as Route).Id, name, consumption);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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
