using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Data_Transfer_Handle
{
    class DatabaseAccess
    {
        public String myConnString = "SERVER=oldbrainbox;Port=3306;Database=dataTransfers;uid=root;Password=Raven47946$;";
        public MySqlConnection conn;
        public MySqlDataAdapter mySqlDataAdapter;
        


        public DatabaseAccess()
        {

            conn = new MySqlConnection(myConnString);
        }

        public DataSet Complete(DataSet DSComplete)
        {
            conn.Open();
           

            mySqlDataAdapter = new MySqlDataAdapter("select EmployeeID,FirstName,LastName,PhoneNumber,OldComputer,NewComputer,VPN,RecievedDate,FinishDate from transferinformation WHERE FinishDate IS NOT NULL;", conn);
            DSComplete = new DataSet();
            mySqlDataAdapter.Fill(DSComplete);
          //  dgCompleted.DataSource = DSComplete.Tables[0];
            return DSComplete;
        }
        public DataSet notComplete(DataSet DSnotComplete)
        {
            conn.Open();
            mySqlDataAdapter = new MySqlDataAdapter("select EmployeeID,FirstName,LastName,PhoneNumber,OldComputer,NewComputer,VPN,RecievedDate from transferinformation WHERE FinishDate IS NULL;", conn);

            DSnotComplete = new DataSet();
            mySqlDataAdapter.Fill(DSnotComplete);
            //dgNotCompleted.DataSource = DSnotComplete.Tables[0];
            return DSnotComplete;

        }

        public void AddToCompleted(TransferInfo T)
        {
            //Gets today current date and Alter format for the database
            DateTime CurrentDate = DateTime.Today;
            String CurrentDateFormat = CurrentDate.ToString("yyyy-MM-dd");

            DateTime Date = Convert.ToDateTime(T.Date);
            String EarlierDate = Date.ToString("yyyy-MM-dd");


            conn.Open();
            String AddToComplete = "UPDATE transferInformation SET FinishDate='" + CurrentDateFormat + "' WHERE EmployeeID='" + T.EmployeeID + "' AND RecievedDate='" + EarlierDate + "';";
            MySqlCommand toComplete = new MySqlCommand(AddToComplete, conn);
            toComplete.ExecuteNonQuery();
            conn.Close();

        }
        public MySqlDataReader ExportToExcel()
        {
            DateTime date = DateTime.Now;
            int Month = date.Month;
            int year = date.Year;
            int last = DateTime.DaysInMonth(year, Month);
            conn.Open();
            String getData = "Select * from transferinformation where RecievedDate BETWEEN \"" + year + "-" + Month + "-1\" And \"" + year + "-" + Month + "-" + last + "\"";
            MySqlCommand dAdapter = new MySqlCommand(getData, conn);
            MySqlDataReader Reader = dAdapter.ExecuteReader();

            return Reader;




        }

    }
}
