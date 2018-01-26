using System;
using System.IO;
using System.Windows.Forms;

namespace KosztorysKierowcy
{
    public partial class DialogBox : Form
    {
        private DBManager dbm;
        public DialogBox(string command)
        {
            InitializeComponent();
            dbm = new DBManager();
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
                    string name = tPersonName.Text;
                    string surname = tPersonSurname.Text;
                    int driver = cbDriver.Checked ? 1 : 0;
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
            button1.Click += (s, e) =>
            {
                DBManager.mysqlpath = tPath.Text;
                DBManager.uid = tUid.Text;
                DBManager.password = tPassword.Text;

                string output = "mysqlpath=" + tPath.Text + "\nuid=" + tUid.Text + "\npassword=" + tPassword.Text;
                StreamWriter file = new StreamWriter("config.ini");
                file.WriteLine(output);
                file.Close();

                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            bImport.Click += (s, e) =>
            {
                string path = tPath.Text;
                if (DBManager.mysqlpath != path)
                    DBManager.mysqlpath = path;
                dbm.Restore();
            };
            bExport.Click += (s, e) =>
            {
                string path = tPath.Text;
                if (DBManager.mysqlpath != path)
                    DBManager.mysqlpath = path;
                dbm.Backup();
            };
        }




        private void pragmaCheck(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
