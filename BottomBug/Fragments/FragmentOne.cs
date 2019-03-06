using Android.OS;
using Android.Views;

namespace BottomBug.Fragments
{
	public class FragmentOne : Android.Gms.Maps.SupportMapFragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

		}

		public override void OnResume()
		{
			base.OnResume();
		}

		public override void OnStop()
		{
			base.OnStop();
		}

		public override void OnDestroyView()
		{
			base.OnDestroyView();
		}

		public static FragmentOne GetNewInstance()
		{
			var frag1 = new FragmentOne { Arguments = new Bundle() };
			return frag1;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{

			var ignored = base.OnCreateView(inflater, container, savedInstanceState);

			return base.OnCreateView(inflater, container, savedInstanceState);
		}

		public override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
		}
	}
}