using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInternship.mySQL
{
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