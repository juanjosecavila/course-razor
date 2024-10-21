using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace course_razor.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public class YourPageModel : PageModel
        {
            public JsonResult OnGetData()
            {
                var data = new List<object>
        {
            new { name = "John", hr = new { position = "Manager", start_date = "2012-01-01", salary = "$120,000" }, contact = new[] { "john@example.com", "+1-800-123-4567" } },
            new { name = "Jane", hr = new { position = "Developer", start_date = "2015-05-15", salary = "$90,000" }, contact = new[] { "jane@example.com", "+1-800-765-4321" } }
        };

                var a = new JsonResult(data);
                Console.WriteLine("AHORA");
                Console.WriteLine(a);
                return a;
            }
        }
    }

}
