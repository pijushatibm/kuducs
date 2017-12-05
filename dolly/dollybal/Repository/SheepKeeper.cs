using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dollybal.Repository
{
    public interface ISheepKeeper
    {
        List<DollySheep> GetSheeps();
        DollySheep GetSheep(string ID);
        DollySheep AddSheep(DollySheep model);
        DollySheep UpdateSheep(DollySheep model);
        DollySheep DeleteSheep(DollySheep model);
    }
    public class SheepKeeper : ISheepKeeper
    {
        private DollyElementContext db = new DollyElementContext();
        public DollySheep AddSheep(DollySheep model)
        {
            db.Sheeps.Add(model);
            db.SaveChanges();
            return model;
        }

        public DollySheep DeleteSheep(DollySheep model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return model;
        }

        public DollySheep GetSheep(string ID)
        {
            var model = db.Sheeps.Where(x => x.ID == ID).FirstOrDefault();
            return model;
        }

        public List<DollySheep> GetSheeps()
        {
            return db.Sheeps.ToList();
        }

        public DollySheep UpdateSheep(DollySheep model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return model;
        }
    }
}
