using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace dataToSql
{
    class OperationsWithSQL : DAL
    {

        public string InsertToSQL(string[] parameterValues)
        {
            /*
            m_Command.Connection = m_Connection;           
            m_Command.CommandType = CommandType.Text;
            // m_Command.CommandText = "INSERT into MyLogs (@MyLogDate, @MyLogNumber, @MyLogType, @MyLogSource, @MyLogMessage) VALUES (@MyLogDate, @MyLogNumber, @MyLogType, @MyLogSource, @MyLogMessage)";
            m_Command.CommandText = "INSERT into MyLogs VALUES (@MyLogDate, @MyLogNumber, @MyLogType, @MyLogSource, @MyLogMessage)";
            m_Command.Parameters.AddWithValue("@MyLogDate", parameterValues[0]);
            m_Command.Parameters.AddWithValue("@MyLogNumber", parameterValues[1]);
            m_Command.Parameters.AddWithValue("@MyLogType", parameterValues[2]);
            m_Command.Parameters.AddWithValue("@MyLogSource", parameterValues[3]);
            m_Command.Parameters.AddWithValue("@MyLogMessage", parameterValues[4]);

            return ExecuteMyComand();
             */
            
            string MyInsertCommand = "INSERT into MyLogs VALUES ('" + parameterValues[0] +
                                                                 "', '" + parameterValues[1] +
                                                                 "', '" + parameterValues[2] +
                                                                 "', '" + parameterValues[3] +
                                                                 "', '" + parameterValues[4] + "')";

            return ExecuteNonQuery(MyInsertCommand);
        }
    }
}
