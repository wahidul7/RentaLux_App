using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;

namespace App5
{
    public class Database
    {
        private SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<int> AddUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<User> GetUserAsync(string username, string password)
        {
            return _database.Table<User>().Where(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return _database.Table<User>().Where(u => u.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DriverLicense { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
