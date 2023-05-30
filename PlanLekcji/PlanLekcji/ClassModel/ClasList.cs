using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace PlanLekcji.ClassModel
{
    public class ClasList
    {
        [PrimaryKey , AutoIncrement]
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string ClassID { get; set; }

        public ClasList()
        {

        }
        public ClasList(string className, string classID)
        {
            ClassName = className;
            ClassID = classID;
        }
    }
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;
        public Database(string dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<ClasList>().Wait();  
            _database.CreateTableAsync<UserConfig>().Wait();  
        }
        public Task<List<ClasList>> GetClases()
        {
            return _database.Table<ClasList>().ToListAsync();
        }
        public Task<int> InsertToDb(ClasList list) 
        {
            return _database.InsertAsync(list);
        }
        public Task<int> ClearClassListAsync()
        {
            return _database.DeleteAllAsync<ClasList>();
        }
        public Task<List<UserConfig>> GetUserConfig()
        {
            return _database.Table<UserConfig>().ToListAsync();
        }
        public Task<int> CreateUserConfig(UserConfig config)
        {
            return _database.InsertAsync(config);
        }
        public Task<int> UpdateUserConfig(UserConfig config)
        {
            return _database.UpdateAsync(config);
        }
        public Task<int> ClearConfigAsync()
        {
            return _database.DeleteAllAsync<UserConfig>();
        }
    }
}
