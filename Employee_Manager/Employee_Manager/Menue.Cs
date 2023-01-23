using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Manager
{
    internal class Menue
    {


        private char switch_Menue;
        public Menue()
        { switch_Menue = ' '; }

        public void startProgramm()
        {
            // Instanzen erstellen
            Employee_Manager employee_Manager = new Employee_Manager();
            Addresses addresses = new Addresses();

            //Personalnummer
            ushort PersonnelNumber = 0;
            string path = "C:\\Users\\Student\\CHSU\\SchoolFirst\\Contacts.TXT";

            PersonnelNumber = employee_Manager.ReadContacts(path, PersonnelNumber);
            Console.Clear();




            // Programm Ablauf
            do
            {

                switch_Menue = ShowMenue();

                switch (switch_Menue)
                {

                    // Alle Mitarbeiter anzeigen
                    case 'A':
                    case 'a':
                        {

                            employee_Manager.ShowAllEmployees();

                        }
                        break;
                    // Mitarbeiter Suchen
                    case 'S':
                    case 's':
                        {
                            employee_Manager.SearchEmployee();


                        }
                        break;
                    // Mitarbeiter Löschen
                    case 'L':
                    case 'l':
                        {
                            employee_Manager.DeleteEmployee();
                            Console.WriteLine();
                        }
                        break;
                    // Mitarbeiter Hinzufügen
                    case 'H':
                    case 'h':
                        {
                            Employee employee = addresses.settingValues(PersonnelNumber);
                            employee_Manager.AddEmployee(employee);
                            PersonnelNumber++;
                        }
                        break;
                    // Urlaub Eintragen
                    case 'U':
                    case 'u':
                        {
                            employee_Manager.HolidayOff();
                        }
                        break;
                    // Dienstplan 
                    case 'D':
                    case 'd':
                        {
                            employee_Manager.TimePlanMenue();

                        }break;
                        
                    //Speichern
                    case 'K':
                    case 'k':
                        {
                            employee_Manager.saveData(path);
                        }
                        break;
                    // Einstellungen
                    case 'E':
                    case 'e':
                        {

                            employee_Manager.ShowTimePlan();
                        }
                        break;

                    // Beenden
                    case 'B':
                    case 'b':
                        {

                        }
                        break;

                    default:
                        Console.WriteLine("Ungültige Eingabe");
                        break;

                }

                Console.WriteLine("Beliebige Taste zum Fortfahren Drücken.");
                Console.ReadKey();
                Console.Clear();

            } while (switch_Menue != 'b' && switch_Menue != 'B');

        }

        // Menue Anzeigen
        private char ShowMenue()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\teManager");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("H.Neuer Mitarbeiter\t" + "A.Alle Datensätze anzeigen\n" +
                               "L.Mitarbeiter Löschen\t" + "E.Einstellungen\n" +
                               "S.Mitarbeiter Suchen\t" + "K.Speichern\n" +
                               "U.Urlaub Eintragen\t" + "B.Programm Beenden\n" +
                               "D.Dienstplan Erstellen\t");
            switch_Menue = Console.ReadKey().KeyChar;
            Console.Clear();
            return switch_Menue;
        }




    }
}
