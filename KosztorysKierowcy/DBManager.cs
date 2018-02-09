using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Data;

namespace KosztorysKierowcy
{
    class DBManager
    {
        private MySqlConnection connection;
        public static string server;
        public static string database;
        public static string uid;
        public static string password;
        public static string mysqlpath;
        public bool IsCorrect { get; private set; }

        public DBManager()
        {
            GetParams();
            Initialize();
            IsCorrect = CheckConnection();
        }

        private void GetParams()
        {
            StreamReader file = new StreamReader("config.ini");
            string mysqlpathtemp = file.ReadLine();
            mysqlpathtemp = mysqlpathtemp.Split('=')[1];
            string uidtemp = file.ReadLine();
            uidtemp = uidtemp.Split('=')[1];
            string passwordtemp = file.ReadLine();
            passwordtemp = passwordtemp.Split('=')[1];
            string databasetemp = file.ReadLine();
            databasetemp = databasetemp.Split('=')[1];
            string servertemp = file.ReadLine();
            servertemp = servertemp.Split('=')[1];
            mysqlpath = mysqlpathtemp;
            uid = uidtemp;
            password = passwordtemp;
            database = databasetemp;
            server = servertemp;
            file.Close();
        }

        private void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool CheckConnection()
        {
            bool result;
            if (this.OpenConnection())
            {
                result = true;
                this.CloseConnection();
            }
            else
                result = false;
            return result;
        }
        
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        
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

        public void insertDebts(int creditorid, int[] debtorsids, double amount)
        {
            if (this.OpenConnection() == true)
            {
                foreach (int debtorid in debtorsids)
                {
                    string query = "INSERT INTO debts (creditorid, debtorid, date, amount) " +
                        "VALUES (@creditorid, @debtorid, NOW(), @amount)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@creditorid", creditorid);
                        cmd.Parameters.AddWithValue("@debtorid", debtorid);
                        cmd.Parameters.AddWithValue("@amount", amount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                        cmd.ExecuteNonQuery();
                    }
                }
                this.CloseConnection();
            }
        }

        public void addDebtor(string name, string surname)
        {
            if (this.OpenConnection() == true)
            {
                string query = "INSERT INTO debtperson (name, surname) " +
                    "VALUES (@name, @surname)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
            }
        }

