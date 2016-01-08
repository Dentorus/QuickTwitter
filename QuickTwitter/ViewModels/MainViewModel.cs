using Caliburn.Micro;
using QuickTwitter.Models;
using QuickTwitter.Models.Data;
using QuickTwitter.Models.Requests;
using System.Diagnostics;

namespace QuickTwitter.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly Repository _repository;


        public BindableCollection<Tweet> Tweets { get; }

        public MainViewModel(Repository repository)
        {
            _repository = repository;
            Tweets = new BindableCollection<Tweet>();
            LoadTweets();
        }

        public async void LoadTweets()
        {
            Tweets.Clear();
            var getTweets = new UserTweetsGet();
            BindableCollection<Tweet> responce = await getTweets.Execute(20, true, await _repository.GetUserInfo());

            Tweets.AddRange(responce);
        }
    }
}
