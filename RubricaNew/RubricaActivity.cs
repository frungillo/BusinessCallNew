
using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using RubricaNew.serviceSae;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading ;
using Xamarin.Contacts;
using Java.Lang.Reflect;
using System.Reflection;
using Android.Preferences;

namespace BusinessCall
{
	[Activity (
		Label = "Business Calls",
		 Icon = "@drawable/icon",
		MainLauncher = true,
		ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
		Theme = "@android:style/Theme.DeviceDefault.Light", 
		WindowSoftInputMode = SoftInput.StateHidden
	)]
	public class RubricaActivity : Activity

	{

		List<RubricaCellW> DatiRubrica = new List<RubricaCellW>();
		//List<RubricaCellW> DatiRubrica = new List<RubricaCellW>();
		//serviceSae.WebService1 s = new serviceSae.WebService1 (); //Creazione nuovo client WebService
		ProgressDialog dialog;
		String IMEI; 
		//bool CaricaPrivati = false;
		ISharedPreferences prefsBase;
		ISharedPreferencesEditor prefs;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			ListView lst = FindViewById<ListView> (Resource.Id.listView1);
			EditText txtRicerca = FindViewById<EditText> (Resource.Id.txtricerca );
			ImageButton btnChiama = FindViewById<ImageButton> (Resource.Id.btnChiama);
			prefsBase  = PreferenceManager.GetDefaultSharedPreferences(this.Application);
			prefs = prefsBase.Edit ();


			/*EventoClickBottone*/
			btnChiama.Click += delegate {
				Intent i = new Intent(this, typeof(frmOpzioni));
				StartActivityForResult(i,0);
			};



			/*On txtRicerca Chenged...*/
			txtRicerca.TextChanged += delegate(object sender, Android.Text.TextChangedEventArgs e) {
				
				/*Effettuo la ricerca solo se non si tratta di un numero.*/
				if (txtRicerca.Text.Length > 1) {


					//ArrayList Dati = new ArrayList();
					List<RubricaCellW> Dati = new List<RubricaCellW>();
					/* Ricerca nella listView
					for (int i=0; i<= lst.Adapter.Count -1 ; i++) {
						RubricaCellW elem = lst.GetItemAtPosition(i).Cast<RubricaCellW>();
						if (elem.findCheck(txtRicerca.Text)) {Dati.Add(elem);}
					}
					*/
					foreach (RubricaCellW itm in DatiRubrica) {
						if (itm.findCheck(txtRicerca.Text)) {Dati.Add(itm);}
					}
					if (Dati.Count > 0) {
						lst.Adapter = new AdattatoreLista(this, Dati);
					} else {
						lst.Adapter = new AdattatoreLista(this, DatiRubrica);
					}

				} else {
					lst.Adapter = new AdattatoreLista(this, DatiRubrica);
				}
			};
			/*Fine evento ontxtRicercaChanged*/

			txtRicerca.LongClick += (object sender, View.LongClickEventArgs e) => {
				if (txtRicerca.InputType == Android.Text.InputTypes.TextVariationPersonName){
					txtRicerca.InputType = Android.Text.InputTypes.ClassPhone;
				} else {
					txtRicerca.InputType = Android.Text.InputTypes.TextVariationPersonName;
				}
			};

			var TelManager = (Android.Telephony.TelephonyManager)GetSystemService (TelephonyService); //Connessione al serivizi di telefonia Hw
			IMEI = TelManager.DeviceId; // Recupero IMEI



			/*Controlliamo se esiste un elenco presente nel dispositivo.*/
			if (File.Exists (Application.GetExternalFilesDir ("") + "/array.bin")) {
				FileStream str = File.OpenRead (Application.GetExternalFilesDir ("") + "/array.bin");
				BinaryFormatter bf = new BinaryFormatter ();
				try {
					DatiRubrica = (List<RubricaCellW>)bf.Deserialize (str);
					 
					CompilaLista (lst, false, IMEI);
					str.Close();

				} catch {

					str.Close ();
					CompilaLista (lst, true, IMEI);
				}
			} else {
				CompilaLista (lst, true, IMEI);
			}
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			CompilaLista (FindViewById<ListView> (Resource.Id.listView1), false, IMEI);
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

	


