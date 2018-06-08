using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UTS.ProduceStore.Data;
using UTS.ProduceStore.DomainLogic;

namespace UTS.ProduceStore.DomainLogicUnitTests
{
    [TestClass]
    public class UnitTests
    {
        RuleEngine ruleEngine = new RuleEngine();
        public static List<Rule> GetRules()
        {
            return new List<Rule>
            {
                new Rule() {RuleId = 1, RegularExpression = "bye", RegExGroup = 1, Query = "", RuleStatus = "", LastUpdateUser = ""},

                new Rule() {RuleId = 2, RegularExpression = "hello", RegExGroup = 1, Query = "", RuleStatus = "", LastUpdateUser = ""}
            };
        }

        [TestMethod]
        public void Answer_Null_ReturnsValidAnswer()
        {
            string answer = ruleEngine.Answer(null);
            Assert.IsNotNull(answer);
        }

        [TestMethod]
        public void FindMatchingRule_ListOfValidRules_NotNull()
        {
            Assert.IsNotNull(ruleEngine.FindMatchingRule(GetRules(), "bye"));
        }

        [TestMethod]
        public void FindMatchingRule_ListOfValidRules_ReturnsMatchingRule()
        {
            Assert.AreEqual(2,ruleEngine.FindMatchingRule(GetRules(), "hello").RuleId);
        }


    }
}
