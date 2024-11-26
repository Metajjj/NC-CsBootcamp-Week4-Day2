using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using BookDatabase.BackEnd.Books;

namespace BookDatabase.BackEnd
{    
    public class DatabaseHandler
    {
        public static readonly string ResLoc = "./Databases/";

        public static readonly string BookDbLoc = ResLoc+"Books.json";
        public static readonly string AuthorDbLoc = ResLoc+"Authors.json";

        /*
            LAYOUT

          DBHandler/Manager (API to access the backends)

            use enums as col names?
          BookHandler
            BOOK : PK, TEXT, TEXT, DATETIME 
            BOOK : ID, NAME, LOCATION, RELEASE_DATE
          AuthorHandler
            AUTHOR: PK, TEXT, TEXT, TEXT, List<TEXT>, List<TEXT>
            AUTHOR: ID, Fname, Lname, PenName, BooksReleased, publishersWorkedWith


        */

        //Book methods.. use book handler
        //author methods.. use author handler

        //Keeps a static database active at all times - cannot have duplicate handlers
        private static DatabaseHandler db = null;
        public static DatabaseHandler getDB()
        {
            if(db == null) { db = new DatabaseHandler(); }
            return db;
        }

            //TODO test purposes only -- remove
        public BookHandler AccessBookHandler() { return BookHandler.getDB(); }
        //public AuthorHandler AccessAuthorHandler() { return AuthorHandler.getDB(); }

        private DatabaseHandler() {
            if (!Directory.Exists(ResLoc))
            { Directory.CreateDirectory(ResLoc); }
        }

        private void AddBook() { }



        /*
        protected synchronized int getAutoIncrement(){
            CleanupDB(); //Hope to grab null craps

            RecheckAutoIncrement();
            return ++AutoIncrementVal;
        }

        protected synchronized void RecheckAutoIncrement(){


            //Loop thru database = highest ID + 1
            ArrayList<HashMap<String,String>> Datas = CursorSorter( this.getReadableDatabase().query(TBLname,new String[]{new ID().Name},null,null,null,null,new ID().Name+" ASC") );

            for (int i=1;i<=Datas.size();i++ ) {
                String CurrID = Datas.get( i-1 ).get( new ID().Name );
                //System.out.println("i: "+ i +" | ID: "+CurrID);
                if(! CurrID.equals(i+"")){
                    //Update to fill up empty spots in ID
                    AutoIncrementVal=--i;
                    break;
                }
                //Update innate A_I to match my new latest ID
                if(i==Datas.size()){ AutoIncrementVal=i; }
            }

            //DatabaseHandler.this.close();
        }
        */
    }
}
