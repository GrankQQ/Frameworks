using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLibrary
{
    public class UserData
    {
        SQLContextDataContext context = new SQLContextDataContext("Data Source=BJ-ZB1-WMS-GRR;Initial Catalog=Test;Persist Security Info=True;User ID=sa;Password=cc.123");
        
        public void Insert()
        {
            User us = new User();
            us.Name = "test1";
            context.User.InsertOnSubmit(us);
            context.SubmitChanges();
        }
    }
}
