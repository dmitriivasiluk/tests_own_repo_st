using System.Drawing.Imaging;
using System.Drawing;
using System.Windows;
using TestStack.White;

namespace SourceTreeAutomation.Helpers
{
    public class ScreenshotsTaker {
        public void  TakeScreenShot() {
            ScreenCapture sc = new ScreenCapture();
            // capture entire screen, and save it to a file
            Bitmap img = sc.CaptureScreenShot();
            img.Save("test.jpg", ImageFormat.Jpeg);
            
        }
    }
}