using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_FormularioInicioDeSesion.Model;

namespace WPF_FormularioInicioDeSesion.ViewModel
{
    internal class TestViewModel
    {
        public ObservableCollection<UserModel> Users { get; set; }

        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=MVVMLoginDb;Trusted_Connection=True;";

        public TestViewModel()
        {
            Users = new ObservableCollection<UserModel>();
            ChargeData();
        }

        private void ChargeData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select Id from [MVVMLoginDb].[dbo].[User]", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Users.Add(new UserModel
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString()
                    });
                }

            }
        }
    }
}
