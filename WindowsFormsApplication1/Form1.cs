using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Classes;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        Person person = new Person();
        public Form1() {
            InitializeComponent();
            personBindingSource.DataSource = person.List();
        }


        private void btnSubmit_Click(object sender, EventArgs e) {
            person.Create(new Person {
                fname = txtfname.Text,
                mn = txtmn.Text,
                lname = txtlname.Text,
                bday = dtpBirthday.Value,
                salary = Convert.ToDecimal(txtsalary.Text)
            });
            personBindingSource.DataSource = person.List();
        }
    }
}
