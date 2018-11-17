using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vancouver.FlightsFolder;

namespace Vancouver.Services
{
    public interface ITicketPurchaseService
    {
        void SetTicketData(ItineraryObject itineraryObject);
        ItineraryObject GetTicketData();
    }

    public class TicketPurchaseService : ITicketPurchaseService
    {
        public ItineraryObject Itinerary { get; set; }

        

        public void SetTicketData(ItineraryObject itineraryObject)
        {
            Itinerary = itineraryObject;
        }

        public ItineraryObject GetTicketData()
        {
            return Itinerary;
        }

    }
}
