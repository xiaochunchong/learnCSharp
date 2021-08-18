using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace My_demo13_整合Dapper.DapperHelper
{
   public interface IDapper
    {
        IDbConnection GetConn();
        void OpenConn(IDbConnection conn);
        IDbTransaction BeginTransaction(IDbConnection conn);
        void Commit(IDbTransaction tran, IDbConnection conn);
        void Rollback(IDbTransaction tran, IDbConnection conn);
        int ExecuteTranQuery<T>(string sql, T obj, IDbTransaction tran, IDbConnection conn);
        List<T> QueryList<T>(string cmd, object param, CommandType? commandType = null, bool beginTransaction = false) where T : class;
        Task<IEnumerable<T>> QueryAsync<T>(string cmd, object param = null, CommandType? commandType = null, IDbTransaction transaction = null) where T : class;
        T QueryFirst<T>(string cmd, object param, CommandType? commandType = null, bool beginTransaction = false)
          where T : class;
        Task<T> QueryFirstOrDefaultAsync<T>(string cmd, object param = null, CommandType? commandType = null,
          IDbTransaction transaction = null) where T : class;
        int ExcuteNonQuery(string cmd, object param, CommandType? commandType = null, bool beginTransaction = false);
        Task<int> ExecuteAsync(string cmd, object param, CommandType? commandType = null,
          IDbTransaction transaction = null);
        public T QueryCount<T>(string sql, object parames = null);

        Task<T> QueryCountAsync<T>(string sql, object parames = null);
        Task<T> ExecuteTranAsync<T>(Func<IDbConnection, IDbTransaction, Task<T>> func, object param);


    }
}
