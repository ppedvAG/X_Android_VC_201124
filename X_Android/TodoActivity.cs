using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X_Android
{
    [Activity(Label = "TodoActivity")]
    public class TodoActivity : Activity
    {
        //Control-Property
        public ListView LstV_Todos { get; set; }
        //Property zum Speichern der Liste
        public List<Model.Todo> Todos { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Aufruf der Base-Methode (Grundlegende Activity-Initialisierung)
            base.OnCreate(savedInstanceState);
            //Verknüpfen und Öffenen der Layout-Datei (im layout-Ordner)
            SetContentView(Resource.Layout.activity_todo);
            //Zuweisung des Controls zur Property
            LstV_Todos = FindViewById<ListView>(Resource.Id.LstV_Todo);

            //Abrufen und Deserialisieren der Daten per statischer Service-Klasse
            Todos = Service.JsonService.GetTodos();

            //Beispiel für codeseitiges 'Abhaken' eines Listeneintrags
            Todos[0].Completed = true;

            //Speichern der Titel in einem String-Array
            string[] todoTitles = Todos.Select(x => x.Title).ToArray();

            //Zuweisung eines Adapters zum ListView. Dieser definiert die Zuordnung der StringArray-Elementen zu
            //ListViewItems. Er benötigt als Parameter den aktuellen Kontext (this), die Art des ListViewItems im
            //ListView (SimpleListItemChecked) und das anzuzeigende Array (todoTitles).
            LstV_Todos.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemChecked, todoTitles);

            //ChoiceMode definiert die Möglichkeit, ob mehrere Elemente gleichzeitig ausgewählt werden können
            LstV_Todos.ChoiceMode = ChoiceMode.Multiple;

            //Schleife, welche kontrolliert, ob die Items 'Complited' sind und diese gegebenenfalls im ListView 'abhakt'
            for (int i = 0; i < Todos.Count; i++)
            {
                if (Todos[i].Completed)
                    //'Abhaken' der Items mittels der SetItemChecked()-Methode des ListViews
                    LstV_Todos.SetItemChecked(i, true);
            }

            //Damit die vom Benutzer 'abgehakten' Items auch im Todo-Objekt als 'Complited' markiert werden,
            //muss das ItemClick-Event des ListView belegt sein
            LstV_Todos.ItemClick += ItemClick;

        }

        //Methode, zur Übernahme eines manuellen 'Abhakens' in das Model-Objekt
        public void ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Todos[e.Position].Completed = LstV_Todos.IsItemChecked(e.Position);
        }
    }
}