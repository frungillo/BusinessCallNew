using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;

namespace RubricaNew
{
	public class AdattatoreLista: BaseAdapter<RubricaCellW>
	{
		private readonly List<RubricaCellW> _rubricaCellW;
		private readonly Activity _activity;

		public AdattatoreLista (Activity activity, List<RubricaCellW> rubCellw)
		{
			_rubricaCellW = rubCellw;//.OrderBy (s => s.Nome).ToList ();
			_activity = activity;
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override RubricaCellW this [int index] {
			get { return _rubricaCellW [index]; }
		}

		public override int Count {
			get { return _rubricaCellW.Count; }
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var view = convertView;

			if (view == null) {
				view = _activity.LayoutInflater.Inflate (Android.Resource.Layout.SimpleListItem2, null);
			

				var rub = _rubricaCellW [position];

				TextView text1 = view.FindViewById<TextView> (Android.Resource.Id.Text1);
				text1.Text = rub.ToString();
				text1.SetTextColor (Android.Graphics.Color.LightSalmon);
				TextView text2 = view.FindViewById<TextView> (Android.Resource.Id.Text2);
				foreach (NumeriRubrica itm in rub.Numeri ) {
					text2.Text += "[" + itm.TipoNumero  + "] " + itm.NumeroTelefono + "\r\n";
				}

			}

			return view;
		}
	}
}