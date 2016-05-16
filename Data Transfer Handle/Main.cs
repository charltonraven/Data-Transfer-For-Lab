using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel=Microsoft.Office.Interop.Excel;
using System.IO;


namespace Data_Transfer_Handle
{
    public partial class Main : Form
    {
        public static String myConnString = "SERVER=oldbrainbox;Port=3306;Database=dataTransfers;uid=root;Password=Raven47946$;";
        public MySqlConnection conn = new MySqlConnection(myConnString);
        MySqlDataAdapter mySqlDataAdapter;
        DataSet DS;
        


        public Main()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshTables();
            




        }
        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }
        //Close connection
        private bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void dgNotCompleted_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
              //  MessageBox.Show("Col: " + e.ColumnIndex + " Row: " + e.RowIndex);
                String EmployeeID = dgNotCompleted.Rows[e.RowIndex].Cells["EmployeeID"].Value.ToString();
                String Date = dgNotCompleted.Rows[e.RowIndex].Cells["RecievedDate"].Value.ToString();

                TransferInfo PrimaryKeys = new TransferInfo(EmployeeID, Date);
                DatabaseAccess ToComplete = new DatabaseAccess();
                ToComplete.AddToCompleted(PrimaryKeys);

            }
            RefreshTables();

        }

        private void dgNotCompleted_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgNotCompleted_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void RefreshTables(){
            //Initilize the Dataset and DataAdapter for generating tables for the completed and not completed datagrids.


            //Adds Complete button on Datagridview
            DataGridViewButtonColumn btnDoneDT = new DataGridViewButtonColumn();
            dgNotCompleted.Columns.Add(btnDoneDT);
            btnDoneDT.HeaderText = "Complete";
            btnDoneDT.Text = "Done";
            // btnDoneDT.Name = "Complete";
            btnDoneDT.UseColumnTextForButtonValue = true;

            //Put the appropriate fields in play for the datagridview
            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select EmployeeID,FirstName,LastName,PhoneNumber,OldComputer,NewComputer,RecievedDate from transferinformation WHERE FinishDate IS NULL;", conn);
                DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgNotCompleted.DataSource = DS.Tables[0];



                mySqlDataAdapter = new MySqlDataAdapter("select EmployeeID,FirstName,LastName,PhoneNumber,OldComputer,NewComputer,RecievedDate,FinishDate from transferinformation WHERE FinishDate IS NOT NULL;", conn);
                DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgCompleted.DataSource = DS.Tables[0];



                //close connection
                this.CloseConnection();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            //Initialize Access to the database
            DatabaseAccess tableInfo = new DatabaseAccess();
            //Get the tables needed to send to Excel
            MySqlDataReader Reader= tableInfo.ExportToExcel();

            //This Exports the tables to Excel.
            int row=1;
            string curFile = @"c:\cops\Archive.xlsx";
            if (!File.Exists(curFile))
            {
                Object misValue = System.Reflection.Missing.Value;
                Excel.Application app = new Excel.Application();
                Excel.Workbook workbook = (Excel.Workbook)app.Workbooks.Add(misValue);
                Excel.Worksheet worksheet=workbook.Sheets[1];
                //Bolds Entire row
                Excel.Range formatRange;
                formatRange = worksheet.get_Range("a1");
                formatRange.EntireRow.Font.Bold = true;

                formatRange = worksheet.get_Range("A1", "M200");
                
                //Add Columns
                worksheet.Cells[1, 1] = "EmployeeID";
                worksheet.Cells[1, 2] = "First Name";
                worksheet.Cells[1, 3] = "Last Name";
                worksheet.Cells[1, 4] = "Phone Number";
                worksheet.Cells[1, 5] = "Old Computer";
                worksheet.Cells[1, 6] = "New Computer";
                worksheet.Cells[1, 7] = "Date Recieved";
                worksheet.Cells[1, 8] = "Date Finished";
                worksheet.Cells[1, 9] = "COPS ID";
                while (Reader.Read())
                {
                    for (int col = 0; col < Reader.FieldCount; col++)
                    {
                        worksheet.Cells[row + 1, col + 1] = Reader.GetValue(col);
                    }
                    row++;
                }
                DateTime date = DateTime.Now;
                String DateSheetName=date.ToString("y", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                //Helps Auto Format Cells
                formatRange.Columns.AutoFit();

                worksheet.Name = DateSheetName;
                workbook.SaveAs(@"C:\cops\Archive.xlsx");
                workbook.Close();
                
               
                

            }else{
                //Gets Exisiting Workbook for Modification
                Excel.Application app = new Excel.Application();
                Excel.Workbook workbook = app.Workbooks.Open(@"c:\cops\Archive.xlsx");
                Excel.Worksheet worksheet = workbook.Sheets.Add();


                //Changes Default worksheet name according to Month name and year. i.e: May, 2016
                DateTime date = DateTime.Now;


                //Try-Catch Block to See if Archiving has been done already
                try
                {
                    worksheet.Name = date.ToString("y", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                    //Bolds Entire row
                    Excel.Range formatRange;
                    formatRange = worksheet.get_Range("a1");
                    formatRange.EntireRow.Font.Bold = true;


                    //Change Format Cell
                    formatRange = worksheet.get_Range("A1", "M200");

                    //Add Columns
                    worksheet.Cells[1, 1] = "EmployeeID";
                    worksheet.Cells[1, 2] = "First Name";
                    worksheet.Cells[1, 3] = "Last Name";
                    worksheet.Cells[1, 4] = "Phone Number";
                    worksheet.Cells[1, 5] = "Old Computer";
                    worksheet.Cells[1, 6] = "New Computer";
                    worksheet.Cells[1, 7] = "Date Recieved";
                    worksheet.Cells[1, 8] = "Date Finished";
                    worksheet.Cells[1, 9] = "COPS ID";
                    while (Reader.Read())
                    {
                        for (int col = 0; col < Reader.FieldCount; col++)
                        {
                            worksheet.Cells[row + 1, col + 1] = Reader.GetValue(col);
                        }
                        row++;
                    }

                    //Helps Auto Format Cells
                    formatRange.Columns.AutoFit();



                    //Saves workwork
                    workbook.Save();
                    workbook.Close();
                

                }
                catch (Exception E)
                {
                    MessageBox.Show("Archive Have already been done this Month");
                }






                
               
            }
            
            

          



        }
     
    }
}
