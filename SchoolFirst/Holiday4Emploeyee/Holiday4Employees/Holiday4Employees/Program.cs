using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Holiday4Employees
{
    internal class Program
    {

        struct Employee
        {
            public ushort Id;
            public string LastName;
            public string FirstName;
            public DateTime Birthdate;
            public int Age;
            public int Holidays;

        }


        static void Main(string[] args)
        {
            bool systemRunning = true;
            ushort maxEmployees = 500;
            ushort currentEmployees = 0;
            ushort PersonnelNumbers = 0;
            char switchmenue = 'p';

            List<Employee> DatabaseEmployee = new List<Employee>();

            while (systemRunning)
            {
                Console.WriteLine("Willkommen bei SAPV2.0 was möchten sie Erledigen?");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("1.Neuen Mitarbeiter Hinzufügen");
                Console.WriteLine("2.Mitarbeiter Löschen");
                Console.WriteLine("3.Urlaub Eintragen");
                Console.WriteLine("4.Mitarbeiter Suchen");
                Console.WriteLine("5.Alle Datensätze anzeigen");
                Console.WriteLine("6.Beenden");
                switchmenue = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (switchmenue)
                {

                    // Neuen Mitarbeiter Anlegen // Fertig
                    case '1':
                        {
                            if (currentEmployees < maxEmployees)
                            {
                                currentEmployees = CreateEmployee(DatabaseEmployee, currentEmployees, PersonnelNumbers);
                                PersonnelNumbers++;
                            }

                            else if (currentEmployees >= maxEmployees)
                            {
                                Console.WriteLine("Die Maximalanzahl an Benutzern ({0}) wurde erreicht.", maxEmployees);
                            }

                        }
                        break;

                    // Mitarbeiter Löschen
                    case '2':
                        {
                            Console.WriteLine("Den zu wünschend Kündigenden Mitarbeiter bitte die PersonalNummer Eingeben : ");
                            try
                            {
                                string CancelEmployee = Console.ReadLine();
                                if (isNumeric(CancelEmployee))
                                {
                                    Console.Clear();
                                    int test = (showEmploye(DatabaseEmployee, Convert.ToInt32(CancelEmployee)));
                                    CancelEmployee = Convert.ToString(test);
                                    Console.WriteLine();
                                    char answer = 't';

                                    do
                                    {
                                        Console.WriteLine("Sind sie Sicher das sie den Mitarbeiter Löschen Wollen ? J/N");
                                        answer = Console.ReadKey().KeyChar;
                                        Console.WriteLine();

                                        if (answer == 'J' || answer == 'j') { DatabaseEmployee.RemoveAt(Convert.ToInt32(CancelEmployee)); currentEmployees--; break; }
                                        else if (answer == 'N' || answer == 'n') { break; }

                                    } while (answer != 'N' || answer != 'n' || answer != 'J' || answer != 'j');
                                }
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;

                    // Urlaub Eintragen
                    case '3':
                        {
                            Console.WriteLine("Bitte Ihre Personalnummer eingeben :");
                            string pID = Console.ReadLine();
                            pID = Convert.ToString(DatabaseEmployee.FindIndex(e => e.Id == Convert.ToInt32(pID)));
                            Console.WriteLine("An welchem Tag soll dein Urlaub beginnen ? z.B 05");
                            string hDay = Console.ReadLine();

                            Console.WriteLine("In Welchem Monat ? z.B 07");
                            string hMonth = Console.ReadLine();

                            Console.WriteLine("Und in welchem Jahr ? z.B {0}", DateTime.Now.Year);
                            string hYear = Console.ReadLine();

                            DateTime Holidaybegin = new DateTime(Convert.ToInt32(hYear), Convert.ToInt32(hMonth), Convert.ToInt32(hDay));

                            Console.WriteLine("Wie Lange soll dein urlaub gehen ?");
                            string HoldayDuration = Console.ReadLine();
                            DateTime HolidayEnd = Holidaybegin.AddDays(Convert.ToInt32(HoldayDuration));

                            ushort Id = DatabaseEmployee[Convert.ToInt32(pID)].Id;
                            string LastName = DatabaseEmployee[Convert.ToInt32(pID)].LastName;
                            string FirstName = DatabaseEmployee[Convert.ToInt32(pID)].FirstName;
                            DateTime Birthdate = DatabaseEmployee[Convert.ToInt32(pID)].Birthdate;
                            int Age = DatabaseEmployee[Convert.ToInt32(pID)].Age;
                            int Holidays = DatabaseEmployee[Convert.ToInt32(pID)].Holidays - Convert.ToInt32(HoldayDuration);

                            DatabaseEmployee.RemoveAt(Convert.ToInt32(pID));
                            DatabaseEmployee.Insert(Convert.ToInt32(pID), new Employee() { Id = Id, LastName = LastName, FirstName = FirstName, Birthdate = Birthdate, Age = Age, Holidays = Holidays });
                       


                        }
                        break;



                    // Mitarbeiter Suchen
                    case '4':
                        {
                            string pID;
                            do
                            {
                                Console.WriteLine("Bitte Geben sie Ihre Personalnummer ein um ihren PersonalDatensatz zu suchen");
                                pID = Console.ReadLine();
                            } while (!isNumeric(pID));
                            int Buffer = showEmploye(DatabaseEmployee, Convert.ToInt32(pID));
                        }
                        break;

                    // Alle Mitarbeiter anzeigen lassen / Fertig
                    case '5':
                        {
                            showEmployees(DatabaseEmployee);

                        }
                        break;

                    // Programm Beenden
                    case '6':
                        {
                            Console.WriteLine("Programm Wird Beendet");
                            systemRunning = false;
                        }
                        break;


                }
                Console.WriteLine();
                Console.WriteLine("Zum Fortfahren Beliebige Taste Drücken");
                Console.ReadLine();
                Console.Clear();
            }

        }

        static ushort CreateEmployee(List<Employee> DatabaseEmployee, ushort currentEmployees, ushort PersonnelNumbers)
        {

            string firstName = "";
            string lastName = "";
            int holidays;

            DateTime birthdate = new DateTime(1999, 01, 01);
            DateTime timeNow = DateTime.Now;
            DateTime Test = DateTime.Now.AddYears(-1);
            DateTime Timecheck = new DateTime(DateTime.Now.Year, 01, 01);

            firstName = getname(firstName, "Vornamen");
            lastName = getname(lastName, "Nachnamen");
            birthdate = getBirthday(birthdate);
            int Age = timeNow.Subtract(birthdate).Days / 365;
            if (Timecheck.Subtract(birthdate).Days / 365 >= 51)
            {
                holidays = 32;
            }
            else { holidays = 30; }




            DatabaseEmployee.Insert(currentEmployees, new Employee() { Id = PersonnelNumbers, FirstName = firstName, LastName = lastName, Birthdate = birthdate, Age = Age, Holidays = holidays });
            currentEmployees += 1;
            return currentEmployees;


        }
        static string getname(string? value, string? template)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Sehr geehrter Mitarbeiter bitte geben sie uns ihren {0} :", template);
                    value = Console.ReadLine();
                    if (isNumeric(value))
                    {
                        Console.WriteLine("Bitte einen Gültigen Namen eingeben");
                        continue;

                    }
                    else if (!isNumeric(value))
                    {
                        return value;
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
        }
        static DateTime getBirthday(DateTime Birthdate)
        {
            while (true)
            {
                try
                {
                    string? Birthday = "1";
                    string? BirthMonth = "1";
                    string? BirthYear = "2000";



                    Console.WriteLine("Bitte nenne uns dein Geburtsjahr (z.B 1999)");
                    BirthYear = Console.ReadLine();
                    if (!isNumeric(BirthYear) || BirthYear.Length != 4) { Console.WriteLine("Ungültiges Format"); Console.Clear(); continue; }

                    Console.WriteLine("Bitte nenne uns dein Geburtsmonat (z.B 10)");
                    BirthMonth = Console.ReadLine();
                    if (!isNumeric(BirthMonth) || BirthMonth.Length != 2) { Console.WriteLine("Ungültiges Format"); Console.Clear(); continue; }

                    Console.WriteLine("Bitte nenne uns dein Geburtstag (z.B 18)");
                    Birthday = Console.ReadLine();
                    if (!isNumeric(Birthday) || Birthday.Length != 2) { Console.WriteLine("Ungültiges Format"); Console.Clear(); continue; }


                    Birthdate = new DateTime(Convert.ToInt32(BirthYear), Convert.ToInt32(BirthMonth), Convert.ToInt32(Birthday));
                    char answer = 't';
                    string Datestring = Birthdate.ToLongDateString();

                    do
                    {
                        Console.WriteLine("Dein Geburtsdatum ist der : {0} Korrekt ? J/N ", Datestring);
                        answer = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        if (answer == 'J' || answer == 'j') { return Birthdate; }
                        else if (answer == 'N' || answer == 'n') { break; }

                    } while (answer != 'N' || answer != 'n' || answer != 'J' || answer != 'j');



                }


                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }

        }
        static void showEmployees(List<Employee> DatabaseEmployee)
        {
            foreach (Employee e in DatabaseEmployee)
            {
                string Datestring = e.Birthdate.ToLongDateString();
                Console.WriteLine("Mitarbeiternummer : {0}", e.Id);
                Console.WriteLine("Name :" + "" + e.FirstName + " " + e.LastName);
                Console.WriteLine("Geburtsjahr : " + Datestring);
                Console.WriteLine("Alter : {0} ", e.Age);
                Console.WriteLine("Urlaubsanspruch : {0}", e.Holidays);
                Console.WriteLine("Index : {0}", DatabaseEmployee.FindIndex(a => a.Id == e.Id));
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
        static int showEmploye(List<Employee> DatabaseEmployee, int index)
        {

            int PersonnelIndex = DatabaseEmployee.FindIndex(e => e.Id == index);
            string Datestring = DatabaseEmployee[PersonnelIndex].Birthdate.ToLongDateString();
            Console.WriteLine("Mitarbeiternummer : {0}", DatabaseEmployee[PersonnelIndex].Id);
            Console.WriteLine("Name :" + "" + DatabaseEmployee[PersonnelIndex].FirstName + " " + DatabaseEmployee[PersonnelIndex].LastName);
            Console.WriteLine("Geburtsjahr : " + Datestring);
            Console.WriteLine("Alter : {0} ", DatabaseEmployee[PersonnelIndex].Age);
            Console.WriteLine("Urlaubsanspruch : {0}", DatabaseEmployee[PersonnelIndex].Holidays);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            return PersonnelIndex;

        }
        static bool isNumeric(string? text)
        {
            return text.All(char.IsNumber);
        }
    }
}