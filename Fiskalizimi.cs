using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Flexie.Fiskalizimi
{
    public class Fiskalizimi
    {
        protected Invoice? Invoice { get; set; }

        protected string Key { get; set; }

        public Fiskalizimi(string key)
        {
            Key = key;
        }

        public Invoice NewInvoice(Invoice invoice, string method = "sync")
        {
            Invoice = invoice;
            NewInvoiceToFlexie();

            return Invoice;
        }

        protected void NewInvoiceToFlexie()
        {
            if (Invoice != null && Invoice?.GetType().GetProperties().Length == 0)
            {
                throw new Exception("Invoice object not initialized. Create Invoice object first, then send to Flexie");
            }

            try
            {
                var res = SendPayload(Endpoint.FX_NEW_INVOICE, Invoice.ToJSON()).Result;

                if (res.IsSuccessStatusCode)
                {
                    string result = res.Content.ReadAsStringAsync().Result;
                    Dictionary<string, object> responseData = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
                    Invoice.EnrichInvoice(responseData);
                }
                else
                {
                    throw new Exception("There was an error on HTTP request, failed with code " + res.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected async Task<HttpResponseMessage> SendPayload(Dictionary<string, string> endpoint, string? payload)
        {
            HttpClient httpClient = new HttpClient();

            // Generate token for Flexie Dynamic Endpoint
            string token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm())
                      .WithSecret(endpoint["secret"])
                      .AddClaim("iss", endpoint["key"])
                      .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                      .AddClaim("iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds())
                      .Encode();

            // Add credentials in the header
            httpClient.DefaultRequestHeaders.Add("token", token);
            httpClient.DefaultRequestHeaders.Add("key", Key);

            StringContent data = new StringContent(payload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(endpoint["url"], data);

            return response;
        }
    }
}