		private void CompilaLista(ListView lista, bool reloadFromService, String IMEI) {
			Ordinamento o;
			switch (prefsBase.GetString("Ordinamento","")) {
			case "Nome":
				o = Ordinamento.Nome;
				break;
			case "Cognome":
				o = Ordinamento.Cognome;
				break;
			case "Nome Visualizzato":
				o = Ordinamento.NomeVisualizzato;
				break;
			default:
				o = Ordinamento.Cognome;
				break;
			}
			if (reloadFromService) {
				prepareWaitDialog ("Caricamento rubrica in corso...", false).Show();
				Thread t = new Thread (() => {
					DatiRubrica.Clear ();
					var book = new AddressBook (this);
					book.PreferContactAggregation = true;
					List<Contact> cnt = new List<Contact> ();
					foreach (Contact contr in book) {
						cnt.Add (contr);
					}

					foreach (Contact contatto in cnt) {

						RubricaCellW rubItem = new RubricaCellW ();
						rubItem.IdContatto = contatto.Id;
						rubItem.NomeVisualizzato = contatto.DisplayName;
						rubItem.Cognome = contatto.LastName;
						rubItem.Nome = contatto.FirstName;
						DirectoryInfo testDir = new DirectoryInfo (Application.GetExternalFilesDir ("") + "/imgCache/");
						if (!testDir.Exists)
							testDir.Create ();
						contatto.SaveThumbnailAsync (Application.GetExternalFilesDir ("") + "/imgCache/" + contatto.Id + ".img");
						rubItem.ImagePath = Application.GetExternalFilesDir ("") + "/imgCache/" + contatto.Id + ".img";
						bool flagTrovato = false;
					
						foreach (Phone tel in contatto.Phones) {
							if (tel.Number != "") {
								if (!rubItem.Numeri.Contains (new NumeriRubrica (tel.Label, tel.Number))) {
									rubItem.Numeri.Add (new NumeriRubrica (tel.Label, tel.Number));
									flagTrovato = true;
								}
							}

						}
						try {
							if (flagTrovato) {
								DatiRubrica.Add (rubItem);
							}

						} catch (Exception ex) {
							MsgBox ("err:" + ex.Message);
						}
					}

					RunOnUiThread (() => {
						dialog.Dismiss ();
						lista.Adapter = new AdattatoreLista (this, DatiRubrica, o); 
						lista.ChoiceMode = ChoiceMode.Single;
						lista.FastScrollEnabled = true;
						lista.ItemClick -= OnListItemClick;
						lista.ItemClick += new EventHandler <AdapterView.ItemClickEventArgs> (OnListItemClick); 

						FileInfo f = new FileInfo(Application.GetExternalFilesDir ("") + "/array.bin");
						if (f.Exists)
							File.Delete(Application.GetExternalFilesDir ("") + "/array.bin");
						//Serializzo le informazioni in un file binario per recuperarle più velocemente
						FileStream str = File.Create (Application.GetExternalFilesDir ("") + "/array.bin");
						BinaryFormatter bf = new BinaryFormatter ();
						bf.Serialize (str, DatiRubrica);
						str.Flush();
						str.Close();
					});
				});
				t.Start ();
			} else {
				//dialog.Dismiss();
				lista.Adapter = new AdattatoreLista (this, DatiRubrica,o); //new ArrayAdapter( this, Android.Resource.Layout.SimpleListItem2, DatiRubrica);
				lista.ChoiceMode = ChoiceMode.Single;
				lista.FastScrollEnabled = true;
				lista.ItemClick -= OnListItemClick;
				lista.ItemClick += new EventHandler <AdapterView.ItemClickEventArgs> (OnListItemClick); //listner click lista

			}

		}

		/*FINE COMPILA LISTA*/

		public override bool OnPrepareOptionsMenu (IMenu menu)
		{
			menu.Clear ();
			menu.Add(0,0,0,"Aggiorna contatti");
		    return base.OnPrepareOptionsMenu (menu);
		}



