using ContactWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ContactWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;


        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public IEnumerable<ContactModel> ContactModels { get; set; }

        public async Task OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("ContactAPI");

            using HttpResponseMessage response = await httpClient.GetAsync("");

            if (response.IsSuccessStatusCode) 
            { 
                using var contentStream = await response.Content.ReadAsStreamAsync();
                ContactModels = await JsonSerializer.DeserializeAsync<IEnumerable<ContactModel>>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
    }
}
