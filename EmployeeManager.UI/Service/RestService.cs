using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeManager.UI.Service
{
	internal class RestService : IRestService
	{
		private readonly HttpClient httpClient;

		public RestService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<T> PerformGetRequestAsync<T>(Uri uri)
		{
			var jsonSerializerOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			};

			jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

			try
			{
				return await httpClient.GetFromJsonAsync<T>(uri, jsonSerializerOptions).ConfigureAwait(false);
			}
			catch (HttpRequestException)
			{
				return default(T);
			}
		}
	}
}
