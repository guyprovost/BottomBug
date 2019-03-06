using Android.OS;
using Android.Views;

namespace BottomBug.Fragments
{
	public class FragmentThree : Android.Support.V4.App.Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

		}

		public static FragmentThree NewInstance()
		{
			var frag3 = new FragmentThree { Arguments = new Bundle() };
			return frag3;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.fragment_three, null);

			return view;
		}
	}
}