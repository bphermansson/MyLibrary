using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Models;
using Newtonsoft.Json;

namespace MyLibrary.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : Controller
    {
        private readonly MyLibraryContext _context;

        public BooksController(MyLibraryContext context)
        {
            _context = context;
        }

		// GET: Books
		[HttpGet]
		public async Task<IActionResult> Index()
        {
            string jsonData = JsonConvert.SerializeObject(await _context.Book.ToListAsync());
            return Content(jsonData, "application/json");
        }

        // GET: BookById/4
        [HttpGet("BookById/{Id}")]

        public async Task<IActionResult> BookById(int Id)
        {
            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.BookId == Id);
            if (book == null)
            {
                return NotFound();
            }
            string jsonData = JsonConvert.SerializeObject(book);
            return Content(jsonData, "application/json");
        }

        //GET: Books/{searchword}
        [HttpGet("{searchword}")]
		public async Task<IActionResult> Search(string? searchword)
		{
			var book =  _context.Book
				.Where(s => s.Name.Contains(searchword) || s.Author.Contains(searchword))
				.ToList();
			if (book == null)
			{
				return NotFound();
			}
            string jsonData = JsonConvert.SerializeObject(book);
            return Content(jsonData, "application/json");
		}

        //GET: Books/Loans/{userid}
        [HttpGet("Loans/{userid}")]
        public async Task<IActionResult> UserLoans(int userid)
        {
            var book = _context.Book
                .Where(s => s.BorrowerId.Equals(userid))
                .ToList();
            if (book == null)
            {
                return NotFound();
            }
            string jsonData = JsonConvert.SerializeObject(book);
            return Content(jsonData, "application/json");
        }
        //GET: Books/Loan/{bookid}/{userid}
        [HttpGet("LoanBook/{bookid}/{userid}")]
        public async Task<IActionResult> LoanBook(int bookid, int userid)
        {
            var book = _context.Book
                .FirstOrDefault(s => s.BookId == bookid);

            book.BorrowerId = userid;
            _context.SaveChanges();

            if (book == null)
            {
                return NotFound();
            }
            string jsonData = JsonConvert.ToString("Ok");
            return Content(jsonData, "application/json");
        }

        //GET: Books/Return/{bookid}
        [HttpGet("ReturnBook/{bookid}")]
        public async Task<IActionResult> ReturnBook(int bookid)
        {
            var book = _context.Book
                .FirstOrDefault(s => s.BookId == bookid);

            book.BorrowerId = 0;
            _context.SaveChanges();

            if (book == null)
            {
                return NotFound();
            }
            string jsonData = JsonConvert.ToString("Ok");
            return Content(jsonData, "application/json");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.BookId == id);
        }
    }
}
