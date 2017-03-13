using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;

namespace ScreenObjectsHelpers.Windows.Options
{
    public abstract class OptionsWindow : GeneralWindow
    {

        public OptionsWindow(Window mainWindow, UIItemContainer optionsWindow) : base(mainWindow)
        {
            OptionsWindowContainer = optionsWindow;
            ClickOnTab();
        }

        #region UIElements
        public abstract UIItem UIElementTab
        {
            get;
        }
        public UIItemContainer OptionsWindowContainer
        {
            get;
        }

        private Button OK
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("OK"));
            }
        }
        #endregion

        #region Methods
        public T OpenTab<T>() where T : OptionsWindow
        {
            return (T)Activator.CreateInstance(typeof(T), MainWindow, OptionsWindowContainer);
        }

        public virtual void ClickOnTab()
        {
            UIElementTab.Click();
        }

        public void ClickOkButton()
        {
            this.OK.Click();
        }
        #endregion

    }
}
