using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ITS.PMT.Api.Infrastructure.ExternalServices
{
    public class AuthenticationServices
    {
        private readonly string _srvTokenIsValid = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("CentralizedAuth")["TokenIsValid"];
        public bool TokenIsValid(string token)
        {
            bool check = false;
            using (var client = new HttpClient())
            {
                var requestData = new { token };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(_srvTokenIsValid, content).Result;

                //string param = $"token={token}";
                //HttpResponseMessage response = client.PostAsync(_srvTokenIsValid + "?token=" + token, null).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var model = JsonConvert.DeserializeObject<Models.TokenIsValidResponse>(responseContent);
                    check = model.data;
                }
            }
            return check;
        }
    }
}
