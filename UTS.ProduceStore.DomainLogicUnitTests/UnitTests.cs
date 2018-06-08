using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Checks to see if the Answer method returns an answer that isn't null
        /// </summary>
        [TestMethod]
        public void Answer_Null_ReturnsValidAnswer()
        {
            //Act
            string answer = ruleEngine.Answer(null);
            //Assert
            Assert.IsNotNull(answer);
        }

        /// <summary>
        /// Checks to see if FindMatchingRule method successfully finds A rule when given an expression
        /// </summary>
        [TestMethod]
        public void FindMatchingRule_ListOfValidRules_NotNull()
        {
            //Assert
            Assert.IsNotNull(ruleEngine.FindMatchingRule(GetRules(), "bye"));
        }

        /// <summary>
        /// Checks to see if FindMatchingRule method returns CORRECT rule when given expression
        /// </summary>
        [TestMethod]
        public void FindMatchingRule_ListOfValidRules_ReturnsMatchingRule()
        {
            //Assert
            Assert.AreEqual(2,ruleEngine.FindMatchingRule(GetRules(), "hello").RuleId);
        }

        /// <summary>
        /// Checks that FindMatchingRule returns null if it doesn't find any rules
        /// </summary>
        [TestMethod]
        public void FindMatchingRule_InvalidExpression_ReturnsNull()
        {
            //Assert
            Assert.IsNull(ruleEngine.FindMatchingRule(GetRules(), "invalid expression"));
        }


        //[TestMethod]
        //public void QueryProduce_ValidQuery_ReturnsAResult()
        //{
        //    //Assert
        //    Assert.IsNotNull(ruleEngine.QueryProduces("SELECT result"));
        //}
    }
}
