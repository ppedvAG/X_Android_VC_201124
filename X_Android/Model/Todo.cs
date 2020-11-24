using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
//Newtonsoft.Json (per NuGet) stellt Funktionen zur (De-)Serialisierung von und in Json-Files zur Verfügung.
//Dadurch können komplexe Objekte (wie diese Todos) als Strings gespeichert werden.
using Newtonsoft.Json;

namespace X_Android.Model
{
    //Diese Klasse wurde automatisch mittels 'https://quicktype.io/' erstellt. Diese Webpage erstellt aus
    //Json-Files C#-Klassen. Hier wurden die unter 'https://jsonplaceholder.typicode.com/todos' ausgegebenen 
    //Beispiel-Todos (welche auch in der Service-Klasse verwendet werden) eingegeben.
    public class Todo
    {
        //Das 'JsonProperty'-Attribut definiert die von Json zu (de-)serialisierenden Properties
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}