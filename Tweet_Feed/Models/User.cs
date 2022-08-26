namespace Tweet_Feed
{ 
    public class User : IUser
    {  
        public string? UserName { get; set; }
         
        public List<IObserver> _followers = new(); 
        public void Subscribe(IObserver observer)
        {
            Console.WriteLine($"{observer.FollowerName} Follows {UserName} ");
            this._followers.Add(observer);
        } 
        public void Notify(string feed)
        {
            foreach (var observer in _followers)
            {
                observer.Update(this, feed);
            } 
        } 
        public void Tweet(string name, string tweet)
        {
            string feed = $"\n\t@{name}:{tweet}";
            Console.WriteLine($"{UserName}{feed}");
            this.Notify(feed);
        } 
    }
}
