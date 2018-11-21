﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vancouver.FlightsFolder;
using Vancouver.CustomerFolder;

namespace Vancouver.Services
{
    public interface ITicketPurchaseService
    {
        void SetItineraryTicketData(ItineraryObject itineraryObject);
        ItineraryObject GetItineraryTicketData();
        void SetItineraryCustomersData(List<Customer> customers);
        List<Customer> GetItineraryCustomersData();
    }

    public class TicketPurchaseService : ITicketPurchaseService
    {
        public ItineraryObject Itinerary { get; set; }
        public List<Customer> Customers { get; set; }

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

    }
}
