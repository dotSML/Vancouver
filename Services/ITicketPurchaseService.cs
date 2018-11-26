using System;
using System.Collections.Generic;
using System.Linq;
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

    }

    public class TicketPurchaseService : ITicketPurchaseService
    {
        public ItineraryObject Itinerary { get; set; }
        public List<Customer> Customers { get; set; }
        public Order Order { get; set; }
        private static Random random = new Random();



        public void SetItineraryCustomersData(List<Customer> customers)
        {
            Customers = customers;
        }

        public List<Customer> GetItineraryCustomersData()
        {
            return Customers;
        }

        public void SetItineraryTicketData(ItineraryObject itineraryObject)
        {
            Itinerary = itineraryObject;
        }

        public ItineraryObject GetItineraryTicketData()
        {
            return Itinerary;
        }

        public void SetOrderData(Order order)
        {
            Order = order;
        }

        public Order GetOrderData()
        {
            return Order;
        }

        public void ClearOrderData()
        {
            Customers = null;
            Order = null;
            Itinerary = null;
        }

        public string GetRandomBookingRef(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
