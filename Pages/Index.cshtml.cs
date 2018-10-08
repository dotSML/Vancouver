using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Vancouver.Pages
{
    public class IndexModel : PageModel
    {
        //[BindProperty]
        //public Flight FlightData { get; set; }

        public void OnGet()
        {

        }
    }
}

//        public ActionResult OnPostSubmitHandler()
//        {
//            var departureTemp = Request.Form["departureField"];
//            var arrivalTemp = Request.Form["arrivalField"];

//            FlightData.Departure = departureTemp;
//            FlightData.Arrival = arrivalTemp;

//            return Page();
//        }


//    }
//}

//public class Flight
//{
//    public string Departure;
//    public string Arrival;
//}
