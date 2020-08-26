using SPRAK.Domain.Entity;
using SPRAK.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRAK.Infrastructure.SQLServer
{
    internal sealed class PartsListSQLServer : IPartsListRipository
    {
        public void Delete(PartsListEtity partsData)
        {
            StringBuilder query = new StringBuilder();
            var parameters = new List<SqlParameter>();

            query.AppendLine("delete");
            query.AppendLine("from");
            query.AppendLine("        [DDD2].[dbo].[PartsList]");
            query.AppendLine("where");
            query.AppendLine("        [ID]=@ID");

            parameters.Clear();
            parameters.Add(new SqlParameter("@ID", partsData.Id));
            SqlServerHelper.Execute(query.ToString(), parameters.ToArray());

        }

        public IReadOnlyList<PartsListEtity> GetPartsList(int sqkId)
        {
            StringBuilder query = new StringBuilder();
            var parameters = new List<SqlParameter>();
            var list = new List<PartsListEtity>();

            query.AppendLine("select");
            query.AppendLine("        [ID]");
            query.AppendLine("        ,[SQKID]");
            query.AppendLine("        ,[部品番号]");
            query.AppendLine("        ,[部品名称]");
            query.AppendLine("        ,[数量]");
            query.AppendLine("from");
            query.AppendLine("        [DDD2].[dbo].[PartsList]");
            query.AppendLine("where");
            query.AppendLine("        [SQKID]=@SQKID");

            parameters.Clear();
            parameters.Add(new SqlParameter("@SQKID", sqkId));

            SqlServerHelper.Query(
                query.ToString(),
                parameters.ToArray(),
                reader =>
                {
                    list.Add(new PartsListEtity(
                        Convert.ToInt32(reader["ID"]),
                        Convert.ToInt32(reader["SQKID"]),
                        Convert.ToString(reader["部品番号"]),
                        Convert.ToString(reader["部品名称"]),
                        Convert.ToInt32(reader["数量"])));
                });
            return list.AsReadOnly();
        }

        public void Save(PartsListEtity partsData)
        {
            StringBuilder query = new StringBuilder();
            var parameters = new List<SqlParameter>();

            query.AppendLine("insert into [PartsList]");
            query.AppendLine("(");
            query.AppendLine("[部品番号]");
            query.AppendLine(",[部品名称]");
            query.AppendLine(",[数量]");
            query.AppendLine(",[SQKID]");
            query.AppendLine(")");
            query.AppendLine("values");
            query.AppendLine("(");
            query.AppendLine("@部品番号");
            query.AppendLine(",@部品名称");
            query.AppendLine(",@数量");
            query.AppendLine(",@SQKID");
            query.AppendLine(")");

            parameters.Clear();
            parameters.Add(new SqlParameter("@部品番号", partsData.PartsNumber));
            parameters.Add(new SqlParameter("@部品名称", partsData.PartsName));
            parameters.Add(new SqlParameter("@数量", partsData.PartsQuantity));
            parameters.Add(new SqlParameter("@SQKID", partsData.SqkId));

            SqlServerHelper.Execute(query.ToString(), parameters.ToArray());
        }
    }
}
