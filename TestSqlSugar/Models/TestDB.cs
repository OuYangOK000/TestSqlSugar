using SqlSugar;

namespace TestSqlSugar.Models
{
    public class TestDB
    {
        public static string db_ConnectionString = "server=.;database=TestDb;uid=sa;pwd=sa;";
        public static string db_Sqlserverconnectionstring { get; set; }
        public static SqlSugarClient db
        {
            get => new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = db_ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
        }
        public static void createDB()
        {
            db.DbMaintenance.CreateDatabase();
            db.CodeFirst.InitTables(
                    typeof(Models.Admins)
                );
            db.Insertable(new Admins()
            {
                id="zhangsan",
                name="高某",
                Login="123456",
                Password="312",
                state="离开"
            }).ExecuteCommand();
        }
        public static List<Admins> admin()
        {
            return db.Queryable<Admins>().ToList();
        }
    }
}
