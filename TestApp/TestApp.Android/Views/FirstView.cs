using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace TestApp.Android.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            LayoutInflater.Factory = MyViewFactory.Instance;
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}
