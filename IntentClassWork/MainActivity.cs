using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace IntentClassWork
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText etWord;
        private Button btnSave;
        private Button btnChoose;

        private string[] words;
        private int index;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitializeViews();

            words = new string[3];
            index = 0;
        }

        private void InitializeViews()
        {
            etWord = FindViewById<EditText>(Resource.Id.etWord);
            btnChoose = FindViewById<Button>(Resource.Id.btnChoose);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);

            btnChoose.Click += btnChoose_click;
            btnSave.Click += btnSave_click;
        }

        private void btnSave_click(object sender, EventArgs e)
        {
            if (etWord.Text == "")
                Toast.MakeText(this, "Please enter word", ToastLength.Short).Show();
            else
            {
                words[index] = etWord.Text;
                index++;

                etWord.Text = "";
                etWord.Hint = "Enter word #" + (index + 1);

                if (index >= words.Length)
                {
                    btnSave.Enabled = false;
                    btnChoose.Enabled = true;
                }
            }
        }

        private void btnChoose_click(object sender, EventArgs e)
        {
            string word1;
            string word2;
            Random rnd = new Random();

            word1 = words[rnd.Next(0, words.Length - 1)];
            word2 = words[rnd.Next(0, words.Length - 1)];

            Intent intent = new Intent(this, typeof(MainActivityWords));
            intent.PutExtra("WORD1", word1);
            intent.PutExtra("WORD2", word2);
            StartActivityForResult(intent, 1);
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            string word = data.GetStringExtra("WORD");
            //Toast.MakeText(this, word, ToastLength.Short).Show();
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this, 1);
            builder.SetTitle("The word you chose:");
            builder.SetMessage(word);
            builder.SetPositiveButton("OK", (c, ev) => { });
            builder.Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}