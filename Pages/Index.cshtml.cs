using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Vancouver.Databases;
using Vancouver.Models;

namespace Vancouver.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TestDbContext _context;

        public IndexModel(TestDbContext context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; }

        public ActionResult OnPostGetTicket()
        {
            var test1 = "";
            var test2 = "";

            {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {
                        var obj = JsonConvert.DeserializeObject<Ticket>(requestBody);
                        if (obj != null)
                        {
                            //Ticket.OriginAirportOutbound = obj.OriginAirportOutbound;
                            //Ticket.OriginAirportInbound = obj.OriginAirportInbound;
                            test1 = obj.originAirportOutbound;
                            test2 = obj.originAirportInbound;
                        }
                    }
                }
            }
            List<string> lstString = new List<string>
            {
                test1,
                test2
            };
            return new JsonResult(lstString);
        }

        public void OnGet()
        {
            
        }
    }
}

