using Android.OS;
using Android.Views;

namespace BottomBug.Fragments
{
	public class FragmentTwo : Android.Support.V4.App.Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public static FragmentTwo NewInstance()
		{
			var frag2 = new FragmentTwo { Arguments = new Bundle() };
			return frag2;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);

			View view = inflater.Inflate(Resource.Layout.fragment_two, null);

			return view;
		}
	}
}