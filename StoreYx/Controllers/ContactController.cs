using Microsoft.AspNetCore.Mvc;
using StoreYx.Models;
using StoreYx.Data;


namespace StoreYx.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        /*[Route("/contact-test")]*/
        [HttpPost]
        public IActionResult LeaveMessage(string fullName, string email, string message)
        {

            _context.Message.Add(new Message()
                {
                    FullName = fullName,
                    Email = email,
                    Body = message,
                    CreatedAt = DateTime.Now
                }
            );
            try
            {
                _context.SaveChanges();
                ViewData["msg"] = $"A message from {fullName}, {email} has been sent successfully. <br /> Message Body: {message}";
            }
            catch (Exception ex)
            {

                ViewData["msg"] = $"Some thing went wrong.{ex.Message}";
            }


            return View();

        }
    }
}
