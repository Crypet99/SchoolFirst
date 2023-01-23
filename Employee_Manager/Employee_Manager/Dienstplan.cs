using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Manager
{
    internal class Dienstplan
    {
    


        public void TimePlanMenue(List<Employee> EmployeeList)
        {
            // Klassen Einbinden
            Employee employee = new Employee();
            Addresses addresses = new Addresses();
            Employee_Manager manager = new Employee_Manager();
     

            // Ausgewähltes Monat Deklarieren
            DateTime[] SelectedMonth = new DateTime[32];

            // Variablen
            char Switch_TPMenue = ' ';
            int sMonth = 0;
            int sDay = 0;

            // Monats Abfrage und Zuweisung
            SelectedMonth = SelectMonth(sMonth, sDay);

           
            do
            {  //Menue Anzeigen und Auswahl zuweisen
                Switch_TPMenue = showMenue(SelectedMonth , EmployeeList);
                Console.Clear();

                switch(Switch_TPMenue)
                {
                    // Mitarbeiter Einteilen
                    case 'E':
                    case 'e':
                        {
                            
                                Console.Clear();
                              //  ShowSelectedTime(SelectedMonth , EmployeeList);
                            do
                            {   ShowSelectedTime(SelectedMonth , EmployeeList); 
                                employee = SelectAvailableEmployees(EmployeeList);
                                Console.Clear();
                                ChooseTime(employee, addresses,SelectedMonth , EmployeeList);
                                Console.Clear();

                                char exit_Menue = ' ';
                                Console.WriteLine("Erneut B Drücken um Zeitplanung zu beenden, Beliebige Taste Drücken um zur Personalauswahl zurückzukommen.");
                                exit_Menue = Console.ReadKey().KeyChar;
                                Console.Clear();
                                if (exit_Menue == 'B' || exit_Menue == 'b') { break; }

                               
                            } while (true);

                        }break;

                    // B Beenden
                    case 'B':
                    case 'b':
                        {

                        }
                        break;




                }


            } while (Switch_TPMenue != 'b' && Switch_TPMenue != 'B');
            





        }


        // Auswahl Monat
        private DateTime[] SelectMonth(int sMonth = 0, int sDay = 0)
        {

            // Monatssuche
            do
            {
                Console.WriteLine("(D)ieses Monat oder (A)nderes");
                char switch_TPDate = ' ';
                switch_TPDate = Console.ReadKey().KeyChar;
                Console.Clear();

                if (switch_TPDate == 'A' || switch_TPDate == 'a')
                {
                    do
                    {
                        try
                        {
                            Console.WriteLine("Bitte Den Monat eingeben :");
                            sMonth = Convert.ToInt32(Console.ReadLine());
                            if (sMonth <= 0 || sMonth > 12) { Console.WriteLine("Ungültiges Monat"); continue; }

                            Console.WriteLine("Bitte Den Tag eingeben :");
                            sDay = Convert.ToInt32(Console.ReadLine());
                            if (sDay <= 0 || sDay > 31) { Console.WriteLine("Ungültiges Monat"); continue; }

                            DateTime CheckValidity = new DateTime(DateTime.Now.Year, sMonth, sDay);
                            break;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            continue;
                        }
                    } while (true);

                }

                Console.Clear();



               


            DateTime firstOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime lastOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddMonths(1).AddDays(-DateTime.Now.Day);
            DateTime SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (sMonth > 0 || sDay > 0) { SelectedDate = new DateTime(DateTime.Now.Year, sMonth, sDay); }

            DateTime sfirstOfMonth;
            DateTime slastOfMonth;

            // Array Größe Festlegen
            DateTime[] Month = new DateTime[lastOfMonth.Day];

            // Ausgewähltes Datum Zuweisen
            if (sMonth > 0 || sDay > 0)
            {

                Console.WriteLine("Ausgewähltes Datum : " + SelectedDate.ToLongDateString());

                slastOfMonth = new DateTime(DateTime.Now.Year, sMonth, sDay).AddMonths(1).AddDays(-sDay);
                sfirstOfMonth = new DateTime(DateTime.Now.Year, sMonth, 1);
                Array.Resize(ref Month, slastOfMonth.Day);

                for (ushort i = 0; i < Month.Length; i++)
                {
                    Month[i] = sfirstOfMonth.AddDays(i);
                }
            }

            // Heutiges Datum Zuweisen
            else
            {
                Console.WriteLine("Heutiges Datum : " + DateTime.Today.ToLongDateString());
                for (ushort i = 0; i < Month.Length; i++)
                {
                    Month[i] = firstOfMonth.AddDays(i);
                }

            }





            // Tage Anzeigen
            for (ushort i = 0; i < Month.Length; i++)
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Month[i].Day + "." + Month[i].Month + " - " + Month[i].DayOfWeek.ToString() + " ");
                if (Month[i].DayOfWeek == DayOfWeek.Sunday) { Console.WriteLine(); }
                Console.ForegroundColor = ConsoleColor.Red;


            }

                Console.WriteLine("\nIst es der Richtige Monat? J/N ");

                char switch_RightMonth = ' ';
                switch_RightMonth = Console.ReadKey().KeyChar;

                if (switch_RightMonth == 'J' || switch_RightMonth == 'j') { Console.Clear(); return Month; }
                else continue;

            } while (true);


            


        }

        private char showMenue(DateTime[] Month , List<Employee> Manager)
        {
            do
            {
                try
                {

                    Console.WriteLine("Dienstplan Menü : \n");
                    ShowSelectedTime(Month,Manager);
                    Console.WriteLine("(E)inteilen\n(A)usteilen\n(B)eenden");

                    char Switch_TPlan = Console.ReadKey().KeyChar;
                    return Switch_TPlan;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            } while (true);
        }

        // Zeitauswahl Anzeigen
        private void ShowSelectedTime(DateTime[] Month, List<Employee> Manager)
        {
            Console.WriteLine("Zeitspanne : {0} bis {1}", Month[0].ToLongDateString(), Month[Month.Length - 1].ToLongDateString());
            for (ushort i = 0; i < Month.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;

                foreach (Employee e in Manager)
                {
                    for(int y = 0; y< e._Workdays.Length; y++)
                    {
                        if (e._Workdays[y] == Month[i]) { Console.ForegroundColor = ConsoleColor.Red; break; }
                    }

                   


                }
                
                
                Console.Write(Month[i].Day + "." + Month[i].Month + " - " + Month[i].DayOfWeek.ToString() + " ");
                if (Month[i].DayOfWeek == DayOfWeek.Sunday) { Console.WriteLine(); }
                Console.ForegroundColor = ConsoleColor.Red;

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
        }

        private Employee SelectAvailableEmployees(List<Employee> Manager)
        {
            foreach (Employee Employee in Manager)
            {
                Console.WriteLine(Employee.Get_FirstName() + " " + Employee.Get_LastName() + " Mitarbeiternummer : " + Employee.Get_EmployeeID());
                
            }

            do
            {
                try
                {
                    Console.WriteLine("Bitte Wählen sie einen Mitarbeiter mittels seiner Mitarbeiternummer : ");
                    ushort Select_Employee = Convert.ToUInt16(Console.ReadLine());

                    foreach (Employee employee in Manager)
                    {
                       if(employee.Get_EmployeeID() == Select_Employee) { return employee; }
                        
                    }

                    Console.WriteLine("Mitarbeiter nicht Gefunden");
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            } while (true);

        }

        private void ChooseTime(Employee employee, Addresses adresses, DateTime[] Month , List<Employee> Manager)
        {
            ushort Workdays = 0;
            bool CheckDate = false;
            do
            {
                ShowSelectedTime(Month, Manager);
                DateTime Workday = adresses.SetSpecificDate("Bitte Geben sie das Datum an an dem Gearbeitet werden soll");
                foreach(DateTime M in Month)
                {
                    if(M == Workday) { CheckDate = true; break; }
                }

                if (CheckDate == false) { Console.WriteLine("Datum ist Nicht Plausible"); Console.Clear(); continue; }
                employee._Workdays[Workdays] = Workday;
                Workdays++;

                Console.Clear();
                Console.WriteLine("B -> Drücken um Auswahl zu Beenden \nBeliebige Taste um Fortzufahren");
               
                char goON = ' ';
                goON = Console.ReadKey().KeyChar;
                Console.Clear();

                if(goON == 'B' || goON == 'b') { break; }

            } while (true);
            

        }
    }
}
