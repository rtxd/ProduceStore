using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTS.ProduceStore.Data;

namespace UTS.ProduceStore.DomainLogic
{
    //Domain Code for Editor and Approver
    public class RulesService
    {
        
        //Generic methods

        //Method for retrieving all rules with a given status
        public List<Rule> GetRulesByStatus(string status)
        {
            using (var db = new ProduceStoreEntities())
            {
                var query = from r in db.Rules
                            where r.RuleStatus == status
                            select r;
                return query.ToList<Rule>();
            }
        }
        

        //Method for retrieving a single Rule
        public Rule GetRuleById(int id)
        {
            using (var db = new ProduceStoreEntities())
            {
                /*return (from r in db.Rules
                        where r.RuleId == id
                        select r).First();*/
                
                Rule rule = db.Rules.Find(id);
                return rule;
            }
        }

        //Editor-only methods

        //Method for adding a rule
        public void Add(Rule rule)
        {
            using (var db = new ProduceStoreEntities())
            {
                db.Rules.Add(rule);
                db.SaveChanges();
            }
        }

        //Method for editing a rule
        public void Update(Rule rule)
        {
            using (var db = new ProduceStoreEntities())
            {
                db.Entry(rule).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //Method for deleting a rule
        public void Delete(Rule rule)
        {
            using (var db = new ProduceStoreEntities())
            {
                db.Rules.Remove(rule);
                db.SaveChanges();
            }
        }

        //Approver Methods
    }
}
