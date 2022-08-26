namespace Tweet_Feed
{
    public interface IUser
    { 
        void Subscribe(IObserver observer); 
        /// <summary>
        /// receives feeds
        /// </summary>
        /// <param name="feed"></param>
        void Notify(string feed);
    }
}
