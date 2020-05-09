using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WobbadexClassLibrary
{
    public class UserRepository
    {
        private readonly List<WobbaUser> userRepository;
        private readonly string connectionString =
            @"Server = DESKTOP-QA4COAS\SQLEXPRESS; Database = Wobbadex; Trusted_Connection = True";

        public UserRepository()
        {
            userRepository = GetUserData(connectionString);
        }        

        public List<WobbaUser> GetRepo()
        {
            return userRepository;
        }

        private List<WobbaUser> GetUserData(string connectionString)
        {            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM wobbaUsers";
                DataTable usersTable = new DataTable();

                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    dataAdapter.Fill(usersTable);
                }

                List<WobbaUser> wobbaUsers = new List<WobbaUser>();
                foreach(DataRow row in usersTable.Rows)
                {
                    wobbaUsers.Add(new WobbaUser
                    {
                        UserId = (int)row.ItemArray[0],
                        UserName = (string)row.ItemArray[1],
                        PwHash = (string)row.ItemArray[2]
                    });
                }
                return wobbaUsers;
            }            
        }
    }
}
