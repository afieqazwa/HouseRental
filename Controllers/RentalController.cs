using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HouseRental.Models;

namespace HouseRental.Controllers
{
    public class RentalController : Controller
    {
        public IActionResult Index(decimal price, double duration, string contractType, string location, double rating, string quality)
        {
            // Get rental dummy table
            List<Rental> rentals = GetRental();

            // Filter price, takes price lower
            if (price != 0)
            {
                rentals = rentals.Where(a => a.Price <= price).ToList();
            }

            // Filter duration, takes duration lower
            if (duration != 0)
            {
                rentals = rentals.Where(a => a.Duration <= duration).ToList();
            }

            // Filter contract type
            if (contractType != null)
            {
                rentals = rentals.Where(a => a.ContractType.ToLower().Contains(contractType.ToLower())).ToList();
            }

            // Filter location
            if (location != null)
            {
                rentals = rentals.Where(a => a.Location.ToLower().Contains(location.ToLower())).ToList();
            }

            // Filter rating, takes rating lower
            if (rating != 0)
            {
                rentals = rentals.Where(a => a.Rating <= rating).ToList();
            }

            // Filter quality
            if (quality != null)
            {
                rentals = rentals.Where(a => a.Quality.ToLower().Contains(quality.ToLower())).ToList();
            }

            return View(rentals);
        }

        public List<Rental> GetRental()
        {
            // Create dummy rental table
            List<Rental> rentals = new List<Rental>
            {
                new Rental { Price = 500, Duration = 6, ContractType = "Permanent", Location = "Bangi", Rating = 3.7, Quality = "Clean and tidy environment"},
                new Rental { Price = 320, Duration = 10, ContractType = "Contract", Location = "Rawang", Rating = 2.9, Quality = "Best place to hangout"},
                new Rental { Price = 450, Duration = 7, ContractType = "Permanent", Location = "Bangsar", Rating = 4.5, Quality = "Suitable for solo traveller"},
                new Rental { Price = 380, Duration = 9, ContractType = "Contract", Location = "Damansara", Rating = 5, Quality = "Easy check in process"},
                new Rental { Price = 290, Duration = 5, ContractType = "Permanent", Location = "Cyberjaya", Rating = 3.9, Quality = "Close to shops and restaurants"},
                new Rental { Price = 475, Duration = 2, ContractType = "Contract", Location = "Putrajaya", Rating = 4.2, Quality = "Located at lowest floor"},
                new Rental { Price = 370, Duration = 12, ContractType = "Permanent", Location = "Kajang", Rating = 2.5, Quality = "Quiet and calm surrounding"},
            };

            return rentals;
        }
    }
}