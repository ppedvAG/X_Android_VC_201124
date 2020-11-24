using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace X_Android.Service
{
    //Diese statische Klasse läd die Beispiel-Daten vom Server und deserialisiert diese zurück in Todo-Objekte
    public static class JsonService
    {
        //Methode zum Abrufen der Todos
        public static List<Model.Todo> GetTodos()
        {
            string url = "https://jsonplaceholder.typicode.com/todos";
            string json;

            using (WebClient client = new WebClient())
            {
                //Download des Json-Strings
                json = client.DownloadString(url);
            }

            //Deserialisierung des Strings und Rückgabe an Aufrufer
            return JsonConvert.DeserializeObject<List<Model.Todo>>(json);
        }
    }
}