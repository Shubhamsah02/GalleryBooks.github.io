using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAdminRepositoryDAL<Admins>
    {
        bool SaveAdmin(Admins admin);
        bool DeleteAdmin(string email);
        bool ValidateAdmin(Admins admin);
        bool SaveBook(Books books);
        bool DeleteBook(int isbn);


        bool UpdateBook(Books books);
    }
}
