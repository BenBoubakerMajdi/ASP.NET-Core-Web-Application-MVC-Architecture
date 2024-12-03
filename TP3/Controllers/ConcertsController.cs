using Microsoft.AspNetCore.Mvc;
using TP3.Models;

namespace TP3.Controllers
{
    public class ConcertsController : Controller
    {
        private static List<ConcertModel> concerts = new List<ConcertModel>
        {
            new ConcertModel { Concert_Id = 1, Concert_Name = "Opening Night", Concert_Description = "Artist: Opening Band at Venue: Main Stage", TicketPrice = 50 },
            new ConcertModel { Concert_Id = 2, Concert_Name = "Jazz Evening", Concert_Description = "Artist: Jazz Trio at Venue: Sunset Hall", TicketPrice = 75 }
        };

        // GET: Concerts
        public IActionResult Index()
        {
            return View(concerts);
        }

        // GET: Concerts/Details/5
        public IActionResult ConcertDetails(int id)
        {
            var concert = concerts.FirstOrDefault(c => c.Concert_Id == id);
            if (concert == null) return NotFound();

            return View(concert);
        }

        // GET: Concerts/Create
        public IActionResult AddConcert()
        {
            return View();
        }

        // POST: Concerts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddConcert(ConcertModel concert)
        {
            if (ModelState.IsValid)
            {
                concert.Concert_Id = concerts.Count > 0 ? concerts.Max(c => c.Concert_Id) + 1 : 1;
                concerts.Add(concert);
                return RedirectToAction(nameof(Index));
            }
            return View(concert);
        }

        // GET: Concerts/Edit/5
        public IActionResult EditConcert(int id)
        {
            var concert = concerts.FirstOrDefault(c => c.Concert_Id == id);
            if (concert == null) return NotFound();

            return View(concert);
        }

        // POST: Concerts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditConcert(int id, ConcertModel updatedConcert)
        {
            var concert = concerts.FirstOrDefault(c => c.Concert_Id == id);
            if (concert == null) return NotFound();

            if (ModelState.IsValid)
            {
                concert.Concert_Name = updatedConcert.Concert_Name;
                concert.Concert_Description = updatedConcert.Concert_Description;
                concert.TicketPrice = updatedConcert.TicketPrice;

                return RedirectToAction(nameof(Index));
            }
            return View(updatedConcert);
        }

        // GET: Concerts/DeleteConcert/5
        public IActionResult DeleteConcert(int id)
        {
            var concert = concerts.FirstOrDefault(c => c.Concert_Id == id);
            if (concert == null) return NotFound();

            return View(concert);
        }

        // POST: Concerts/DeleteConcert/5
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var concert = concerts.FirstOrDefault(c => c.Concert_Id == id);

            concerts.Remove(concert);
            return RedirectToAction(nameof(Index));
        }
    }
}

