using System;
using System.IO;
using System.Media;

namespace ChatbotGUI.Services
{
    public class VoiceService
    {
        public void PlayGreeting()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"[SYSTEM] Playing voice greeting: {filePath}");
                Console.ResetColor();

                using (SoundPlayer player = new SoundPlayer(filePath))
                {
                    player.PlaySync();
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("[SYSTEM] Voice greeting completed.");
                Console.ResetColor();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[SYSTEM] Audio device not available. Continuing...");
                Console.ResetColor();
            }
        }
    }
}