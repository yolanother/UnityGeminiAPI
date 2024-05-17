using System.Linq;
using DoubTech.ThirdParty.AI.Common;
using DoubTech.ThirdParty.AI.Common.Data;
using DoubTech.ThirdParty.Gemini.Data;
using DoubTech.ThirdParty.Gemini.Data.Requests;
using Newtonsoft.Json;
using UnityEngine;

namespace DoubTech.ThirdParty.Gemini
{
    [AddComponentMenu("DoubTech/Third Party/AI/Gemini Streaming API")]
    public class GeminiAIStreamingAPI : BaseAIStreamingAPI 
    {
        protected override object OnPrepareData(Request requestData)
        {
            return GenerateContentRequest.From(requestData);
        }

        protected override string[] OnGetRequestPath() => new []
        {
            Model + ":generateContent"
        };

        protected override Response OnHandleStreamedResponse(string blob, Response currentResponse)
        {
            Debug.Log(blob);
            var response = currentResponse.ParseResponse<GeminiGenerateContentResponse>(blob);
            currentResponse.response += response.Candidates.First().Content.Parts.First().Text;
            return currentResponse;
        }

        protected override Response OnHandleResponse(string blob, Response currentResponse)
        {
            Debug.Log(blob);
            var response = currentResponse.ParseResponse<GeminiGenerateContentResponse>(blob);
            currentResponse.response += response.Candidates.First().Content.Parts.First().Text;
            return currentResponse;
        }
    }
}