using System;
using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Accounting
{
    public class ReportInfo
    {
        [SimpleAttribute]
        public string ReportId { get; set; }

        [SimpleAttribute]
        public string ReportName { get; set; }

        [SimpleAttribute]
        public string ReportType { get; set; }

        [SimpleAttribute]
        public string Company { get; set; }

        [SimpleAttribute]
        public int ReportYear { get; private set; }

        [SimpleAttribute]
        public int ReportMonth { get; private set; }

        [SimpleAttribute]
        public DateTime ReportDate
        {
            get
            {
                if (ReportMonth == 0 || ReportYear == 0)
                    return default(DateTime);
                return new DateTime(ReportYear, ReportMonth, 1);
            }
            set 
            { 
                ReportYear = value.Year;
                ReportMonth = value.Month;
            }
        }
    }
}
