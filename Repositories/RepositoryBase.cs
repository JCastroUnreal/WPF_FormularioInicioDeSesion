using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WPF_FormularioInicioDeSesion.Repositories
{
    internal abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Server=(local); Database=MVVMLoginDb; Integrated Security_true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection( _connectionString );
        }
    }
}
