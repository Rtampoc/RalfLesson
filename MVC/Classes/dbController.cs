using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using AAJControl;

namespace MVC.Classes
{
    public class dbController: DBControl
    {
       
        public dbController() : base(DatabaseType.MSSQL, ConfigurationManager.ConnectionStrings["TrainingCon"].ConnectionString)
        {

        }
    }
}