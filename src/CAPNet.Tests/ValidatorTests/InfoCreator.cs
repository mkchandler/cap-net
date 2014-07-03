using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CAPNet.Models;

namespace CAPNet
{
    public class InfoCreator
    {
        public static Info CreateValidInfo()
        {
            var info = new Info();

            var category = Category.Fire;

            //Category required
            info.Categories.Add(category);
            //Certainty required
            info.Certainty = Certainty.Observed;
            //EventRequired
            info.Event = "ImportantEvent";
            //SeverityRequired
            info.Severity = Severity.Minor;
            //UrgencyRequired
            info.Urgency = Urgency.Future;

            return info;
        }

        public static Info CreateInvalidCategory()
        {
            var info = new Info();

            Category category = (Category)123;

            //Category required
            info.Categories.Add(category);
            //Certainty required
            info.Certainty = Certainty.Observed;
            //EventRequired
            info.Event = "ImportantEvent";
            //SeverityRequired
            info.Severity = Severity.Minor;
            //UrgencyRequired
            info.Urgency = Urgency.Future;

            return info;
        }
    }
}
