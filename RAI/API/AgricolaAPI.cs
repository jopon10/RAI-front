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
        public static async Task<List<Nutriente>> GetNutrientesAsync()
        {
            using (var client = Helper.getHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("nutrientes");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Nutriente>>();
                }
                else
                {
                    throw new Exception((await response.Content.ReadAsAsync<Error>()).error);
                }
            }
        }

        public static async Task<List<AnaliseSolo>> GetAnalisesSoloAsync(DateTime dataInicio, DateTime dataFim, Local local = null)
        {
            using (var client = Helper.getHttpClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);
                queryString["dataInicio"] = dataInicio.ToString("yyyy-MM-dd");
                queryString["dataFim"] = dataFim.ToString("yyyy-MM-dd");
                if(local != null) queryString["localId"] = local.id.ToString();

                HttpResponseMessage response = await client.GetAsync($"analisessolos?{queryString.ToString()}");

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
                HttpResponseMessage response = await client.GetAsync($"analisessolos/{analise.id}");

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
                HttpResponseMessage response = await client.PostAsJsonAsync("analisessolos", analise);

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
                HttpResponseMessage response = await client.PutAsJsonAsync($"analisessolos/{analise.id}", analise);

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
                HttpResponseMessage response = await client.DeleteAsync($"analisessolos/{analiseId}");

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