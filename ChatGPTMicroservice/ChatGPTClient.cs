using OpenAI.Managers;
using OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;

namespace ChatGPTMicroservice
{
    public class ChatGPTClient:IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string GetPhishingMail(string prompt)
        {
            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = "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"
            });

            var completionResult = openAiService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = prompt,
                Model = Models.TextDavinciV3,
                MaxTokens = 500,
                FrequencyPenalty = 0,
                Temperature = (float?)0.7,
                PresencePenalty = 0,
            });

            if (completionResult.Result.Successful)
            {
                return completionResult.Result.Choices.FirstOrDefault().Text;
            }
            else
            {
                if (completionResult.Result.Error == null)
                {
                    throw new Exception("Unknown Error");
                }
                return $"{completionResult.Result.Error.Code}: {completionResult.Result.Error.Message}";
            }
        }
    }
}