        public List<Debt> getDebtsByCreditor(int creditorid)
        {
            List<Debt> debts = new List<Debt>();
            string query = "SELECT debtid, creditorid, d1.name, d1.surname, debtorid, d2.name, d2.surname, amount, date FROM debts LEFT JOIN debtperson d1 ON d1.personid = creditorid LEFT JOIN debtperson d2 ON d2.personid = debtorid WHERE creditorid = " + creditorid;

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            debts.Add(new Debt(
                                (int)dataReader[0],
                                new Person((int)dataReader[1], dataReader[2].ToString(), dataReader[3].ToString(), ""),
                                new Person((int)dataReader[4], dataReader[5].ToString(), dataReader[6].ToString(), ""),
                                (double)dataReader[7],
                                (DateTime)dataReader[8]
                                    ));

                this.CloseConnection();
                return debts;
            }
            return debts;
        }

        public List<Debt> getDebtsByCreditor(int creditorid, string from, string to)
        {
            List<Debt> debts = new List<Debt>();
            string query = "SELECT debtid, creditorid, d1.name, d1.surname, debtorid, d2.name, d2.surname, amount, date " +
                "FROM debts " +
                "LEFT JOIN debtperson d1 ON d1.personid = creditorid " +
                "LEFT JOIN debtperson d2 ON d2.personid = debtorid " +
                "WHERE creditorid = " + creditorid + " AND date BETWEEN '" + from + "' AND '" + to + "'";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        debts.Add(new Debt(
                            (int)dataReader[0],
                            new Person((int)dataReader[1], dataReader[2].ToString(), dataReader[3].ToString(), ""),
                            new Person((int)dataReader[4], dataReader[5].ToString(), dataReader[6].ToString(), ""),
                            (double)dataReader[7],
                            (DateTime)dataReader[8]
                                ));

                this.CloseConnection();
                return debts;
            }
            return debts;
        }

        public List<Debt> getDebtsByDebtor(int debtorid)
        {
            List<Debt> debts = new List<Debt>();
            string query = "SELECT debtid, creditorid, d1.name, d1.surname, debtorid, d2.name, d2.surname, amount, date FROM debts LEFT JOIN debtperson d1 ON d1.personid = creditorid LEFT JOIN debtperson d2 ON d2.personid = debtorid WHERE debtorid = " + debtorid;

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        debts.Add(new Debt(
                            (int)dataReader[0],
                            new Person((int)dataReader[1], dataReader[2].ToString(), dataReader[3].ToString(), ""),
                            new Person((int)dataReader[4], dataReader[5].ToString(), dataReader[6].ToString(), ""),
                            (double)dataReader[7],
                            (DateTime)dataReader[8]
                                ));

                this.CloseConnection();
                return debts;
            }
            return debts;
        }

        public List<Debt> getDebtsByDebtor(int debtorid, string from, string to)
        {
            List<Debt> debts = new List<Debt>();
            string query = "SELECT debtid, creditorid, d1.name, d1.surname, debtorid, d2.name, d2.surname, amount, date " +
                "FROM debts " +
                "LEFT JOIN debtperson d1 ON d1.personid = creditorid " +
                "LEFT JOIN debtperson d2 ON d2.personid = debtorid " +
                "WHERE debtorid = " + debtorid + " AND date BETWEEN '" + from + "' AND '" + to + "'";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        debts.Add(new Debt(
                            (int)dataReader[0],
                            new Person((int)dataReader[1], dataReader[2].ToString(), dataReader[3].ToString(), ""),
                            new Person((int)dataReader[4], dataReader[5].ToString(), dataReader[6].ToString(), ""),
                            (double)dataReader[7],
                            (DateTime)dataReader[8]
                                ));

                this.CloseConnection();
                return debts;
            }
            return debts;
        }

        public List<Person> getDebtpersons()
        {
            List<Person> persons = new List<Person>();
            string query = "SELECT * FROM debtperson ";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        persons.Add(new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), ""));

                this.CloseConnection();
                return persons;
            }
            return persons;
        }

        public void insertTransit(int driverid, int carid, int routeid, double cost)
        {
            string query = "INSERT INTO transits (driverid, carid, routeid, driven, cost) " +
                "VALUES (@driverid, @carid, @routeid, NOW(), @cost );";


            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@driverid", driverid);
                    cmd.Parameters.AddWithValue("@carid", carid);
                    cmd.Parameters.AddWithValue("@routeid", routeid);
                    cmd.Parameters.AddWithValue("@cost", cost.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
            }
        }
        
        public void insertPassengers(int transitid, int[] passengersid)
        {
            string query = "INSERT INTO passengersToTransit VALUES ";
            for(int i = 0; i < passengersid.Count(); i++)
            {
                if (i < passengersid.Count()-1)
                    query += "(@transitid, @passenger_" + i.ToString() + "), ";
                else
                    query += "(@transitid, @passenger_" + i.ToString() + ")";
            }

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@transitid", transitid);
                    for (int i = 0; i < passengersid.Count(); i++)
                    {
                        string field = "@passenger_" + i.ToString();
                        cmd.Parameters.AddWithValue(field,passengersid[i]);
                    }
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
            }
        }

        public void deletePerson(int id)
        {
            string query = "DELETE FROM persons WHERE personid = " + id;

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void editPerson(int id, string name, string surname, int driver)
        {
            string query = "UPDATE persons SET name=@name, surname=@surname, driver= @driver WHERE personid = @id";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@driver", driver);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
            }
        }

        public void addPerson(string name, string surname, int driver)
        {
            string query = "INSERT INTO persons(name, surname, driver) VALUES (@name, @surname, @driver)";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@driver", driver);
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
            }
        }

        public void deleteRoute(int id)
        {
            string query = "DELETE FROM routes WHERE routeid = " + id;

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void editRoute(int id, string name, int distance)
        {
            //przed
            /*
            string query = "UPDATE routes SET name='" + name + "', distance=" + distance + " WHERE routeid = " + id;

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
            */

            //po
            string query = "UPDATE routes SET name= @name, distance= @distance WHERE routeid = @id";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@distance", distance);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
            }
        }

        public void addRoute(string name, int distance)
        {
            string query = "INSERT INTO routes(name, distance) VALUES (@name, @distance)";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@distance", distance);
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
            }
        }

        public void deleteCar(int id)
        {
            string query = "DELETE FROM cars WHERE carid = " + id;

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public void editCar(int id, string name, int consumption, int ownerid)
        {
            string query = "UPDATE cars SET name=@name, consumption=@consumption, ownerid = @ownerid WHERE carid = @carid";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@consumption", consumption);
                    cmd.Parameters.AddWithValue("@ownerid", ownerid);
                    cmd.Parameters.AddWithValue("@carid", id);
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
            }
        }

        public void addCar(string name, int consumption, int ownerid)
        {
            string query = "INSERT INTO cars(name, consumption, ownerid) VALUES (@name, @consumption, @ownerid)";

            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@consumption", consumption);
                    cmd.Parameters.AddWithValue("@ownerid", ownerid);
                    cmd.ExecuteNonQuery();
                }
                this.CloseConnection();
            }
        }

        public List<Person> getDrivers()
        {
            string query = "SELECT personid, name, surname, driver FROM persons WHERE driver = 1";
            List<Person> drivers = new List<Person>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        drivers.Add(new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString()));
                
                this.CloseConnection();
                return drivers;
            }
            else
                return drivers;
        }

        public int getLastTransitID()
        {
            string query = "SELECT MAX(transitid) as 'max' FROM transits";
            int result = -1;
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    result = (int)cmd.ExecuteScalar();
                this.CloseConnection();
                return result;
            }
            else
                return result;
        }

        public bool checkPerson(string name, string surname)
        {
            string query = "SELECT * FROM persons WHERE name = @name AND surname = @surname";
            bool result = true;
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        result = dataReader.HasRows;
                }
                this.CloseConnection();
                return result;
            }
            else
                return result;
        }
        
        public List<Transit> getTransitsByDriver(int id)
        {
            string query =
                "SELECT transitid, cost, p1.personid, p1.name, p1.surname, p1.driver, cars.carid, cars.name, cars.consumption, cars.ownerid, routes.routeid, routes.name, routes.distance, transits.driven " +
                "FROM transits " +
                "LEFT JOIN persons p1 " +
                "ON driverid = p1.personid " +
                "LEFT JOIN cars " +
                "ON transits.carid = cars.carid " +
                "LEFT JOIN routes " +
                "ON transits.routeid = routes.routeid " +
                "WHERE transits.driverid = " + id + " " +
                "ORDER BY transits.transitid";

            List<Transit> transits = new List<Transit>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        transits.Add(new Transit(
                                (int)dataReader[0],
                                (double)dataReader[1],
                                dataReader[2].ToString() == "" ?
                                    new Person(0, "Usunięto", "", "null") :
                                    new Person((int)dataReader[2], dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString()),
                                dataReader[6].ToString() == "" ?
                                    new Car(0, "Usunięto", 0, 0) :
                                    new Car((int)dataReader[6], dataReader[7].ToString(), (int)dataReader[8], (int)dataReader[9]),
                                dataReader[10].ToString() == "" ?
                                    new Route(0, "Usunięto", 0) :
                                    new Route((int)dataReader[10], dataReader[11].ToString(), (int)dataReader[12]),
                                (DateTime)dataReader[13]
                                ));

                foreach (Transit element in transits)
                    element.Passengers = getPassengersByTransitid(element.Transitid).ToArray();
                this.CloseConnection();
                return transits;
            }
            else
                return transits;
        }

        public List<Transit> getTransitsByDriver(int id, string from, string to)
        {
            string query =
                "SELECT transitid, cost, p1.personid, p1.name, p1.surname, p1.driver, cars.carid, cars.name, cars.consumption, cars.ownerid, routes.routeid, routes.name, routes.distance, transits.driven " +
                "FROM transits " +
                "LEFT JOIN persons p1 " +
                "ON driverid = p1.personid " +
                "LEFT JOIN cars " +
                "ON transits.carid = cars.carid " +
                "LEFT JOIN routes " +
                "ON transits.routeid = routes.routeid " +
                "WHERE transits.driverid = " + id + " " +
                "AND driven BETWEEN '" + from + "' AND '" + to + "' " +
                "ORDER BY transits.transitid";

            List<Transit> transits = new List<Transit>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        transits.Add(new Transit(
                                (int)dataReader[0],
                                (double)dataReader[1],
                                dataReader[2].ToString() == "" ?
                                    new Person(0, "Usunięto", "", "null") :
                                    new Person((int)dataReader[2], dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString()),
                                dataReader[6].ToString() == "" ?
                                    new Car(0, "Usunięto", 0, 0) :
                                    new Car((int)dataReader[6], dataReader[7].ToString(), (int)dataReader[8], (int)dataReader[9]),
                                dataReader[10].ToString() == "" ?
                                    new Route(0, "Usunięto", 0) :
                                    new Route((int)dataReader[10], dataReader[11].ToString(), (int)dataReader[12]),
                                (DateTime)dataReader[13]
                                ));

                foreach (Transit element in transits)
                    element.Passengers = getPassengersByTransitid(element.Transitid).ToArray();
                this.CloseConnection();
                return transits;
            }
            else
                return transits;
        }

        public List<Transit> getTransitsByPassengers(string ids)
        {
            string query =
                "SELECT * FROM passengersToTransit LEFT JOIN persons ON passengerid = personid WHERE passengerid IN(" + ids + ") GROUP BY transitid ORDER BY transitid ASC, surname ASC";
            List<Transit> transits = new List<Transit>();
            List<Passengers> passengers = new List<Passengers>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        passengers.Add(new Passengers((int)dataReader["transitid"], new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString())));
                foreach (Passengers element in passengers)
                {
                    int transitid = element.TransitId;
                    query =
                        "SELECT transitid, cost, p1.personid, p1.name, p1.surname, p1.driver, cars.carid, cars.name, cars.consumption, cars.ownerid, routes.routeid, routes.name, routes.distance, transits.driven " +
                        "FROM transits " +
                        "LEFT JOIN persons p1 " +
                        "ON driverid = p1.personid " +
                        "LEFT JOIN cars " +
                        "ON transits.carid = cars.carid " +
                        "LEFT JOIN routes " +
                        "ON transits.routeid = routes.routeid " +
                        "WHERE transits.transitid = " + transitid + " " +
                        "ORDER BY transits.transitid";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        if (dataReader.Read())
                            transits.Add(new Transit(
                        (int)dataReader[0],
                        (double)dataReader[1],
                        dataReader[2].ToString() == "" ?
                            new Person(0, "Usunięto", "", "null") :
                            new Person((int)dataReader[2], dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString()),
                        dataReader[6].ToString() == "" ?
                            new Car(0, "Usunięto", 0, 0) :
                            new Car((int)dataReader[6], dataReader[7].ToString(), (int)dataReader[8], dataReader[9].ToString() == "" ? 0 : (int)dataReader[9]),
                        dataReader[10].ToString() == "" ?
                            new Route(0, "Usunięto", 0) :
                            new Route((int)dataReader[10], dataReader[11].ToString(), (int)dataReader[12]),
                        (DateTime)dataReader[13]
                        ));
                    transits.Last().Passengers = getPassengersByTransitid(transitid).ToArray();
                }
                this.CloseConnection();
                return transits;
            }
            else
                return transits;
        }

        public List<Transit> getTransitsByPassengers(string ids, string from, string to)
        {
            string query =
                "SELECT * FROM passengersToTransit LEFT JOIN persons ON passengerid = personid WHERE passengerid IN(" + ids + ") GROUP BY transitid ORDER BY transitid ASC, surname ASC";
            List<Transit> transits = new List<Transit>();
            List<Passengers> passengers = new List<Passengers>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        passengers.Add(new Passengers((int)dataReader["transitid"], new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString())));
                foreach (Passengers element in passengers)
                {
                    int transitid = element.TransitId;
                    query =
                        "SELECT transitid, cost, p1.personid, p1.name, p1.surname, p1.driver, cars.carid, cars.name, cars.consumption, cars.ownerid, routes.routeid, routes.name, routes.distance, transits.driven " +
                        "FROM transits " +
                        "LEFT JOIN persons p1 " +
                        "ON driverid = p1.personid " +
                        "LEFT JOIN cars " +
                        "ON transits.carid = cars.carid " +
                        "LEFT JOIN routes " +
                        "ON transits.routeid = routes.routeid " +
                        "WHERE transits.transitid = " + transitid + " " +
                        "AND driven BETWEEN '" + from + "' AND '" + to + "' " +
                        "ORDER BY transits.transitid";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        if (dataReader.Read())
                            transits.Add(new Transit(
                        (int)dataReader[0],
                        (double)dataReader[1],
                        dataReader[2].ToString() == "" ?
                            new Person(0, "Usunięto", "", "null") :
                            new Person((int)dataReader[2], dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString()),
                        dataReader[6].ToString() == "" ?
                            new Car(0, "Usunięto", 0, 0) :
                            new Car((int)dataReader[6], dataReader[7].ToString(), (int)dataReader[8], dataReader[9].ToString() == "" ? 0 : (int)dataReader[9]),
                        dataReader[10].ToString() == "" ?
                            new Route(0, "Usunięto", 0) :
                            new Route((int)dataReader[10], dataReader[11].ToString(), (int)dataReader[12]),
                        (DateTime)dataReader[13]
                        ));
                    transits.Last().Passengers = getPassengersByTransitid(transitid).ToArray();
                }
                this.CloseConnection();
                return transits;
            }
            else
                return transits;
        }

        public List<Transit> getTransitsByPassengersNotGrouped(string ids)
        {
            string query =
                "SELECT * FROM passengersToTransit, persons WHERE passengersToTransit.passengerid = persons.personid AND passengerid IN (" + ids + ") ORDER BY surname ASC";
            List<Transit> transits = new List<Transit>();
            List<Passengers> passengers = new List<Passengers>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        passengers.Add(new Passengers((int)dataReader["transitid"], new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString())));

                foreach (Passengers element in passengers)
                {
                    int transitid = element.TransitId;
                    query =
                        "SELECT transitid, cost, p1.personid, p1.name, p1.surname, p1.driver, cars.carid, cars.name, cars.consumption, cars.ownerid, routes.routeid, routes.name, routes.distance, transits.driven " +
                        "FROM transits " +
                        "LEFT JOIN persons p1 " +
                        "ON driverid = p1.personid " +
                        "LEFT JOIN cars " +
                        "ON transits.carid = cars.carid " +
                        "LEFT JOIN routes " +
                        "ON transits.routeid = routes.routeid " +
                        "WHERE transits.transitid = " + transitid + " " +
                        "ORDER BY transits.transitid";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        if (dataReader.Read())
                            transits.Add(new Transit(
                                (int)dataReader[0],
                                (double)dataReader[1],
                                dataReader[2].ToString() == "" ?
                                    new Person(0, "Usunięto", "", "null") :
                                    new Person((int)dataReader[2], dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString()),
                                dataReader[6].ToString() == "" ?
                                    new Car(0, "Usunięto", 0, 0) :
                                    new Car((int)dataReader[6], dataReader[7].ToString(), (int)dataReader[8], dataReader[9].ToString() == "" ? 0 : (int)dataReader[9]),
                                dataReader[10].ToString() == "" ?
                                    new Route(0, "Usunięto", 0) :
                                    new Route((int)dataReader[10], dataReader[11].ToString(), (int)dataReader[12]),
                                element.Passenger,
                                (DateTime)dataReader[13]
                                ));
                }
                this.CloseConnection();
                return transits;
            }
            else
                return transits;
        }

        public List<Transit> getTransitsByPassengersNotGrouped(string ids, string from, string to)
        {
            string query =
                "SELECT * FROM passengersToTransit, persons WHERE passengersToTransit.passengerid = persons.personid AND passengerid IN (" + ids + ") ORDER BY surname ASC";
            List<Transit> transits = new List<Transit>();
            List<Passengers> passengers = new List<Passengers>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        passengers.Add(new Passengers((int)dataReader["transitid"], new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString())));

                foreach (Passengers element in passengers)
                {
                    int transitid = element.TransitId;
                    query =
                        "SELECT transitid, cost, p1.personid, p1.name, p1.surname, p1.driver, cars.carid, cars.name, cars.consumption, cars.ownerid, routes.routeid, routes.name, routes.distance, transits.driven " +
                        "FROM transits " +
                        "LEFT JOIN persons p1 " +
                        "ON driverid = p1.personid " +
                        "LEFT JOIN cars " +
                        "ON transits.carid = cars.carid " +
                        "LEFT JOIN routes " +
                        "ON transits.routeid = routes.routeid " +
                        "WHERE transits.transitid = " + transitid + " " +
                        "AND driven BETWEEN '" + from + "' AND '" + to + "' " +
                        "ORDER BY transits.transitid";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        if (dataReader.Read())
                            transits.Add(new Transit(
                                (int)dataReader[0],
                                (double)dataReader[1],
                                dataReader[2].ToString() == "" ?
                                    new Person(0, "Usunięto", "", "null") :
                                    new Person((int)dataReader[2], dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString()),
                                dataReader[6].ToString() == "" ?
                                    new Car(0, "Usunięto", 0, 0) :
                                    new Car((int)dataReader[6], dataReader[7].ToString(), (int)dataReader[8], dataReader[9].ToString() == "" ? 0 : (int)dataReader[9]),
                                dataReader[10].ToString() == "" ?
                                    new Route(0, "Usunięto", 0) :
                                    new Route((int)dataReader[10], dataReader[11].ToString(), (int)dataReader[12]),
                                element.Passenger,
                                (DateTime)dataReader[13]
                                ));
                }
                this.CloseConnection();
                return transits;
            }
            else
                return transits;
        }

        private List<Person> getPassengersByTransitid(int id)
        {
            string query = "SELECT personid,name,surname,driver FROM passengersToTransit LEFT JOIN persons ON passengerid=personid WHERE transitid = " + id + " ORDER BY surname ASC";
            List<Person> passengers = new List<Person>();
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        passengers.Add(
                            dataReader["personid"].ToString() == "" ?
                                new Person(0, "Usunięto", "", "") :
                                new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString())
                            );
            return passengers;
        }

        public List<Route> getRoutes()
        {
            string query = "SELECT routeid, name, distance FROM routes";
            List<Route> routes = new List<Route>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            routes.Add(new Route((int)dataReader["routeid"], dataReader["name"].ToString(), (int)dataReader["distance"]));
                this.CloseConnection();
                return routes;
            }
            else
                return routes;
        }

        public List<Car> getCarsByID(int id)
        {
            string query = "SELECT cars.carid, cars.name, cars.consumption, ownerid FROM cars  WHERE ownerid = " + id;
            List<Car> cars = new List<Car>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        while (dataReader.Read())
                            cars.Add(new Car((int)dataReader["carid"], dataReader["name"].ToString(), (int)dataReader["consumption"], (int)dataReader["ownerid"]));
                this.CloseConnection();
                return cars;
            }
            else
                return cars;
        }

        public List<Car> getCars()
        {
            string query = "SELECT cars.carid, cars.name, cars.consumption, ownerid FROM cars";
            List<Car> cars = new List<Car>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        cars.Add(new Car((int)dataReader["carid"], dataReader["name"].ToString(), (int)dataReader["consumption"], (dataReader[3].ToString() == "" ? 0 : (int)dataReader["ownerid"])));
                this.CloseConnection();
                return cars;
            }
            else
                return cars;
        }

        public List<Person> getPassengersWithoutDriver(int id)
        {
            string query = "SELECT personid, name, surname, driver FROM persons WHERE personid <> " + id;
            List<Person> passengers = new List<Person>();
            if (this.OpenConnection() == true)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                    while (dataReader.Read())
                        passengers.Add(new Person((int)dataReader["personid"], dataReader["name"].ToString(), dataReader["surname"].ToString(), dataReader["driver"].ToString()));
                this.CloseConnection();
                return passengers;
            }
            else
                return passengers;
        }

        public void Export()
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
                MessageBox.Show("Error, unable to backup! "+ex.Message);
            }
        }

        public void Import()
        {
            try
            {
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
                MessageBox.Show("Error, unable to restore! "+ex.Message);
            }
        }
    }
}