		/*Selezoni del menuOpzioni*/
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
			case 0: //Do stuff for button 0
				CompilaLista (FindViewById<ListView> (Resource.Id.listView1), true, IMEI);
				return true;
			default:
				return base.OnOptionsItemSelected(item);
			}
		}

	
		/*Click elemento lista (Breve)*/
		void OnListItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			ListView l = (ListView) sender;
			RubricaCellW sel = l.Adapter.GetItem (e.Position).Cast<RubricaCellW> ();
			//Toast.MakeText (ApplicationContext, sel.Utenza, ToastLength.Short).Show ();
			int IdMenu = 0;
			int OrdineMenu = 1;
			PopupMenu mnu = new PopupMenu (this, e.View);
			mnu.Inflate (Resource.Menu.contexMenu);
			mnu.Menu.Add (0, 0, OrdineMenu, sel.NomeVisualizzato);
			mnu.Menu.FindItem (0).SetEnabled (false);

			for (int i = 0; i < sel.Numeri.Count; i++) {
				mnu.Menu.Add (0, IdMenu++, OrdineMenu++, "[" + sel.Numeri [i].TipoNumero + "] " + sel.Numeri [i].NumeroTelefono );
			}



			mnu.MenuItemClick += (s1, arg1) => {
				string numeroDaChiamare = arg1.Item.TitleFormatted.ToString();
				numeroDaChiamare = numeroDaChiamare.Substring(numeroDaChiamare.IndexOf("]")+1).Trim();
				ChiamaNumero(numeroDaChiamare);

			};

	

			mnu.Show();

		}



		private void ChiamaNumero(string Numero) {
			Intent c = new Intent (Intent.ActionCall);
			string pref = prefsBase.GetString ("Prefisso", "");
			string NoMessage = "";
			if (prefsBase.GetBoolean ("EliminaMessaggio", true))
				NoMessage = ",1";
			c.SetData (Android.Net.Uri.Parse ("tel:"+ pref + Numero + NoMessage));
			StartActivity (c);
		}

		/*Progress Dialog*/
		private ProgressDialog  prepareWaitDialog(string msg, bool CanDismiss) 
		{
			dialog = new ProgressDialog(this);
			dialog.Indeterminate = true;
			dialog.SetProgressStyle (ProgressDialogStyle.Spinner);
			dialog.SetMessage (msg);
			dialog.SetCancelable (CanDismiss);
			return dialog;
		}



		private AlertDialog.Builder MsgBox(string msg,string titolo="Attenzione", 
			string PositiveText="OK", string NegativeText = "Annulla",
			Action PositiveAction = null, Action NegativeAction = null){
			AlertDialog.Builder d = new AlertDialog.Builder (this);
			d.SetCancelable (false);
			d.SetMessage (msg);
			d.SetPositiveButton (PositiveText, ( sender,  e) => {
				if (PositiveAction == null) {
					Android.OS.Process.KillProcess(Android.OS.Process.MyPid()); //Chiusura processo applicazione!
				} else {
					PositiveAction.Invoke();
				}
			});
			if (NegativeAction != null) {
				d.SetNegativeButton(NegativeText, (sender, e) => { NegativeAction.Invoke();});
			}
			d.SetTitle (titolo);
			return d;

		}



	}



	[Serializable()]
	public class NumeriRubrica 
	{
		public string TipoNumero { get; set;}
		public string NumeroTelefono { get; set;}

		public NumeriRubrica(string Tipo, string Numero){
			this.TipoNumero = Tipo;
			this.NumeroTelefono = Numero;
		}

		public override bool Equals (object obj)
		{
			var n = obj as NumeriRubrica;
			if (n.NumeroTelefono.Trim() == this.NumeroTelefono.Trim() )
				return true;
			else return false;
		}
		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

	}



	[Serializable()]
	public class RubricaCellW 
	{
		private bool _privato;
		public bool privato {
			get {
				return _privato;
			}
			set {
				_privato = value;
			}
		}
		public string IdContatto { get; set;}
		public string NomeVisualizzato { get; set;}
		public string Cognome { get; set;}
		public string Nome { get; set;}
		public string ImagePath { get; set;}
		//public I Foto { get; set;}
		public List<NumeriRubrica> Numeri{ get; set;}

		public RubricaCellW() {
			this.Numeri = new List<NumeriRubrica> ();
		}

		public RubricaCellW(string cognome, string nome) {
			this.Cognome = cognome;
			this.Nome = nome;
			this.Numeri = new List<NumeriRubrica> ();
		}

		public override string ToString ()
		{
			return this.Cognome + " " + this.Nome;
		}

		public bool findCheck(string txt) {
			if (this.ToString ().ToUpper().Contains (txt.ToUpper ()) ) {
				return true;
			} else {
				return false;
			}
		}


	}

	public enum Ordinamento
	{
		Cognome,Nome,NomeVisualizzato 
	}


	public static class ObjectTypeHelper
	{
		public static T Cast<T>(this Java.Lang.Object obj) where T : class
		{
			var propertyInfo = obj.GetType().GetProperty("Instance");
			return propertyInfo == null ? null : propertyInfo.GetValue(obj, null) as T;
		}
	}


}


