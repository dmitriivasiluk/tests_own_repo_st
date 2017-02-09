using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Linq;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.WindowsAPI;
using TestStack.White;
using NUnit.Framework;
using TestStack.White.UIItems.WindowItems;


namespace SourceTreeAutomation.Tests
{
    class BasicTest
    {
        protected Window MainWindow;
        [SetUp]
        public void SetUp()
        {
           MainWindow = Desktop.Instance.Windows().FirstOrDefault(x => x.Name == "SourceTree");
        }
        public void ifSourceTreeOpened()
        {

        }
    }
}
