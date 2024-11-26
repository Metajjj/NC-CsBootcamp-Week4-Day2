using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.BackEnd.Authors
{
    public class AuthorHandler
    {
        private static AuthorHandler authorHandler = null;
        public static AuthorHandler getDB()
        {
            if (authorHandler == null) { authorHandler = new AuthorHandler(); }
            return authorHandler;
        }

        private static FileInfo authorDB = null;
        private AuthorHandler() {
            //Create place for db if doesnt exist!
            if (!File.Exists(DatabaseHandler.BookDbLoc))
            {
                File.Create(DatabaseHandler.BookDbLoc);
            }
            authorDB = new FileInfo(DatabaseHandler.BookDbLoc);
        }
    }
}
