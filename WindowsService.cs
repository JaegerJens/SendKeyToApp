using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace SendKeyToApp {
    public class WindowsService {

        public Process[] getApplications() {
            return Process.GetProcesses();
        }

        public string getWindowTitle(Process process) {
            var handle = process.MainWindowHandle;
            var length = GetWindowTextLength(handle);
            var outText = new StringBuilder(length + 1);
            var res = GetWindowText(handle, outText, outText.Capacity);
            return outText.ToString();
        }

        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString,
            int nMaxCount);
        }
}