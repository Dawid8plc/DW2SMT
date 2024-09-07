using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace DW2SMT.Managers
{
    static internal class RegistryManager
    {
        public static void Initialize()
        {
            string exePath = "\"" + (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location) + ".exe") + "\" \"%1\"";

            bool updateExplorer = false;

            RegistryKey curUser = Registry.CurrentUser;

            var curUserKey = curUser.OpenSubKey(@"Software\Classes", true);

            //Stage 1 - Create DW2SMT registry key
            var dasmt = curUserKey.OpenSubKey(@"dw2smt", true);

            if (dasmt == null)
            {
                dasmt = curUserKey.CreateSubKey("dw2smt");
            }

            dasmt.SetValue("", "Dawid's Worms 2 Language");
            dasmt.SetValue("URL Protocol", "\"\"");

            var shellKey = dasmt.CreateSubKey("shell");
            var openKey = shellKey.CreateSubKey("open");
            var commandKey = openKey.CreateSubKey("command");

            object commandValue = commandKey.GetValue("");
            if (commandValue != null)
            {
                string a = commandValue.ToString();

                if (a != exePath)
                {
                    commandKey.SetValue("", exePath, RegistryValueKind.String);

                    updateExplorer = true;
                }
            }
            else
            {
                commandKey.SetValue("", exePath, RegistryValueKind.String);

                updateExplorer = true;
            }

            //Stage 2 - Create .dw2lang file association
            var dasp = curUserKey.OpenSubKey(@".dw2lang", true);

            if (dasp == null)
            {
                dasp = curUserKey.CreateSubKey(".dw2lang");
            }

            object daspValue = dasp.GetValue("");
            if (daspValue != null)
            {
                string a = daspValue.ToString();

                if (a != "dw2smt")
                {
                    dasp.SetValue("", "dw2smt");

                    updateExplorer = true;
                }
            }
            else
            {
                dasp.SetValue("", "dw2smt");

                updateExplorer = true;
            }

            //Tell explorer that we added/updated the file association, and now it has to refresh its icons and such
            if (updateExplorer)
            {
                SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
    }
}
