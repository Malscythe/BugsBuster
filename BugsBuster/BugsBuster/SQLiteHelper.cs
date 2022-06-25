using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using BugsBuster.Tables;

namespace BugsBuster
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<RegUserTable>();
        }

        public Task<int> CreateUser(RegUserTable user)
        {
            return db.InsertAsync(user);
        }

        public Task<List<RegUserTable>>ReadUsers()
        {
            return db.Table<RegUserTable>().ToListAsync();
        }
        
        public Task<int> UpdateUsers(RegUserTable user)
        {
            return db.UpdateAsync(user);
        }

        public Task<int> DeleteUsers(RegUserTable user)
        {
            return db.DeleteAsync(user);
        }

        public Task<int> DeleteAllUsers()
        {
            return db.DeleteAllAsync<RegUserTable>();
        }
    }
}
