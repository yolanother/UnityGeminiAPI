using System;
using System.Collections.Generic;
using DoubTech.ThirdParty.AI.Common.Data;

namespace DoubTech.ThirdParty.Gemini.Data.Requests
{
    [Serializable]
    public class GenerateContentRequest
    {
        public Content[] contents;

        public static GenerateContentRequest From(Request request)
        {
            GenerateContentRequest geminiRequest = new GenerateContentRequest();
            geminiRequest.contents = new Content[request.messages.Length];
            for (int i = 0; i < request.messages.Length; i++)
            {
                var message = request.messages[i];
                var content = new Content();
                geminiRequest.contents[i] = content;
                content.Parts = new List<Part>();
                content.Parts.Add(new Part
                {
                    Text = message.content
                });
                switch (message.role)
                {
                    case Roles.User:
                        content.Role = "user";
                        break;
                    default:
                        content.Role = "model";
                        break;
                }
            }

            return geminiRequest;
        }
    }
}