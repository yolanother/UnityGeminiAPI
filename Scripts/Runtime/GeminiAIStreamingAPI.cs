using System.Threading.Tasks;
using DoubTech.Gemini.OpenAI;
using DoubTech.ThirdParty.Gemini.Data;
using UnityEngine;

namespace DoubTech.ThirdParty.Gemini
{
    [AddComponentMenu("DoubTech/Third Party/AI/Gemini Streaming API")]
    public class GeminiAIStreamingAPI : MonoBehaviour 
    {
        [SerializeField] private GeminiConfig config;

        public async Task<GeminiGenerateContentResponse> GenerateContent()
        {
            
        }
    }
}