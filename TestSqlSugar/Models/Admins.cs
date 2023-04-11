namespace TestSqlSugar.Models
{
    [SqlSugar.SugarTable("Admins")]
    public class Admins
    {
        public string id { get; set; }
        public string name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string state { get; set; }
    }
}
