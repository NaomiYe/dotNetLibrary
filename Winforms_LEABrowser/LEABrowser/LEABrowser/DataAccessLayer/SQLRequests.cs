using LEABrowser.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace LEABrowser.DataAccessLayer
{
    public class SQLRequests
    {
        public ObservableCollection<InvestigationClass> GetInvestigations()
        {
            ObservableCollection<InvestigationClass> ReturnList = new ObservableCollection<InvestigationClass>();

            string connectionString = ConfigurationManager.ConnectionStrings["LEABrowser.Properties.Settings.LEADBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection((connectionString)))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM InvestigationTable", con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                InvestigationClass itemToAdd = new InvestigationClass();

                                itemToAdd.ID = int.Parse(reader["ID"].ToString());
                                itemToAdd.Name = reader["Name"].ToString();
                                itemToAdd.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());

                                ReturnList.Add(itemToAdd);
                            }
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                    }
                    finally
                    {
                        if ((con != null) && (con.State == ConnectionState.Open))
                        {
                            con.Close();
                        }
                    }
                }
            }
            return ReturnList;
        }

        public ObservableCollection<ProductClass> GetProducts(int InvestigationID)
        {
            ObservableCollection<ProductClass> ReturnList = new ObservableCollection<ProductClass>();

            string connectionString = ConfigurationManager.ConnectionStrings["LEABrowser.Properties.Settings.LEADBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection((connectionString)))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                try
                {
                    if (InvestigationID == 0)
                    {
                        cmd = new SqlCommand("SELECT ID, Type, CreationDate, Source, Destination, InvestigationID, Text, Path, CallLengthInMS FROM ProductTable tblProduct FULL JOIN SMSMessageTable tblSMS ON tblProduct.ID = tblSMS.ProductID FULL JOIN VoiceCallTable tblCall ON tblProduct.ID = tblCall.ProductID ORDER BY CreationDate", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT ID, Type, CreationDate, Source, Destination, InvestigationID, Text, Path, CallLengthInMS FROM ProductTable tblProduct FULL JOIN SMSMessageTable tblSMS ON tblProduct.ID = tblSMS.ProductID FULL JOIN VoiceCallTable tblCall ON tblProduct.ID = tblCall.ProductID WHERE InvestigationID = @InvestigationIDVal ORDER BY CreationDate", con);
                        cmd.Parameters.AddWithValue("@InvestigationIDVal", InvestigationID);
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var itemToAdd = new ProductClass();

                            switch (int.Parse(reader["Type"].ToString()))
                            {
                                case ((int)ProductType.Call):
                                    itemToAdd = new CallClass();
                                    itemToAdd.TypeIcon = new Bitmap(Properties.Resources.Call, new Size(20, 20));
                                    (itemToAdd as CallClass).Path = reader["Path"].ToString();
                                    (itemToAdd as CallClass).CallLengthInMS = long.Parse(reader["CallLengthInMS"].ToString());
                                    itemToAdd.Type = ProductType.Call;
                                    break;

                                case ((int)ProductType.SMS):
                                    itemToAdd = new SMSClass();
                                    itemToAdd.TypeIcon = new Bitmap(Properties.Resources.SMS, new Size(20, 20));
                                    (itemToAdd as SMSClass).Text = reader["Text"].ToString();
                                    itemToAdd.Type = ProductType.SMS;
                                    break;
                            }

                            itemToAdd.ID = int.Parse(reader["ID"].ToString());
                            itemToAdd.CreationDate = DateTime.Parse(reader["CreationDate"].ToString());
                            itemToAdd.Source = reader["Source"].ToString();
                            itemToAdd.Destination = reader["Destination"].ToString();
                            itemToAdd.InvestigationID = int.Parse(reader["InvestigationID"].ToString());

                            ReturnList.Add(itemToAdd);
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
                finally
                {
                    if ((con != null) && (con.State == ConnectionState.Open))
                    {
                        con.Close();
                    }
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return ReturnList;
        }

        public Tuple<string, int> AddInvestigation(string InvestigationName)
        {
            int IsNameExistInTable = CheckIfItemExistInTable("InvestigationTable", "Name", InvestigationName);

            Tuple<string, int> returnActionValue;
            switch (IsNameExistInTable)
            {
                case 0:
                    int indexToInsert = GetNextIndexFromTable("InvestigationTable", "ID");

                    if (indexToInsert == -1)
                    {
                        returnActionValue = Tuple.Create("Error inserting investigation", 0);
                    }
                    else
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["LEABrowser.Properties.Settings.LEADBConnectionString"].ConnectionString;
                        using (SqlConnection con = new SqlConnection((connectionString)))
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO InvestigationTable (ID, Name, CreationDate)" +
                                    "VALUES(@IDVal, @NameVal, @CreationDateVal)", con))
                            {
                                try
                                {
                                    cmd.Parameters.AddWithValue("@IDVal", indexToInsert);
                                    cmd.Parameters.AddWithValue("@NameVal", InvestigationName);
                                    cmd.Parameters.AddWithValue("@CreationDateVal", DateTime.Now);

                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("ERROR: " + ex.Message);
                                    returnActionValue = Tuple.Create("Error inserting investigation", 0);
                                }
                                finally
                                {
                                    if ((con != null) && (con.State == ConnectionState.Open))
                                    {
                                        con.Close();
                                    }
                                }
                            }
                        }
                        returnActionValue = Tuple.Create("Investigation inserted successfully", 1);
                    }
                    break;

                case 1:
                    returnActionValue = Tuple.Create("Investigation name already exist", 0);
                    break;

                case 2:
                default:
                    returnActionValue = Tuple.Create("Error inserting investigation", 0);
                    break;

            }
            return returnActionValue;
        }

        public bool DeleteInvestigation(int InvestigationIDToDelete)
        {
            Dictionary<int, List<int>> ProductsToDelete = GetAllInvestigationProductsByType(InvestigationIDToDelete);
            bool returnValue = false;

            if (ProductsToDelete == null)
            {
                returnValue = false;
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LEABrowser.Properties.Settings.LEADBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection((connectionString)))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        foreach (int item in ProductsToDelete[1])
                        {
                            cmd = new SqlCommand("DELETE FROM VoiceCallTable WHERE ProductID = @ProductIDVal", con);
                            cmd.Parameters.AddWithValue("@ProductIDVal", item);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM ProductTable WHERE ID = @IDVal", con);
                            cmd.Parameters.AddWithValue("@IDVal", item);
                            cmd.ExecuteNonQuery();
                        }
                        foreach (int item in ProductsToDelete[2])
                        {
                            cmd = new SqlCommand("DELETE FROM SMSMessageTable WHERE ProductID = @ProductIDVal", con);
                            cmd.Parameters.AddWithValue("@ProductIDVal", item);
                            cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("DELETE FROM ProductTable WHERE ID = @IDVal", con);
                            cmd.Parameters.AddWithValue("@IDVal", item);
                            cmd.ExecuteNonQuery();
                        }
                        cmd = new SqlCommand("DELETE FROM InvestigationTable WHERE ID = @IDVal", con);
                        cmd.Parameters.AddWithValue("@IDVal", InvestigationIDToDelete);
                        cmd.ExecuteNonQuery();

                        returnValue = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                        returnValue = false;
                    }
                    finally
                    {
                        if ((con != null) && (con.State == ConnectionState.Open))
                        {
                            con.Close();
                        }
                        if (cmd != null)
                        {
                            cmd.Dispose();
                        }
                    }
                }
            }
            return returnValue;
        }

        public bool DeleteProduct(int ProductIDToDelete, int ProductTypeNumber)
        {
            bool returnValue = false;
            string connectionString = ConfigurationManager.ConnectionStrings["LEABrowser.Properties.Settings.LEADBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection((connectionString)))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                try
                {
                    switch (ProductTypeNumber)
                    {
                        case (int)ProductType.Call:
                            cmd = new SqlCommand("DELETE FROM VoiceCallTable WHERE ProductID = @ProductIDVal", con);
                            cmd.Parameters.AddWithValue("@ProductIDVal", ProductIDToDelete);
                            cmd.ExecuteNonQuery();
                            break;

                        case (int)ProductType.SMS:
                            cmd = new SqlCommand("DELETE FROM SMSMessageTable WHERE ProductID = @ProductIDVal", con);
                            cmd.Parameters.AddWithValue("@ProductIDVal", ProductIDToDelete);
                            cmd.ExecuteNonQuery();
                            break;
                    }

                    cmd = new SqlCommand("DELETE FROM ProductTable WHERE ID = @IDVal", con);
                    cmd.Parameters.AddWithValue("@IDVal", ProductIDToDelete);
                    cmd.ExecuteNonQuery();

                    returnValue = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                    returnValue = false;
                }
                finally
                {
                    if ((con != null) && (con.State == ConnectionState.Open))
                    {
                        con.Close();
                    }
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return returnValue;
        }

        public bool AddProduct(string pSource, string pDestination, string pType, string pTextForSMS, long pLengthForCall, string pPathForCall, int pInvestigationID)
        {
            bool returnValue = false;
            int indexToInsert = GetNextIndexFromTable("ProductTable", "ID");

            if (indexToInsert == -1)
            {
                returnValue = false;
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LEABrowser.Properties.Settings.LEADBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection((connectionString)))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int TypeToInsert = -1;
                        switch (pType)
                        {
                            case "SMS":
                                TypeToInsert = 2;
                                cmd = new SqlCommand("INSERT INTO SMSMessageTable (ProductID, Text)" +
                                "VALUES(@ProductIDVal, @TextVal)", con);
                                cmd.Parameters.AddWithValue("@ProductIDVal", indexToInsert);
                                cmd.Parameters.AddWithValue("@TextVal", pTextForSMS);
                                cmd.ExecuteNonQuery();
                                break;

                            case "Call":
                                TypeToInsert = 1;
                                cmd = new SqlCommand("INSERT INTO VoiceCallTable (ProductID, Path, CallLengthInMS)" +
                                "VALUES(@ProductIDVal, @PathVal, @CallLengthInMSVal)", con);
                                cmd.Parameters.AddWithValue("@ProductIDVal", indexToInsert);
                                cmd.Parameters.AddWithValue("@PathVal", pPathForCall);
                                cmd.Parameters.AddWithValue("@CallLengthInMSVal", pLengthForCall);
                                cmd.ExecuteNonQuery();
                                break;

                            default:
                                returnValue = false;
                                break;
                        }

                        cmd = new SqlCommand("INSERT INTO ProductTable (ID, Type, CreationDate, Source, Destination, InvestigationID)" +
                            "VALUES(@IDVal, @TypeVal, @CreationDateVal, @SourceVal, @DestinationVal, @InvestigationIDVal)", con);
                        cmd.Parameters.AddWithValue("@IDVal", indexToInsert);
                        cmd.Parameters.AddWithValue("@TypeVal", TypeToInsert);
                        cmd.Parameters.AddWithValue("@CreationDateVal", DateTime.Now);
                        cmd.Parameters.AddWithValue("@SourceVal", pSource);
                        cmd.Parameters.AddWithValue("@DestinationVal", pDestination);
                        cmd.Parameters.AddWithValue("@InvestigationIDVal", pInvestigationID);

                        cmd.ExecuteNonQuery();

                        returnValue = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                        returnValue = false;
                    }
                    finally
                    {
                        if ((con != null) && (con.State == ConnectionState.Open))
                        {
                            con.Close();
                        }
                        if (cmd != null)
                        {
                            cmd.Dispose();
                        }
                    }
                }
            }
            return returnValue;
        }

        private int CheckIfItemExistInTable(string TableName, string ColumnName, string ValueToCheck)
        {
            int returnValue = -1;
            string connectionString = ConfigurationManager.ConnectionStrings["LEABrowser.Properties.Settings.LEADBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection((connectionString)))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM " + TableName + " WHERE " + ColumnName + " = @ValueToCheckVal", con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@ValueToCheckVal", ValueToCheck);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            string returnedReader = "";
                            while (reader.Read())
                            {
                                returnedReader = reader[ColumnName].ToString();
                            }

                            if (returnedReader == "")
                            {
                                returnValue = 0; // not exist
                            }
                            else
                            {
                                returnValue = 1; // exist
                            }

                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                        returnValue = 2;
                    }
                    finally
                    {
                        if ((con != null) && (con.State == ConnectionState.Open))
                        {
                            con.Close();
                        }
                    }
                }
            }
            return returnValue;
        }

        private int GetNextIndexFromTable(string TableName, string ColumnName)
        {
            int returnValue = -1;
            string connectionString = ConfigurationManager.ConnectionStrings["LEABrowser.Properties.Settings.LEADBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection((connectionString)))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 " + ColumnName + " FROM " + TableName + " ORDER BY " + ColumnName + " DESC", con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int indx = 0;
                            while (reader.Read())
                            {
                                indx = int.Parse(reader[ColumnName].ToString());
                                indx++;
                            }
                            returnValue = indx;
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                        returnValue = -1;
                    }
                    finally
                    {
                        if ((con != null) && (con.State == ConnectionState.Open))
                        {
                            con.Close();
                        }
                    }
                }
            }
            return returnValue;
        }

        private Dictionary<int, List<int>> GetAllInvestigationProductsByType(int InvestigationIDToDelete)
        {
            Dictionary<int, List<int>> returnDictionary = new Dictionary<int, List<int>>();
            returnDictionary.Add(1, new List<int>());
            returnDictionary.Add(2, new List<int>());

            string connectionString = ConfigurationManager.ConnectionStrings["LEABrowser.Properties.Settings.LEADBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection((connectionString)))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ID, Type, InvestigationID FROM ProductTable WHERE InvestigationID = @InvestigationIDVal", con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@InvestigationIDVal", InvestigationIDToDelete);
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (int.Parse(reader["Type"].ToString()) == 1)
                                {
                                    returnDictionary[1].Add(int.Parse(reader["ID"].ToString()));
                                }
                                else
                                {
                                    returnDictionary[2].Add(int.Parse(reader["ID"].ToString()));
                                }
                            }
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message);
                        returnDictionary = null;
                    }
                    finally
                    {
                        if ((con != null) && (con.State == ConnectionState.Open))
                        {
                            con.Close();
                        }
                    }
                }
            }
            return returnDictionary;
        }
    }
}
