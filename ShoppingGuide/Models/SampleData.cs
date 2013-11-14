using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ShoppingGuide.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<ShoppingGuideDB>
    {
        protected override void Seed(ShoppingGuideDB context)
        {
            /*
            var objects = new List<Object>
            {
                new Object { Variable = "value1" },
                new Object { Variable = "value2" },
                new Object { Variable = "value3" },
                new Object { Variable = "value4" },
                new Object { Variable = "value5" },
                new Object { Variable = "value6" },
                new Object { Variable = "value7" },
            };
            */
        }
    }
}