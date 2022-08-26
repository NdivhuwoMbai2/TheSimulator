using Tweet_Feed.Extension;

namespace Tweet_Feed
{
    public class Processor
    {
        public Processor()
        {  
            var tweetPath = Path.Combine(Directory.GetCurrentDirectory(), "Files\\tweet.txt");
            var userPath = Path.Combine(Directory.GetCurrentDirectory(), "Files\\user.txt");

            var tweetsFileExist = FileNotFound(tweetPath);
            Console.WriteLine($"Does the tweet file Exist? {tweetsFileExist}");
            var userFileExist = FileNotFound(userPath);
            Console.WriteLine($"Does the user file Exist? {userFileExist}");
            List<User> users = new();
            users = DataHandler.ReadUsers(Path.Combine(Directory.GetCurrentDirectory(), "Files\\user.txt"),users).Result;

            users = DataHandler.LoadFollowers(users, Path.Combine(Directory.GetCurrentDirectory(), "Files\\user.txt"));

            DataHandler.ReadTweets(Path.Combine(Directory.GetCurrentDirectory(), "Files\\tweet.txt"), users);

            Console.ReadLine();
        }
          
        public bool FileNotFound(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File on path {path} could not be found");
            return true;
        } 
    }
}