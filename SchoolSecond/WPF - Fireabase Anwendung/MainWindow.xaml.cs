using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Firebase;
using FireSharp;
using FireSharp.Interfaces;
using FireSharp.Config;
using System.Windows.Media.Animation;
using FireSharp.Response;
using System.Windows.Interop;
using System.Xml.Linq;
using System.Diagnostics.Metrics;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace WPF___Fireabase_Anwendung
{

    public partial class MainWindow : Window
    {

        public IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "\tCV9xSkFKXEOJNghXgJGS6eBh35NEpyiOdAXSIL1I",

            BasePath = "https://schule2ya-default-rtdb.firebaseio.com/"

        };


        IFirebaseClient client;


    public MainWindow()
    {
        InitializeComponent();

        client = new FireSharp.FirebaseClient(config);
        InitializeFirebase();


    }


    private async void Button_Erstellen_Click(object sender, RoutedEventArgs e)
    {

        string vorname = tVorname.Text;
        string nachname = tNachname.Text;
        int alter = 0;

        if (isnumeric(tAlter.Text) && tAlter.Text != "") { alter = Convert.ToInt32(tAlter.Text); };

        if (vorname == "" || nachname == "" || alter == 0) { lbl_PersonSuchen.Content = "Bitte Alle Felder ausfüllen"; return; }
        else
        {
            lbl_PersonSuchen.Content = "";

        }

        client.Set("Personen/" + nachname + " " + vorname, new Personen(vorname, nachname, alter));


    }

    private async void Button_Löschen_Click(object sender, RoutedEventArgs e)
    {

        string vorname = tVorname.Text;
        string nachname = tNachname.Text;
        string alter = "";


        if (isnumeric(tAlter.Text) && tAlter.Text != "") { alter = tAlter.Text; };

        if (vorname == "" || nachname == "" || alter == "") { lbl_PersonSuchen.Content = "Bitte Alle Felder ausfüllen"; return; }
        else
        {
            lbl_PersonSuchen.Content = "";

        }

        FirebaseResponse response = await client.GetAsync("Personen");


        Personen[] persons = PersonsDataGrid.Items.Cast<Personen>()
            .Where(p => p.selected)
            .ToArray();

        foreach (Personen p in persons)
        {
            FirebaseResponse responsenew = await client.DeleteAsync("Personen/" + p.nachname + " " + p.vorname);
        }


    }

    private async void InitializeFirebase()
    {
        try
        {
            var response = await client.GetAsync("Personen/Anzahl");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                lbl_Verbindungsstatus.Content = "Verbindungsstatus: Verbunden";
                lbl_Verbindungsstatus.Foreground = Brushes.Green;

            }
            else
            {
                lbl_Verbindungsstatus.Content = "Verbindungsstatus: Fehler";
                lbl_Verbindungsstatus.Foreground = Brushes.Red;

            }
        }
        catch (Exception ex)
        {
            lbl_Verbindungsstatus.Content = "Verbindungsstatus: Fehler - " + ex.Message;
            lbl_Verbindungsstatus.Foreground = Brushes.Red;

        }
    }

    private bool isnumeric(string value)
    {
        if (value.All(char.IsNumber))
            return true;

        else return false;
    }

    private async void Button_Suchen_Click(object sender, RoutedEventArgs e)
    {


        string vorname = tVorname.Text;
        string nachname = tNachname.Text;
        string alter = "";

        if (vorname == "" || nachname == "" || alter == "") { lbl_PersonSuchen.Content = "Bitte Alle Felder ausfüllen"; }
        lbl_PersonSuchen.Content = "";
        if (isnumeric(tAlter.Text) && tAlter.Text != "") { alter = tAlter.Text; };

        FirebaseResponse response = await client.GetAsync("Personen");

        Dictionary<string, Personen> DicPerson = response.ResultAs<Dictionary<string, Personen>>();

        Personen[] personen = DicPerson.Where(p => p.Key.ToString().Contains(vorname) && p.Key.ToString().Contains(nachname))
            .Select(p => p.Value)
            .ToArray();

        PersonsDataGrid.ItemsSource = personen;


        if (personen.Length > 0)
        {
            lbl_PersonSuchen.Content = "Person(en) gefunden";
            lbl_PersonSuchen.Foreground = Brushes.Green;
        }

        else
        {
            lbl_PersonSuchen.Content = "Person nicht gefunden";
            lbl_PersonSuchen.Foreground = Brushes.Red;

        }

    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        string vorname = tVorname.Text;
        string nachname = tNachname.Text;
        string alter = "";


        if (isnumeric(tAlter.Text) && tAlter.Text != "") { alter = tAlter.Text; };

        if (vorname == "" || nachname == "" || alter == "") { lbl_PersonSuchen.Content = "Bitte Alle Felder ausfüllen"; return; }
        else
        {
            lbl_PersonSuchen.Content = "";

        }


        FirebaseResponse response = await client.GetAsync("Personen");


        Personen[] persons = PersonsDataGrid.Items.Cast<Personen>()
            .Where(p => p.selected)
            .ToArray();

        foreach (Personen p in persons)
        {


            client.Update("Personen/" + p.nachname + " " + p.vorname, new { alter = alter, vorname = vorname, nachname = nachname });
        }


    }
}
}
