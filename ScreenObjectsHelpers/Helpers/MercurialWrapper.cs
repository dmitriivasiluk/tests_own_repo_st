using System;
using System.Diagnostics;

namespace ScreenObjectsHelpers.Helpers
{
    public class MercurialWrapper
    {
        private static readonly string PathToEmbeddedHg = Environment.ExpandEnvironmentVariables(ConstantsList.pathToEmbeddedHg);
        public const string HgInit = "init";


        public static Tuple<string, string> HgRun(string command, string path)
        {
            var args = string.Join(" ", command, path);

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = PathToEmbeddedHg;
            p.StartInfo.Arguments = args;
            p.Start();
            var error = p.StandardError.ReadToEnd();
            var output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

           return new Tuple<string, string>(error, output);
        }
    }
}
