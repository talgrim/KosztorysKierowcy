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


        public MainWindow()
        {
            InitializeComponent();
            this.cCars.SelectedIndexChanged += new EventHandler(this.Calculate);
            this.cRoutes.SelectedIndexChanged += new EventHandler(this.Calculate);
            this.tPetroleum.TextChanged += new EventHandler(this.Calculate);
            this.lPassengers.SelectedIndexChanged += new EventHandler(this.Calculate);

            dbm = new DBManager();
            drivers = dbm.getDrivers();
            cDrivers.ValueMember = "Id";
            cDrivers.DisplayMember = "FullName";
            cDrivers.DataSource = drivers;

            routes = dbm.getRoutes();
            cRoutes.ValueMember = "Id";
            cRoutes.DisplayMember = "Information";
            cRoutes.DataSource = routes;

            int id = (int)cDrivers.SelectedValue;
            cars = dbm.getCarsByID(id);
            cCars.ValueMember = "Id";
            cCars.DisplayMember = "Information";
            cCars.DataSource = cars;

            passengers = dbm.getPassengersWithoutDriver(id);
            lPassengers.ValueMember = "Id";
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
            int id = (int)cDrivers.SelectedValue;
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

                double result = distance * ((double)consumption / 100) * petroleum;
                tRouteCost.Text = result.ToString("F") + " zł";
                int passengers = lPassengers.SelectedItems.Count+1;
                tPassengersCost.Text = (result / passengers).ToString("F") + " zł";
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
    }
}
