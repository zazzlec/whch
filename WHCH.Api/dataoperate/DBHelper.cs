using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using MySql.Data.MySqlClient;

namespace SynWHCH
{
    public class DBHelper
    {
        //连接地址：sqlpaas1400
        //数据库名：SBWLWHCH
        //用户名：sbwl_WHCH
        //密码：105*sbwlWHCH*
        //"Data Source=sqlpaas1400; Initial Catalog=SBWLWHCH;User Id=sbwl_WHCH; PassWord=105*sbwlWHCH*;"


        //private string m_dbs = "Data Source=127.0.0.1;Database=sg_WHCH;User ID=root;Password=123456;pooling=true;CharSet=utf8;port=3306;sslmode=none";
       // private string m_dbs = "Data Source=DESKTOP-SF05DK1; Initial Catalog=SBWLWHCH;User Id=sa; PassWord=123;";
        /// <summary>
        /// 构造函数
        /// </summary>
        public DBHelper() { }
        public static string dbcon = "";

        public string ConnectString
        {
            get
            {
                //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ConnectionString"];
                //string str = settings.ConnectionString;
                //return str;
                return dbcon;

            }
        }

        /// <summary>
        /// 插入并获取ID
        /// </summary>
        /// <param name="connectString">数据库连接字符串</param>
        /// <param name="commandStr">SQL语句 包含获取ID的命令</param>
        /// <returns>新记录的ID</returns>
        public int ExecuteScalarInsert(string connectString, string commandStr)
        {
            string err = "";
            int ret = 0;
            if (string.IsNullOrEmpty(connectString))
            {
                return -1;
            }
            using (MySqlConnection dbc = new MySqlConnection(connectString))
            {
                MySqlCommand insert = new MySqlCommand(commandStr, dbc);

                try
                {
                    dbc.Open();
                    ret = Convert.ToInt32(insert.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
            }

            if (err.Length > 0)
            {
                return -1;
            }
            else
            {
                return ret;
            }
        }

        /// <summary>
        /// 插入并获取ID
        /// </summary>
        /// <param name="commandStr">SQL语句 包含获取ID的命令</param>
        /// <returns>新记录的ID</returns>
        public int ExecuteScalarInsert(string commandStr)
        {
            string err = "";
            int ret = 0;
            if (string.IsNullOrEmpty(ConnectString))
            {
                return -1;
            }
            using (MySqlConnection dbc = new MySqlConnection(ConnectString))
            {
                MySqlCommand insert = new MySqlCommand(commandStr, dbc);

                try
                {
                    dbc.Open();
                    ret = Convert.ToInt32(insert.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
            }

            if (err.Length > 0)
            {
                return -1;
            }
            else
            {
                return ret;
            }
        }

        /// <summary>
        /// 添加、删除、更新操作
        /// </summary>
        /// <param name="connectString">数据库连接字符串</param>
        /// <param name="commandstr">SQL语句</param>
        /// <returns>受影响的行数</returns>
        public int CommandExecuteNonQuery(string connectString, string commandstr)
        {
            if (string.IsNullOrEmpty(connectString) || string.IsNullOrEmpty(commandstr))
            {
                return -1;
            }
            string err = "";
            int result = 0;
            using (MySqlConnection dbc = new MySqlConnection(connectString))
            {
                MySqlCommand command = new MySqlCommand(commandstr, dbc);
                try
                {
                    dbc.Open();
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
            }

            if (err.Length > 0)
            {
                return -1;
            }
            else
            {
                return result;
            }

        }



        /// <summary>
        /// 添加、删除、更新操作
        /// </summary>
        /// <param name="connectString">数据库连接字符串</param>
        /// <param name="commandstr">SQL语句</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>受影响的行数</returns>
        public int CommandExecuteNonQuery(string connectString, string commandstr, params MySqlParameter[] cmdParms)
        {
            if (string.IsNullOrEmpty(connectString) || string.IsNullOrEmpty(commandstr))
            {
                return -1;
            }
            string err = "";
            int result = 0;
            using (MySqlConnection dbc = new MySqlConnection(connectString))
            {
                using (MySqlCommand command = new MySqlCommand(commandstr, dbc))
                {
                    try
                    {
                        //dbc.Open();
                        PrepareCommand(command, dbc, null, commandstr, cmdParms);
                        result = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        err = ex.Message;
                    }
                }
                
            }

            if (err.Length > 0)
            {
                return -1;
            }
            else
            {
                return result;
            }

        }
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        /// <summary>
        /// 添加、删除、更新操作
        /// </summary>
        /// <param name="commandstr">SQL语句</param>
        /// <returns>受影响的行数</returns>
        public int CommandExecuteNonQuery(string commandstr)
        {
            if (string.IsNullOrEmpty(ConnectString) || string.IsNullOrEmpty(commandstr))
            {
                return -1;
            }
            string err = "";
            int result = 0;
            using (MySqlConnection dbc = new MySqlConnection(ConnectString))
            {
                MySqlCommand command = new MySqlCommand(commandstr, dbc);
                try
                {
                    dbc.Open();
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
            }

            if (err.Length > 0)
            {
                return -1;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="connectString">数据库连接字符串</param>
        /// <param name="selectstr">SQL语句</param>
        /// <returns>数据表</returns>
        public DataTable GetCommand(string connectString, string selectstr)
        {
            if (string.IsNullOrEmpty(connectString) || string.IsNullOrEmpty(selectstr))
            {
                return null;
            }
            DataTable table = new DataTable();

            string err = "";
            using (MySqlConnection dbc = new MySqlConnection(connectString))
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(selectstr, dbc);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
            }

            if (err.Length > 0)
            {
                return null;
            }
            else
            {
                return table;
            }
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="selectstr">SQL语句</param>
        /// <returns>数据表</returns>
        public DataTable GetCommand(string selectstr)
        {
            if (string.IsNullOrEmpty(ConnectString))
            {
                return null;
            }
            DataTable table = new DataTable();
            string err = "";
            using (MySqlConnection dbc = new MySqlConnection(ConnectString))
            {
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = new MySqlCommand(selectstr, dbc);
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    err = ex.Message;
                }
            }

            if (err.Length > 0)
            {
                return null;
            }
            else
            {
                return table;
            }
        }

        /// <summary>
        /// 执行一个事务
        /// </summary>
        /// <param name="commands">事务中要执行的所有语句</param>
        /// <returns>事务是否成功执行</returns>
        public bool ExecuteTransaction(List<string> commands)
        {
            if (string.IsNullOrEmpty(ConnectString) || commands == null)
            {
                return false;
            }

            string err = "";
            bool ret = false;
            using (MySqlConnection dbc = new MySqlConnection(ConnectString))
            {
                dbc.Open();
                using (MySqlTransaction transaction = dbc.BeginTransaction())
                {
                    try
                    {
                        foreach (string commandstr in commands)
                        {
                            MySqlCommand command = new MySqlCommand(commandstr, dbc);
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        ret = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        err = ex.Message;
                    }
                }
            }

            if (err.Length > 0)
            {
                return false;
            }
            else
            {
                return ret;
            }
        }

        /// <summary>
        /// 执行一个事务
        /// </summary>
        /// <param name="connectString">数据库连接字符串</param>
        /// <param name="commands">事务中要执行的所有语句</param>
        /// <returns>事务是否成功执行</returns>
        public bool ExecuteTransaction(string connectString, List<string> commands)
        {
            if (string.IsNullOrEmpty(connectString) || commands == null)
            {
                return false;
            }

            string err = "";
            bool ret = false;
            using (MySqlConnection dbc = new MySqlConnection(connectString))
            {
                dbc.Open();
                using (MySqlTransaction transaction = dbc.BeginTransaction())
                {
                    try
                    {
                        foreach (string commandstr in commands)
                        {
                            MySqlCommand command = new MySqlCommand(commandstr, dbc);
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        ret = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        err = ex.Message;
                    }
                }
            }

            if (err.Length > 0)
            {
                return false;
            }
            else
            {
                return ret;
            }
        }
    }
}