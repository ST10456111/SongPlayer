using System;
using System.IO;
using System.Media;


namespace ice02
{
    class WorkerClass
    {
        private string[] wavFiles = {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"tech-house-loop-124-bpm-bandcamp-249455.wav"),
                 Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"deep-house-pluck-25180.wav"),
                 Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"2-euro-sample-packs-bandcamp-249333.wav")
            };

        private bool[] played = { false, false, false };

        public void PlayMusic()
        {
            while (true)
            {
                DisplayMenu();
                Console.Write("Enter option (1-3) or 0 to Exit: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.WriteLine("Exiting Application...");
                    break;
                }

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)
                {
                    PlayWav(choice - 1);
                }
                else
                {
                    Console.WriteLine("Invalid Option! Please select between 1-3.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Select a wav file to play:");
            for (int i = 0; i < wavFiles.Length; i++)
            {
                if (played[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine($"{i + 1}. {Path.GetFileName(wavFiles[i])}");
                Console.ResetColor();
            }
        }


        private void PlayWav(int index)
        {
            try
            {
                SoundPlayer player = new SoundPlayer(wavFiles[index]);
                player.PlaySync();
                played[index] = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}