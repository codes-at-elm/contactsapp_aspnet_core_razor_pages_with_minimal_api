using ContactWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ContactWebApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public DeleteModel(ILogger<DeleteModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public ContactModel ContactModels { get; set; }
        public async Task OnGet(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ContactAPI");
            using HttpResponseMessage response = await httpClient.GetAsync(id.ToString());

            if(response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                ContactModels = await JsonSerializer.DeserializeAsync<ContactModel>(contentStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }            
        }

        public async Task<IActionResult> OnPost()
        {
            var httpClient = _httpClientFactory.CreateClient("ContactAPI");
            using HttpResponseMessage message = await httpClient.DeleteAsync(ContactModels.Id.ToString());

            if (message.IsSuccessStatusCode)
            {
                TempData["success"] = "Data was deleted successfully";
            }
            else
            {
                TempData["failure"] = "Operation was not successful";
            }

            return RedirectToPage("Index");
        }
    }
}
