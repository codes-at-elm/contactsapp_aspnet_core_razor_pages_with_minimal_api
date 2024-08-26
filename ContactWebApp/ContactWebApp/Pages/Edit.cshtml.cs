using ContactWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;

namespace ContactWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public EditModel(ILogger<EditModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty(SupportsGet = true)]
        public ContactModel ContactModels { get; set; }
        public async Task OnGet(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ContactAPI");
            using HttpResponseMessage response = await httpClient.GetAsync(id.ToString());

            if (response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                ContactModels = await JsonSerializer.DeserializeAsync<ContactModel>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(ContactModels), Encoding.UTF8, "application/json");

            var httpClient = _httpClientFactory.CreateClient("ContactAPI");
            using HttpResponseMessage response = await httpClient.PutAsync(ContactModels.Id.ToString(), jsonContent);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Data was edited successfully.";
            }
            else
            {
                TempData["failure"] = "Operation was not successful.";
            }

            return RedirectToPage("Index");
        }
    }
}
