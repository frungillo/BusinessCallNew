
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

namespace RubricaNew
{
	[Activity (
		Label = "Rubrica ANM",
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
		bool CaricaPrivati = false;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			ListView lst = FindViewById<ListView> (Resource.Id.listView1);
			EditText txtRicerca = FindViewById<EditText> (Resource.Id.txtricerca );
			ImageButton btnChiama = FindViewById<ImageButton> (Resource.Id.btnChiama);

			/*EventoClickBottone*/
			btnChiama.Click += delegate {
				Intent i = new Intent(this, typeof(CallPhoneActivity));
				StartActivity(i);
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
					 
					//CompilaLista (lst, false, IMEI);
					str.Close();

				} catch {

					str.Close ();
					CompilaLista (lst, true, IMEI);
				}
			} else {
				CompilaLista (lst, true, IMEI);
			}
		}



		private void SalvaSettaggi(){
			StreamWriter w = new StreamWriter ((Application.GetExternalFilesDir ("") + "/prefs.txt"), false);
			w.WriteLine (CaricaPrivati);
			w.Flush ();
			w.Close ();
			/*
			var prefs = this.GetSharedPreferences ("it.anm.rubrica", FileCreationMode.Private);
			var prefEdit = prefs.Edit ();
			prefEdit.PutBoolean ("CaricaPrivati", CaricaPrivati);
			prefEdit.Commit ();
			*/
		}

		private void CaricaSettaggi() {
			try {
				StreamReader r = new StreamReader ((Application.GetExternalFilesDir ("") + "/prefs.txt"));
				CaricaPrivati = (r.ReadLine () == "True") ? true:false;
				r.Close ();
			} catch (Exception) {
			}
			/*
			var prefs = this.GetSharedPreferences ("it.anm.rubrica", FileCreationMode.Private);
			CaricaPrivati = prefs.GetBoolean ("CaricaPrivati", false);
			*/
		}


		private void CompilaLista(ListView lista, bool reloadFromService, String IMEI) {
			prepareWaitDialog ("Caricamento rubrica in corso...", false).Show();
			Thread t = new Thread (() => {
				DatiRubrica.Clear();
				var book = new AddressBook(this);
				book.PreferContactAggregation = true;
				List<Contact> cnt = new List<Contact>();
				foreach (Contact contr in book) {
					cnt.Add(contr);
				}

				foreach (Contact contatto in cnt) {

					RubricaCellW rubItem = new RubricaCellW();
					rubItem.Cognome = contatto.LastName ;
					rubItem.Nome =contatto.FirstName;
					
					bool flagTrovato = false ;
					
					foreach(Phone tel in contatto.Phones) 
					{
						if (tel.Number != "") {
							rubItem.Numeri.Add(new NumeriRubrica(tel.Label,tel.Number));
							flagTrovato = true ;
						}

					}
					try
					{
						if (flagTrovato) {
							DatiRubrica.Add(rubItem);
						}

					} catch (Exception ex) {
						MsgBox("err:"+ex.Message);
					}
				}

				RunOnUiThread (()=>{
					dialog.Dismiss();
					lista.Adapter = new AdattatoreLista (this, DatiRubrica); 
					lista.ChoiceMode = ChoiceMode.Single;
					lista.FastScrollEnabled = true;
					lista.ItemClick -= OnListItemClick;
					lista.ItemClick += new EventHandler <AdapterView.ItemClickEventArgs> (OnListItemClick); 
				});


				/**
				RunOnUiThread (delegate {
					dialog.Dismiss();
					Toast.MakeText (ApplicationContext, "Caricamento Completato...", ToastLength.Long).Show ();
					//Creazione delle righe nella ListView
					lista.Adapter = new AdattatoreLista (this, DatiRubrica); //Classe di adattamento per la lista contatti;
					lista.ChoiceMode = ChoiceMode.Single;
					lista.FastScrollEnabled = true;
					lista.ItemClick -= OnListItemClick;
					lista.ItemClick += new EventHandler <AdapterView.ItemClickEventArgs> (OnListItemClick); //listner click lista
					//Elimino il file prima di ricrearlo

					File.Delete(Application.GetExternalFilesDir ("") + "/array.bin");
					//Serializzo le informazioni in un file binario per recuperarle più velocemente
					FileStream str = File.Create (Application.GetExternalFilesDir ("") + "/array.bin");
					BinaryFormatter bf = new BinaryFormatter ();
					bf.Serialize (str, DatiRubrica);
					str.Flush();
					str.Close();
				});*///


			});
			/*
				lista.Adapter = new AdattatoreLista (this, DatiRubrica); //new ArrayAdapter( this, Android.Resource.Layout.SimpleListItem2, DatiRubrica);
				lista.ChoiceMode = ChoiceMode.Single;
				lista.FastScrollEnabled = true;
				lista.ItemClick -= OnListItemClick;
				lista.ItemClick += new EventHandler <AdapterView.ItemClickEventArgs> (OnListItemClick); //listner click lista
				*/
			t.Start ();

		}

		/*FINE COMPILA LISTA*/

		public override bool OnPrepareOptionsMenu (IMenu menu)
		{
			CaricaSettaggi ();
			menu.Clear ();
			menu.Add(0,0,0,"Aggiorna contatti");
			menu.Add (1, 1, 1, "Mostra Privati");
			menu.SetGroupCheckable (1, true,false);
			menu.GetItem (1).SetCheckable (true);
			menu.GetItem (1).SetChecked (CaricaPrivati);
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
			case 1: //Do stuff for button 1
				CaricaPrivati = (CaricaPrivati) ? false : true;
				SalvaSettaggi ();
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

			PopupMenu mnu = new PopupMenu (this, e.View);
			mnu.Inflate (Resource.Menu.contexMenu);
			IMenuItem itmNominativo = mnu.Menu.GetItem (0);
			/*
			IMenuItem itmUtenza = mnu.Menu.GetItem (1);
			IMenuItem itmNumero1 = mnu.Menu.GetItem (2);
			IMenuItem itmNumero2 = mnu.Menu.GetItem (3);
			IMenuItem itmNumero3 = mnu.Menu.GetItem (4);

			itmNominativo.SetTitle (sel.Cognome+" "+sel.Nome);
			itmNominativo.SetEnabled (false);

			itmUtenza.SetTitle (sel.Utenza);
			if (sel.Numero1 == "") {
				itmNumero1.SetVisible (false);
			} else {
				itmNumero1.SetTitle (sel.Numero1);
			}
			if (sel.Numero2 == "") {
				itmNumero2.SetVisible (false);
			} else {
				itmNumero2.SetTitle (sel.Numero2);
			}
			if (sel.Numero3 == "") {
				itmNumero3.SetVisible (false);
			} else {
				itmNumero3.SetTitle (sel.Numero3);
			}
			*/

			mnu.MenuItemClick += (s1, arg1) => {
				ChiamaNumero(arg1.Item.TitleFormatted.ToString());

			};

	

			mnu.Show();

		}



		private void ChiamaNumero(string Numero) {
			Intent c = new Intent (Intent.ActionCall);
			c.SetData (Android.Net.Uri.Parse ("tel:" + Numero));
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

		public string Cognome { get; set;}
		public string Nome { get; set;}
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

	public static class ObjectTypeHelper
	{
		public static T Cast<T>(this Java.Lang.Object obj) where T : class
		{
			var propertyInfo = obj.GetType().GetProperty("Instance");
			return propertyInfo == null ? null : propertyInfo.GetValue(obj, null) as T;
		}
	}


}


