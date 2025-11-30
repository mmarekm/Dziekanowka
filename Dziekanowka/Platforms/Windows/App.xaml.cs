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

            if (Application.Windows.Count == 0)
                return;

            var mauiWindow = Application.Windows[0];

            if (mauiWindow?.Handler?.PlatformView is not Microsoft.UI.Xaml.Window nativeWindow)
                return;

            var hwnd = WindowNative.GetWindowHandle(nativeWindow);
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);
            var displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Primary);
            var workArea = displayArea.WorkArea;

            int width = 1932;
            int height = 1045;
            appWindow.Resize(new SizeInt32(width, height));

            int left = workArea.X;
            int top = workArea.Y + 1;
            appWindow.Move(new PointInt32(left, top));
        }
    }
}