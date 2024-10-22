using System.Collections.Generic;
using System;

namespace RAI.ViewModel
{
    public class AnaliseSolo
    {
        public int id { get; set; }

        public DateTime data { get; set; }

        public int fazenda_id { get; set; }
        public string fazenda { get; set; }

        public int parceiro_id { get; set; }
        public string parceiro { get; set; }
    }
}