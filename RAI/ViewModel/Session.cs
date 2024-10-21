namespace RAI.ViewModel
{
    public class Session
    {
        public Session()
        {
            user = new User();
        }

        public string token { get; set; }
        public User user { get; set; } 
        public int Login_id { get; set; }
    }
}