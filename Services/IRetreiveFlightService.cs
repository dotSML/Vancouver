using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Vancouver.Databases;
using Vancouver.FlightsFolder;
using Vancouver.Models;

namespace Vancouver.Services
{
    public interface IRetreiveFlightService
    {
        Task<ItineraryObject> GetFlight(ItineraryObject itineraryObject);
        Task<ItineraryObject> FlightToUser(ItineraryObject itineraryObject, string userId);
    }


    public class RetreiveFlightService : IRetreiveFlightService
    {
        public ItineraryObject ItineraryObject { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly VancouverDbContext _context;

        public RetreiveFlightService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, VancouverDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<ItineraryObject> GetFlight(ItineraryObject itineraryObject)
        {
            if (itineraryObject == null)
            {
                return itineraryObject;
            }
            else
            {
                ItineraryObject = itineraryObject;
                return ItineraryObject;
            }
            
        }

        public async Task<ItineraryObject> FlightToUser(ItineraryObject itineraryObject, string userId)
        {
            if (itineraryObject == null || userId == null)
            {
                return itineraryObject;
            }
            else
            {
                var itinerary = await GetFlight(itineraryObject);
                itinerary.ApplicationUserId = userId;
                return itinerary;
            }
            
        }
    }
}
