using NUnit.Framework;
using ScreenObjectsHelpers.Helpers;
using ScreenObjectsHelpers.Windows.Options;
using ScreenObjectsHelpers.Windows.MenuFolder;
using ScreenObjectsHelpers.Windows.ToolbarTabs;
using System.IO;
using System;

namespace AutomationTestsSolution.Tests
{
    class GitFlowInitialiseTests : BasicTest
    {
        [SetUp]
        public override void SetUp()
        {
            //var resourceName = Resources.customactions;
            //var customActionsFilePath = Environment.ExpandEnvironmentVariables(@"%localappdata%\Atlassian\SourceTree\customactions.xml");
            //RestoreFile(customActionsFilePath);
            //File.WriteAllText(customActionsFilePath, resourceName);
            base.SetUp();
        }
        [Test]
        public void AddCustomAction()
        {
           
        }
    }
}
