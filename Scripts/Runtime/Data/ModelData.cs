using System.Collections.Generic;
using Newtonsoft.Json;

namespace DoubTech.ThirdParty.Gemini.Data
{
    public class ModelInfo
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("version")] public string Version { get; set; }

        [JsonProperty("displayName")] public string DisplayName { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("inputTokenLimit")] public int InputTokenLimit { get; set; }

        [JsonProperty("outputTokenLimit")] public int OutputTokenLimit { get; set; }

        [JsonProperty("supportedGenerationMethods")]
        public List<string> SupportedGenerationMethods { get; set; }

        [JsonProperty("temperature")] public double? Temperature { get; set; }

        [JsonProperty("topP")] public double? TopP { get; set; }

        [JsonProperty("topK")] public int? TopK { get; set; }
    }

    public class ModelsResponse
    {
        [JsonProperty("models")] public List<ModelInfo> Models { get; set; }
    }
}