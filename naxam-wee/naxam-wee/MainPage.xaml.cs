using System;
using Naxam.Controls.Mapbox.Forms;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace naxamwee
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            On<iOS>().SetUseSafeArea(true);
            var viewModel = new MainPageViewModel();
            BindingContext = viewModel;
            InitializeComponent();

//            viewModel.UpdateViewPortAction(new Position(30, -110), 11, null, true,
//                () => { System.Diagnostics.Debug.WriteLine("Map Moved"); });
        }
    }

    public static class MapboxConfig
    {
        public static string AccessToken { get; } = "sk.eyJ1IjoibmF4YW10ZXN0IiwiYSI6ImNqNWtpb2d1ZzJpMngyd3J5ZnB2Y2JhYmQifQ.LEvGqQkAqM4MO3ZtGbQrdw";
        public static string DefaultStyle { get; } = "mapbox://styles/kevinactualize/cjlwdwb6b3hsj2sp7baxo4j19";
    }

    public class MainPageViewModel
    {
        public string Message => "Do you see a map?";

        public double ZoomLevel { get; set; } = 11;
        public Position Center { get; set; } = new Position(25, -100);
        public MapStyle MapStyle { get; set; } = new MapStyle(MapboxConfig.DefaultStyle);
        public Action<Position, double?, double?, bool, Action> UpdateViewPortAction { get; set; }
    }
}
