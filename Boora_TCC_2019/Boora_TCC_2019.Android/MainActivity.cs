using System;
using FFImageLoading.Forms.Platform;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;
using ImageCircle.Forms.Plugin.Droid;

namespace Boora_TCC_2019.Droid
{
    [Activity(Label = "BoORa!", Icon = "@drawable/iconApp", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
           
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            ImageCircleRenderer.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true); //Adicionado para utilizar FFloading
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            CrossCurrentActivity.Current.Init(this, savedInstanceState);//adiconado para usar o ckebox
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //
        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }

        protected override void OnResume()
        {
            
            base.OnResume();
        }
        protected override void OnStart()
        {
            
            base.OnStart();
        }
        protected override void OnStop()
        {
            
            base.OnStop();
        }
        protected override void OnRestart()
        {

            base.OnRestart();
        }
    }
}