using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dollybal
{
    public class DollySheep
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public float Height { get; set; }
        public DateTime DOB { get; set; }
        //public DollySheep()
        //{

        //}
    }
    public class DollyElementContext:DbContext
    {
        public DollyElementContext():base("defaultConnection")
        {
            Database.CreateIfNotExists();
        }
        public DollyElementContext(string connection = "defaultConnection") : base(connection)
        {
            Database.CreateIfNotExists();
        }
        public DbSet<DollySheep> Sheeps { get; set; }
    }
}
