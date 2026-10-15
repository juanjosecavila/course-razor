using course_razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;

namespace course_razor.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        // Example dataset with 66 records
        private static readonly List<object> DataSet = new List<object>
        {
            new { name = "John Doe", hr = new { position = "Manager", start_date = "2012-01-01", salary = "$120,000" }, contact = new[] { "john.doe@example.com", "+1-800-123-4567" } },
            new { name = "Jane Smith", hr = new { position = "Developer", start_date = "2015-05-15", salary = "$90,000" }, contact = new[] { "jane.smith@example.com", "+1-800-765-4321" } },
            new { name = "Alice Johnson", hr = new { position = "Engineer", start_date = "2018-03-22", salary = "$95,000" }, contact = new[] { "alice.johnson@example.com", "+1-800-234-5678" } },
            new { name = "Bob Brown", hr = new { position = "Sales", start_date = "2019-07-30", salary = "$80,000" }, contact = new[] { "bob.brown@example.com", "+1-800-345-6789" } },
            new { name = "Charlie White", hr = new { position = "HR", start_date = "2020-11-12", salary = "$75,000" }, contact = new[] { "charlie.white@example.com", "+1-800-456-7890" } },
            new { name = "Diana Green", hr = new { position = "Analyst", start_date = "2016-04-05", salary = "$70,000" }, contact = new[] { "diana.green@example.com", "+1-800-567-8901" } },
            new { name = "Ethan Black", hr = new { position = "Developer", start_date = "2021-01-15", salary = "$85,000" }, contact = new[] { "ethan.black@example.com", "+1-800-678-9012" } },
            new { name = "Fiona Gray", hr = new { position = "Manager", start_date = "2014-08-20", salary = "$115,000" }, contact = new[] { "fiona.gray@example.com", "+1-800-789-0123" } },
            new { name = "George Blue", hr = new { position = "Sales", start_date = "2022-03-17", salary = "$65,000" }, contact = new[] { "george.blue@example.com", "+1-800-890-1234" } },
            new { name = "Hannah Pink", hr = new { position = "HR", start_date = "2017-12-31", salary = "$77,000" }, contact = new[] { "hannah.pink@example.com", "+1-800-901-2345" } },
            new { name = "Isaac Silver", hr = new { position = "Analyst", start_date = "2018-02-14", salary = "$72,000" }, contact = new[] { "isaac.silver@example.com", "+1-800-012-3456" } },
            new { name = "Jessica Gold", hr = new { position = "Engineer", start_date = "2013-09-10", salary = "$92,000" }, contact = new[] { "jessica.gold@example.com", "+1-800-123-4568" } },
            new { name = "Kevin Red", hr = new { position = "Manager", start_date = "2015-06-06", salary = "$123,000" }, contact = new[] { "kevin.red@example.com", "+1-800-234-5679" } },
            new { name = "Laura Orange", hr = new { position = "Sales", start_date = "2021-05-11", salary = "$66,000" }, contact = new[] { "laura.orange@example.com", "+1-800-345-6780" } },
            new { name = "Mark Violet", hr = new { position = "Developer", start_date = "2019-10-01", salary = "$88,000" }, contact = new[] { "mark.violet@example.com", "+1-800-456-7891" } },
            new { name = "Nina Cyan", hr = new { position = "HR", start_date = "2020-12-12", salary = "$74,000" }, contact = new[] { "nina.cyan@example.com", "+1-800-567-8902" } },
            new { name = "Oscar Magenta", hr = new { position = "Analyst", start_date = "2016-03-28", salary = "$69,000" }, contact = new[] { "oscar.magenta@example.com", "+1-800-678-9013" } },
            new { name = "Paula Teal", hr = new { position = "Engineer", start_date = "2014-11-15", salary = "$94,000" }, contact = new[] { "paula.teal@example.com", "+1-800-789-0124" } },
            new { name = "Quincy Brown", hr = new { position = "Manager", start_date = "2022-07-22", salary = "$118,000" }, contact = new[] { "quincy.brown@example.com", "+1-800-890-1235" } },
            new { name = "Rachel Purple", hr = new { position = "Sales", start_date = "2018-01-01", salary = "$67,000" }, contact = new[] { "rachel.purple@example.com", "+1-800-901-2346" } },
            new { name = "Steve Coral", hr = new { position = "Developer", start_date = "2023-02-25", salary = "$99,000" }, contact = new[] { "steve.coral@example.com", "+1-800-012-3457" } },
            new { name = "Tina Gold", hr = new { position = "HR", start_date = "2017-09-10", salary = "$78,000" }, contact = new[] { "tina.gold@example.com", "+1-800-123-4569" } },
            new { name = "Ursula Blue", hr = new { position = "Analyst", start_date = "2019-05-06", salary = "$71,000" }, contact = new[] { "ursula.blue@example.com", "+1-800-234-5670" } },
            new { name = "Victor Green", hr = new { position = "Engineer", start_date = "2020-04-04", salary = "$93,000" }, contact = new[] { "victor.green@example.com", "+1-800-345-6781" } },
            new { name = "Wendy Red", hr = new { position = "Manager", start_date = "2018-12-15", salary = "$119,000" }, contact = new[] { "wendy.red@example.com", "+1-800-456-7892" } },
            new { name = "Xander White", hr = new { position = "Sales", start_date = "2016-08-20", salary = "$68,000" }, contact = new[] { "xander.white@example.com", "+1-800-567-8903" } },
            new { name = "Yara Black", hr = new { position = "Developer", start_date = "2021-03-03", salary = "$90,000" }, contact = new[] { "yara.black@example.com", "+1-800-678-9014" } },
            new { name = "Zach Gold", hr = new { position = "HR", start_date = "2023-06-18", salary = "$76,000" }, contact = new[] { "zach.gold@example.com", "+1-800-789-0125" } },
            new { name = "Ally Silver", hr = new { position = "Analyst", start_date = "2015-01-29", salary = "$72,000" }, contact = new[] { "ally.silver@example.com", "+1-800-890-1236" } },
            new { name = "Brad Orange", hr = new { position = "Engineer", start_date = "2014-07-30", salary = "$91,000" }, contact = new[] { "brad.orange@example.com", "+1-800-901-2347" } },
            new { name = "Cara Cyan", hr = new { position = "Manager", start_date = "2022-10-10", salary = "$115,000" }, contact = new[] { "cara.cyan@example.com", "+1-800-012-3458" } },
            new { name = "Dale Teal", hr = new { position = "Sales", start_date = "2019-11-11", salary = "$63,000" }, contact = new[] { "dale.teal@example.com", "+1-800-123-4570" } },
            new { name = "Elle Coral", hr = new { position = "Developer", start_date = "2020-05-05", salary = "$84,000" }, contact = new[] { "elle.coral@example.com", "+1-800-234-5681" } },
            new { name = "Fred Black", hr = new { position = "HR", start_date = "2018-12-01", salary = "$75,000" }, contact = new[] { "fred.black@example.com", "+1-800-345-6792" } },
            new { name = "Gina White", hr = new { position = "Analyst", start_date = "2016-09-30", salary = "$70,000" }, contact = new[] { "gina.white@example.com", "+1-800-456-7903" } },
            new { name = "Hank Gray", hr = new { position = "Engineer", start_date = "2017-02-15", salary = "$89,000" }, contact = new[] { "hank.gray@example.com", "+1-800-567-8914" } },
            new { name = "Ivy Blue", hr = new { position = "Manager", start_date = "2019-04-25", salary = "$112,000" }, contact = new[] { "ivy.blue@example.com", "+1-800-678-9025" } },
            new { name = "Jack Brown", hr = new { position = "Sales", start_date = "2023-07-07", salary = "$65,000" }, contact = new[] { "jack.brown@example.com", "+1-800-789-0136" } },
            new { name = "Kelly Pink", hr = new { position = "Developer", start_date = "2021-08-18", salary = "$97,000" }, contact = new[] { "kelly.pink@example.com", "+1-800-890-1247" } },
            new { name = "Liam Red", hr = new { position = "HR", start_date = "2020-06-30", salary = "$73,000" }, contact = new[] { "liam.red@example.com", "+1-800-901-2358" } },
            new { name = "Mia Green", hr = new { position = "Analyst", start_date = "2016-03-03", salary = "$69,000" }, contact = new[] { "mia.green@example.com", "+1-800-012-3469" } },
            new { name = "Noah Gold", hr = new { position = "Engineer", start_date = "2015-10-14", salary = "$88,000" }, contact = new[] { "noah.gold@example.com", "+1-800-123-4581" } },
            new { name = "Olivia Silver", hr = new { position = "Manager", start_date = "2022-11-22", salary = "$120,000" }, contact = new[] { "olivia.silver@example.com", "+1-800-234-5692" } },
            new { name = "Paul Purple", hr = new { position = "Sales", start_date = "2018-08-08", salary = "$66,000" }, contact = new[] { "paul.purple@example.com", "+1-800-345-6803" } },
            new { name = "Quinn Black", hr = new { position = "Developer", start_date = "2019-01-18", salary = "$85,000" }, contact = new[] { "quinn.black@example.com", "+1-800-456-7914" } },
            new { name = "Rita Coral", hr = new { position = "HR", start_date = "2020-02-22", salary = "$72,000" }, contact = new[] { "rita.coral@example.com", "+1-800-567-8925" } },
            new { name = "Sam Orange", hr = new { position = "Analyst", start_date = "2017-09-09", salary = "$68,000" }, contact = new[] { "sam.orange@example.com", "+1-800-678-9036" } },
            new { name = "Tina Gray", hr = new { position = "Engineer", start_date = "2016-05-21", salary = "$90,000" }, contact = new[] { "tina.gray@example.com", "+1-800-789-0147" } },
            new { name = "Ursula Blue", hr = new { position = "Manager", start_date = "2018-11-11", salary = "$115,000" }, contact = new[] { "ursula.blue@example.com", "+1-800-890-1258" } },
            new { name = "Vince Yellow", hr = new { position = "Sales", start_date = "2022-06-06", salary = "$64,000" }, contact = new[] { "vince.yellow@example.com", "+1-800-901-2369" } },
            new { name = "Wendy Gold", hr = new { position = "Developer", start_date = "2021-02-15", salary = "$96,000" }, contact = new[] { "wendy.gold@example.com", "+1-800-012-3470" } },
            new { name = "Xander Red", hr = new { position = "HR", start_date = "2019-04-20", salary = "$74,000" }, contact = new[] { "xander.red@example.com", "+1-800-123-4592" } },
            new { name = "Yvonne Silver", hr = new { position = "Analyst", start_date = "2020-03-13", salary = "$70,000" }, contact = new[] { "yvonne.silver@example.com", "+1-800-234-5703" } },
            new { name = "Zachary Green", hr = new { position = "Engineer", start_date = "2023-01-01", salary = "$92,000" }, contact = new[] { "zachary.green@example.com", "+1-800-345-6814" } },
        };

        // Handles the server-side request from DataTables
        [HttpGet]
        public JsonResult OnGetData(int draw, int start, int length, int col, string dir, string quickSearch = "")
        {
            var parameters = this.HttpContext.Request.Query;
            var a = parameters["search[value]"];
            foreach (var key in parameters.Keys) {
                Console.WriteLine($"{key}: {parameters[key]}");            
            }
            var result = new
            {
                draw = draw, 
                recordsTotal = DataSet.Count, 
                recordsFiltered = DataSet.Count,
                data = DataSet 
            };

            // Log the response
            _logger.LogInformation("Returning server-side DataTables response: {@Result}", result);

            return new JsonResult(result);
        }
    }
}
