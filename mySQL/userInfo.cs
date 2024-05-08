using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInternship.mySQL
{
    [Table("userdata")]
    internal class userInfo
    {
        public string id { get; set; }
        public string username { get; set; }

        public userInfo(string id, string username)
        {
            this.id = id;
            this.username = username;
        }

        public userInfo()
        {
        }
    }
}