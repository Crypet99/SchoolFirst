using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WPF___Fireabase_Anwendung
{
    internal class Personen
    {
        public Personen(string firstname, string lastname, int age) { vorname = firstname; nachname = lastname; alter = age; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public int alter { get; set; }
        public bool selected { get; set; }
    }
}
