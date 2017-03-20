using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RestService : IRestService
    {
        private static Dictionary<string, Game> games = new Dictionary<string, Game>();

        public RegisterResult RegisterGame()
        {
            string token = Game.CreateToken();
            games[token] = new Game();
            return new RegisterResult("ok", token);
        }

        public GuessResult MakeGuess(GuessRequest req)
        {
            if (games.ContainsKey(req.Token))
            {
                Game game = games[req.Token];

                if (game.Guess(req.Value) == 0)
                    games.Remove(req.Token);

                return new GuessResult("ok", game.LastGuessMessage, game.Guesses);
            }

            return new GuessResult("error", "invalid token", -1);
        }
    }
}
