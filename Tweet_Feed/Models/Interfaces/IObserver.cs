namespace Tweet_Feed
{
    public interface IObserver
    { 
        public string FollowerName { get; set; }
        /// <summary>
        /// receives the user and the feed to print 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="feed"></param>
        void Update(IUser subject,string feed);
    }
}
