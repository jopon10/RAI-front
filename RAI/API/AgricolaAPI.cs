using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using RAI.ViewModel;
using System.Text;
using System.Web;
using System;

namespace RAI.API
{
    public class AgricolaAPI
    {
        public static async Task<List<AnaliseSolo>> GetAnalisesSoloAsync()
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"analisessolo");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<AnaliseSolo>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<AnaliseSolo> GetAnaliseSoloAsync(AnaliseSolo analise)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"analisessolo/{analise.id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AnaliseSolo>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<AnaliseSolo> PostAnaliseSoloAsync(AnaliseSolo analise)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("analisessolo", analise);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AnaliseSolo>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<AnaliseSolo> PutAnaliseSoloAsync(AnaliseSolo analise)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"analisessolo/{analise.id}", analise);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AnaliseSolo>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<bool> DeleteAnaliseSoloAsync(int analiseId)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"analisessolo/{analiseId}");

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

        public static async Task<List<AnaliseSoloResultado>> GetAnalisesSoloResultadosAsync()
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"analisessoloresultados");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<AnaliseSoloResultado>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<AnaliseSoloResultado> GetAnaliseSoloResultadoAsync(AnaliseSoloResultado resultado)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"analisessoloresultados/{resultado.id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AnaliseSoloResultado>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<AnaliseSoloResultado> PostAnaliseSoloResultadoAsync(AnaliseSoloResultado resultado)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("analisessoloresultados", resultado);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AnaliseSoloResultado>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<AnaliseSoloResultado> PutAnaliseSoloResultadoAsync(AnaliseSoloResultado resultado)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"analisessoloresultados/{resultado.id}", resultado);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<AnaliseSoloResultado>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<bool> DeleteAnaliseSoloResultadoAsync(int resultadoId)
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"analisessoloresultados/{resultadoId}");

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
    }
}