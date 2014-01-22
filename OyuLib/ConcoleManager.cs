using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using System.IO;

namespace OyuLib
{
    public static class ConcoleManager
    {
        public static void Exec(string currentPath, string exeName, string optionAndParam)
        {
            Process.Start(Path.Combine(currentPath, exeName), optionAndParam);
        }

        public static void Exec(string exePath, string optionAndParam)
        {
            Process.Start(exePath, optionAndParam);
        }
    }
}
