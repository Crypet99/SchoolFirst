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
            Addresses addresses= new Addresses();
            //Personalnummer
            ushort PersonnelNumber = 0;
           
            // Vorhandene Daten Einlesen
            Console.WriteLine("Bitte einen Pfad + /Kontaktdatei Eingeben :");
            string Path = Console.ReadLine();
           PersonnelNumber = employee_Manager.ReadContacts(Path , PersonnelNumber);





            // Programm Ablauf
            do
            {
                Console.WriteLine("H.Neuen Mitarbeiter Hinzufügen");
                Console.WriteLine("L.Mitarbeiter Löschen");
                //Console.WriteLine(".Urlaub Eintragen");
                Console.WriteLine("S.Mitarbeiter Suchen");
                Console.WriteLine("A.Alle Datensätze anzeigen");
                Console.WriteLine("B.Beenden");

                switch_Menue = Console.ReadKey().KeyChar;
                Console.Clear();
                

                switch (switch_Menue)
                {
                    
                    // Alle Mitarbeiter anzeigen
                    case 'A':
                    case 'a':
                        {
                            
                            employee_Manager.ShowAllEmployees();
                            Console.WriteLine("Beliebige Taste zum Fortfahren drücken...");
                           char a  = Console.ReadKey().KeyChar;
                        }
                        break;
                        // Mitarbeiter Suchen
                    case 'S':
                    case 's':
                        {
                            employee_Manager.SearchEmployee();
                            Console.WriteLine("Beliebige Taste zum Fortfahren drücken");
                            char a  = Console.ReadKey().KeyChar;
                           
                        }
                        break;

                    case 'L':
                    case 'l':
                        {
                            employee_Manager.DeleteEmployee();
                        }
                        break;
                        // Mitarbeiter Hinzufügen
                    case 'H':
                    case 'h':
                        {
                            Employee employee = addresses.settingValues(PersonnelNumber);
                            PersonnelNumber++;
                            employee_Manager.AddEmployee(employee);
                        }
                        break;


                    case 'B':
                    case 'b':
                        {
                            
                        }
                        break;

                }
                Console.Clear();

            } while (switch_Menue != 'b' && switch_Menue != 'B');
        
        }


    }
}
