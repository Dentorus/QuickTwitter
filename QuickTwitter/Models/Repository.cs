using System;
using System.Collections.Generic;
using Caliburn.Micro;
using QuickTwitter.Models.Data;
using QuickTwitter.Models.Requests;
using System.Diagnostics;
using System.IO;
using SQLite;
using System.Threading.Tasks;

namespace QuickTwitter.Models
{
    public class Repository
    {

        private static UserInfo CurrentUserInfo;
        private static readonly string databasePath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "UserInfo.db");
        private readonly SQLiteAsyncConnection _connection;
        private bool isTablesCreated = false;

        public Repository()
        {
            _connection = new SQLiteAsyncConnection(databasePath);
            Initialize();
        }

        public async Task CreateTables()
        {
            if (!isTablesCreated)
            {
                await _connection.CreateTableAsync<UserInfo>();
                isTablesCreated = true;
            }
        }

        public async Task<UserInfo> GetUserInfo()
        {
            await CreateTables();
            //userInfo object is Null
            //TODO: Initialize Repo before sending request
                Initialize();
            var userInfo = await _connection.Table<UserInfo>().FirstOrDefaultAsync();

            return userInfo;
        }

        public async void InsertItem(object item)
        {
            await CreateTables();

            await _connection.InsertAsync(item);
        }

        public async void Initialize()
        {
            try
            {
                Authentication auth = new Authentication();

                CurrentUserInfo = await auth.Login();

                InsertItem(CurrentUserInfo);

            }
            catch (Exception e)
            {
                Debug.WriteLine("EXCEPTION: " + e.StackTrace);
            }
        }

        public static async void LoadTweets()
        {
            try
            {
                var getTweets = new UserTweetsGet();

                BindableCollection<Tweet> responce = await getTweets.Execute(2, false, CurrentUserInfo);

                foreach (Tweet item in responce)
                {
                    Debug.WriteLine(item.Text);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(String.Format("ERROR in LoadFriends: {0}", e));
            }
        }
    }
}
