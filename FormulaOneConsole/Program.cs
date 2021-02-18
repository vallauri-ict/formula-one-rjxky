using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using ClassUtilities;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Data\\";
        public static string DB ="[" + WORKINGPATH + "FormulaOne.mdf]";

        static void Main(string[] args)
        {
            Utilities utilitiesClass = new Utilities(WORKINGPATH, CONNECTION_STRING, THISDATAPATH, DB);
            char choice = ' ';
            bool wrongChoice;

            do
            {
                wrongChoice = false;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n*** FORMULA ONE - BATCH SCRIPTS ***\n");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("4 - Create Circuits");
                Console.WriteLine("5 - Create Races");
                Console.WriteLine("6 - Create Results");
                Console.WriteLine("7 - Create TeamsResults");
                Console.WriteLine("8 - Create Relations");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("a - Create all tables");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("d - Drop all tables");
                Console.WriteLine("p - Drop all relations");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("r - Reset DB");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("------------------");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("X - EXIT\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
                choice = Console.ReadKey(true).KeyChar;
                switch (choice)
                {
                    case '1':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.ExecuteSqlScript("Countries.sql");
                        break;
                    case '2':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.ExecuteSqlScript("Teams.sql");
                        break;
                    case '3':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.ExecuteSqlScript("Drivers.sql");
                        break;
                    case '4':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.ExecuteSqlScript("Circuits.sql");
                        break;
                    case '5':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.ExecuteSqlScript("Races.sql");
                        break;
                    case '6':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.ExecuteSqlScript("Results.sql");
                        break;
                    case '7':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.ExecuteSqlScript("TeamsResults.sql");
                        break;
                    case '8':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.ExecuteSqlScript("Relations.sql");
                        break;
                    case 'a':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.Set();
                        break;
                    case 'd':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.Drop();
                        break;
                    case 'p':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.ExecuteSqlScript("DropRelations.sql");
                        break;
                    case 'r':
                        utilitiesClass.CopySQLFiles();
                        utilitiesClass.ResetDB();
                        break;
                    default:
                        if (choice != 'X' && choice != 'x')
                        {
                            Console.WriteLine("\nUncorrect Choice - Try Again\n");
                            Thread.Sleep(1000);
                            wrongChoice = true;
                        }
                        break;
                }
                if (choice != 'X' && choice != 'x' && !wrongChoice)
                {
                    Thread.Sleep(500);
                    ConsoleKeyInfo c;
                    Console.Write("\n\nPress enter to continue ");
                    do
                    {
                        c = Console.ReadKey();
                        if(c.Key != ConsoleKey.Enter)
                        {
                            Console.Write("\b\b   \b\b");
                        }
                    } while (c.Key != ConsoleKey.Enter);
                }
                Console.Clear();
            } while (choice != 'X' && choice != 'x');
        }   
    }
}
