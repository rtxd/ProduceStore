using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTS.ProduceStore.Data;

namespace UTS.ProduceStore.DomainLogic
{
    
    public class ProduceService
    {

        //Domain code for Data Maintainer 

        //Method for retreiving all produce
        public List<Produce> AllProduce()
        {
            using (var db = new ProduceStoreEntities())
            {
                var query = from p in db.Produces
                            where p.ProduceName == name
                            select p;
                return query.ToList();
                return db.Produces.ToList();
            }
        }

        //Method for finding produce by ID
        public Produce GetProduceById(int id)
        {
            using (var db = new ProduceStoreEntities())
            {
                Produce Find = db.Produces.Find(id);
                return Find;
            }
            
        }

        //Method for adding produce
        public void Add(Produce produce)
        {
            using (var db = new ProduceStoreEntities())
            {
                db.Produces.Add(produce);
                db.SaveChanges();
            }
        }

        //Method for editing produce
        public void Update(Produce produce)
        {
            using (var db = new ProduceStoreEntities())
            {
                db.Entry(produce).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //Method for deleting product
        public void Delete(Produce produce)
        {
            using (var db = new ProduceStoreEntities())
            {
                db.Produces.Remove(produce);
                db.SaveChanges();
            }
        }
    }
}
