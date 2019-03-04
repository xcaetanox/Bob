using System.Data;
using System.Collections.Generic;

namespace Bobson.Core.Base
{
    public interface IBaseDAO<T>
    {
        IDbConnection Connection
        {
            get;
        }

        IDbTransaction Transaction
        {
            get;
        }

        void Salvar(T entrada);

        void Deletar(T entrada);

        List<T> Listar(T entrada);

        int Contar(T entrada);

        void CloseConnection();

        void OpenConnection();

        void BeginTransaction();

        void CommitTransaction();

        void RollBackTransaction();

    }
}

