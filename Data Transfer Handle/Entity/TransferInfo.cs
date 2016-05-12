using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Transfer_Handle
{
    class TransferInfo{
     public String EmployeeID;
        public String FirstName;
        public String LastName;
        public String Date;
        public String PhoneNumber;
        public String OldComputer;
        public String CopsID;
        

       public TransferInfo(String EmployeeID, String Date){
            this.EmployeeID=EmployeeID;
            this.Date = Date;
        }
      
    }
}
