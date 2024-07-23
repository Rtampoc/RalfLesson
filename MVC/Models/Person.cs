using AAJControl;
using MVC.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Person
    {
        dbController s = new dbController();
        /*DBControl s = new DBControl(DatabaseType.MSSQL, @"SERVER=(local)\SQLEXPRESS;DATABASE=DBCRUD;USER=SA;PWD=1234");*/
        public int ID { get; set; }
        [Display(Name = "First name")]
        public string fname { get; set; }

        [Display(Name = "Middle name")]
        public string mn { get; set; }

        [Display(Name = "Last name")]
        public string lname { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
       
        public DateTime bday { get; set; }
        
        public decimal? salary { get; set; }

        public List<Person> List()
        {
            return s.Query<Person>("SELECT * FROM tbl_sample");
        }

        /*public List<Person> List(string Search)
        {
            return s.Query<Person>("SELECT * FROM tbl_sample WHERE fname LIKE @fname OR mn LIKE @mn OR lname LIKE @lname", p => {
                p.Add("@fname", $"%{ Search }%");
                p.Add("@mn", $"%{ Search }%");
                p.Add("@lname", $"%{ Search }%");
            });
        }*/


        //Another method
        public List<Person> List(string Search)
        {   
            
            return s.Query<Person>("SELECT * FROM tbl_sample WHERE CONCAT(fname,mn,lname) LIKE @search", p => p.Add("@search", $"%{ Search }%"));
        }

        public Person Find(int ID)
        {
            return s.Query<Person>("SELECT * FROM tbl_sample WHERE ID = @ID", p => p.Add("@ID", ID)).SingleOrDefault();
        }


        public void Insert(Person obj)
        {
            s.InsertNormal("tbl_sample", p =>
            {
                p.Add("fname", obj.fname);
                p.Add("mn", obj.mn);
                p.Add("lname", obj.lname);
                p.Add("bday", obj.bday);
                p.Add("salary", obj.salary);
            });
        }

        public void Update(Person obj)
        {
            s.Update("tbl_sample", obj.ID, p =>
            {
                p.Add("fname", obj.fname);
                p.Add("mn", obj.mn);
                p.Add("lname", obj.lname);
                p.Add("bday", obj.bday);
                p.Add("salary", obj.salary);
            });
        }
        public Person DeleteData(int ID)
        {
            return s.Query<Person>("DELETE FROM tbl_sample WHERE ID = @ID", p => p.Add("ID", ID)).SingleOrDefault();
        }
        public void DeleteViewData(Person obj)
        {
            s.Update("tbl_sample", obj.ID, p =>
            {
                p.Add("fname", obj.fname);
                p.Add("mn", obj.mn);
                p.Add("lname", obj.lname);
                p.Add("bday", obj.bday);
                p.Add("salary", obj.salary);
            });

        }

    }
}