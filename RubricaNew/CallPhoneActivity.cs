
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
using Android.Preferences;
using Android.Media;

namespace BusinessCall
{
	[Activity (
		Label = "Rubrica ANM - Chiama",
		Icon = "@drawable/icon",
		ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
		Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar", 
		WindowSoftInputMode = SoftInput.StateHidden
	)]			
	public class CallPhoneActivity : Activity
	{
		TextView txtMonitor;
		ISharedPreferences prefsBase;
		ISharedPreferencesEditor prefs;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Create your application here
			SetContentView(Resource.Layout.callPhone);
			txtMonitor = FindViewById<TextView> (Resource.Id.txtNumeroCall);

			prefsBase  = PreferenceManager.GetDefaultSharedPreferences(this.Application);
			prefs = prefsBase.Edit ();

			/*Dichiaro i Bottoni*/
			Button btn1 = FindViewById<Button> (Resource.Id.button1);
			Button btn2 = FindViewById<Button> (Resource.Id.button2);
			Button btn3 = FindViewById<Button> (Resource.Id.button3);
			Button btn4 = FindViewById<Button> (Resource.Id.button4);
			Button btn5 = FindViewById<Button> (Resource.Id.button5);
			Button btn6 = FindViewById<Button> (Resource.Id.button6);
			Button btn7 = FindViewById<Button> (Resource.Id.button7);
			Button btn8 = FindViewById<Button> (Resource.Id.button8);
			Button btn9 = FindViewById<Button> (Resource.Id.button9);
			Button btn0 = FindViewById<Button> (Resource.Id.button0);
			Button btnStar = FindViewById<Button> (Resource.Id.buttonStar);
			Button btnSharp = FindViewById<Button> (Resource.Id.buttonSharp);
			ImageButton btnCall = FindViewById<ImageButton> (Resource.Id.buttonCall);
			ImageButton btnBack = FindViewById<ImageButton> (Resource.Id.btnBack);
			ImageButton btnDel = FindViewById<ImageButton> (Resource.Id.buttonDel);
			btnCall.Tag = "call";
			btnDel.Tag = "del";
			btnBack.Tag = "back";

			btn0.Click += onButtonClick;
			btn1.Click += onButtonClick;
			btn2.Click += onButtonClick;
			btn3.Click += onButtonClick;
			btn4.Click += onButtonClick;
			btn5.Click += onButtonClick;
			btn6.Click += onButtonClick;
			btn7.Click += onButtonClick;
			btn8.Click += onButtonClick;
			btn9.Click += onButtonClick;
			btnStar.Click += onButtonClick;
			btnSharp.Click += onButtonClick;

			btnCall.Click += imageButtonsClick;;
			btnBack.Click += imageButtonsClick;
			btnDel.Click += imageButtonsClick;

			txtMonitor.Text = "";


		}

		void imageButtonsClick (object sender, EventArgs e)
		{
			var btn = sender as ImageButton;

			if (btn.Tag.ToString() == "del") {
				if (txtMonitor.Text.Length == 0)
					return;
				txtMonitor.Text = txtMonitor.Text.Substring (0, txtMonitor.Text.Length - 1);
			}
			if (btn.Tag.ToString() == "call") {

				Intent c = new Intent (Intent.ActionCall);
				string EliminaMessaggio = "";
				if (prefsBase.GetBoolean ("EliminaMessaggio", false))
					EliminaMessaggio = " ,1";
				c.SetData (Android.Net.Uri.Parse ("tel:" +  prefsBase.GetString ("Prefisso", "4146") + txtMonitor.Text + EliminaMessaggio ));
				StartActivity (c);
			}

			if (btn.Tag.ToString() == "back") {
				OnBackPressed ();
			}
		}

		//[Java.Interop.Export("onButtonClick")]
		public void onButtonClick(Object sender, EventArgs e) {
			Button btn = (Button)sender;
			int test = 0;
			//int streamType = AudioTrackMode.Stream;
			//int volume = 50;
			ToneGenerator toneGenerator = new ToneGenerator(Stream.Dtmf, Volume.Max);
			//int toneType = (int)Tone.Dtmf0;
			int durationMs = 300;
			Tone tn; 
			Enum.TryParse ("Dtmf" + btn.Text, true,out tn);
			toneGenerator.StartTone(tn,durationMs);
		
			if (Int32.TryParse (btn.Text, out test)) {
				txtMonitor.Text += btn.Text;
			}

		}



	}

}

