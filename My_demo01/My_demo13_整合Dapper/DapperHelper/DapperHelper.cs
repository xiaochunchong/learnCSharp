using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace My_demo13_整合Dapper.DapperHelper
{
    public class SQLDapperHelper : IDapper
    {
        public static IConfiguration _Configuration { get; set; }
        public SQLDapperHelper(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        /// <summary>数据库连接字符串</summary>
        public string _connectionString = new DataBaseConfig(_Configuration).Mysqlconnectionstring;

        private IDbConnection _connection { get; set; }
        public IDbConnection Connection
        {
            get
            {
                if (_connection == null || _connection.State == ConnectionState.Closed)
                {
                    _connection = new MySqlConnection(_connectionString);
                }
                return _connection;
            }
        }
        /// <summary>
        /// 获得conn对象
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetConn()
        {
            return Connection;
        }
        /// <summary>
        /// 打开conn
        /// </summary>
        /// <param name="conn"></param>
        public void OpenConn(IDbConnection conn)
        {
            conn.Open();
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public IDbTransaction BeginTransaction(IDbConnection conn)
        {
            IDbTransaction tran = conn.BeginTransaction();
            return tran;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="conn"></param>
        public void Commit(IDbTransaction tran, IDbConnection conn)
        {
            tran.Commit();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="conn"></param>
        public void Rollback(IDbTransaction tran, IDbConnection conn)
        {
            tran.Rollback();
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="beginTransaction"></param>
        /// <returns></returns>
        public List<T> QueryList<T>(string cmd, object param, CommandType? commandType = null, bool beginTransaction = false) where T : class
        {
            try
            {
                return Execute((conn, dbTransaction) =>
                {
                    return conn.Query<T>(cmd, param, dbTransaction, commandType: commandType ?? CommandType.Text).ToList();
                }, beginTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 异步获取数据列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string cmd, object param = null, CommandType? commandType = null, IDbTransaction transaction = null) where T : class
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    return await conn.QueryAsync<T>(cmd, param, transaction, commandType: commandType ?? CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="beginTransaction"></param>
        /// <returns></returns>
        public T QueryFirst<T>(string cmd, object param, CommandType? commandType = null, bool beginTransaction = false) where T : class
        {
            try
            {
                return Execute((conn, dbTransaction) =>
                {
                    return conn.QuerySingleOrDefault<T>(cmd, param, dbTransaction, commandType: commandType ?? CommandType.Text);
                }, beginTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 异步获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<T> QueryFirstOrDefaultAsync<T>(string cmd, object param = null, CommandType? commandType = null, IDbTransaction transaction = null) where T : class
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    return await conn.QueryFirstOrDefaultAsync<T>(cmd, param, transaction, commandType: commandType ?? CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 数据执行
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="beginTransaction"></param>
        /// <returns></returns>
        public int ExcuteNonQuery(string cmd, object param, CommandType? commandType = null, bool beginTransaction = false)
        {
            try
            {
                return Execute<int>((conn, dbTransaction) =>
                {
                    return conn.Execute(cmd, param, dbTransaction, commandType: commandType ?? CommandType.Text);
                }, beginTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 销毁conn
        /// </summary>
        /// <param name="conn"></param>
        public void DisposeConn(IDbConnection conn)
        {
            conn.Dispose();
            conn.Close();
        }

        /// <summary>
        /// 异步执行
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<int> ExecuteAsync(string cmd, object param, CommandType? commandType = null, IDbTransaction transaction = null)
        {
            try
            {
                using (IDbConnection conn = Connection)
                {
                    return await conn.ExecuteAsync(cmd, param, transaction, commandType: commandType ?? CommandType.Text);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T QueryCount<T>(string sql, object parames = null)
        {
            try
            {
                Connection.Open();
                return Connection.ExecuteScalar<T>(sql, parames);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Dispose();
            }
        }
        public async Task<T> QueryCountAsync<T>(string sql, object parames = null)
        {
            try
            {
                Connection.Open();
                return await Connection.ExecuteScalarAsync<T>(sql, parames);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Dispose();
            }
        }
        /// <summary>
        /// 执行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="beginTransaction">是否事务</param>
        /// <param name="disposeConn">关闭连接</param>
        /// <returns></returns>
        private T Execute<T>(Func<IDbConnection, IDbTransaction, T> func, bool beginTransaction = false, bool disposeConn = true)
        {

            IDbTransaction dbTransaction = null;

            if (beginTransaction)
            {
                Connection.Open();
                dbTransaction = Connection.BeginTransaction();
            }

            try
            {
                T reslutT = func(Connection, dbTransaction);
                dbTransaction?.Commit();
                return reslutT;
            }
            catch (Exception ex)
            {
                dbTransaction?.Rollback();
                Connection.Dispose();
                throw ex;
            }
            finally
            {
                if (disposeConn)
                {
                    Connection.Dispose();
                }
            }
        }

        /// <summary>
        /// 事务执行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int ExecuteTranQuery<T>(string sql, T obj, IDbTransaction tran, IDbConnection conn)
        {
            int result = 0;
            try
            {
                result = conn.Execute(sql, obj, tran);
            }
            catch (Exception ex)
            {
                //回滚事务并销毁连接对象
                Rollback(tran, conn);
                DisposeConn(conn);
                throw new Exception(ex.Message);
            }
            return result;
        }

        public async Task<T> ExecuteTranAsync<T>(Func<IDbConnection, IDbTransaction, Task<T>> func, object param)
        {
            T t;
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                using (var tran = (MySqlTransaction)conn.BeginTransaction())
                {
                    try
                    {
                        t = await func(conn, tran);
                        await tran.CommitAsync();
                        return t;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
    }
}
