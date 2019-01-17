using System.Collections.Generic;
using System.Threading.Tasks;
using Vancouver.FlightsFolder;
using Vancouver.CustomerFolder;
using Vancouver.Databases;
using Vancouver.Models;

namespace Vancouver.Services
{
    public interface ITicketPurchaseService
    {
        void SetItineraryTicketData(ItineraryObject itineraryObject);
        ItineraryObject GetItineraryTicketData();
        void SetItineraryCustomersData(List<Customer> customers);
        List<Customer> GetItineraryCustomersData();
        void SetOrderData(Order order);
        Order GetOrderData();
        void ClearOrderData();
        string GetRandomBookingRef(int length);
        List<Customer> CustomerCleanup(List<Customer> customersToSort);
        List<Ticket> GenerateTickets(List<Customer> customers, Order order);
    }
}
