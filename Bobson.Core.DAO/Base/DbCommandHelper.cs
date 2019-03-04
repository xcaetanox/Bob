using System;
using System.Data;

namespace Bobson.Core.DAO
{
    public class DbCommandHelper
    {
        public static void AddInParameter(IDbCommand cmd, string parameterName, object parameterValue, DbType dbType)
        {
            IDbDataParameter newParameter = cmd.CreateParameter();
            newParameter.Direction = ParameterDirection.Input;
            newParameter.ParameterName = parameterName;
            newParameter.DbType = dbType;

            if (parameterValue == null)
                newParameter.Value = DBNull.Value;
            else
                newParameter.Value = parameterValue;

            if (dbType == DbType.String)
                newParameter.Size = ((parameterValue != null && parameterValue.ToString().Length > 0) ? parameterValue.ToString().Length : 1);

            cmd.Parameters.Add(newParameter);
        }

        public static void AddOutParameter(IDbCommand cmd, string parameterName, DbType dbType, int size)
        {
            IDbDataParameter newParameter = cmd.CreateParameter();
            newParameter.Direction = ParameterDirection.Output;
            newParameter.ParameterName = parameterName;
            newParameter.DbType = dbType;
            newParameter.Size = size;

            cmd.Parameters.Add(newParameter);
        }

        public static void AddOutParameter(IDbCommand cmd, string parameterName, DbType dbType)
        {
            IDbDataParameter newParameter = cmd.CreateParameter();
            newParameter.Direction = ParameterDirection.Output;
            newParameter.ParameterName = parameterName;
            newParameter.DbType = dbType;

            cmd.Parameters.Add(newParameter);
        }

        public static void AddInOutParameter(IDbCommand cmd, string parameterName, object parameterValue, int size, DbType dbType)
        {
            IDbDataParameter newParameter = cmd.CreateParameter();
            newParameter.Direction = ParameterDirection.InputOutput;
            newParameter.ParameterName = parameterName;
            newParameter.DbType = dbType;

            if (parameterValue == null)
                newParameter.Value = DBNull.Value;
            else
                newParameter.Value = parameterValue;
            
            newParameter.Size = size;

            cmd.Parameters.Add(newParameter);
        }

        public static object ReturnValue(object parametro)
        {
            return ((IDbDataParameter)parametro).Value;
        }

        public static IDataReader ExecuteDataReader(IDbCommand command)
        {
            return command.ExecuteReader();
        }

        public static int ExecuteNonQuery(IDbCommand command)
        {
            return command.ExecuteNonQuery();
        }

        public static object ExecuteScalar(IDbCommand command)
        {
            return command.ExecuteScalar();
        }

    }
}