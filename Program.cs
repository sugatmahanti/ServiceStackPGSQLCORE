using ServiceStack.OrmLite;
using ServiceStack.Text;

namespace ConsoleApplication
{
    public class sample{
       
        public int id{get;set;}
        public string Name{get;set;}
    }
    public class Program
    {
        public static void Main(string[] args)
        {
           string connectionString ="UserID=smahanti;Host=localhost;Port=5432;Database=test;";
          var dbFactory = new OrmLiteConnectionFactory(
    connectionString,  
    PostgreSqlDialect.Provider);
    using (var db = dbFactory.Open())
{
    if (db.CreateTableIfNotExists<sample>())
    {
        db.Insert(new sample { id = 1, Name = "Seed Data"});
    }
    var result = db.Single<sample>(1);
    result.PrintDump(); 
}
        }
    }
}
