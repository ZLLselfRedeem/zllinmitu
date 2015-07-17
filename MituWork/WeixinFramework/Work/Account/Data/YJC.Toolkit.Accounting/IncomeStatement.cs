using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Accounting
{
    public class IncomeStatement
    {
        [SimpleElement(Order = 10, LocalName = "主营业收入")]
        public double RevenueMainOperation { get; set; }

        [SimpleElement(Order = 20, LocalName = "主营业务成本")]
        public double CostOfMainOperation { get; set; }

        [SimpleElement(Order = 30, LocalName = "主营业务税金及附加")]
        public double TaxesMain { get; set; }

        [SimpleElement(Order = 40, LocalName = "主营业务利润")]
        public double ProfitMain { get; set; }

        [SimpleElement(Order = 50, LocalName = "其他业务利润")]
        public double OtherProfit { get; set; }

        [SimpleElement(Order = 60, LocalName = "营业费用")]
        public double OperatingExpense { get; set; }

        [SimpleElement(Order = 70, LocalName = "管理费用")]
        public double AdminExpense { get; set; }

        [SimpleElement(Order = 80, LocalName = "财务费用")]
        public double FinancialExpense { get; set; }

        [SimpleElement(Order = 90, LocalName = "营业利润")]
        public double OperatingProfit { get; set; }

        [SimpleElement(Order = 100, LocalName = "投资收益")]
        public double InvestmentIncome { get; set; }

        [SimpleElement(Order = 110, LocalName = "补贴收入")]
        public double RevenueSubsidy { get; set; }

        [SimpleElement(Order = 120, LocalName = "营业外收入")]
        public double OperatingRevenue { get; set; }

        [SimpleElement(Order = 130, LocalName = "营业外支出")]
        public double OperatingExp { get; set; }

        [SimpleElement(Order = 140, LocalName = "利润总额")]
        public double IncomeBeforeTax { get; set; }

        [SimpleElement(Order = 150, LocalName = "所得税")]
        public double IncomeTax { get; set; }

        [SimpleElement(Order = 160, LocalName = "净利润")]
        public double NetIncome { get; set; }
    }
}
