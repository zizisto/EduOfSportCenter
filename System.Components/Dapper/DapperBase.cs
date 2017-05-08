using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Components.Dapper
{
    public class DapperBase
    {
        private readonly int _commandTimeout;

        protected DapperBase(int commandTimeout = 30)
        {
            _commandTimeout = commandTimeout;
        }

        public T QueryOne<T>(string storedprocedure, string connectionString)
        {
            return QueryOne<T>(storedprocedure, null, connectionString);
        }

        public T QueryOne<T>(string storedprocedure, object parameterModel, string connectionString)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.Query<T>(storedprocedure, parameterModel, null, true, _commandTimeout, CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<T> QueryList<T>(string storedprocedure, string connectionString)
        {
            return QueryList<T>(storedprocedure, new { }, connectionString);
        }

        public List<T> QueryList<T>(string storedprocedure, object parameterModel, string connectionString)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                return con.Query<T>(storedprocedure, parameterModel, null, true, null, CommandType.StoredProcedure).ToList();

            }
        }

        public List<T> QueryList<T>(string storedprocedure, DynamicParameters parameterModel, string connectionString)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                return con.Query<T>(storedprocedure, parameterModel, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }

        public DynamicParameters Execute(string storedprocedure, DynamicParameters parameterModel, string connectionString)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                con.QueryMultiple(storedprocedure, parameterModel, null, null, CommandType.StoredProcedure);

                return parameterModel;

            }
        }

        public bool Execute(string storedprocedure, string connectionString)
        {
            var result = ExecuteModel(storedprocedure, new { }, connectionString);

            return result;
        }

        public TOutValue Execute<TOutValue>(string storedprocedure, string connectionString)
        {
            return ExecuteModel<TOutValue>(storedprocedure, new { }, connectionString);
        }

        public bool ExecuteModel(string storedprocedure, object parameterModel, string connectionString)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                con.Execute(storedprocedure, parameterModel, null, null, CommandType.StoredProcedure);
            }
            return true;
        }

        public TOutValue ExecuteModel<TOutValue>(string storedprocedure, object parameterModel, string connectionString)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                return con.Query<TOutValue>(storedprocedure, parameterModel, null, true, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        
        public void ExecuteCollection(string storedprocedure, IEnumerable<object> parameterCollection, string connectionString)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                var trans = con.BeginTransaction();

                con.Execute(storedprocedure, parameterCollection, trans, null, CommandType.StoredProcedure);

                trans.Commit();
            }
        }

        public List<TOutValue> ExecuteCollection<TOutValue>(string storedprocedure, IEnumerable<object> parameterCollection, string connectionString)
        {
            var result = new List<TOutValue>();

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                result.AddRange(parameterCollection.Select(parameterModel => con.Query<TOutValue>(storedprocedure, parameterModel, null, true, null, CommandType.StoredProcedure).FirstOrDefault()));
            }

            return result;
        }

        public int Execute(string storeprocedure, object parameter, string connectionString)
        {
            int affected;

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();

                affected = con.Execute(storeprocedure, parameter, commandType: CommandType.StoredProcedure);
            }

            return affected;
        }
    }

}
