using System;

namespace SendKeyToApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application List");
            var player = PlayerController.FindYoutubePlayer();
        }
    }
}
