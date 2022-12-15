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
            const string path = "C:\\Users\\labor\\Desktop\\chsu\\SchoolFirst\\Contacts.TXT";

            PersonnelNumber =  employee_Manager.GetSavedContacts(path, PersonnelNumber);
            Console.Clear();




            // Programm Ablauf
            do
            {
                Console.WriteLine("H.Neuen Mitarbeiter Hinzufügen\n" + "L.Mitarbeiter Löschen\n" + "S.Mitarbeiter Suchen\n" + "A.Alle Datensätze anzeigen\n" +
                   "U.Urlaub Beantragen\n" + "K.Kontakte aus Datei Hinzufügen\nE.Speichern Einleiten \nO.Neuer Speicherort (In Arbeit)\n" + "B.Beenden");
                switch_Menue = Console.ReadKey().KeyChar;
                Console.Clear();


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

                    case 'U':
                    case 'u':
                        {
                            employee_Manager.HolidayOff();
                        }
                        break;
                    // Vorhandene Daten Einlesen
                    case 'K':
                    case 'k':
                        {

                            {

                                string Path = Console.ReadLine();
                                Console.Clear();
                                PersonnelNumber = employee_Manager.GetSavedContacts(path, PersonnelNumber);


                            }
                        }
                        break;

                    case 'E':
                    case 'e':
                        {
                            employee_Manager.saveData(path);
                        }
                        break;

                    case 'O':
                    case 'o':
                        {
                            Console.WriteLine("Speicerort einfügen");
                        }break;

                    case 'B':
                    case 'b':
                        {

                        }break;

                    default:
                        Console.WriteLine("Ungültige Eingabe");
                        break;

                }

                Console.WriteLine("Beliebige Taste zum Fortfahren Drücken.");
                Console.ReadKey();
                Console.Clear();

            } while (switch_Menue != 'b' && switch_Menue != 'B');

        }




    }
}
