using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace X_Android
{
    //Jede Android-Activity steht für eine Aktion oder ein Layout, welche durch die App durchgeführt
    //oder angezeigt wird. Der 'Code Behind' einer Activity ist eine C#-Klasse, welche mit dem 'Activity'
    //-Attribut gekennzeichnet ist. Hier kann auch der evtl. angezeigte Titel und der verwendete Style
    //definiert werden.
    //Soll die Activity die zuerst angezeigte Activity (=Startseite) der App sein, muss hier die Property
    //'MainLauncher' auf true stehen.
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //Properties, in welchen die Steuerelemente des Layouts für den Zugriff durch C# abgelegt werden
        public Button Btn_Ok { get; set; }
        public EditText Edt_Input { get; set; }
        public Button Btn_Google { get; set; }
        public Button Btn_ShowPicture { get; set; }

        //Methode, welche beim Starten (Initialisieren) der Activity ausgeführt wird
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Aufruf der Base-OnCreate()-Methode (Grundlegende Activity-Initialisierung)
            base.OnCreate(savedInstanceState);
            //Initialisierung der Xamarin-Essentials
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            //Zuweisung und Aktivierung eines Layouts (aus dem layout-Ordner) zu dieser Activity. Dies
            //erfolgt mittels der Ressourcen-Klassen).
            SetContentView(Resource.Layout.content_main);

            //Zuweisung der UI-Elemente zu den Properties mittels der FindViewById<>()-Methode,
            //welche die Resource-Klassen nach der angegebenen Id durchsucht.
            Btn_Ok = FindViewById<Button>(Resource.Id.content_main_Btn_Ok);
            Edt_Input = FindViewById<EditText>(Resource.Id.content_main_Edt_Input);
            Btn_Google = FindViewById<Button>(Resource.Id.content_main_Btn_Google);
            Btn_ShowPicture = FindViewById<Button>(Resource.Id.content_main_Btn_ShowPicture);

            //Zuweisung einer Methode zu einem Click-Event eines Buttons.
            //Diese Methode kreiert einen Toast (kl. Anzeige am unteren Bildschirmrand) und zeigt ihn an.
            Btn_Ok.Click += (s, e) => Toast.MakeText(this, $"Ihre gewählte Zahl ist {Edt_Input.Text}.", ToastLength.Long).Show();

            //Impliziter Intent (Verweis auf eine Activity, welche mit dem ihrem Typen zugeordneten
            //Standartprogramm geöffnet wird) am Beispiel eines Webpage-Aufrufs im Standartbrowser.

            //Erstellung des Intents
            Intent implizieterIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://www.google.de"));
            //Zuweisung des Click-Events mit der StartActivity()-Methode, welcher der Intent übergeben wird
            Btn_Google.Click += (s, e) => StartActivity(implizieterIntent);

            //Expliziter Intent (Verweis auf eine Activity, welche in einer genau definierten App ausgeführt wird)
            //Am Beispiel des Öffnens eines neuen Layouts

            //Erstellung des Intents
            Intent explizieterIntent = new Intent(this, typeof(ShowPictureActivity));
            //Zuweisung des Click-Events
            Btn_ShowPicture.Click += (s, e) => StartActivity(explizieterIntent);

            //Todo-Übung
            Button btnTodo = FindViewById<Button>(Resource.Id.content_main_Btn_Todo);
            btnTodo.Click += (s, e) => StartActivity(new Intent(this, typeof(TodoActivity)));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
