using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Webkit;

namespace Aplicativo_Gerenciador
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.DayNight.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private WebView webView;
        private string url = "http://192.168.1.65";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);
            webView = FindViewById<WebView>(Resource.Id.webView);
            webView.SetWebViewClient(new ExtendWebViewclient());
            webView.LoadUrl(url);
            WebSettings webSettings = webView.Settings;
            webSettings.JavaScriptEnabled = true;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    internal class ExtendWebViewclient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            view.LoadUrl("http://192.168.1.65");
            return true;
        }

        public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
        {
            view.LoadUrl("file:///android_asset/404/index.html");
        }
    }
}