using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Text;

namespace ClassUtilities
{
    public class Utilities
    {
        public string WORKINGPATH;
        private string CONNECTION_STRING;
        public string THISDATAPATH;
        public string DB;

        public List<string> tableNames;
        public List<string> fileNames;
        public Utilities(string wp, string cs, string tdp, string db)
        {
            WORKINGPATH = wp;
            CONNECTION_STRING = cs;
            THISDATAPATH = tdp;
            DB = db;
            tableNames = TablesNames();
            fileNames = new List<string>();
        }

        #region GET TABLES
        public List<Models.Country> getCountry()
        {
            List<Models.Country> retVal = new List<Models.Country>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = "SELECT * FROM Country;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string isoCode = reader.GetString(0);
                            string CountryName = reader.GetString(1);
                            retVal.Add(new Models.Country(isoCode, CountryName));
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Country getCountryByCode(string code)
        {
            Models.Country retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Country WHERE CountryCode LIKE '{code}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string isoCode = reader.GetString(0);
                            string CountryName = reader.GetString(1);
                            retVal = new Models.Country(isoCode, CountryName);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Models.Circuit> getCircuit()
        {
            List<Models.Circuit> retVal = new List<Models.Circuit>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = "SELECT * FROM Circuit;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string circuitRef = reader.GetString(1);
                            string circuitName = reader.GetString(2);
                            string circuitLocation = reader.GetString(3);
                            string circuitCountry = reader.GetString(4);

                            retVal.Add(new Models.Circuit(circuitRef, circuitName,
                                                   circuitLocation, circuitCountry));
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Circuit getCircuitByCode(int code)
        {
            Models.Circuit retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Circuit WHERE circuitCode = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string circuitRef = reader.GetString(1);
                            string circuitName = reader.GetString(2);
                            string circuitLocation = reader.GetString(3);
                            string circuitCountry = reader.GetString(4);

                            retVal = new Models.Circuit(circuitRef, circuitName,
                                               circuitLocation, circuitCountry);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Models.Driver> getDriver()
        {
            List<Models.Driver> retVal = new List<Models.Driver>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = "SELECT * FROM Driver;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int driverCode = reader.GetInt32(3);
                            string driverFirstname = reader.GetString(4);
                            string driverLastname = reader.GetString(5);
                            DateTime driverDateOfBirth = reader.GetDateTime(6);
                            string driverPlaceOfBirth = reader.GetString(7);

                            retVal.Add(new Models.Driver(driverCode, driverFirstname,
                                                  driverLastname, driverDateOfBirth,
                                                  driverPlaceOfBirth));
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Driver getDriverByCode(int code)
        {
            Models.Driver retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Driver WHERE driverCode = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int driverCode = reader.GetInt32(3);
                            string driverFirstname = reader.GetString(4);
                            string driverLastname = reader.GetString(5);
                            DateTime driverDateOfBirth = reader.GetDateTime(6);
                            string driverPlaceOfBirth = reader.GetString(7);

                            retVal = new Models.Driver(driverCode, driverFirstname,
                                              driverLastname, driverDateOfBirth,
                                              driverPlaceOfBirth);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Models.Race> getRace()
        {
            List<Models.Race> retVal = new List<Models.Race>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = "SELECT * FROM Race;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int raceYear = reader.GetInt32(2);
                            int raceRound = reader.GetInt32(3);
                            string raceName = reader.GetString(4);
                            DateTime raceDate = reader.GetDateTime(5);
                            string raceTime = reader.GetString(6);

                            retVal.Add(new Models.Race(raceYear, raceRound,
                                                raceName, raceDate, raceTime));
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Race getRaceByCode(int code)
        {
            Models.Race retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Race WHERE raceCode = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int raceYear = reader.GetInt32(2);
                            int raceRound = reader.GetInt32(3);
                            string raceName = reader.GetString(4);
                            DateTime raceDate = reader.GetDateTime(5);
                            string raceTime = reader.GetString(6);

                            retVal = new Models.Race(raceYear, raceRound,
                                            raceName, raceDate, raceTime);
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Models.Team> getTeam()
        {
            List<Models.Team> retVal = new List<Models.Team>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = "SELECT * FROM Team;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string teamFullName = reader.GetString(1);
                            string teamBase = reader.GetString(2);
                            string teamChief = reader.GetString(3);
                            string teamPowerUnit = reader.GetString(4);
                            int teamWorldChampionships = reader.GetInt32(5);
                            int teamPolePositions = reader.GetInt32(6);

                            retVal.Add(new Models.Team(teamFullName, teamBase,
                                            teamChief, teamPowerUnit,
                                            teamWorldChampionships, teamPolePositions));
                        }
                    }
                }
            }
            return retVal;
        }

        public Models.Team getTeamByCode(int code)
        {
            Models.Team retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Team WHERE teamCode = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string teamFullName = reader.GetString(1);
                            string teamBase = reader.GetString(2);
                            string teamChief = reader.GetString(3);
                            string teamPowerUnit = reader.GetString(4);
                            int teamWorldChampionships = reader.GetInt32(5);
                            int teamPolePositions = reader.GetInt32(6);

                            retVal = new Models.Team(teamFullName, teamBase,
                                              teamChief, teamPowerUnit,
                                              teamWorldChampionships, teamPolePositions);
                        }
                    }
                }
            }
            return retVal;
        }
        #endregion

