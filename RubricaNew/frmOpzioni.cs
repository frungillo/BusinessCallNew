
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

namespace BusinessCall
{
	[Activity (Label = "Opzioni",
		Icon = "@drawable/icon",
		ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
		Theme = "@android:style/Theme.DeviceDefault.Light", NoHistory = true, 
		WindowSoftInputMode = SoftInput.StateHidden)]			
	public class frmOpzioni : Activity
	{

		ISharedPreferences prefsBase;
		ISharedPreferencesEditor prefs;
		
		EditText txtPrefisso;
		RadioGroup chkGruppoOrdinamento;
		ToggleButton btnEliminaMessaggio;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.frmOpzioni);
			txtPrefisso = FindViewById<EditText> (Resource.Id.txtPrefissoBusiness);
			chkGruppoOrdinamento = FindViewById<RadioGroup> (Resource.Id.chkGruppoOrdinamento);
			btnEliminaMessaggio = FindViewById<ToggleButton> (Resource.Id.btnEliminaMessaggio);
			Button btnSalva = FindViewById<Button> (Resource.Id.btnSalva);

			btnSalva.Click += delegate {
				OnBackPressed();
			};

			prefsBase  = PreferenceManager.GetDefaultSharedPreferences(this.Application);
			prefs = prefsBase.Edit ();

			txtPrefisso.Text = 	prefsBase.GetString ("Prefisso", "4146");
			try {
				FindViewById<RadioButton> (prefsBase.GetInt ("IdOrdinamento", 0)).Checked = true;
			} catch (Exception) {
				
			}

			btnEliminaMessaggio.Checked = prefsBase.GetBoolean ("EliminaMessaggio", false);

		}


		private void SalvaSettaggi(string key,object value){
			prefs.Remove (key);
			if (value.GetType () == typeof(string)) {
				prefs.PutString (key, (string)value);
			} else if (value.GetType () == typeof(int)) {
				prefs.PutInt (key, (int)value);
			} else if (value.GetType() == typeof(bool)){
				prefs.PutBoolean (key, (bool)value);
			}
			prefs.Commit ();
			prefs.Apply ();
		}

		public override void OnBackPressed ()
		{
			SalvaSettaggi ("Prefisso", txtPrefisso.Text);
			SalvaSettaggi ("EliminaMessaggio", btnEliminaMessaggio.Checked);
			SalvaSettaggi ("Ordinamento", FindViewById<RadioButton> (chkGruppoOrdinamento.CheckedRadioButtonId).Text);
			SalvaSettaggi ("IdOrdinamento", FindViewById<RadioButton> (chkGruppoOrdinamento.CheckedRadioButtonId).Id);
			SetResult (Result.Ok);
			base.OnBackPressed ();
		}
	}
}

