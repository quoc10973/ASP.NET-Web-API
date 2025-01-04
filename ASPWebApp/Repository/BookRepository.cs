using ASPWebApp.Entities;
using ASPWebApp.Model;
using ASPWebApp.Util;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASPWebApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _modelMapper;
        public BookRepository(BookStoreContext context, IMapper modelMapper)
        {
            _context = context;
            _modelMapper = modelMapper;
        }
        public async Task<BookDTO> AddBookAsync(BookDTO book)
        {
            var newBook = _modelMapper.Map<Book>(book);
            _context.Books!.Add(newBook);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBookAsync(int id)
        {
            var currentBook = await _context.Books!.SingleOrDefaultAsync(b => b.Id == id);
            if (currentBook == null)
            {
                throw new ArgumentException("Book with the specified ID does not exist.");
            }
            _context.Books!.Remove(currentBook);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = await _context.Books!.ToListAsync();
            return books;
        }

        public async Task<BookDTO> GetBookByIdAsync(long id)
        {
            var book = await _context.Books!.FindAsync(id);
            return _modelMapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> UpdateBookAsync(int id, BookDTO book)
        {
            var currentBook = await _context.Books!.SingleOrDefaultAsync(b => b.Id == id);
            if(currentBook == null)
            {
                throw new ArgumentException("Book with the specified ID does not exist.");
            }
            currentBook.Author = book.Author;
            currentBook.Title = book.Title;
            currentBook.Price = book.Price;
            currentBook.Description = book.Description;
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
