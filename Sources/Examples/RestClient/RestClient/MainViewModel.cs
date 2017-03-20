using System.Text;
using System.ComponentModel;
using RestSharp;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;

namespace RestClient
{
    class MainViewModel :INotifyPropertyChanged
    {
        private string token;
        public string Token
        {
            get { return token; }
            set
            {
                token = value;
                OnPropertyChange("Token");
            }
        }
        public string Guess { get; set; }

        private string result;
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChange("Result");
            }
        }

        public MainViewModel()
        {
            Token = "";
            Guess = "";
            Result = "";
        }

        public void Send()
        {
            if (Token.Length == 0)
            {
                SendRegister();
            }
            else
            {
                SendGuess();
            }
        }

        private void SendRegister()
        {
            var client = new RestSharp.RestClient("http://api.gamer365.hu/numgame");
            var request = new RestRequest("register", Method.GET);
            IRestResponse response = client.Execute(request);
            RegisterResult result = Deserialize<RegisterResult>(response.Content);

            Token = result.Token;
            Result = result.Status;
        }

        private void SendGuess()
        {
            var client = new RestSharp.RestClient("http://api.gamer365.hu/numgame");
            var request = new RestRequest("guess", Method.POST);

            request.AddParameter("token", Token);
            request.AddParameter("value", Guess);

            IRestResponse response = client.Execute(request);
            GuessResult result = Deserialize<GuessResult>(response.Content);

            Result = result.Answer;

            if(result.Answer == "win")
            {
                Result = string.Format("Answer found in {0} guesses.", result.Guesses);
                Token = "";
            }

            Guess = "";
        }

        private T Deserialize<T>(string jsonText)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonText));

            return (T)serializer.ReadObject(stream);
        }

        #region INotifyPropertyChanged interface implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
