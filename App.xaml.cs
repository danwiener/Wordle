namespace Worlde;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		var width = 2400;
		var height = 1800;
		Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
		{
#if WINDOWS
			var nativeWindow = handler.PlatformView;
			nativeWindow.Activate();
			IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
			Microsoft.UI.WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
			Microsoft.UI.Windowing.AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
			//TODO: this is hardcoded stuff for fullhd
			appWindow.MoveAndResize(new Windows.Graphics.RectInt32((2400 / 2) - width / 2, (1800 / 2) - height / 2, width, height));
#endif
		});


		MainPage = new AppShell();
	}
}
