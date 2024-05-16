using System.Threading.Tasks;
using DoubTech.ThirdParty.AI.Common.Attributes;
using DoubTech.ThirdParty.AI.Common.Data;
using DoubTech.ThirdParty.Gemini.Data;
using Networking;
using UnityEngine;

namespace DoubTech.Gemini.OpenAI
{
    [CreateAssetMenu(fileName = "GeminiConfig", menuName = "DoubTech/Third Party/Gemini/Config", order = 0)]
    public class GeminiConfig : ApiConfig, IQueryParameterAuth
    {
        const string DEFAULT_HOST = "https://generativelanguage.googleapis.com";
        private const string ENDPOINT_VERSION = "v1beta";
        const string ENDPOINT_MODELS = "models";

        [Header("Authentication")]
        [Password]
        [SerializeField] private string apiKey;
        
        [Header("Server Configuration")]
        [SerializeField] public string host = DEFAULT_HOST;
        [SerializeField] public string endpointVersion = ENDPOINT_VERSION;
        
        [Header("Data")]
        [SerializeField] public string[] models;
        [SerializeField] public string[] modelDisplayNames;

        public string ApiURL => $"{host}/{endpointVersion}";
        public override string[] Models => models;
        public override string GetUrl(params string[] path) => string.Join("/", ApiURL, string.Join("/", path));

        public override async Task RefreshModels()
        {
            var modelResponse = await RestUtils.Get<ModelsResponse>(this, ENDPOINT_MODELS);
            
            if (null != modelResponse)
            {
                models = new string[modelResponse.Models.Count];
                modelDisplayNames = new string[modelResponse.Models.Count];
                for (int i = 0; i < modelResponse.Models.Count; i++)
                {
                    models[i] = modelResponse.Models[i].Name;
                    modelDisplayNames[i] = modelResponse.Models[i].DisplayName;
                }
            }
        }

        public string ApiKey => apiKey;
        public string QueryParameterName => "key";
    }
}