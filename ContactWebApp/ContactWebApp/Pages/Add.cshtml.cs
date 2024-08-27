using ContactWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;

namespace ContactWebApp.Pages
{
    public class AddModel : PageModel
    {
        private readonly ILogger<AddModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public AddModel(ILogger<AddModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public ContactModel ContactModels { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(ContactModels), Encoding.UTF8, "application/json");
            var httpClient = _httpClientFactory.CreateClient("ContactAPI");

            using HttpResponseMessage response = await httpClient.PostAsync("", jsonContent);

            if (response.IsSuccessStatusCode) 
            {
                TempData["success"] = "Data was added successfully";
            }
            else
            {
                TempData["failure"] = "Operation was not successful";
            }

            return RedirectToPage("Index");
        }
    }
}
