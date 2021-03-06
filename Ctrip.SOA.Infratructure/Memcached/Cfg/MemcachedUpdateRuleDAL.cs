/******************************************************************
** 数据库HHCfgDB中表MemcachedUpdateRule数据访问层操作类
** 此代码由工具自动生成
******************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using HHInfratructure.Data;

namespace HHInfratructure.Memcached.Cfg
{
    /// <summary>
    /// 缓存刷新规则表数据访问类
    /// </summary>
   public class MemcachedUpdateRuleDAL : DALContext
   {
        public MemcachedUpdateRuleDAL() : base(DBConsts.HHCfgDB_SELECT) { }

        /// <summary>
        /// 根据主键获取一个实体对象
        /// </summary>
        public MemcachedUpdateRuleEntity Select(int MemcachedUpdateRuleId)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "select * from MemcachedUpdateRule with(nolock) where MemcachedUpdateRuleId=@MemcachedUpdateRuleId";
            cmd.CommandType = System.Data.CommandType.Text;

            DB.AddInParameter(cmd, "MemcachedUpdateRuleId", DbType.Int32, MemcachedUpdateRuleId);
            DataSet ds = DB.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0) return null;

            DataRow dr = ds.Tables[0].Rows[0];
            return MemcachedUpdateRuleEntity.CreateEntity(dr);
        }

        /// <summary>
        /// 根据条件获取一个实体对象
        /// </summary>
        public MemcachedUpdateRuleEntity Select(string where)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "select * from MemcachedUpdateRule with(nolock) where " + where;
            cmd.CommandType = System.Data.CommandType.Text;

            DataSet ds = DB.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0) return null;

            DataRow dr = ds.Tables[0].Rows[0];
            return MemcachedUpdateRuleEntity.CreateEntity(dr);
        }

        /// <summary>
        /// 根据条件获取对应的记录集
        /// </summary>
        public DataTable SelectTable(string where)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "select * from MemcachedUpdateRule with(nolock) where " + where;
            cmd.CommandType = System.Data.CommandType.Text;

            DataSet ds = DB.ExecuteDataSet(cmd);
            if (ds.Tables[0].Rows.Count == 0) return null;

            return ds.Tables[0];
        }

        /// <summary>
        /// 根据指定字段、字段值、表达式，查询出符合条件的记录，并按照指定的排序方式返回记录集
        /// </summary>
        /// <param name="fields">字段集</param>
        /// <param name="values">字段对应的值</param>
        /// <param name="expressions">字段与值的表达式</param>
        /// <param name="orderby">排序字段，默认asc，需要desc直接含在排序字段中</param>
        /// <returns>符合条件的记录集</returns>
        public DataTable Select(List<string> fields, List<string> values, List<string> expressions, List<string> orderby)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "select * from MemcachedUpdateRule with(nolock) where ";
            cmd.CommandType = System.Data.CommandType.Text;

            for (int i = 0; i < fields.Count; i++)
            {
                cmd.CommandText += fields[i] + " " + expressions[i] + " @" + fields[i] + " & ";
                if (expressions[i].ToLower() != "like")
                    DB.AddInParameter(cmd, "@" + fields[i], DbType.Object, values[i]);
                else
                    DB.AddInParameter(cmd, "@" + fields[i], DbType.String, " % " + values[i] + " % ");
            }
            cmd.CommandText = cmd.CommandText.TrimEnd().TrimEnd('&').Replace("&", " and ");

            if (orderby != null && orderby.Count > 0)
            {
                cmd.CommandText += " order by ";
                for (int i = 0; i < orderby.Count; i++)
                {
                    cmd.CommandText += orderby[i] + ",";
                }
            }
            cmd.CommandText = cmd.CommandText.TrimEnd(',');

            return DB.ExecuteDataSet(cmd).Tables[0];
        }

        public bool Insert(MemcachedUpdateRuleEntity entity)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "spA_MemcachedUpdateRule_i";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DB.AddOutParameter(cmd, "@MemcachedUpdateRuleId", DbType.Int32, entity.MemcachedUpdateRuleId);
            if (entity.CacheKey != null) DB.AddInParameter(cmd, "@CacheKey", DbType.AnsiString, entity.CacheKey);
            if (entity.LastUpdateTime.Year != 1) DB.AddInParameter(cmd, "@LastUpdateTime", DbType.DateTime, entity.LastUpdateTime);
            DB.AddInParameter(cmd, "@UpdateHourSpan", DbType.Int32, entity.UpdateHourSpan);
            if (entity.CacheKeyPrefix != null) DB.AddInParameter(cmd, "@CacheKeyPrefix", DbType.AnsiString, entity.CacheKeyPrefix);
            DB.AddInParameter(cmd, "@IsJobActByMin", DbType.Int32, entity.IsJobActByMin);
            if (entity.ConditionEntityJson != null) DB.AddInParameter(cmd, "@ConditionEntityJson", DbType.AnsiString, entity.ConditionEntityJson);
            DB.AddInParameter(cmd, "@IsMainKey", DbType.Int32, entity.IsMainKey);
            if (entity.ProcessIP != null) DB.AddInParameter(cmd, "@ProcessIP", DbType.AnsiString, entity.ProcessIP);
            if (entity.UpdateLockTime.Year != 1) DB.AddInParameter(cmd, "@UpdateLockTime", DbType.DateTime, entity.UpdateLockTime);
            if (entity.DataChange_LastTime.Year != 1) DB.AddInParameter(cmd, "@DataChange_LastTime", DbType.DateTime, entity.DataChange_LastTime);
            bool b = (int)DB.ExecuteNonQuery(cmd) == 0 ? true : false;
            entity.MemcachedUpdateRuleId = int.Parse(DB.GetParameterValue(cmd, "@MemcachedUpdateRuleId").ToString());
            return b;
        }

        public bool Update(MemcachedUpdateRuleEntity entity)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "spA_MemcachedUpdateRule_u";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DB.AddInParameter(cmd, "@MemcachedUpdateRuleId", DbType.Int32, entity.MemcachedUpdateRuleId);
            if (entity.CacheKey != null) DB.AddInParameter(cmd, "@CacheKey", DbType.AnsiString, entity.CacheKey);
            if (entity.LastUpdateTime.Year != 1) DB.AddInParameter(cmd, "@LastUpdateTime", DbType.DateTime, entity.LastUpdateTime);
            DB.AddInParameter(cmd, "@UpdateHourSpan", DbType.Int32, entity.UpdateHourSpan);
            if (entity.CacheKeyPrefix != null) DB.AddInParameter(cmd, "@CacheKeyPrefix", DbType.AnsiString, entity.CacheKeyPrefix);
            DB.AddInParameter(cmd, "@IsJobActByMin", DbType.Int32, entity.IsJobActByMin);
            if (entity.ConditionEntityJson != null) DB.AddInParameter(cmd, "@ConditionEntityJson", DbType.AnsiString, entity.ConditionEntityJson);
            DB.AddInParameter(cmd, "@IsMainKey", DbType.Int32, entity.IsMainKey);
            if (entity.ProcessIP != null) DB.AddInParameter(cmd, "@ProcessIP", DbType.AnsiString, entity.ProcessIP);
            if (entity.UpdateLockTime.Year != 1) DB.AddInParameter(cmd, "@UpdateLockTime", DbType.DateTime, entity.UpdateLockTime);
            if (entity.DataChange_LastTime.Year != 1) DB.AddInParameter(cmd, "@DataChange_LastTime", DbType.DateTime, entity.DataChange_LastTime);
            return DB.ExecuteNonQuery(cmd) == 0 ? true : false;
        }

        public bool Delete(int MemcachedUpdateRuleId)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            cmd.CommandText = "spA_MemcachedUpdateRule_d";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DB.AddInParameter(cmd, "@MemcachedUpdateRuleId", DbType.Int32, MemcachedUpdateRuleId);
            return DB.ExecuteNonQuery(cmd) == 0 ? true : false;
        }

        public List<MemcachedUpdateRuleEntity> GetJobUpdateData(int mod, int remainder)
        {
            DbCommand cmd = DB.DbProviderFactory.CreateCommand();
            string sql = string.Format(@"SELECT TOP 1000 A.MemcachedUpdateRuleId, A.CacheKey,A.CacheKeyPrefix, A.ConditionEntityJson FROM MemcachedUpdateRule AS A
INNER JOIN MemcachedGetFrequency AS B ON A.CacheKeyPrefix=B.CacheKeyPrefix
INNER JOIN MemcachedUpdateSetConfig AS C ON A.CacheKeyPrefix=C.CacheKeyPrefix
WHERE B.FreCount>C.FreMin AND DATEDIFF(mi,A.LastUpdateTime,GETDATE())>=C.UpdateHourSpan
AND MemcachedUpdateRuleId % {0}={1} ORDER BY C.UpdateHourSpan ASC, B.FreCount DESC,A.LastUpdateTime DESC;", mod, remainder);

            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            DataSet ds = DB.ExecuteDataSet(cmd);

            List<MemcachedUpdateRuleEntity> list = new List<MemcachedUpdateRuleEntity>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MemcachedUpdateRuleEntity ent = new MemcachedUpdateRuleEntity();
                if (dr["MemcachedUpdateRuleId"] != DBNull.Value) ent.MemcachedUpdateRuleId = int.Parse(dr["MemcachedUpdateRuleId"].ToString());
                if (dr["CacheKey"] != DBNull.Value) ent.CacheKey = (string)dr["CacheKey"];
                if (dr["CacheKeyPrefix"] != DBNull.Value) ent.CacheKeyPrefix = (string)dr["CacheKeyPrefix"];
                if (dr["ConditionEntityJson"] != DBNull.Value) ent.ConditionEntityJson = (string)dr["ConditionEntityJson"];
                list.Add(ent);
            }
            return list;
        }
    }
}
