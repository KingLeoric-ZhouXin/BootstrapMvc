using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbContextFactory
    {
        public static DbContext Create()
        {
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;

            if (dbContext == null)
            {
                dbContext = new RM_DBEntities();
                CallContext.SetData("DbContext", dbContext);
            }

            return dbContext;

        }
    }
}
