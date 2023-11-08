using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ContactBook
{
    public static class DatabaseManager
    {
        private static readonly string ConnectionString = "Data Source=DESKTOP-2QDLRPH\\SQLEXPRESS;Initial Catalog=ContactBook;Integrated Security=True;";
        
        private const string GetContactsProcedure = "dbo.GetContacts";
        private const string InsertContactProcedure = "dbo.InsertContact";
        private const string DeleteContactProcedure = "dbo.DeleteContact";
        private const string EditContactProcedure = "dbo.EditContact";

        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
            }
            else if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }

        public static List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();

            try
            {
                SqlConnection connection = GetConnection();

                SqlCommand command = new SqlCommand(GetContactsProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contact contact = new Contact
                    {
                        ContactID = (int)reader["ContactID"],
                        FullName = (string)reader["FullName"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        BirthDate = (DateTime)reader["BirthDate"]
                    };

                    contacts.Add(contact);
                }

                connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while retrieving contacts: " + ex.Message);
                throw;
            }

            return contacts;
        }

        public static int InsertContact(string fullName, string phoneNumber, DateTime birthDate)
        {
            try
            {
                SqlConnection connection = GetConnection();
                SqlCommand command = new SqlCommand(InsertContactProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 255)).Value = fullName;
                command.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 20)).Value = phoneNumber;
                command.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.Date)).Value = birthDate;

                SqlParameter contactIdParam = new SqlParameter("@ContactID", SqlDbType.Int);
                contactIdParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(contactIdParam);

                command.ExecuteNonQuery();

                int newContactID = (int)command.Parameters["@ContactID"].Value;

                connection.Close();

                return newContactID;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while inserting a contact: " + ex.Message);
                throw;
            }
        }

        public static void DeleteContact(int contactID)
        {
            try
            {
                SqlConnection connection = GetConnection();
                SqlCommand command = new SqlCommand(DeleteContactProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int)).Value = contactID;

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while deleting a contact: " + ex.Message);
                throw;
            }
        }

        public static void EditContact(int id, string fullName, string phoneNumber, DateTime birthDate)
        {
            try
            {
                SqlConnection connection = GetConnection();
                SqlCommand command = new SqlCommand(EditContactProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int)).Value = id;
                command.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 255)).Value = fullName;
                command.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 20)).Value = phoneNumber;
                command.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.Date)).Value = birthDate;

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while editing a contact: " + ex.Message);
                throw;
            }
        }

        public static void FillData()
        {
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                string fullName = "Random User " + i;
                string phoneNumber = GenerateRandomPhoneNumber(random);
                DateTime birthDate = GenerateRandomBirthDate(random);

                try
                {
                    SqlConnection connection = GetConnection();
                    SqlCommand command = new SqlCommand("dbo.InsertContact", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@BirthDate", birthDate);

                    SqlParameter contactIdParam = new SqlParameter("@ContactID", SqlDbType.Int);
                    contactIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(contactIdParam);

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("An error occurred while filling data: " + ex.Message);
                    throw;
                }
            }
        }

        private static string GenerateRandomPhoneNumber(Random random)
        {
            string phoneNumber = "+370 " + random.Next(100, 999) + " " + random.Next(10000, 99999);
            return phoneNumber;
        }

        private static DateTime GenerateRandomBirthDate(Random random)
        {
            DateTime minDate = new DateTime(1950, 1, 1);
            DateTime maxDate = new DateTime(2000, 1, 1);
            int range = (maxDate - minDate).Days;
            return minDate.AddDays(random.Next(range));
        }
    }
}
