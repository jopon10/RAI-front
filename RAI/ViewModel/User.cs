using System.Drawing;

namespace RAI.ViewModel
{
    public class User
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf_cnpj { get; set; }
        public int cliente_id { get; set; }
        public bool inativo { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public string Cliente { get; set; }
        public string celular { get; set; }

        public bool escuro { get; set; }
        public string cor_primaria { get; set; }
        public string cor_secundaria { get; set; }

        public bool admin { get; set; }
        public bool proprietarios { get; set; }
        public bool fazendas { get; set; }
        public bool locais { get; set; }
        public bool parceiros { get; set; }
        public bool usuarios { get; set; }

        public bool analise_solo { get; set; }

        public Login login { get; set; }

        public string logo_url { get; set; }
        public Image logo { get; set; }

        public User Clone()
        {
            return (User)this.MemberwiseClone();
        }
    }
}