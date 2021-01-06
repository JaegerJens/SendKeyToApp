using System;

namespace SendKeyToApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application List");

            var windows = new WindowsService();

            foreach(var process in windows.getApplications()) {
                if (windows.IsChromeProcess(process)) {
                    Console.WriteLine("Chrome: {0}", process.Id);
                    continue;
                }
                if (process.MainWindowTitle == "") {
                    continue;
                }
                Console.WriteLine("Process \"{0}\" [{1}]", process.MainWindowTitle, process.Id);
            }
        }
    }
}