        #region Copy & Execute SQL
        public void CopySQLFiles()
        {
            fileNames.Clear();
            string[] fileEntries = Directory.GetFiles(THISDATAPATH);
            string relations = string.Empty;

            foreach (string filePath in fileEntries)
            {
                string fileName = filePath.Split('\\')[filePath.Length - 1];
                string ext = fileName.Split('.')[fileName.Length - 1];
                if (ext == "sql")
                {
                    string newDbFilePath = WORKINGPATH + fileName;
                    string oldDbFilePath = filePath;
                    File.Copy(oldDbFilePath, newDbFilePath, true);
                    if (!fileName.Contains("Relations"))
                    {
                        fileNames.Add(fileName);
                    }
                }
            }
        }

        public void ExecuteSqlScript(string sqlScriptName, bool set = false, bool reset = false)
        {
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("query", con);

            con.Open(); int i = 0; int nErr = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine($"{sqlScriptName}: Errore in esecuzione della query numero: {i}\n" +
                                               $"\tErrore SQL: {err.Number} - {err.Message}");
                    nErr++;
                }
            }
            con.Close();

            if (nErr == 0 && !set)
            {
                Console.WriteLine($"Script {sqlScriptName} ended");
            }
            else if (nErr != 0 && !set)
            {
                Console.WriteLine($"Script {sqlScriptName} ended with {nErr} errors");

            }
            else if (nErr != 0 && set)
            {
                Console.WriteLine($"Error during set in {sqlScriptName}");
                if (reset) throw new Exception("Error during Relations");
            }
        }
        #endregion

        #region SQL Functions
        public void ExecuteQuery(string query, SqlConnection con)
        {
            var cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public void ResetDB()
        {
            Backup();
            try
            {
                Drop();
                Set(true);
                Console.WriteLine("Reset ended without errors");
            }
            catch (Exception)
            {
                Restore();
            }
        }

        public void Drop()
        {
            var con = new SqlConnection(CONNECTION_STRING);
            tableNames = TablesNames();

            con.Open();

            try
            {
                DropTables(con);
            }
            catch (Exception)
            {
                // Se va in errore per le relazioni, le cancella
                ExecuteSqlScript("DropRelations.sql");
                DropTables(con);
            }
            con.Close();
            Console.WriteLine("\nDrop tables ended");
        }

        private void DropTables(SqlConnection con)
        {
            for (int i = 0; i < tableNames.Count; i++)
            {
                ExecuteQuery($"DROP TABLE IF EXISTS {tableNames[i]}", con);
            }
        }

        public void Set(bool reset = false)
        {
            for (int i = 0; i < fileNames.Count; i++)
            {
                ExecuteSqlScript(fileNames[i], true, reset);
            }
            ExecuteSqlScript("Relations.sql", true, reset);
            Console.WriteLine("\nCreate tables ended");
        }

        public void Backup()
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = $@"ALTER DATABASE {DB} SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection())
                {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand())
                    {
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = $@"BACKUP DATABASE {DB} TO DISK='{WORKINGPATH}FormulaOneBackup.bak'";
                        backupcomm.ExecuteNonQuery();
                    }
                    backupConn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Restore()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    string sqlStmt2 = string.Format($@"ALTER DATABASE {DB} SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = $@"USE MASTER RESTORE DATABASE {DB} FROM DISK='{WORKINGPATH}FormulaOneBackup.bak' WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format($@"ALTER DATABASE {DB} SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    Console.WriteLine("PROBLEMS WITH RESET FUNCTION. The most recent beckup was restored");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region Other
        public DataTable GetDataTable(string table)
        {
            DataTable retVal = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            string sql = $"SELECT * FROM {table}";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(retVal);
            con.Close();
            da.Dispose();
            return retVal;
        }

        public List<string> TablesNames()
        {
            List<string> tables = new List<string>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                //Console.WriteLine("\nQuery data example:");
                //Console.WriteLine("=========================================\n");

                string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0}", reader.GetString(0));
                            tables.Add($"{reader.GetString(0)}");
                        }
                    }
                }
            }
            return tables;
        }

        public void Dots()
        {
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write('.');
                    Thread.Sleep(1000);
                    if (i == 2)
                    {
                        Console.Write("\b\b\b   \b\b\b");
                        i = -1;
                        Thread.Sleep(1000);
                    }
                }
            }
        }
        #endregion
    }
}
