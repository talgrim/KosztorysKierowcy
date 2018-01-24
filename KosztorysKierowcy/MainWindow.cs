using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KosztorysKierowcy
{
    public partial class MainWindow : Form
    {
        private DBManager dbm;
        private List<Person> drivers;
        private List<Route> routes;
        private List<Car> cars;
        private List<Person> passengers;
        private List<Transit> transits;
        private double result;

        public MainWindow()
        {
            InitializeComponent();
            this.cCars.SelectedIndexChanged += new EventHandler(this.Calculate);
            this.cRoutes.SelectedIndexChanged += new EventHandler(this.Calculate);
            this.tPetroleum.TextChanged += new EventHandler(this.Calculate);
            this.lPassengers.SelectedIndexChanged += new EventHandler(this.Calculate);

            dbm = new DBManager();
            drivers = dbm.getDrivers();
            cDrivers.DisplayMember = "FullName";
            cDrivers.DataSource = drivers;

            routes = dbm.getRoutes();
            cRoutes.DisplayMember = "Information";
            cRoutes.DataSource = routes;

            int id = (cDrivers.SelectedValue as Person).Id;
            cars = dbm.getCarsByID(id);
            cCars.DisplayMember = "Information";
            cCars.DataSource = cars;

            passengers = dbm.getPassengersWithoutDriver(id);
            lPassengers.DisplayMember = "FullName";
            lPassengers.DataSource = passengers;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void bRestore_Click(object sender, EventArgs e)
        {
            dbm.Restore();
        }

        private void bBackup_Click(object sender, EventArgs e)
        {
            dbm.Backup();
        }

        private void cDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (cDrivers.SelectedValue as Person).Id;
            cars = dbm.getCarsByID(id);
            passengers = dbm.getPassengersWithoutDriver(id);
            cCars.DisplayMember = "Information";
            cCars.DataSource = cars;
            lPassengers.DisplayMember = "FullName";
            lPassengers.DataSource = passengers;
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
                int passengers = lPassengers.SelectedItems.Count+1;
                result /= passengers;
                tPassengersCost.Text = result.ToString("F") + " zł";
            }
        }

        private void tPetroleum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void RefreshTables()
        {
            drivers = dbm.getDrivers();
            routes = dbm.getRoutes();
        }

        private void lPassengers_SelectedIndexChanged(object sender, EventArgs e)
        {
            tPassengersCount.Text = lPassengers.SelectedItems.Count.ToString() + " + kierowca";
        }

        private void bAddTransit_Click(object sender, EventArgs e)
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
            text += "\nKoszt: " + result.ToString("F") + " zł.";
            DialogResult dialogResult = MessageBox.Show(text, "Potwierdź", MessageBoxButtons.OKCancel);
            if(dialogResult == DialogResult.OK)
            {
                int driverid = (cDrivers.SelectedValue as Person).Id;
                int carid = (cCars.SelectedValue as Car).Id;
                int routeid = (cRoutes.SelectedValue as Route).Id;
                dbm.insertTransit(driverid, carid, routeid);
                dbm.insertPassengers(dbm.getLastTransitID(), passengerids.ToArray());
                bCheckTransits.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transits = dbm.getTransitsByDriver((cDrivers.SelectedValue as Person).Id);
            gTransits.DataSource = transits;
        }
    }
}
