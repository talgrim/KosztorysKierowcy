using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace KosztorysKierowcy
{
    public partial class MainWindow : Form
    {
        private DBManager dbm;
        private List<Person> drivers;
        private List<Route> routes;
        private List<Car> cars;
        private List<Person> passengers;
        private double result;
        private List<Transit> transits;
        private string[] sorter = new string[2];
        private bool debt = false;
        public MainWindow()
        {
            InitializeComponent();
            sorter[0] = "TransitID";
            sorter[1] = "ASC";
            this.cCars.SelectedIndexChanged += new EventHandler(this.Calculate);
            this.cRoutes.SelectedIndexChanged += new EventHandler(this.Calculate);
            this.tPetroleum.TextChanged += new EventHandler(this.Calculate);
            this.lPassengers.SelectedIndexChanged += new EventHandler(this.Calculate);
            bExit.Click += (s, e) => { this.Close(); };

            bSettings.Click += (s, e) => { showDialogBox((s as Button).Text); };
            bDebts.Click += (s, e) => { showDialogBox((s as Button).Text); };

            bAddPerson.Click += (s, e) => { showDialogBox((s as Button).Text); };
            bAddRoute.Click += (s, e) => { showDialogBox((s as Button).Text); };
            bAddCar.Click += (s, e) => { showDialogBox((s as Button).Text); };

            bEditPerson.Click += (s, e) => { showDialogBox((s as Button).Text); };
            bEditRoute.Click += (s, e) => { showDialogBox((s as Button).Text); };
            bEditCar.Click += (s, e) => { showDialogBox((s as Button).Text); };

            bDeletePerson.Click += (s, e) => { showDialogBox((s as Button).Text); };
            bDeleteRoute.Click += (s, e) => { showDialogBox((s as Button).Text); };
            bDeleteCar.Click += (s, e) => { showDialogBox((s as Button).Text); };
            
            dbm = new DBManager();
            if (dbm.IsCorrect)
            {
                bRetry.Visible = false;
                InitFields();
            }
            else
                bRetry.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void cDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dbm.IsCorrect)
            {
                int id = (cDrivers.SelectedValue as Person).Id;
                cars = dbm.getCarsByID(id);
                passengers = dbm.getPassengersWithoutDriver(id);
                cCars.DisplayMember = "Information";
                cCars.DataSource = cars;
                lPassengers.DisplayMember = "FullName";
                lPassengers.DataSource = passengers;
            }
        }

        private void Calculate(object sender, EventArgs e)
        {
            double petroleum = Double.Parse(tPetroleum.Text);
            if (cRoutes.SelectedIndex > -1 && cCars.SelectedIndex > -1)
            {
                int distance = routes[cRoutes.SelectedIndex].Distance;
                int consumption = cars[cCars.SelectedIndex].Consumption;

                result = distance * ((double)consumption / 100) * petroleum;
                tRouteCost.Text = result.ToString("F") + " zł";
                int passengers = lPassengers.SelectedItems.Count + 1;
                result /= passengers;
                tPassengersCost.Text = result.ToString("F") + " zł";
            }
        }

        private void InitFields()
        {
            try
            {


                drivers = dbm.getDrivers();
                cDrivers.DisplayMember = "FullName";
                cDrivers.DataSource = drivers;

                routes = dbm.getRoutes();
                cRoutes.DisplayMember = "Information";
                cRoutes.DataSource = routes;

                if (cDrivers.SelectedValue != null)
                {
                    int id = (cDrivers.SelectedValue as Person).Id;
                    cars = dbm.getCarsByID(id);
                    cCars.DisplayMember = "Information";
                    cCars.DataSource = cars;

                    passengers = dbm.getPassengersWithoutDriver(id);
                    lPassengers.DisplayMember = "FullName";
                    lPassengers.DataSource = passengers;
                }
            }
            catch (Exception e)
            {
                dbm.Import();
            }
        }

        private void lPassengers_SelectedIndexChanged(object sender, EventArgs e)
        {
            tPassengersCount.Text = lPassengers.SelectedItems.Count.ToString() + " + kierowca";
        }

        private void bAddTransit_Click(object sender, EventArgs e)
        {
            if (dbm.IsCorrect)
            {
                List<int> passengerids = new List<int>();
                string text;
                text = "Czy na pewno chcesz dodać przejazd:\n";
                text += "Kierowca: " + (cDrivers.SelectedValue as Person).FullName + "\n";
                text += "Auto: " + (cCars.SelectedValue as Car).Name + "\n";
                text += "Trasa: " + (cRoutes.SelectedValue as Route).Name + "\n";
                text += "Pasażerowie: ";
                foreach (Person passenger in lPassengers.SelectedItems)
                {
                    text += passenger.FullName + ", ";
                    passengerids.Add(passenger.Id);
                }
                if (passengerids.Count == 0)
                    text += "Brak, ";
                text = text.Remove(text.Length - 2, 2);
                text += "\nKoszt: " + result.ToString("F") + " zł.";
                DialogResult dialogResult = MessageBox.Show(text, "Potwierdź", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    int driverid = (cDrivers.SelectedValue as Person).Id;
                    int carid = (cCars.SelectedValue as Car).Id;
                    int routeid = (cRoutes.SelectedValue as Route).Id;
                    dbm.insertTransit(driverid, carid, routeid, result);
                    if (passengerids.Count > 0)
                    {
                        dbm.insertPassengers(dbm.getLastTransitID(), passengerids.ToArray());
                        dbm.insertDebts(driverid, passengerids.ToArray(), result);
                    }
                    bCheckTransits.PerformClick();
                }
            }
        }

        private void bCheckTransits_Click(object sender, EventArgs e)
        {
            if (dbm.IsCorrect)
            {
                if ((sender as Button).Name == "bAddTransit")
                    gTransits.DataSource = dbm.getTransitsByDriver((cDrivers.SelectedValue as Person).Id);
                else
                {
                    if (rbPassenger.Checked && lPassengers.SelectedItems.Count >= 1)
                    {
                        List<string> ids = new List<string>();
                        foreach (Person person in lPassengers.SelectedItems)
                            ids.Add(person.Id.ToString());
                        if (cbAddDriver.Checked)
                            ids.Add((cDrivers.SelectedValue as Person).Id.ToString());
                        string tabids = String.Join(", ", ids);
                        if(cbPeriod.Checked)
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
                                    if (cbNotGrouped.Checked)
                                        gTransits.DataSource = dbm.getTransitsByPassengersNotGrouped(tabids, From.ToString("yyyy-MM-dd"), To.ToString("yyyy-MM-dd"));
                                    else
                                        gTransits.DataSource = dbm.getTransitsByPassengers(tabids, From.ToString("yyyy-MM-dd"), To.ToString("yyyy-MM-dd"));
                                }
                            }
                        }
                        else
                            if (cbNotGrouped.Checked)
                                gTransits.DataSource = dbm.getTransitsByPassengersNotGrouped(tabids);
                            else
                                gTransits.DataSource = dbm.getTransitsByPassengers(tabids);
                    }
                    else
                    {
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
                                    gTransits.DataSource = dbm.getTransitsByDriver((cDrivers.SelectedValue as Person).Id, From.ToString("yyyy-MM-dd"), To.ToString("yyyy-MM-dd"));
                            }
                        }
                        else
                        {
                            transits = dbm.getTransitsByDriver((cDrivers.SelectedValue as Person).Id);
                            gTransits.DataSource = transits;
                        }
                    }
                }
                debt = false;
            }
        }

        private void showDialogBox(string command)
        {
            using (DialogBox form = new DialogBox(command))
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                    if (dbm.IsCorrect)
                    {
                        InitFields();
                        if (command == bDebts.Text)
                        {
                            gTransits.DataSource = form.Debts;
                            debt = true;
                        }
                    }
            }
        }

        private void enableCheckboxes(object sender, EventArgs e)
        {
            if (rbPassenger.Checked)
            {
                cbAddDriver.Enabled = true;
                cbNotGrouped.Enabled = true;
            }
            else if(rbDriver.Checked)
            {
                cbAddDriver.Checked = false;
                cbAddDriver.Enabled = false;
                cbNotGrouped.Checked = false;
                cbNotGrouped.Enabled = false;
            }
        }

        private void bRetry_Click(object sender, EventArgs e)
        {
            dbm = new DBManager();
            if (dbm.IsCorrect)
            {
                InitFields();
            }
        }

        private void cbAddDriver_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAddDriver.Checked)
                cbNotGrouped.Enabled = true;
            else if (lPassengers.SelectedItems.Count < 2)
            {
                cbNotGrouped.Checked = false;
                cbNotGrouped.Enabled = false;
            }
                
        }

        private void cbPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if(cbPeriod.Checked)
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

        private void pragmaDate(object sender, KeyPressEventArgs e)
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

        private void pragmaNumericDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void gTransits_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = gTransits.Columns[e.ColumnIndex];
            ListSortDirection direction;

            if (sorter != null)
            {
                if (sorter[0] == column.Name)
                {
                    if (sorter[1] == "ASC")
                    {
                        direction = ListSortDirection.Descending;
                        sorter[1] = "DESC";
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                        sorter[1] = "ASC";
                    }

                }
                else
                {
                    sorter[0] = column.Name;
                    if (sorter[1] == "ASC")
                    {
                        direction = ListSortDirection.Descending;
                        sorter[1] = "DESC";
                    }
                    else
                    {
                        direction = ListSortDirection.Ascending;
                        sorter[1] = "ASC";
                    }
                }
            }
            else
                direction = ListSortDirection.Ascending;
            
            if (debt)
            {
                List<Debt> tab = gTransits.DataSource as List<Debt>;
                List<Debt> sorted = new List<Debt>();
                switch (column.Name)
                {
                    case "Debtid":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Debt>(tab.OrderBy(o => o.Debtid)).ToList() :
                        new List<Debt>(tab.OrderByDescending(o => o.Debtid)).ToList();
                        break;
                    case "Creditor":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Debt>(tab.OrderBy(o => o.Creditor).ToList()) :
                        new List<Debt>(tab.OrderByDescending(o => o.Creditor).ToList());
                        break;
                    case "Debtor":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Debt>(tab.OrderBy(o => o.Debtor).ToList()) :
                        new List<Debt>(tab.OrderByDescending(o => o.Debtor).ToList());
                        break;
                    case "TransitCost":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Debt>(tab.OrderBy(o => o.TransitCost).ToList()) :
                        new List<Debt>(tab.OrderByDescending(o => o.TransitCost).ToList());
                        break;
                    case "Date":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Debt>(tab.OrderBy(o => o.Date).ToList()) :
                        new List<Debt>(tab.OrderByDescending(o => o.Date).ToList());
                        break;
                }

                gTransits.DataSource = sorted;
            }
            else
            { 
                List<Transit> tab = gTransits.DataSource as List<Transit>;
                List<Transit> sorted = new List<Transit>();
                switch (column.Name)
                {
                    case "TransitID":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Transit>(tab.OrderBy(o => o.Transitid)).ToList() :
                        new List<Transit>(tab.OrderByDescending(o => o.Transitid)).ToList();
                        break;
                    case "DriverName":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Transit>(tab.OrderBy(o => o.Driver).ToList()) :
                        new List<Transit>(tab.OrderByDescending(o => o.Driver).ToList());
                        break;
                    case "PassengersList":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Transit>(tab.OrderBy(o => o.PassengersList).ToList()) :
                        new List<Transit>(tab.OrderByDescending(o => o.PassengersList).ToList());
                        break;
                    case "TransitCost":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Transit>(tab.OrderBy(o => o.Cost).ToList()) :
                        new List<Transit>(tab.OrderByDescending(o => o.Cost).ToList());
                        break;
                    case "Date":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Transit>(tab.OrderBy(o => o.Driven).ToList()) :
                        new List<Transit>(tab.OrderByDescending(o => o.Driven).ToList());
                        break;
                    case "CarName":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Transit>(tab.OrderBy(o => o.CarName).ToList()) :
                        new List<Transit>(tab.OrderByDescending(o => o.CarName).ToList());
                        break;
                    case "RouteName":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Transit>(tab.OrderBy(o => o.RouteName).ToList()) :
                        new List<Transit>(tab.OrderByDescending(o => o.RouteName).ToList());
                        break;
                    case "Distance":
                        sorted =
                        direction == ListSortDirection.Ascending ?
                        new List<Transit>(tab.OrderBy(o => o.Distance).ToList()) :
                        new List<Transit>(tab.OrderByDescending(o => o.Distance).ToList());
                        break;
                }

                gTransits.DataSource = sorted;
            }
        }

        private void gTransits_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Put each of the columns into programmatic sort mode.
            foreach (DataGridViewColumn column in gTransits.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
    }
}
