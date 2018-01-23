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
        private List<string>[] drivers;
        private List<string>[] routes;
        private List<string>[] cars;

        public MainWindow()
        {
            InitializeComponent();
            this.cCars.SelectedIndexChanged += new System.EventHandler(this.Calculate);
            this.cRoutes.SelectedIndexChanged += new System.EventHandler(this.Calculate);
            this.tPetroleum.TextChanged += new System.EventHandler(this.Calculate);
            dbm = new DBManager();
            drivers = dbm.getDrivers();
            routes = dbm.getRoutes();
            BindingSource bsDrivers = new BindingSource();
            BindingSource bsRoutes = new BindingSource();
            BindingSource bsCars = new BindingSource();
            bsDrivers.DataSource = drivers[1];
            bsRoutes.DataSource = routes[1];
            cDrivers.DataSource = bsDrivers.DataSource;
            cRoutes.DataSource = bsRoutes.DataSource;
            int id = Int16.Parse(drivers[0][cDrivers.SelectedIndex]);
            cars = dbm.getCarsByID(id);
            bsCars.DataSource = cars[1];
            cCars.DataSource = bsCars.DataSource;
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
            int id = Int16.Parse(drivers[0][cDrivers.SelectedIndex]);
            cars = dbm.getCarsByID(id);
            BindingSource bsCars = new BindingSource();
            bsCars.DataSource = cars[1];
            cCars.DataSource = bsCars.DataSource;
        }

        private void Calculate(object sender, EventArgs e)
        {
            double petroleum = Double.Parse(tPetroleum.Text);
            if (cRoutes.SelectedIndex > -1 && cCars.SelectedIndex > -1)
            { 
                int distance = Int16.Parse(routes[2][cRoutes.SelectedIndex]);
                int consumption = Int16.Parse(cars[2][cCars.SelectedIndex]);

                double result = distance * ((double)consumption / 100) * petroleum;
                tOut.Text = result.ToString("F") + " zł";
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
    }
}
