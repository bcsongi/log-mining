
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace dataToSql
{
    /* Database Access Layer */
    public abstract class DAL
    {
        protected static bool Connected;
        protected static bool ConnectionCreated;

        protected static SqlConnection m_Connection;
        protected string m_ConnectionString = "Data Source=ISTVÁN;Initial Catalog=AccentureLogs;Integrated Security=SSPI";

        protected SqlDataReader m_DataReader;
        protected SqlCommand m_Command;
        protected DataSet m_DataSet;


        protected SqlCommand myComm;

        protected bool IsConnectCreated()
        {
            return ConnectionCreated;
        }

        protected bool IsConnected()
        {
            return Connected;
        }

        protected SqlConnection GetConnection()
        {
            return m_Connection;
        }

        /* Creates a new Database Connection */
        protected bool CreateConnection()
        {
            // Create the Connection if is was not already created.
            if (ConnectionCreated != true)
            {
                try
                {
                    m_Connection = new SqlConnection(m_ConnectionString);
                    m_Connection.Open();
                    ConnectionCreated = true;
                    m_Connection.Close();
                    Connected = false;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        /* Open the Connection when the state is not already open. */
        protected bool OpenConnection()
        {
            // Open the Connection when the state is not already open.
            if (Connected != true)
            {
                try
                {
                    CreateConnection();
                    m_Connection.Open();
                    Connected = true;
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            else
            {
                return true;
            }
        }

       /* Close the Connection when the connection is opened. */
        internal void CloseConnection()
        {
            if (Connected == true)
            {
                m_Connection.Close();
                Connected = false;
            }
        }

        public void ResetConnection()
        {
            CloseConnection();
            CreateConnection();
        }

        /* Closes the data reader given as a parameter, and also closes the connection */
        protected void CloseDataReader(SqlDataReader rdr)
        {
            if (rdr != null)
                rdr.Close();
            CloseConnection();
        }

        /* Executes a given insert/update/delete command, and returns an error message. 
            (errormessage is "OK" if no exception occured) */
        protected string ExecuteNonQuery(string command)
        {
            string error;
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(command, m_Connection);
                cmd.ExecuteNonQuery();
                error = "OK";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                CloseConnection();
            }
            return error;

        }

        /* Executes a command from m_Command */
        protected string ExecuteMyComand()
        {
            string error = "OK";
            try
            {
                OpenConnection();
                int recordsAffected = m_Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                error = "Insert error";
            }
            finally
            {
                CloseConnection();
            }
            return error;

        }

        
    }
}
