using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Gms.Maps;
using Android.Util;
using BottomBug.Fragments;

namespace BottomBug
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, NoHistory = true)]
	public class MainActivity : AppCompatActivity, IOnMapReadyCallback
	{

		BottomNavigationView bottomNavigation;
		public Android.Gms.Maps.SupportMapFragment fragmentMap = FragmentOne.NewInstance();
		public Android.Support.V4.App.Fragment fragmentSecond = FragmentTwo.NewInstance();
		public Android.Support.V4.App.Fragment fragmentThird = FragmentThree.NewInstance();
		public int currentTab = Resource.Id.menu_map;
		public bool alreadyGeoLoc = false;
		public GoogleMap map = null;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_main);
			bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);
			bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
			LoadInitialFragment(Resource.Id.menu_map);

		}

		public void OnMapReady(GoogleMap googleMap)
		{
			Log.Info("BottomBug", "Map is ready...");
			googleMap.UiSettings.ZoomControlsEnabled = true;
			googleMap.UiSettings.ZoomGesturesEnabled = true;
			googleMap.UiSettings.MyLocationButtonEnabled = true;
			googleMap.UiSettings.RotateGesturesEnabled = true;
			googleMap.UiSettings.ScrollGesturesEnabled = true;
			map = googleMap;
		}

		private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
		{
			LoadFragment(e.Item.ItemId, currentTab);
			currentTab = e.Item.ItemId;
		}

		void LoadInitialFragment(int id)
		{
			fragmentMap.GetMapAsync(this);
			SupportFragmentManager.BeginTransaction().Add(Resource.Id.content_frame, fragmentMap, "ONE").Commit();
			SupportFragmentManager.BeginTransaction().Add(Resource.Id.content_frame, fragmentSecond, "TWO").Commit();
			SupportFragmentManager.BeginTransaction().Add(Resource.Id.content_frame, fragmentThird, "THREE").Commit();
			SupportFragmentManager.BeginTransaction().Hide(fragmentSecond).Commit();
			SupportFragmentManager.BeginTransaction().Hide(fragmentThird).Show(fragmentMap).Commit();
			currentTab = Resource.Id.menu_map;
		}

		void LoadFragment(int theFragment, int preFragment)
		{
			switch (theFragment)
			{
				case Resource.Id.menu_map:
					switch (preFragment)
					{
						case Resource.Id.menu_two:
							SupportFragmentManager.BeginTransaction().Hide(fragmentSecond).Show(fragmentMap).Commit();
							break;
						case Resource.Id.menu_three:
							SupportFragmentManager.BeginTransaction().Hide(fragmentThird).Show(fragmentMap).Commit();
							break;
					}
					break;

				case Resource.Id.menu_two:

					switch (preFragment)
					{

						case Resource.Id.menu_map:
							SupportFragmentManager.BeginTransaction().Hide(fragmentMap).Show(fragmentSecond).Commit();
							break;
						case Resource.Id.menu_three:
							SupportFragmentManager.BeginTransaction().Hide(fragmentThird).Show(fragmentSecond).Commit();
							break;
					}
					break;

				case Resource.Id.menu_three:

					switch (preFragment)
					{

						case Resource.Id.menu_map:
							SupportFragmentManager.BeginTransaction().Hide(fragmentMap).Show(fragmentThird).Commit();
							break;
						case Resource.Id.menu_two:
							SupportFragmentManager.BeginTransaction().Hide(fragmentSecond).Show(fragmentThird).Commit();
							break;
					}
					break;
			}

		}
	}
}