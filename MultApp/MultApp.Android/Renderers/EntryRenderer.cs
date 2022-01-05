using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Renderers;
using Android.OS;
using Multapp.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(WhiteLineEntry), typeof(MyEntryRenderer))]
namespace Android.Renderers
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) : base(context)
        {
        }
        public WhiteLineEntry ElementV2 => Element as WhiteLineEntry;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                Control.BackgroundTintList = ColorStateList.ValueOf(Color.White);
            else
                Control.Background.SetColorFilter(Color.White, PorterDuff.Mode.SrcAtop);
        }
    }
}