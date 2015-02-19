using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SE_3800InclassProj.Models
{
    public class Projectdb : DbContext
    {
        public DbSet<Number> Numbers { get; set; }
    }
}