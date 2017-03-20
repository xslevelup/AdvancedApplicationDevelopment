using System;
using System.Linq;

namespace RestService
{
    public class Game
    {
        private static Random rnd = new Random();

        public static string  CreateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = string.Format("Q-{0}", Convert.ToBase64String(time.Concat(key).ToArray()));
            return token;
        }

        public int Number { get; set; }
        public int Guesses { get; set; }
        public string LastGuessMessage { get; set; }

        public Game()
        {
            Number = rnd.Next(100);
            Guesses = 0;
        }

        public int Guess(int guess)
        {
            Guesses++;
            LastGuessMessage = "win";

            if (Number > guess)
            {
                LastGuessMessage = "TooLow";
                return -1;
            }

            if (Number < guess)
            {
                LastGuessMessage = "TooHigh";
                return 1;
            }

            return 0;
        }
    }
}