using System;
using System.Data;

namespace Bobson.Core.DAO
{
    public abstract class BaseDAO : IDisposable
    {
        bool disposed = false;

        IDbTransaction transaction = null;
        protected IDbConnection connection = null;
        IDbCommand command = null;

        public IDbConnection Connection
        {
            get
            {
                return this.connection;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return this.transaction;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                CleanUp();
            }

            ExtraCleanUp();

            disposed = true;
        }

        private void CleanUp()
        {
            CleanCommand();
            CloseAndCleanConnection();
        }

        private void CleanCommand()
        {
            if (command != null)
            {
                command.Dispose();
                command = null;
            }
        }

        private void CloseAndCleanConnection()
        {
            if (connection != null)
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                    transaction = null;
                }

                if (connection.State == ConnectionState.Open)
                    connection.Close();

                transaction.Dispose();

                connection.Dispose();
                connection = null;
            }
        }

        private void ExtraCleanUp()
        {

        }

        public void CreateCommand(string commandText)
        {
            this.CreateProcedureCommand(commandText);
        }

        public void CreateTextCommand(string sqlText)
        {
            this.command = this.connection.CreateCommand();
            this.command.Connection = this.connection;
            
            if (this.transaction != null)
                this.command.Transaction = this.transaction;

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = sqlText;
        }

        public void CreateProcedureCommand(string storedProcedureName)
        {
            this.command = this.connection.CreateCommand();
            this.command.Connection = this.connection;

            if (this.transaction != null)
                this.command.Transaction = this.transaction;

            this.command.CommandType = CommandType.StoredProcedure;
            this.command.CommandText = storedProcedureName;
        }

        public void AddInParameter(string parameterName, object parameterValue, DbType dbType)
        {
            DbCommandHelper.AddInParameter(this.command, parameterName, parameterValue, dbType);
        }

        public void AddOutParameter(string parameterName, DbType dbType, int size)
        {
            DbCommandHelper.AddOutParameter(this.command, parameterName, dbType, size);
        }

        public void AddOutParameter(string parameterName, DbType dbType)
        {
            DbCommandHelper.AddOutParameter(this.command, parameterName, dbType);
        }

        public object ReturnValue(string parameterName)
        {
            return DbCommandHelper.ReturnValue(this.command.Parameters[parameterName]);
        }

        public IDataReader ExecuteDataReader()
        {
            OpenConnection();

            return DbCommandHelper.ExecuteDataReader(this.command);
        }

        public void OpenConnection()
        {
            if (this.connection.State != ConnectionState.Open)
                this.connection.Open();
        }

        public void CloseConnection()
        {
            if (this.connection != null && this.connection.State != ConnectionState.Closed)
                this.connection.Close();
        }

        public void BeginTransaction()
        {
            OpenConnection();
            this.transaction = this.connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.transaction.Commit();
        }

        public void RollBackTransaction()
        {
            this.transaction.Rollback();
        }

        public int ExecuteNonQuery()
        {
            OpenConnection();

            return DbCommandHelper.ExecuteNonQuery(this.command);
        }

        public object ExecuteScalar()
        {
            OpenConnection();

            return DbCommandHelper.ExecuteScalar(this.command);
        }

        public IDataReader ExecuteQuery(string query)
        {
            this.CreateCommand(query);
            this.command.CommandType = CommandType.Text;
            return this.ExecuteDataReader();
        }


        public BaseDAO()
            : this(new DbConnectionManager().CreateDbConnection())
        {
        }

        public BaseDAO(IDbConnection connection)
            : this(connection, null)
        {
        }

        public BaseDAO(IDbConnection connection, IDbTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }

        //~BaseDAO()
        //{
        //    Dispose(false);
        //}

    }
}
