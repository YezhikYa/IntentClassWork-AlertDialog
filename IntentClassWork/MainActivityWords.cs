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

namespace IntentClassWork
{
    [Activity(Label = "MainActivityWords")]
    public class MainActivityWords : Activity
    {
        private Button btnWord1;
        private Button btnWord2;
        private Button btnReturn;

        private string word;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_mainWords);

            InitializeViews();

            btnWord1.Text = Intent.GetStringExtra("WORD1");
            btnWord2.Text = Intent.GetStringExtra("WORD2");
        }

        private void InitializeViews()
        {
            btnWord1 = FindViewById<Button>(Resource.Id.btnWord1);
            btnWord2 = FindViewById<Button>(Resource.Id.btnWord2);
            btnReturn = FindViewById<Button>(Resource.Id.btnReturn);

            btnWord1.Click += btnWord1_click;
            btnWord2.Click += btnWord2_click;
            btnReturn.Click += btnReturn_click;
        }

        private void btnReturn_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(word))
                Toast.MakeText(this, "Please choose a word", ToastLength.Short).Show();
            else
            {
                Intent intent = new Intent();
                intent.PutExtra("WORD", word);
                SetResult(Result.Canceled, intent);
                Finish();
            }
        }

        private void btnWord2_click(object sender, EventArgs e)
        {
            word = btnWord2.Text;
        }

        private void btnWord1_click(object sender, EventArgs e)
        {
            word = (sender as Button).Text;
        }
    }
}