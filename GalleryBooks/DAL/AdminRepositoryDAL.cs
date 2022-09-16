using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AdminRepositoryDAL : IAdminRepositoryDAL<Admins>
    {


        public bool SaveAdmin(Admins admin)
        {
            {
                try
                {
                    using (BooksContext dbContext = new BooksContext())
                    {
                        var any = dbContext.Admins.Any(x => x.EmailId == admin.EmailId);
                        if (any)
                        {
                            return false;
                        }
                        else
                        {
                            dbContext.Admins.Add(admin);
                            var rows = dbContext.SaveChanges();
                            if (rows > 0)
                            {
                                return true;
                            }
                            return false;
                        }
                    }



                }
                catch (Exception ex)
                {



                }
                return false;
            }
        }


        public bool ValidateAdmin(Admins admin)
        {

            try
            {
                using (BooksContext dbContext = new BooksContext())
                {
                    var any = dbContext.Admins.Any(x => x.EmailId == admin.EmailId && x.Password == admin.Password);
                    if (any)
                    {
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                }



            }
            catch (Exception ex)
            {



            }
            return false;
        }

        public bool DeleteAdmin(string email)
        {
            throw new NotImplementedException();
        }


        public bool SaveBook(Books books)
        {
            try
            {
                using (BooksContext dbContext = new BooksContext())
                {
                    dbContext.Books.Add(books);
                    var rows = dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public bool UpdateBook(Books books)
        {
            try
            {
                using (BooksContext dbContext = new BooksContext())
                {
                    var exists = dbContext.Books.FirstOrDefault(x => x.ISBN == books.ISBN);
                    if (exists != null)
                    {
                        exists.ISBN = books.ISBN;
                        exists.BookName = books.BookName;
                        exists.AuthorName = books.AuthorName;
                        exists.TotalPages = books.TotalPages;
                        exists.BookGenre = books.BookGenre;
                        exists.ImageUrl = books.ImageUrl;
                        exists.DescriptionUrl = books.DescriptionUrl;
                        exists.PublisherId = books.PublisherId;



                        var rows = dbContext.SaveChanges();
                        if (rows > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {



            }
            return false;
        }

        public bool DeleteBook(int isbn)
        {
            try
            {
                using (BooksContext dbContext = new BooksContext())
                {
                    var book = dbContext.Books.FirstOrDefault(x => x.ISBN == isbn);
                    if (book != null)
                    {
                        dbContext.Books.Remove(book);
                    }
                    var rows = dbContext.SaveChanges();
                    if (rows > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            catch (Exception ex)
            {

            }
            return false;
        }


    }


  
    }

