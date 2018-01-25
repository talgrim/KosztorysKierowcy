using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace KosztorysKierowcy
{
    class DBManager
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public static string mysqlpath = "D:\\xampp\\mysql\\bin";
        public DBManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "estimate";
            uid = "root";
            password = "test";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                switch(ex.Number)
                {
                    case 0:
                        MessageBox.Show("Connection error: Cannot connect to server (0).");
                        break;
                    case 1045:
                        MessageBox.Show("Connection error: Invalid username/password (1045).");
                        break;
                    default:
                        MessageBox.Show("Connection error (" + ex.Number.ToString() + "). "+ex.Message);
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void insertTransit(int driverid, int carid, int routeid, double cost)
        {
            string query = "INSERT INTO transits (driverid, carid, routeid, driven, cost) " +
                "VALUES (" + driverid.ToString() + ", " + carid.ToString() + ", " + routeid.ToString() + ", NOW(), " + cost.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " );";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        
        public void insertPassengers(int transitid, int[] passengersid)
        {
            string query = "INSERT INTO passengersToTransit VALUES ";
            foreach (int x in passengersid)
                if (x != passengersid.Last())
                    query += "(" + transitid.ToString() + ", " + x.ToString() + "), ";
                else
                    query += "(" + transitid.ToString() + ", " + x.ToString() + ")";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void editPerson(int id, string name, string surname, int driver)
        {
            string query = "UPDATE persons SET name='" + name + "', surname='" + surname + "', driver= " + driver + " WHERE personid = " + id;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void addPerson(string name, string surname, int driver)
        {
            string query = "INSERT INTO persons(name, surname, driver) VALUES ('" + name + "', '" + surname + "', " + driver + ")";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void editRoute(int id, string name, int distance)
        {
            string query = "UPDATE routes SET name='" + name + "', distance=" + distance + " WHERE routeid = " + id;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void addRoute(string name, int distance)
        {
            string query = "INSERT INTO routes(name, distance) VALUES ('" + name + "', " + distance + ")";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void editCar(int id, string name, int consumption, int ownerid)
        {
            string query = "UPDATE cars SET name='" + name + "', consumption=" + consumption + ", ownerid = " + ownerid + " WHERE carid = " + id;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void addCar(string name, int consumption, int ownerid)
        {
            string query = "INSERT INTO cars(name, consumption, ownerid) VALUES ('" + name + "', " + consumption + ", " + ownerid + ")";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public List<Person> getDrivers()
        {
            string query = "SELECT personid, name, surname, driver FROM persons WHERE driver = 1";

            //Create a list to store the result
            List<Person> drivers = new List<Person>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                    drivers.Add(new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString()));

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return drivers;
            }
            else
                return drivers;
        }

        public int getLastTransitID()
        {
            string query = "SELECT MAX(transitid) as 'max' FROM transits";
            int result = 0;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                dataReader.Read();
                result = (int)dataReader["max"];

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return result;
            }
            else
                return result;
        }

        public int getPassengersCount(int transitid)
        {
            string query = "SELECT COUNT(passengerid) as 'count' FROM passengerstotransit GROUP BY transitid HAVING transitid = "+transitid;
            int result = 0;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                dataReader.Read();
                result = (int)dataReader["count"];

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return result;
            }
            else
                return result;
        }

        public List<Transit> getTransitsByDriver(int id)
        {
            string query =
                "SELECT transitid, cost, p1.personid, p1.name, p1.surname, p1.driver, cars.carid, cars.name, cars.consumption, cars.ownerid, routes.routeid, routes.name, routes.distance, transits.driven " +
                "FROM persons p1, transits, cars, routes " +
                "WHERE " +
                    "transits.carid = cars.carid AND " +
                    "transits.routeid = routes.routeid AND " +
                    "transits.driverid = p1.personid AND " +
                    "transits.driverid = " + id + " " +
                "ORDER BY transits.transitid";

            //Create a list to store the result
            List<Transit> transits = new List<Transit>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    //Create a data reader and Execute the command
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        //Read the data and store them in the list
                        while (dataReader.Read())
                            transits.Add(new Transit(
                                    (int)dataReader[0],
                                    (double)dataReader[1],
                                    new Person((int)dataReader[2], dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString()),
                                    new Car((int)dataReader[6], dataReader[7].ToString(), (int)dataReader[8], (int)dataReader[9]),
                                    new Route((int)dataReader[10], dataReader[11].ToString(), (int)dataReader[12]),
                                    (DateTime)dataReader[13]
                                    ));
                    }
                }

                foreach (Transit element in transits)
                {
                    List<Person> passengers = new List<Person>();
                    query = "SELECT * FROM passengerstotransit, persons WHERE passengerid = personid AND transitid = " + element.Transitid.ToString() + " ORDER BY name";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                                passengers.Add(new Person((int)dataReader["passengerid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString()));
                            element.Passengers = passengers.ToArray();
                        }
                    }
                }

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return transits;
            }
            else
                return transits;
        }

        public List<Transit> getTransitsByPassengers(string ids)
        {
            string query =
                "SELECT * FROM passengersToTransit, persons WHERE passengersToTransit.passengerid = persons.personid AND passengerid IN (" + ids + ") ORDER BY transitid ASC";

            //Create a list to store the result
            List<Transit> transits = new List<Transit>();
            List<Passengers> passengers = new List<Passengers>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    //Create a data reader and Execute the command
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        //Read the data and store them in the list
                        while (dataReader.Read())
                            passengers.Add(new Passengers((int)dataReader["transitid"], new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString())));
                    }
                }

                foreach (Passengers element in passengers)
                {
                    int transitid = element.TransitId;
                    query =
                        "SELECT transitid, cost, p1.personid, p1.name, p1.surname, p1.driver, cars.carid, cars.name, cars.consumption, cars.ownerid, routes.routeid, routes.name, routes.distance, transits.driven " +
                        "FROM persons p1, transits, cars, routes " +
                        "WHERE " +
                            "transits.carid = cars.carid AND " +
                            "transits.routeid = routes.routeid AND " +
                            "transits.driverid = p1.personid AND " +
                            "transits.transitid = " + transitid + " " +
                        "ORDER BY transits.transitid";

                    int id = transits.FindIndex(x => x.Transitid == transitid);
                    if (id == -1)
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader dataReader = cmd.ExecuteReader())
                            {
                                if (dataReader.Read())
                                    transits.Add(new Transit(
                                        (int)dataReader[0],
                                        (double)dataReader[1],
                                        new Person((int)dataReader[2], dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString()),
                                        new Car((int)dataReader[6], dataReader[7].ToString(), (int)dataReader[8], (int)dataReader[9]),
                                        new Route((int)dataReader[10], dataReader[11].ToString(), (int)dataReader[12]),
                                        element.Passenger,
                                        (DateTime)dataReader[13]
                                        ));
                            }
                        }
                    else
                        transits[id].AddPassenger(element.Passenger);
                }

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return transits;
            }
            else
                return transits;
        }

        public List<Transit> getTransitsByPassengersNotGrouped(string ids)
        {
            string query =
                "SELECT * FROM passengersToTransit, persons WHERE passengersToTransit.passengerid = persons.personid AND passengerid IN (" + ids + ") ORDER BY surname ASC";

            //Create a list to store the result
            List<Transit> transits = new List<Transit>();
            List<Passengers> passengers = new List<Passengers>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    //Create a data reader and Execute the command
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        //Read the data and store them in the list
                        while (dataReader.Read())
                            passengers.Add(new Passengers((int)dataReader["transitid"], new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString())));
                    }
                }

                foreach (Passengers element in passengers)
                {
                    int transitid = element.TransitId;
                    query =
                        "SELECT transitid, cost, p1.personid, p1.name, p1.surname, p1.driver, cars.carid, cars.name, cars.consumption, cars.ownerid, routes.routeid, routes.name, routes.distance, transits.driven " +
                        "FROM persons p1, transits, cars, routes " +
                        "WHERE " +
                            "transits.carid = cars.carid AND " +
                            "transits.routeid = routes.routeid AND " +
                            "transits.driverid = p1.personid AND " +
                            "transits.transitid = " + transitid + " " +
                        "ORDER BY transits.transitid";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            if (dataReader.Read())
                                transits.Add(new Transit(
                                    (int)dataReader[0],
                                    (double)dataReader[1],
                                    new Person((int)dataReader[2], dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString()),
                                    new Car((int)dataReader[6], dataReader[7].ToString(), (int)dataReader[8], (int)dataReader[9]),
                                    new Route((int)dataReader[10], dataReader[11].ToString(), (int)dataReader[12]),
                                    element.Passenger,
                                    (DateTime)dataReader[13]
                                    ));
                        }
                    }
                }

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return transits;
            }
            else
                return transits;
        }

        public List<Route> getRoutes()
        {
            string query = "SELECT routeid, name, distance FROM routes";

            //Create a list to store the result
            List<Route> routes = new List<Route>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                    routes.Add(new Route((int)dataReader["routeid"], dataReader["name"].ToString(), (int)dataReader["distance"]));

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return routes;
            }
            else
                return routes;
        }

        public List<Car> getCarsByID(int id)
        {
            string query = "SELECT cars.carid, cars.name, cars.consumption, ownerid FROM cars  WHERE ownerid = " + id;

            //Create a list to store the result
            List<Car> cars = new List<Car>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                    cars.Add(new Car((int)dataReader["carid"], dataReader["name"].ToString(), (int)dataReader["consumption"], (int)dataReader["ownerid"]));

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return cars;
            }
            else
                return cars;
        }

        public List<Person> getPassengersWithoutDriver(int id)
        {
            string query = "SELECT personid, name, surname, driver FROM persons WHERE personid <> " + id;

            //Create a list to store the result
            List <Person> passengers = new List<Person>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                        passengers.Add(new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString()));

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return passengers;
            }
            else
                return passengers;
        }

        //Count statement
        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;

                string path;
                path = "db\\backup\\estimate" + year + "-" + month + "-" + day +
            "-" + hour + "-" + minute + "-" + second + ".sql";
                StreamWriter file = new StreamWriter(path);
                path = "db\\estimate.sql";
                StreamWriter file2 = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = mysqlpath+"\\mysqldump.exe";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                file2.WriteLine(output);
                process.WaitForExit();
                file2.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup! "+ex.Message);
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "db\\estimate.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = mysqlpath + "\\mysql.exe";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore! "+ex.Message);
            }
        }
    }
}
