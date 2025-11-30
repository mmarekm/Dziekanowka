using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using WinRT.Interop;
namespace Dziekanowka.WinUI
{
    public partial class App : MauiWinUIApplication
    {
        public App()
        {
            this.InitializeComponent();
        }
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
            var mauiWindow = Application.Windows[0];
            var nativeWindow = mauiWindow.Handler.PlatformView as Microsoft.UI.Xaml.Window;
            var hwnd = WindowNative.GetWindowHandle(nativeWindow);
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);
            var displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Primary);
            var workArea = displayArea.WorkArea;
            int width = 1900;
            int height = 1000;
            appWindow.Resize(new SizeInt32(width, height));
            int left = workArea.X + 5;
            int top = workArea.Y + 5;
            appWindow.Move(new PointInt32(left, top));
        }
    }
}