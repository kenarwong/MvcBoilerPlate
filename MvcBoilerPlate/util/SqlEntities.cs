using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;

namespace MvcBoilerPlate.Models
{
    public class SqlEntities : IDisposable
    {
        private SqlConnection _sqlCn;
        public SqlConnection sqlCn
        {
            get { return _sqlCn; } // Read-only
        }

        public SqlEntities(string sqlConnStr)
        {
            if (String.IsNullOrEmpty(sqlConnStr))
            {
                //TODO: Throw Exception
            }
            else
            {
                _sqlCn = new SqlConnection(sqlConnStr);
                _sqlCn.Open();
            }
        }

        #region "IDisposable Support"
        private bool disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).

                    // Close connection
                    this._sqlCn.Close();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                // TODO: set large fields to null.
            }
            this.disposedValue = true;
        }

        // TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        //Protected Overrides Sub Finalize()
        //    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        //    Dispose(False)
        //    MyBase.Finalize()
        //End Sub

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public static class SqlEntityExtension
    {
        public static IEnumerable<T> Query<T>(this SqlEntities entity, string sql, object param = null, SqlTransaction transaction = null, bool buffered = true)
        {
            return entity.sqlCn.Query<T>(sql, param, transaction, buffered);
        }

        public static SqlMapper.GridReader QueryMultiple(this SqlEntities entity, string sql, object param = null, SqlTransaction transaction = null)
        {
            return entity.sqlCn.QueryMultiple(sql, param, transaction);
        }

        public static void Execute(this SqlEntities entity, string sql, object param = null, SqlTransaction transaction = null)
        {
            entity.sqlCn.Execute(sql, param, transaction);
        }

        public static IEnumerable<T> StoredProcedure<T>(this SqlEntities entity, string sql, object param = null)
        {
            return entity.sqlCn.Query<T>(sql, param, commandType: CommandType.StoredProcedure);
        }
    }
}
