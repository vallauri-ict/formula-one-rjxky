using System;
using System.Data.SqlClient;
using System.IO;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";

        static void Main(string[] args)
        {
            char scelta = ' ';
            do
            {
                Console.WriteLine("\n*** FORMULA ONE - BATCH SCRIPTS ***\n");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("------------------");
                Console.WriteLine("R - RESET DB");
                Console.WriteLine("------------------");
                Console.WriteLine("X - EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch (scelta)
                {
                    case '1':
                        ExecuteSqlScript("Countries.sql");
                        break;
                    case '2':
                        ExecuteSqlScript("Teams.sql");
                        break;
                    case '3':
                        ExecuteSqlScript("Drivers.sql");
                        break;
                    case 'R':
                        ResetDb();
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }

        private static void ResetDb()
        {
            var con = new SqlConnection(CONNECTION_STRING);
            try
            {
                con.Open();

                ExecuteQuery("DROP TABLE IF EXISTS Country", con);
                ExecuteQuery("DROP TABLE IF EXISTS Driver", con);
                ExecuteQuery("DROP TABLE IF EXISTS Team", con);
                con.Close();

                ExecuteSqlScript("Countries.sql");
                ExecuteSqlScript("Teams.sql");
                ExecuteSqlScript("Drivers.sql");
                Console.WriteLine("Reset completato correttamente.");
            }
            catch (Exception)
            {
                Console.WriteLine("Errore durante il reset.");
            }
        }

        private static void ExecuteQuery(string query, SqlConnection con)
        {
            var cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        static void ExecuteSqlScript(string sqlScriptName)
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
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                    nErr++;
                }
            }
            con.Close();
            string finalMessage = nErr == 0 ? "Script " + sqlScriptName + " ended successfully without errors" : "Script ended with " + nErr + " errors";0
            Console.WriteLine(finalMessage);
        }
    }
}
