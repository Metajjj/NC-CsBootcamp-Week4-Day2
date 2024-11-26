using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookDatabase.BackEnd.Books
{

    public enum BookColumns
    { ID, NAME, LOCATION, RELEASE_DATE }

    public class BookHandler
    {
            /*

            JSON LAYOUT
            {
              [
                {
                    ID : ID
                }
              ]
            }

            */

        private static BookHandler bookHandler = null;
        public static BookHandler getDB()
        {
            if (bookHandler == null) { bookHandler = new BookHandler(); }
            return bookHandler;
        }
            //Create place for db if doesnt exist!
        private static FileInfo bookDB = null;
        private BookHandler() {
            if (!File.Exists(DatabaseHandler.BookDbLoc))
            { File.Create(DatabaseHandler.BookDbLoc).Close(); }
            bookDB = new FileInfo(DatabaseHandler.BookDbLoc);
        }

        //UpdateBookID to be file.ReadLines.Count +1 ?
        private static int BookID = 0;
        private static int getBookId()
        {
                //Serialise = works on class/instance  arg2 : new options{ writeIndented=true }
                    //Deserialising a array of objs?
            var books = JsonSerializer.Deserialize<List<Book>>(
                File.ReadAllText(DatabaseHandler.BookDbLoc) 
            ).Select(book => book.ID).ToList();

            for (int i = 1; i <= books.Count(); i++)
            {
                int CurrID = books[i - 1];
                if (CurrID != i)
                {
                    //Update to fill up empty spots in ID
                    BookID = i;
                    break;
                }
                //Update innate A_I to match my new latest ID
                if (i == books.Count()) { 
                    BookID = i+1; 
                }
            }
            return BookID;
        }


        private List<Dictionary<BookColumns, string>> GetEntries()
        {
            var books = JsonSerializer.Deserialize<List<Book>>(File.ReadAllText(DatabaseHandler.BookDbLoc));

            return books.Select(book =>
            {
                int i = 0;
                var dic = new Dictionary<BookColumns, string>
                {
                    { (BookColumns)i++ , book.ID+""} ,
                    { (BookColumns)i++ , book.Name+""} ,
                    { (BookColumns)i++ , book.Location+""} ,
                    { (BookColumns)i++ , book.ReleaseDate+""} ,
                };

                return dic;
            }).ToList();
        }

        public Book AddBook(string name="", string location="", DateTime? releaseDate=null )
        {
            var toAdd = new Book(
                getBookId(), "", "", releaseDate
            );

            var JsonEntry = JsonSerializer.Serialize( toAdd , 
                new JsonSerializerOptions { WriteIndented = true }
            );

            /*var entry = new Dictionary<BookColumns, string> {
                {
                   BookColumns.ID, getBookId()+""
                } ,
                {
                   BookColumns.NAME, name.Replace(" ","_")
                } ,
                {
                   BookColumns.LOCATION, location.Replace(" ","_")
                } , 
                {
                   BookColumns.RELEASE_DATE, releaseDate.ToShortDateString() +"_"+releaseDate.ToShortTimeString()
                } ,
            };*/

            //TODO Clean params to no underscores when serialising

            var entries = this.GetEntries();
            //entries.Add(JsonEntry);

            Console.WriteLine("Adding...\n"+ JsonEntry);

            return JsonSerializer.Deserialize<Book>(JsonEntry);
        }


            //TODO TODO TODO
        public Book DeleteBook()
        {
            //Get details i.e. Dic Col.ID => List<ID>
            //Del all that matches List

            return new Book(0,"","",null);
        }

        public List<Book> EditBookDetails(params List<List<String>> param1)
        {
                            // {Col.ID.. etc} {Pattern1.. etc} {Replacement.. etc}
            bool throwError=false; int cnt = 0;

            foreach (var item in param1)
            {
                if (cnt == 0) { cnt = item.Count; }
                throwError = cnt != item.Count || param1.Count != 3; //if error is true.. throw it

                if (throwError) { throw new Exception("Params not accepted!"); }
            }

            Console.WriteLine("..Updating database");

            /*
                accept a regex/wildcard with *

                convert * to .*

                edit all thats applicable

                    Accept cols i.e.  ? 1 param
                Dic<Col1, pattern, replacement>

                params List<string> -- enum to string??
                    EditBookDetails (1,2,3 cols.. 1,2,3 pattern.. 1,2,3 replacement)
                        //How to force even amount inside ??
                    {
                      for i ; i++< Math.Max(...param )
                        //populate.. grab where col[1] == dbcol[1] ++ regex.Match(pattern)
                            dbcol[1] == replacement..
                    }
            */
            return new List<Book> { new Book(0, "", "", null) };
        }

        public List<Book> ViewBooks(String pattern)
        {
            //Dic param cols.. specify patterns.. return books taht matach
            //default as * for any!

            return new List<Book> { new Book(0, "", "", null) };
        }

    }
}
