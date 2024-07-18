using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Database;

namespace WindowsFormsApplication1.Classes {
    public class Person {
        dbcontrol s = new dbcontrol();
        public int ID { get; set; }
        public string fname { get; set; }
        public string mn { get; set; }
        public string lname { get; set; }
        public DateTime bday { get; set; }
        public decimal? salary { get; set; }

        public int Age { get { return GetAge(bday); } }

        int GetAge(DateTime _Birthday) {
            return DateTime.Now.Subtract(_Birthday).Days / 365;
        }

        public List<Person> List() {
            var list = new List<Person>();
            foreach (DataRow r in s.Query("SELECT * FROM tbl_sample").Rows) {
                list.Add(new Person {
                    ID = Convert.ToInt32(r["ID"]),
                    fname = r["fname"] as string,
                    mn = r["mn"] as string,
                    lname = r["lname"].ToString(),
                    bday = Convert.ToDateTime(r["bday"]),
                    salary = r.IsNull(5) ? 0 : Convert.ToDecimal(r[5])
                });
            }
            return list;
        }

        public void Create(Person obj) {
            s.Query($"INSERT INTO tbl_sample (fname,mn,lname,bday,salary) VALUES (@fname,@mn,@lname,@bday,@salary)", p => {
                p.Add("@fname", obj.fname);
                p.Add("@mn", obj.mn);
                p.Add("@lname", obj.lname);
                p.Add("@bday", obj.bday);
                p.Add("@salary", obj.salary);
            });
        }
    }
}
