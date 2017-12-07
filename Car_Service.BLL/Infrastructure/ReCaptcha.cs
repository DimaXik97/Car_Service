using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Car_Service.BLL.Infrastructure
{
    public class ReCaptcha
    {
        private static string sekretKey = "6LfTizUUAAAAAOH-_rnNKMXpi-iUzRLUjJ7adpzn";
        public static bool  Validate(string Response)
        {
            var captchaResponse = JsonConvert.DeserializeObject<ReCaptcha>(Response);

            return bool.Parse(captchaResponse.Success);
        }
        public static async Task<string> GetRespons(string captcha)
        {
            string responce;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.google.com");
                var values = new Dictionary<string, string>
                {
                    { "secret", sekretKey },
                    { "response", captcha}

                }; 
                var content = new FormUrlEncodedContent(values);
                var result = await client.PostAsync("/recaptcha/api/siteverify", content).ConfigureAwait(false);
                responce = await result.Content.ReadAsStringAsync();
            }
            return responce;
        }

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }


        private List<string> m_ErrorCodes;
    }
}
