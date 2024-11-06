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
    }
}
