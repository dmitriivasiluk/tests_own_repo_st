using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows
{
    public class DownloadHgWindow : GeneralWindow
    {
        public DownloadHgWindow(Window mainWindow, UIItemContainer downloadHgWindow) : base(mainWindow)
        {
            DownloadHgWindowContainer = downloadHgWindow;
        }

        public UIItemContainer DownloadHgWindowContainer { get; }
        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING _DownloadHg_ WINDOW");
        }
    }
}
