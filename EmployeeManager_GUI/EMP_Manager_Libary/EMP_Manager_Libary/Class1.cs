﻿namespace EMP_Manager_Libary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;



    // Person Mit allen Variablen und ZugriffsMethoden
    public class Employee
    {
        public ushort _EmployeeID;
        private string _FirstName;
        private string _LastName;
        private ushort _Age;
        private ushort _HolidaysAvailable;
        private ushort _UsedHolidays;
        public DateTime[] _Holidays = new DateTime[32];
        private DateTime _Birthdate;
        public DateTime[] _Workdays = new DateTime[32];

        // Konstruktor
        public Employee()
        {
            _EmployeeID = 10000;
            _FirstName = " ";
            _LastName = " ";
            _Age = 0;
            _HolidaysAvailable = 0;
            _UsedHolidays = 0;
            _Birthdate = new DateTime(2000, 01, 01);

        }

        //Operator Überladung Vergleichen von 2 Mitarbeitern
        public static bool operator ==(Employee a, Employee b)
        {

            return a._FirstName == b._FirstName && a._LastName == b._LastName && a._Birthdate == b._Birthdate;
        }

        public static bool operator !=(Employee a, Employee b)
        {
            return a._FirstName != b._FirstName && a._LastName != b._LastName && a._Birthdate != b._Birthdate;

        }

        #region Setting / Getting Permissions


        // Zuweisung - Get Variablen
        public ushort Get_EmployeeID()
        {
            return _EmployeeID;
        }

        public string Get_FirstName()
        {
            return _FirstName;
        }

        public string Get_LastName()
        {
            return _LastName;
        }

        public ushort Get_Age()
        {
            return _Age;
        }

        public ushort Get_HolidaysAvailable()
        {
            return _HolidaysAvailable;
        }

        public ushort Get_UsedHolidays()
        {
            return _UsedHolidays;
        }

        public DateTime Get_Birthdate()
        {
            return _Birthdate;
        }


        public void Set_EmployeeID(ushort value)
        {
            _EmployeeID = value;
        }

        public void SET_FirstName(string value)
        {
            _FirstName = value;
        }

        public void SET_LastName(string value)
        {
            _LastName = value;
        }

        public void Set_Age(ushort value)
        {
            _Age = value;
        }

        public void Set_HolidaysAvailable(ushort value)
        {
            _HolidaysAvailable = value;
        }

        public void Set_UsedHolidays(ushort value)
        {
            _UsedHolidays = value;
        }

        public void Set_Birthdate(DateTime value)
        {
            _Birthdate = value;
        }
        #endregion



    };



}


