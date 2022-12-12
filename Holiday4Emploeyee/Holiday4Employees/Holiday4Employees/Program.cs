using System;

namespace Holiday4Employees
{
    internal class Program
    {

        struct Employee
        {
            public ushort Id;
            public string LastName;
            public string FirstName;
            public DateOnly Geburtsjahr;

        }


        static void Main(string[] args)
        {
            bool maxReached = false;
            ushort maxEmployees = 500;
            ushort currentEmployees = 0;

            List<Employee> DatabaseEmployee = new List<Employee>();

            currentEmployees = CreateEmployee(DatabaseEmployee, currentEmployees);

        }



        static ushort CreateEmployee(List<Employee> DatabaseEmployee, ushort currentEmployees)
        {
            string firstName = "";
            string lastName = "";
            DateOnly Birthdate = new DateOnly(2000, 01, 01);

            getname(firstName, "Vornamen");
            getname(lastName, "Nachnamen");
            getBirthday(Birthdate);
            DatabaseEmployee.Add(new Employee());
            DatabaseEmployee.Insert(currentEmployees, new Employee());




            return currentEmployees++;


        }
        static string getname(string value, string template)
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
                        break;
                    }
                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);

                }
            }
        }
        static DateOnly getBirthday(DateOnly Birthdate)
        {
            while (true)
            {
                try
                {
                    string Birthday;
                    string BirthMonth;
                    string BirthYear;



                    Console.WriteLine("Bitte nenne uns dein Geburtsjahr");
                    BirthYear = Console.ReadLine();

                    Console.WriteLine("Bitte nenne uns dein Geburtsmonat");
                    BirthMonth = Console.ReadLine();

                    Console.WriteLine("Bitte nenne uns dein Geburtstag");
                    Birthday = Console.ReadLine();

                    if (isNumeric(BirthYear) && isNumeric(BirthMonth) && isNumeric(Birthday))
                    {
                        Birthdate = new DateOnly(Convert.ToInt32(BirthYear), Convert.ToInt32(BirthMonth), Convert.ToInt32(Birthday));
                        Console.WriteLine("Dein Geburtsdatum ist der : {0} Korrekt ? J/N ", Birthdate);
                        char answer = Console.ReadKey().KeyChar;

                        do
                        {
                            if (answer == 'J' || answer == 'j') { return Birthdate; }

                            else if (answer == 'N' || answer == 'n') { continue; }
                        }while(answer != 'J' || answer !'j' || answer != 'n' || answer != 'N')
                     
                       
                    }
                }


                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.Message);
                }
            }
          
        }
        static bool isNumeric(string text)
        {
            return text.All(char.IsNumber);
        }
    }
}