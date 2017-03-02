﻿using System;
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
    public class UpdatesTab : OptionsWindow
    {

        private UIItem updatesFromOptionTab;

        public UpdatesTab(Window mainWindow, UIItemContainer optionsWindow, UIItem updateTab) : base(mainWindow, optionsWindow)
        {
            updatesFromOptionTab = updateTab;
        }

        public override void ValidateWindow()
        {
            // Need verify opened tab in this method, need implementation! If validation is fail, throw exception!
            Console.WriteLine("WAIT FOR OPENING TAB");
        }

        #region UI Elements
        public Button CheckForUpdatesButton
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("Check For Updates"));
            }
        }
        private Button OK
        {
            get
            {
                return OptionsWindowContainer.Get<Button>(SearchCriteria.ByText("OK"));
            }
        }
        #endregion

        public void CheckForUpdate()
        {
            this.ClickOnButton(CheckForUpdatesButton);
            this.ClickOnButton(OK);
        }
    }
}