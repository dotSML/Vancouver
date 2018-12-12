using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vancouver.Databases;

namespace Vancouver.Services
{
    public interface IGetTravelers
    {
        void GetOrderTravelers(string orderId);
    }

    public class GetTravelers : IGetTravelers
    {
        DbContext _context;

        public GetTravelers(VancouverDbContext context)
        {
            _context = context;
        }


        public void GetOrderTravelers(string orderId)
        {
            
        }
    }
}
