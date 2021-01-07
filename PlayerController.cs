using System;
using System.Diagnostics;

namespace SendKeyToApp {
    public class PlayerController {
        private static string ChromeProcessName = "chrome";
        private static string YoutubePlayerName = "YouTube Music";

        private Process process;

        private PlayerController(Process process) {
            this.process = process;
            Console.WriteLine("YouTube Music Process {0}", process.Id);
        }

        public static PlayerController FindYoutubePlayer() {
            var windows = new WindowsService();
            foreach(var process in windows.GetApplications()) {
                if (process.ProcessName != ChromeProcessName) {
                    continue;
                }
                var title = windows.GetWindowTitle(process);
                if (title.Contains(YoutubePlayerName)) {
                    return new PlayerController(process);
                }
            }
            throw new Exception("Process " + YoutubePlayerName + " not found");
        }
    }
}