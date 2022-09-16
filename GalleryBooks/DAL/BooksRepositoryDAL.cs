using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BooksRepositoryDAL : IBooksRepositoryDAL<Books>
    {
        public List<Books> GetAllBooks()
        {
            using (BooksContext dbContext = new BooksContext())
            {
                return dbContext.Books.ToList();
            }
        }

        internal object AddBook(Books book)
        {
            throw new NotImplementedException();
        }


        //public Books GetAllBooks(int id)
        //{
        //    using (BooksContext dbContext = new BooksContext())
        //    {
        //        var books = dbContext.Books.Find(id);
        //        return books;
        //    }
        //}

        public List<Books> GetBooksByAuthor(string author)
        {
            using (BooksContext dbContext = new BooksContext())
            {
                var books = dbContext.Books.Where(m => m.AuthorName == author).ToList();
                return books;
            }
        }


        public List<Books> GetBooksByGenre(int genre)
        {
            using (BooksContext dbContext = new BooksContext())
            {
                var books = new List<Books>();
                Enum.TryParse(Convert.ToString(genre), out Genre genre1);
                books = dbContext.Books.Where(m => m.BookGenre == genre1).ToList();

                return books;
            }
        }

        public List<Books> GetBooksByName(string name)
        {
            using (BooksContext dbContext = new BooksContext())
            {
                var books = dbContext.Books.Where(m => m.BookName == name).ToList();
                return books;
            }
        }

        public Books GetBookById(int isbn)
        {
            try
            {
                using (BooksContext dbContext = new BooksContext())
                {
                    var book = dbContext.Books.FirstOrDefault(x => x.ISBN == isbn);
                    if (book != null)
                    {
                        return book;
                    }

                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {



            }
            return null;
        }
    }
}
