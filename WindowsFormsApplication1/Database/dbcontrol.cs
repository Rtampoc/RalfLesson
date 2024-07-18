using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Database {
    public class dbcontrol {
        SqlConnection cn = new SqlConnection("SERVER=(local)\\MAYOGROUP;DATABASE=dbsample;user=sa;pwd=1234");
        SqlCommand cm;
        SqlDataAdapter da;
        List<SqlParameter> param = new List<SqlParameter>();

        public DataTable Query(string Command, Action<Dictionary<string,object>> _parameters = null) {
            var dt = new DataTable();
            cn.Open();
            cm = new SqlCommand(Command, cn);

            var data = new Dictionary<string, object>();
            if (_parameters != null) {
                _parameters(data);
                foreach (KeyValuePair<string, object> d in data) {
                    cm.Parameters.Add(new SqlParameter(d.Key, d.Value));
                }
            }
            
            da = new SqlDataAdapter(cm);
            da.Fill(dt);
            cn.Close();
            return dt;
        }
    }
}
