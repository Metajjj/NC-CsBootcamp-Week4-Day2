using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.BackEnd.Authors
{
    public record class Author(string Fname, string Lname, string PenName, List<string> bookName)
    {
        private static int AuthorID;
    }
}
