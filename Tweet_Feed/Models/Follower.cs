namespace Tweet_Feed
{
    // Concrete Observers react to the updates issued by the Subject they had
    // been attached to.
    public class Follower : IObserver
    { 
        public Follower(string followerName)
        {
            FollowerName = followerName;
        }
        public string FollowerName { get; set; }

        public void Update(IUser subject, string feed)
        {  
            Console.WriteLine($"{FollowerName} {feed}");
        } 
    }
}
