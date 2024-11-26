using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.BackEnd.Books
{
    public record class Book(int ID, string Name, string Location, DateTime? ReleaseDate)
    {
        
    }
}
