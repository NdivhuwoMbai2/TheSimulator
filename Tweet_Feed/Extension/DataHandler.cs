namespace Tweet_Feed.Extension
{
    public static class DataHandler
    {
        public static async Task<List<User>> ReadUsers(string path, List<User> users)
             => await Task.Run(() =>
             {
                 var lines = FileReader.ReadFile(path).ToList().OrderBy(e => e);

                 foreach (var line in lines)
                 {
                     var splitLine = line.Split(" follows ");
                     var user = new User() { UserName = splitLine[0] };
                     users.Add(user);
                 }
                 users = users.DistinctBy(e => e.UserName).ToList();
                 return users;
             });

        public static List<User> LoadFollowers(List<User> users, string path)
        {
            var lines = FileReader.ReadFile(path).ToList();

            foreach (var line in lines)
            {
                //Ward follows Alan 
                var splitString = line.Split(" follows ");
                var splitFollows = splitString[1].Split(",");
                CheckIfAllUsersExist(splitFollows, users);

                foreach (var follows in splitFollows)
                {
                    var followerName = splitString[0].TrimEnd().TrimStart();
                    var user = users?.FirstOrDefault(e => e.UserName == follows.TrimEnd().TrimStart());
                    if (user?._followers.FirstOrDefault(e => e.FollowerName == followerName) == null)
                    {
                        user?.Subscribe(new Follower(followerName));
                    }
                }
            }
            return users;
        }



        static void CheckIfAllUsersExist(string[] splitfollowers, List<User> users)
        {
            foreach (var item in splitfollowers)
            {
                if (users?.FirstOrDefault(e => e.UserName == item.TrimStart().TrimEnd()) == null)
                {
                    users?.Add(new User() { UserName = item });
                }
            }
        }

        public static void ReadTweets(string path, List<User> users)
        {
            var lines = FileReader.ReadFile(path);
            if (users != null)
            {
                LoadTweets(lines, ref users);
            }
            else
            {
                _ = ReadUsers(Path.Combine(Directory.GetCurrentDirectory(), "Files\\user.txt"), users).Result;
            }
        }

        static void LoadTweets(List<string> lines, ref List<User> users)
        {
            var orderedList = lines.OrderBy(e => e);
            foreach (var item in users.OrderBy(e => e.UserName))
            {
                if (!orderedList.Any(e => e.Split(">")[0] == item.UserName))
                {
                    Console.WriteLine(item.UserName);
                }
                else
                {
                    foreach (var line in orderedList)
                    {
                        var splitLine = SplitFeed(line, ">");
                        var tUserName = splitLine[0];
                        var tTweet = splitLine[1];
                        var user = users?.FirstOrDefault(e => e.UserName == tUserName);
                        if (item.UserName == tUserName)
                        {
                            user?.Tweet(tUserName, tTweet);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
        static string[] SplitFeed(string line, string separator)
        {
            return line.Split(separator);
        }
    }
}

