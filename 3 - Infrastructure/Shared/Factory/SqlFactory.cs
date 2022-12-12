using System.Data;
using System.Data.SqlClient;

namespace Shared.Factory
{
    public class SqlFactory
    {
        public IDbConnection SqlConnection()
        {
            return new SqlConnection("Data Source=DESKTOP-NTJGB36\\SQLEXPRESS; Initial Catalog=BANCO_FROTA; Integrated Security=SSPI;");
            //data source = DESKTOP - NTJGB36\SQLEXPRESS; initial catalog = DatabaseFirstVendas; integrated security = True; MultipleActiveResultSets = True
        }
    }
}
