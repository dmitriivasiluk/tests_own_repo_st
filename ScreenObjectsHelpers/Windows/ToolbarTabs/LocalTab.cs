using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace ScreenObjectsHelpers.Windows.ToolbarTabs
{
    public class LocalTab : NewTabWindow
    {
        public LocalTab(Window mainWindow) : base(mainWindow)
        {
        }

        public override UIItem ToolbarTabButton
        {            
            get
            {
                try
                {
                    return MainWindow.Get<UIItem>(SearchCriteria.ByText("Local"));
                }
                catch (AutomationException)
                {                    
                    return null;
                }                
            }            
        }


        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING TAB");
        }
    }
}
