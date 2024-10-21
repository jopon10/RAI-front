using System.Threading.Tasks;
using System.Net.Http;
using RAI.ViewModel;
using System;

namespace RAI.API
{
    public class LoginAPI
    {
        public static async Task<bool> PostSessionAsync(User user)
        {
            using (var client = Helper.getHttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("sessions", user);

                    if (response.StatusCode == System.Net.HttpStatusCode.Unused)
                    {
                        throw new InvalidOperationException("Este Usuário está Inativo!");
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        var session = await response.Content.ReadAsAsync<Session>();
                        Helper.Token = session.token;
                        Helper.Empresa = session.user.Cliente;
                        Helper.user = session.user;
                        Helper.user.login = user.login;
                        Helper.Login_id = session.Login_id;
                        return true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return false;
        }

        public async static Task<bool> LogoutAsync()
        {
            try
            {
                using (var client = Helper.getHttpClient())
                {
                    await client.PutAsJsonAsync($"sessions/{Helper.Login_id}", Helper.user);
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}