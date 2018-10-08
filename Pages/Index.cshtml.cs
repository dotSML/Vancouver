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
<<<<<<< HEAD
<<<<<<< HEAD
        //[BindProperty]
        //public Flight FlightData { get; set; }
=======
        [BindProperty]
        public Flight FlightData { get; set; }
>>>>>>> parent of a17b761... proovisin midagi, pean commirima

=======
>>>>>>> c2513bff8bc2ba59bff719fcc44eee07cc1432f2
        public void OnGet()
        {
            
        }

<<<<<<< HEAD
<<<<<<< HEAD
//        public ActionResult OnPostSubmitHandler()
//        {
//            var departureTemp = Request.Form["departureField"];
//            var arrivalTemp = Request.Form["arrivalField"];
=======
        public ActionResult OnPostSubmitHandler()
        {
            var departureTemp = Request.Form["departureField"];
            var arrivalTemp = Request.Form["arrivalField"];
>>>>>>> parent of a17b761... proovisin midagi, pean commirima

            FlightData.Departure = departureTemp;
            FlightData.Arrival = arrivalTemp;

<<<<<<< HEAD
//            return Page();
//        }
=======
        
>>>>>>> c2513bff8bc2ba59bff719fcc44eee07cc1432f2
=======
            return Page();
        }
>>>>>>> parent of a17b761... proovisin midagi, pean commirima


    }
}

<<<<<<< HEAD
<<<<<<< HEAD
//public class Flight
//{
//    public string Departure;
//    public string Arrival;
//}
=======
>>>>>>> c2513bff8bc2ba59bff719fcc44eee07cc1432f2
=======
public class Flight
{
    public string Departure;
    public string Arrival;
}
>>>>>>> parent of a17b761... proovisin midagi, pean commirima
