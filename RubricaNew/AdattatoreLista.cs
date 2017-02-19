using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace BusinessCall
{
	public class AdattatoreLista: BaseAdapter<RubricaCellW>
	{
		private readonly List<RubricaCellW> _rubricaCellW;
		private readonly Activity _activity;

		public AdattatoreLista (Activity activity, List<RubricaCellW> rubCellw, Ordinamento o = Ordinamento.Cognome ) : base()
		{
			switch (o) {
			case Ordinamento.Cognome: 
				_rubricaCellW = rubCellw.OrderBy (s => s.Cognome).ToList ();
				break;
				
			case Ordinamento.Nome: 
				_rubricaCellW = rubCellw.OrderBy (s => s.Nome).ToList ();
				break;
			case Ordinamento.NomeVisualizzato:
				_rubricaCellW = rubCellw.OrderBy (s => s.NomeVisualizzato).ToList ();
				break;
			default:
				break;
			}

			_activity = activity;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override RubricaCellW this [int position] {
			get { return _rubricaCellW [position]; }
		}

		public override int Count {
			get { return _rubricaCellW.Count; }
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView;

			if (view == null) {
				view = _activity.LayoutInflater.Inflate (Android.Resource.Layout.ActivityListItem, null);
			}


			var rub = _rubricaCellW [position];
			ImageView img = view.FindViewById<ImageView> (Android.Resource.Id.Icon);
			try {
				Android.Graphics.Bitmap bm = Android.Graphics.BitmapFactory.DecodeFile (rub.ImagePath);
				Matrix m = new Matrix();
				m.SetRectToRect(new RectF(0, 0, bm.Width, bm.Height), new RectF(0, 0, 48, 48), Matrix.ScaleToFit.Center);
				Bitmap newBitMap = Bitmap.CreateScaledBitmap(bm, 48, 48, false); // Bitmap.CreateBitmap(bm, 0, 0, bm.Width, bm.Height, m, true);
				img.SetImageBitmap(newBitMap);


			} catch {
				
			}


			TextView text1 = view.FindViewById<TextView> (Android.Resource.Id.Text1);
			text1.Text = rub.ToString ();
			text1.SetTextColor (Android.Graphics.Color.LightSalmon);
			text1.SetTextSize (Android.Util.ComplexUnitType.Px, 60); //34
			/*
			TextView text2 = view.FindViewById<TextView> (Android.Resource.Id.Text2);
			text2.Text = "";
			foreach (NumeriRubrica itm in rub.Numeri) {
					text2.Text += "[" + itm.TipoNumero + "] " + itm.NumeroTelefono + "\r\n";
			}
			*/
			return view;
		}
	}
}