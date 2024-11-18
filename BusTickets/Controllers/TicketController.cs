using Microsoft.AspNetCore.Mvc;
using BusTickets.Data;
using System.Linq;

namespace BusTickets.Controllers
{
    public class TicketController : Controller
    {
        private readonly TicketDbContext _context;

        public TicketController(TicketDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tickets = _context.TicketSet.ToList();
            return View(tickets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.PurchaseDate = DateTime.Now;
                _context.TicketSet.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        [HttpPost]
        public IActionResult DeactivateTicket(int id)
        {
            try
            {
                var ticket = _context.TicketSet.FirstOrDefault(t => t.TicketId == id);
                if (ticket != null)
                {
                    _context.TicketSet.Remove(ticket);
                    _context.SaveChanges();
                    Console.WriteLine($"Bilet o ID {id} został usunięty."); // Log w konsoli
                    return Ok(); // Kod HTTP 200
                }
                Console.WriteLine($"Bilet o ID {id} nie został znaleziony.");
                return NotFound(); // Kod HTTP 404
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas usuwania biletu: {ex.Message}");
                return StatusCode(500, "Wystąpił błąd serwera."); // Kod HTTP 500
            }
        }

    }
}
