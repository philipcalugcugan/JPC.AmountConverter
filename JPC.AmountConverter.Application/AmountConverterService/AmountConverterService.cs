using JPC.AmountConverter.Application.Shared.Configuration;
using JPC.AmountConverter.Application.Shared.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace JPC.AmountConverter.Application.AmountConverterService
{
    /// <summary>
    /// Amount Converter Service
    /// </summary>
    public class AmountConverterService : IAmountConverterService
    {
        private readonly AmountConverterConfiguration _amountConverterConfiguration;

        public AmountConverterService(AmountConverterConfiguration amountConverterConfiguration)
        {
            _amountConverterConfiguration = amountConverterConfiguration;
        }

        /// <summary>
        /// This method converts the decimal amount in words using Rapid API
        /// Rapid API is used and I included the keys and api endpoint here for configuration (located in appsettings.json)
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AmountConverterResponseDto> GetAmountToWords(decimal amount, CancellationToken cancellationToken)
        {
            var body = JsonConvert.SerializeObject(new RapidApiRequestDto()
            {
                Number = amount
            }, Formatting.None,
            new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var client = new RestClient(_amountConverterConfiguration.RapidApiUrl);
            var request = new RestRequest(_amountConverterConfiguration.ConverterEndpoint, Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-RapidAPI-Key", _amountConverterConfiguration.Key);
            request.AddHeader("X-RapidAPI-Host", _amountConverterConfiguration.Host);
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var response = await client.ExecutePostAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var amountToWordsResponse = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
                if (amountToWordsResponse != null && !string.IsNullOrEmpty(amountToWordsResponse.Message))
                {
                    return new AmountConverterResponseDto()
                    {
                        Amount = amount,
                        Words = amountToWordsResponse.Message
                    };
                }
            }
            return null;
        }
    }
}
