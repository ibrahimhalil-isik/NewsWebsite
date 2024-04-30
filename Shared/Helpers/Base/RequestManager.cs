using Newtonsoft.Json;
using RestSharp;
using Shared.Helpers.Abstract;

namespace Shared.Helpers.Base
{
    public class RequestManager : IRequestService
    {
        readonly string baseApiAddress = "https://localhost:44352/api/";
        public T Get<T>(string url)
        {
            var client = new RestClient(baseApiAddress);
            var request = new RestRequest(url);
            var response = client.ExecuteGet(request);

            return HandleResponse<T>(response);
        }

        public T Post<T>(string url, object model)
        {
            var client = new RestClient(baseApiAddress);
            var request = new RestRequest(url);
            request.AddBody(model);
            var response = client.ExecutePost(request);

            return HandleResponse<T>(response);
        }

        private T HandleResponse<T>(RestResponse response)
        {
            if (response == null || !response.IsSuccessful)
            {
                throw new Exception("HTTP request failed.");
            }

            try
            {
                var result = JsonConvert.DeserializeObject<T>(response.Content);
                return result;
            }
            catch (JsonException ex)
            {
                throw new Exception("Failed to deserialize JSON content.", ex);
            }
        }
    }
}