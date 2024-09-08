using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace WPF_FormularioInicioDeSesion.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string connectionString = "Server = localhost\\SQLEXPRESS;Database=MVVMLoginDb;Trusted_Connection=True;";

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand CorrectPassword { get; }
        public ICommand ErrorPasword { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Login()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [MVVMLoginDb].[dbo].[User] WHERE Username = @Username AND Password = @Password";
                Console.WriteLine("Consulta realizada");

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    // Usuario encontrado
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        Console.WriteLine($"Bienvenido {name}");

                        // Lo que ocurre si es correcto
                    }
                } else
                {
                    // Login fallido
                    Console.WriteLine("Usuario o contraseña incorrectos");
                }
            }
        }

    }
}
