using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows
{
    public class AuthorizationWindow : BasicWindow
    {
        private Window authorizationWindow;

        public AuthorizationWindow(Window mainWindow, Window authorizationWindow) : base(mainWindow)
        {
            this.authorizationWindow = authorizationWindow;
        }

        public void ValidateWindow()
        {

        }

    }
}
