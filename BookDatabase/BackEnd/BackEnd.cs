using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.BackEnd
{
    public class BackEnd
    {
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
