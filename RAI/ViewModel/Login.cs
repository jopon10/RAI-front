using System;

namespace RAI.ViewModel
{
    public class Login
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public string app_version { get; set; }
        public string computer_name { get; set; }
        public string domain_name { get; set; }
        public string user_windows_name { get; set; }
        public string windows_version { get; set; }
        public string network_name { get; set; }
        public string external_ip { get; set; }
        public string local_ip { get; set; }
        public int user_id { get; set; }
    }
}