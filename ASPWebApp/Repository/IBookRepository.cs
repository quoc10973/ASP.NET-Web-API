using ASPWebApp.Entities;
using ASPWebApp.Model;

namespace ASPWebApp.Repository
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllBooksAsync();
        public Task<BookDTO> GetBookByIdAsync(long id);
        public Task<BookDTO> AddBookAsync(BookDTO book);
        public Task<BookDTO> UpdateBookAsync(int id, BookDTO book);
        public Task DeleteBookAsync(int id);
    }
}
