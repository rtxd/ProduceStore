using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UTS.ProduceStore.Data;

namespace UTS.ProduceStore.DomainLogic
{
    public class RuleEngine
    {
        //The list of rules
        List<Rule> ruleCollection = new List<Rule>();

        /// <summary>
        /// Gets all rules from database 
        /// </summary>
        /// <returns>A list of rules</returns>
        public List<Rule> getRules()
        {
            List<Rule> rules = new List<Rule>();
            using (var db = new ProduceStoreEntities())
            {
                rules = db.Rules.ToList();
            }
            return rules;
        }

        /// <summary>
        /// Takes a question, matches it with a rule and returns its answer
        /// </summary>
        /// <param name="question"></param>
        /// <returns>A string answer to the question</returns>
        public string Answer(string question)
        {
            Regex regex;
            Match match;
            ruleCollection = getRules();


            string answer = "Sorry, I don't understand";
            foreach(Rule rule in ruleCollection)
            {
                if (rule.RuleStatus == "Rejected" || rule.RuleStatus == "Pending") break;
                regex = new Regex(rule.RegularExpression);
                match = regex.Match(question);
                if(match.Success)
                {
                    answer = QueryProduces(rule.Query.Replace("{0}", match.Groups[rule.RegExGroup].Value));
                    
                }
            }

            return answer.Trim();
        }

        /// <summary>
        /// Queries the produce table
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Result of query</returns>
        public string QueryProduces(string command)
        {
            string result = "";
            using (var context = new ProduceStoreEntities())
            {
                var ListOfQueryResults = context.Database.SqlQuery<string>(command).ToList();
                foreach(var queryResult in ListOfQueryResults)
                {
                    result += queryResult;
                }
            }
            return result;
        }

    }
}
