using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace PlanLekcji.ClassModel
{
    public class UserConfig
    {
        [PrimaryKey , AutoIncrement]
        public int ID { get; set; }
        public string DeafultClass { get; set; }

        public UserConfig()
        {

        }

        public UserConfig(string clas)
        {
            DeafultClass = clas;
        }
    }
    
}
