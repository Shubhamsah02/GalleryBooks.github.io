using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBooksRepositoryDAL<Books>
    {
        List<Books> GetAllBooks();
        Books GetBookById(int isbn);

        List<Books> GetBooksByAuthor(string author);

        List<Books> GetBooksByName(string name);

        List<Books> GetBooksByGenre(int genre);
    }
}
