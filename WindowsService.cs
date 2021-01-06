using System.Diagnostics;

namespace SendKeyToApp {
    public class WindowsService {
        private static string ChromeProcessName = "chrome";

        public Process[] getApplications() {
            return Process.GetProcesses();
        }

        public bool IsChromeProcess(Process process) {
            return process.ProcessName == ChromeProcessName;
        }
    }
}