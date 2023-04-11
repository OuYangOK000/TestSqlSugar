using SqlSugar;
using System.Runtime.Intrinsics.X86;

namespace TestSqlSugar.Models
{
    public class SqlDB
    {
        public static SqlSugarClient ssc = new SqlSugarClient(
            new ConnectionConfig()
            {
                ConnectionString= "server=.;DataBase=DB_Cinema;Uid=sa;Pwd=sa;",
                DbType=DbType.SqlServer,
                IsAutoCloseConnection=true,
                //InitKeyType=InitKeyType.Attribute
            });
        public static List<Admins> admins()
        {
            return ssc.Queryable<Admins>().ToList();
        }
        public static int upadmin(Admins ab,string id)
        {
            return ssc.Updateable(ab).Where(ad => ad.id == id).ExecuteCommand();
        }
    }
}
