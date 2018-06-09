using Android.App;
using Android.Widget;
using Android.OS;
using OffAreaApp.Repository;
using Android.Graphics;

namespace OffArea
{
    [Activity(Label = "صفحه ورود", MainLauncher = true, Icon = "@drawable/mainIcon", Theme ="@android:style/Theme.Material.Light.DarkActionBar")]    
    public class MainActivity : Activity
    {
        ApiRepository Od = new ApiRepository();
        private Button btnLogin;
        private TextView txtUsername;
        private TextView txtPassword;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //CalligraphyConfig.InitDefault(new CalligraphyConfig.Builder()
            //.SetDefaultFontPath("fonts/BNazanin.ttf")
            //.SetFontAttrId(Resource.Attribute.fontPath)
            //.Build());        

            SetContentView(Resource.Layout.Main);
            txtPassword = FindViewById<TextView>(Resource.Id.txtPassword);
            txtUsername = FindViewById<TextView>(Resource.Id.txtUsername);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.SetBackgroundColor(Color.PaleGreen);
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            if(Od.IsUserValid(txtUsername.Text, txtPassword.Text))
                StartActivity(typeof(OrderAvtivity));
            else
            {
                Toast.MakeText(this, "نام کاربری یا کلمه عبور اشتباه است", ToastLength.Long);
            }
        }
    }
}

