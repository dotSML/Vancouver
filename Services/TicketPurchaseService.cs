using System;
using System.Collections.Generic;
using System.Linq;
using Vancouver.CustomerFolder;
using Vancouver.FlightsFolder;
using Vancouver.Models;

namespace Vancouver.Services
{
    public class TicketPurchaseService : ITicketPurchaseService
    {
        public ItineraryObject Itinerary { get; set; }
        public List<Customer> Customers { get; set; }
        public Order Order { get; set; }
        private static Random random = new Random();

        public List<Ticket> GenerateTickets(List<Customer> customers, Order order)
        {
            var listOfTickets = new List<Ticket>();
            for (int i = 0; i < customers.Count; i++)
            {
                listOfTickets.Add(
                    new Ticket
                    {
                        Customer = customers[i],
                        Order = order
                    });
            }
            return listOfTickets;
        }

        public List<Customer> CustomerCleanup(List<Customer> customersToSort)
        {
            if (customersToSort != null)
            {
                customersToSort.RemoveAll(x => (x.FirstName == "Unspecified") && (x.LastName == "Unspecified"));
            }
            return customersToSort;
        }

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