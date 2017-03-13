using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Win32;

namespace AutomationTestsSolution.Helpers
{
    public class UninstallSourceTree
    {
        private const string nameOfProgram = "SourceTree";

        public void DeleteSourceTree()
        {
            string uninstallCommandSourceTree = GetUninstallCommandFor(nameOfProgram);
            if (uninstallCommandSourceTree != null && uninstallCommandSourceTree != "")
            {
                ExecuteWindowsCommand(uninstallCommandSourceTree);
                // Give a time for removing SourceTree
                Console.WriteLine("Waiting 5 seconds for complete uninstall...");
                Thread.Sleep(5000);
            }
            RemoveFoldersSourceTree();
            Console.WriteLine("SourceTree was successfully removed from computer!");
        }

        public static void ExecuteWindowsCommand(string commandForExecute)
        {
            string windowProgram = "cmd";
            Console.WriteLine("Executing uninstall command in cmd.exe...");
            Process.Start(windowProgram, "/C " + commandForExecute);
            Console.WriteLine("Executing is finished!");
        }

        /// <summary>
        /// This method remove all necessary folders owned to SourceTree. Also it find dynamic folders in 
        /// C:\Users\%USERNAME%\AppData\Local\Atlassian like "SourceTree.exe_Url_qsuikde1gcnj3eovksjtmq0msq50grno" and romove it.
        /// </summary>
        public void RemoveFoldersSourceTree()
        {
            // Static folders SourceTree
            List<string> pathsForSourceTree = new List<string>();
            pathsForSourceTree.Add(Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\AppData\Local\SourceTree"));
            pathsForSourceTree.Add(Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\AppData\Local\SourceTreeBeta"));
            pathsForSourceTree.Add(Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\AppData\Local\SourceTree-Settings"));
            pathsForSourceTree.Add(Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\AppData\Local\SquirrelTemp"));

            // Need to find out dynamic name of folders which owned SourceTree in Atlassian folder
            string pathAtlassian = Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\AppData\Local\Atlassian");
            string[] fileArray = Directory.GetDirectories(pathAtlassian);
            for (int i = 0; i < fileArray.Length; i++)
            {
                if (fileArray[i].Contains("SourceTree"))
                {
                    pathsForSourceTree.Add(fileArray[i]);
                }
            }

            foreach (string pathToSourceTree in pathsForSourceTree)
            {
                try
                {
                    Directory.Delete(pathToSourceTree, true);
                    Console.WriteLine($"Directory {pathToSourceTree} was removed!");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"You don't have access to remove {pathToSourceTree}");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine($"Directory {pathToSourceTree} is not found.");
                }
            }
        }

        /// <summary>
        /// This method finds DisplayName in registries with path 
        /// HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrectVersion\Uninstall and
        /// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrectVersion\Uninstall
        /// When it finds the current program, it gets UninstallString or QuietUninstallString uninstall command for executing it from command line.
        /// </summary>
        /// <param name="productDisplayName">A part of name program which want to uninstall</param>
        /// <returns>Command for uninstall current program using cmd.exe</returns>
        public static string GetUninstallCommandFor(string productDisplayName)
        {
            string uninstallCommand = "";
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            List<RegistryKey> differentRegisteryFolder = new List<RegistryKey>();
            differentRegisteryFolder.Add(Registry.LocalMachine.OpenSubKey(registry_key));
            differentRegisteryFolder.Add(Registry.CurrentUser.OpenSubKey(registry_key));

            // loop for different registries
            foreach (RegistryKey openSubKeys in differentRegisteryFolder)
            {
                using (RegistryKey key = openSubKeys)
                {
                    Console.WriteLine($"Start looking for {productDisplayName} in registry - {key.Name}");
                    foreach (string subkey_name in key.GetSubKeyNames())
                    {
                        using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                        {
                            string displayName = (string)subkey.GetValue("DisplayName");
                            if (displayName != null && displayName.Contains(productDisplayName))
                            {
                                var QuiteUninstallCommand = subkey.GetValue("QuietUninstallString");
                                if (QuiteUninstallCommand != null)
                                {
                                    uninstallCommand = (string)QuiteUninstallCommand;
                                    Console.WriteLine("Quite uninstall is present!");
                                    Console.WriteLine($"Uninstall command is {uninstallCommand}");
                                    return uninstallCommand;
                                }
                                uninstallCommand = (string)subkey.GetValue("UninstallString") + " /S"; //Additional key for silence Uninstall;
                                Console.WriteLine($"Uninstall command is {uninstallCommand}");
                                return uninstallCommand;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Program {productDisplayName} is not found.");
            return uninstallCommand;
        }

        public bool isExist()
        {
            string uninstallCommandSourceTree = GetUninstallCommandFor(nameOfProgram);
            if (uninstallCommandSourceTree != null && uninstallCommandSourceTree != "")
            {
                return true;
            }
            return false;
        }
    }
}
