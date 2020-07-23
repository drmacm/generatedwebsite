using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using PDFiller.Website.Models;
// ReSharper disable MethodHasAsyncOverload

namespace PDFiller.Website.Services
{
    public static class SendUserDataService
    {
        public static async void SendUserData(PRPModel model)
        {
            var userData = new
            {
                FirstName = model.Ime,
                LastName = model.Prezime,
                EmailAddress = model.EmailAdresa,
                Country = model.DrzavaVanBiH,
                ContactApproval = model.PristanakZaKontakt
            };

            var userDataContent = JsonConvert.SerializeObject(userData);

            using var httpClient = new HttpClient();
            
            var content = new StringContent(userDataContent, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(Settings.Url, content);
        }
    }
}
