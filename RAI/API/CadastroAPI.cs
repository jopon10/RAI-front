using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using RAI.ViewModel;
using System.Text;
using System.Web;
using System;

namespace RAI.API
{
    public class CadastroAPI
    {
        public static async Task<ConsultaCEP> GetConsultaCepAsync(string cep)
        {
            using (var client = Helper.getHttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
                queryString["cep"] = cep;

                HttpResponseMessage response = await client.GetAsync($"consultarcep?{queryString.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ConsultaCEP>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<Estado>> GetEstadosAsync()
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("estados");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Estado>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<Cidade>> GetCidadesAsync(Estado estado)
        {
            using (var client = Helper.getHttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
                queryString["estadoId"] = estado.id.ToString();

                HttpResponseMessage response = await client.GetAsync($"cidades?{queryString.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Cidade>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<ProprietarioCnpj> GetProprietariosCNPJAsync(string cnpj)
        {
            using (var client = Helper.getHttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
                queryString["cnpj"] = cnpj;

                HttpResponseMessage response = await client.GetAsync($"proprietarioscnpj?{queryString.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ProprietarioCnpj>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<Proprietario>> GetProprietariosAsync(bool minimal = false, bool somenteInativos = false)
        {
            using (var client = Helper.getHttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
                if (minimal) queryString["minimal"] = "1";
                queryString["somenteInativos"] = somenteInativos.ToString();

                HttpResponseMessage response = await client.GetAsync($"proprietarios?{queryString.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Proprietario>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Proprietario> GetProprietarioAsync(Proprietario proprietario)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"proprietarios/{proprietario.id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Proprietario>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Proprietario> PostProprietarioAsync(Proprietario proprietario)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("proprietarios", proprietario);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Proprietario>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Proprietario> PutProprietarioAsync(Proprietario proprietario)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"proprietarios/{proprietario.id}", proprietario);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Proprietario>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<bool> DeleteProprietarioAsync(int proprietarioId)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"proprietarios/{proprietarioId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<Cultura>> GetCulturasAsync(bool? agricola = null, bool culturaSafra = false)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);

            if (agricola != null) queryString["agricola"] = agricola.ToString();
            if (culturaSafra) queryString["culturaSafra"] = culturaSafra.ToString();

            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"culturasclientes?{queryString.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Cultura>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<Variedade>> GetVariedadesAsync()
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"variedades");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Variedade>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Variedade> PostVariedadeAsync(Variedade variedade)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("variedades", variedade);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Variedade>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<Fazenda>> GetFazendasAsync(bool minimal = false, bool somenteInativas = false)
        {
            using (var client = Helper.getHttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);

                if (minimal) queryString["minimal"] = "1";
                queryString["somenteInativas"] = somenteInativas.ToString();

                HttpResponseMessage response = await client.GetAsync($"fazendas?{queryString.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Fazenda>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Fazenda> GetFazendaAsync(Fazenda fazenda)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"fazendas/{fazenda.id}");

                if (response.IsSuccessStatusCode)
                {
                    var fazendaAux = await response.Content.ReadAsAsync<Fazenda>();
                    fazenda.culturas = fazendaAux.culturas;
                    return fazenda;
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<Local>> GetFazendasMapasAsync()
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("fazendasmapa");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Local>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Fazenda> GetFazendaMapaAsync(Fazenda fazenda)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"fazendasmapa/{fazenda.id}");

                if (response.IsSuccessStatusCode)
                {
                    var fazendaAux = await response.Content.ReadAsAsync<Fazenda>();
                    fazenda.locais = fazendaAux.locais;
                    return fazenda;
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Fazenda> PostFazendasAsync(Fazenda fazenda)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("fazendas", fazenda);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Fazenda>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Fazenda> PutFazendaAsync(Fazenda fazenda)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"fazendas/{fazenda.id}", fazenda);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Fazenda>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<bool> DeleteFazendaAsync(int fazendaId)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"fazendas/{fazendaId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<Local>> GetLocaisAsync(string culturas = "", bool minimal = false, bool somenteInativos = false)
        {
            using (var client = Helper.getHttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
                queryString["culturas"] = culturas;
                if (minimal) queryString["minimal"] = "1";
                queryString["somenteInativos"] = somenteInativos.ToString();

                HttpResponseMessage response = await client.GetAsync($"locais?{queryString.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Local>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Local> GetLocalAsync(Local local)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"locais/{local.id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Local>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Local> PostLocalAsync(Local local)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("locais", local);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Local>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Local> PutLocalAsync(Local local)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"locais/{local.id}", local);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Local>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<bool> DeleteLocalAsync(int localId)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"locais/{localId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<LocalQuadra>> GetLocaisQuadrasAsync(Local local)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"locaisquadras/{local.id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<LocalQuadra>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<bool> PatchLocalCoordenadasAsync(Local local)
        {
            using (var client = Helper.getHttpClient())
            {
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"locais/{local.id}")
                {
                    Content = new StringContent(local.coordenadas, Encoding.UTF8, "application/json")
                };

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<Parceiro>> GetParceirosAsync(string tipo = "", bool minimal = false, bool somenteInativos = false)
        {
            using (var client = Helper.getHttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
                if (minimal) queryString["minimal"] = "1";
                queryString["somenteInativos"] = somenteInativos.ToString();
                queryString["tipo"] = tipo;

                HttpResponseMessage response = await client.GetAsync($"parceiros?{queryString.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Parceiro>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Parceiro> PostParceiroAsync(Parceiro parceiro)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("parceiros", parceiro);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Parceiro>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<Parceiro> PutParceiroAsync(Parceiro parceiro)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"parceiros/{parceiro.id}", parceiro);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Parceiro>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<bool> DeleteParceiroAsync(int parceiroId)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"parceiros/{parceiroId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<User>> GetUsuariosAsync(bool somenteInativos = false)
        {
            using (var client = Helper.getHttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
                queryString["somenteInativos"] = somenteInativos.ToString();

                HttpResponseMessage response = await client.GetAsync($"users?{queryString.ToString()}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<User>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<User> PostUserAsync(User user)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("users", user);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<User>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<User> PutUserAsync(User user)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"users/{user.id}", user);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<User>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }
    }
}