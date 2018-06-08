using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UTS.ProduceStore.Data;

namespace UTS.ProduceStore.WebFrontEnd.Models
{
    public class EditorViewModel
    {
        public List<Rule> PendingRules;

        public List<Rule> RejectedRules;
    }
}