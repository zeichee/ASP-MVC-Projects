using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SamplePB.Models;

namespace SamplePB.DAL
{
    public class DatabaseOperations
    {
        public string InsertContactPerson(PersonViewModel model)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                SqlCommand cmd = new SqlCommand("uspContactPersonAddition", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", model.MiddleName);
                cmd.Parameters.AddWithValue("@BirthDate", model.BirthDate);
                cmd.Parameters.AddWithValue("@HomeAddress", model.HomeAddress);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;

            }
            catch
            {

                return result;
            }
            finally { 
                con.Close();
            }
        }

        public string UpdateContactPerson(PersonViewModel model)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                SqlCommand cmd = new SqlCommand("uspContactPersonInfoUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", model.PersonId);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@MiddleName", model.MiddleName);
                cmd.Parameters.AddWithValue("@BirthDate", model.BirthDate);
                cmd.Parameters.AddWithValue("@HomeAddress", model.HomeAddress);
                cmd.Parameters.AddWithValue("@Company", model.Company);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;

            }
            catch
            {

                return result="";
            }
            
        }

        public string DeleteContact(int personId)
        {
            SqlConnection con = null;
            string result = "";
            //int bla=4;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                SqlCommand cmd = new SqlCommand("uspContactDeletion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", personId);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;

            }
            catch
            {

                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public DataSet SelectAllContacts()
        {
            SqlConnection con = null;
            string result = "";
            DataSet ds = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                SqlCommand cmd = new SqlCommand("uspContactList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {

                return ds;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet SelectById(int id)
        {
            SqlConnection con = null;
            string result = "";
            DataSet ds = null;
            
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                var cmd = new SqlCommand("uspContactShowDetail", con);
                ds = new DataSet();
                var da = new SqlDataAdapter();
            
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", id);
                con.Open();
                
                da.SelectCommand = cmd;
                
                da.TableMappings.Add("Table", "tblPerson");
                da.TableMappings.Add("Table1", "tblContactNumbers");
                da.TableMappings.Add("Table2", "tblEmails");
                da.Fill(ds);
                return ds;

            }
            catch
            {

                return ds;
            }
            finally
            {
                con.Close();
            }
        }
        public string AddEmails(EmailsViewModel eModel)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                SqlCommand cmd = new SqlCommand("uspEmailAddition", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", eModel.PersonId);
                cmd.Parameters.AddWithValue("@EmailAddress", eModel.Emails);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;

            }
            catch
            {

                return result;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }
        public string AddContactNumbers(ContactNumbersViewModel cModel)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                var cmd = new SqlCommand("uspContactAddition", con) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@PersonID", cModel.PersonId);
                cmd.Parameters.AddWithValue("@SelectedContactType", cModel.SelectedContactType);
                cmd.Parameters.AddWithValue("@ContactNumber", cModel.ContactNumber);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;

            }
            catch
            {

                return result;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }

        //practice ni tracker
        public DataSet SearchContact()
        {
            SqlConnection con = null;
            string result = "";
            DataSet ds = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                SqlCommand cmd = new SqlCommand("uspContactPersonSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch
            {

                return ds;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }

        //dulo ng practice

        //ginno
        public string ViewContactDetails(int personId)
        {
            SqlConnection con = null;
            string result = "";
            //int bla=4;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                SqlCommand cmd = new SqlCommand("uspContactSearching", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PersonID", personId);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;

            }
            catch
            {

                return result;
            }
            finally
            {
                if (con != null) con.Close();
            }

        }
        public DataSet SelectByContactId(int id)
        {
            SqlConnection con = null;
            string result = "";
            DataSet ds = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                var cmd = new SqlCommand("uspContactNumberSearchId", con);
                ds = new DataSet();
               
                var da = new SqlDataAdapter();
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", id);
                con.Open();
                da.SelectCommand = cmd;
                //da.TableMappings.Add("Table", "tblPerson");
                //da.TableMappings.Add("Table1", "tblContactNumbers");
                //da.TableMappings.Add("Table2", "tblEmails");
                da.Fill(ds);
                return ds;

            }
            catch
            {

                return ds;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }
        public string UpdateContactNumber(ContactNumbersViewModel model)
        {
            string result = "";
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                var cmd = new SqlCommand("uspContactNumberUpdate", con) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@ContactID", model.ContactId);
                cmd.Parameters.AddWithValue("@SelectedContactType", model.SelectedContactType);
                cmd.Parameters.AddWithValue("@ContactNumber", model.ContactNumber);
                result = cmd.ExecuteScalar().ToString();
                return result;

            }
            catch
            {

                return result = "";
            }

        
        }
        public string DeleteContactNumber(int contactId)
        {
            SqlConnection con = null;
            string result = "";
            //int bla=14;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                var cmd = new SqlCommand("uspContactNumberDeletion", con) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@ContactID", contactId);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;

            }
            catch
            {

                return result;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }

        public DataSet SelectByEmailId(int id)
        {
            SqlConnection con = null;
            string result = "";
            DataSet ds = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                var cmd = new SqlCommand("uspEmailSearchById", con);
                ds = new DataSet();

                var da = new SqlDataAdapter();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", id);
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch
            {

                return ds;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }
        public string UpdateEmail(EmailsViewModel model)
        {
            string result = "";
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                var cmd = new SqlCommand("uspEmailUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", model.EmailId);
                cmd.Parameters.AddWithValue("@EmailAddress", model.Emails);
                result = cmd.ExecuteScalar().ToString();
                return result;

            }
            catch
            {

                return result = "";
            }


        }
        public string DeleteEmail(int emailId)
        {
            SqlConnection con = null;
            string result = "";
            //int bla=14;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactDbContext"].ToString());
                var cmd = new SqlCommand("uspEmailDeletion", con) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@EmailID", emailId);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;

            }
            catch
            {

                return result;
            }
            finally
            {
                if (con != null) con.Close();
            }
        }
    }

}