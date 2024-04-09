using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poolsteuerung.models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ENERGY
    {
        public string STAT_STATE { get; set; }
        public string STAT_STATE_DECODE { get; set; }
        public string GUI_BAT_DATA_POWER { get; set; }
        public string GUI_INVERTER_POWER { get; set; }
        public string GUI_HOUSE_POW { get; set; }
        public string GUI_GRID_POW { get; set; }
        public string GUI_BAT_DATA_FUEL_CHARGE { get; set; }
        public string GUI_CHARGING_INFO { get; set; }
        public string GUI_BOOSTING_INFO { get; set; }
    }

    public class WIZARD
    {
        public string CONFIG_LOADED { get; set; }
        public string SETUP_NUMBER_WALLBOXES { get; set; }
    }

    public class SYSUPDATE
    {
        public string UPDATE_AVAILABLE { get; set; }
    }

    public class RequestModel

    {
        public ENERGY ENERGY { get; set; }
        public WIZARD WIZARD { get; set; }
        public SYSUPDATE SYS_UPDATE { get; set; }
    }

    public class WebRequest
    {
        private static readonly HttpClient MyClient = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        });

        /// <summary>
        /// Gets the GUI_GRID_POW as double
        /// </summary>
        /// <returns></returns>
        public static async Task<double> GetValue()
        {
            var requestModel = await GetRequestModel();
            var erg = Hex2Float(requestModel.ENERGY.GUI_GRID_POW);
            return erg;
        }

        private static async Task<RequestModel> GetRequestModel()
        {
            var requestPoco = new RequestModel
            {
                ENERGY = new ENERGY
                {
                    STAT_STATE = "",
                    STAT_STATE_DECODE = "",
                    GUI_BAT_DATA_POWER = "",
                    GUI_INVERTER_POWER = "",
                    GUI_HOUSE_POW = "",
                    GUI_GRID_POW = "",
                    GUI_BAT_DATA_FUEL_CHARGE = "",
                    GUI_CHARGING_INFO = "",
                    GUI_BOOSTING_INFO = ""
                },
                WIZARD = new WIZARD
                {
                    CONFIG_LOADED = "",
                    SETUP_NUMBER_WALLBOXES = ""
                },
                SYS_UPDATE = new SYSUPDATE
                {
                    UPDATE_AVAILABLE = ""
                }
            };

            var jsonString = JsonConvert.SerializeObject(requestPoco);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await MyClient.PostAsync("https://192.168.2.82/lala.cgi", content);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var responseBody = JsonConvert.DeserializeObject<RequestModel>(responseString);
                return responseBody;
            }

            return null;
        }

        private static double Hex2Float(string hexString)
        {
            var cuttedHexString = hexString.Substring(3, hexString.Length - 3);
            var num = uint.Parse(cuttedHexString, NumberStyles.AllowHexSpecifier);
            var floatVals = BitConverter.GetBytes(num);
            var f = BitConverter.ToSingle(floatVals, 0);

            var erg = Math.Round(f * 100) / 100000;
            return erg;
        }

    }
}