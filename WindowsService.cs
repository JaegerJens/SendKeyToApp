using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace SendKeyToApp {
    public class WindowsService {

        public Process[] GetApplications() {
            return Process.GetProcesses();
        }

        public string GetWindowTitle(Process process) {
            var handle = process.MainWindowHandle;
            var length = GetWindowTextLength(handle);
            var outText = new StringBuilder(length + 1);
            var res = GetWindowText(handle, outText, outText.Capacity);
            return outText.ToString();
        }

        public void SendKeyToProcess(Process process, char key) {
            // https://github.com/dotnet/winforms/blob/master/src/System.Windows.Forms/src/System/Windows/Forms/SendKeys.cs#L640
            // https://docs.microsoft.com/en-us/windows/win32/inputdev/keyboard-input
            // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput
            // https://docs.microsoft.com/en-us/dotnet/api/system.windows.input.keyboard.getkeystates?view=net-5.0
            System.Windows.Input.GetKeyStates();
            throw new NotImplementedException();
        }

        [DllImport("user32.dll", SetLastError=true, CharSet=CharSet.Auto)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet=CharSet.Unicode, SetLastError=true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString,
            int nMaxCount);
        }
}