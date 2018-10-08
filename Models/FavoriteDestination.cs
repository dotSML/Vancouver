using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vancouver.Models
{
    public class FavoriteDestination
    {
        public int ID { get; set; } // see ID peaks ühilduma Lennujaama IsoThree*** Koodiga vms. Selleks et saaks tabelis hoida kohe otse lennujaama koodi
        // public List<string> FavoriteDestinationsList = new List<string> { }; <--- seda ei pea siia tegema. saab teha IEnumerable<> listi otse Customerisse
        public string AirportName { get; set; } //ideaalis peaks tegema klassi Airport vastavate omadustega, aga kuna prg need tulevad sealt jQueryst, siis las ta olla string???
        public string AirportCity { get; set; }
        public string AirportCountry { get; set; } // sama lugu, peaks tegema City ja Country jaoks eraldi klassi, aga seda vaatab hiljem
        public List<Customer> ChosenByCustomers { get; } = new List<Customer>();
    }
}
