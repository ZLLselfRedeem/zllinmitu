﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Accounting
{
    public class CashFlowStatement
    {
        [SimpleElement(Order = 20, LocalName = "商品劳务收到的现金")]
        public double SaleCash { get; set; }

        [SimpleElement(Order = 30, LocalName = "收到的税费返还")]
        public double RefundTax { get; set; }

        [SimpleElement(Order = 40, LocalName = "经营活动相关现金")]
        public double OtherOperatingCash { get; set; }

        [SimpleElement(Order = 50, LocalName = "经营现金流入小计")]
        public double OperatingCashIn { get; set; }

        [SimpleElement(Order = 60, LocalName = "商品劳务支付现金")]
        public double PaidCash { get; set; }

        [SimpleElement(Order = 70, LocalName = "支付职工相关现金")]
        public double EmployeeCash { get; set; }

        [SimpleElement(Order = 80, LocalName = "支付的税费")]
        public double PaymentTax { get; set; }

        [SimpleElement(Order = 90, LocalName = "支付经营现金")]
        public double OtherOperatingPayment { get; set; }

        [SimpleElement(Order = 100, LocalName = "经营现金流出小计")]
        public double OperationgCashOut { get; set; }

        [SimpleElement(Order = 110, LocalName = "现金流量净额")]
        public double OperatingNetCash { get; set; }

        [SimpleElement(Order = 130, LocalName = "收回投资所收到的现金")]
        public double CashInvestment { get; set; }

        [SimpleElement(Order = 140, LocalName = "投资收益所得现金")]
        public double CashReturnInvestment { get; set; }

        [SimpleElement(Order = 150, LocalName = "收回资产所得现金净额")]
        public double CashAsset { get; set; }

        [SimpleElement(Order = 160, LocalName = "投资活动收入的现金")]
        public double CahsInvesting { get; set; }

        [SimpleElement(Order = 170, LocalName = "投资现金流入小计")]
        public double InvestingCashIn { get; set; }

        [SimpleElement(Order = 180, LocalName = "购买资产的现金")]
        public double CashAcquireAsset { get; set; }

        [SimpleElement(Order = 190, LocalName = "投资所支付的现金")]
        public double CashPaidInvestment { get; set; }

        [SimpleElement(Order = 200, LocalName = "投资现金支出")]
        public double OtherCashPayment { get; set; }

        [SimpleElement(Order = 210, LocalName = "投资现金流出小计")]
        public double InvestingCashOut { get; set; }

        [SimpleElement(Order = 220, LocalName = "投资活动现金流量净额")]
        public double InvesingNetCash { get; set; }

        [SimpleElement(Order = 240, LocalName = "吸收投资所收到的现金")]
        public double CashOthers { get; set; }

        [SimpleElement(Order = 250, LocalName = "借款所收到的现金")]
        public double CashBorrowing { get; set; }

        [SimpleElement(Order = 260, LocalName = "收到的其他筹资活动现金")]
        public double CashFinacing { get; set; }

        [SimpleElement(Order = 270, LocalName = "筹资现金流入小计")]
        public double FinacingCashIn { get; set; }

        [SimpleElement(Order = 280, LocalName = "偿还债务所支付的现金")]
        public double CashRepayment { get; set; }

        [SimpleElement(Order = 290, LocalName = "股利等相关支付的现金")]
        public double CashDistribution { get; set; }

        [SimpleElement(Order = 300, LocalName = "支付的其他筹资相关的现金")]
        public double OtherRelatingCashPayment { get; set; }

        [SimpleElement(Order = 310, LocalName = "筹资现金流出小计")]
        public double FinacingCashOut { get; set; }

        [SimpleElement(Order = 320, LocalName = "筹资活动产生的现金流量净额")]
        public double NetCashFinacing { get; set; }

        [SimpleElement(Order = 330, LocalName = "汇率变动对现金的影响")]
        public double CashExchange { get; set; }

        [SimpleElement(Order = 340, LocalName = "现金及现金等价物净增加额")]
        public double NetIncreaseEnquivalent { get; set; }

        [SimpleElement(Order = 360, LocalName = "净利润")]
        public double NetProfit { get; set; }

        [SimpleElement(Order = 370, LocalName = "计提的资产减值准备")]
        public double AssetProvision { get; set; }

        [SimpleElement(Order = 380, LocalName = "固定资产折旧")]
        public double FixedDepreciation { get; set; }

        [SimpleElement(Order = 390, LocalName = "无形资产摊销")]
        public double IntangibleAmortization { get; set; }

        [SimpleElement(Order = 400, LocalName = "长期待摊费用摊销")]
        public double LongAmortization { get; set; }

        [SimpleElement(Order = 410, LocalName = "待摊费用减少")]
        public double DeferredDecrese { get; set; }

        [SimpleElement(Order = 420, LocalName = "预提费用增加")]
        public double AccruedIncrese { get; set; }

        [SimpleElement(Order = 430, LocalName = "处置资产的损失")]
        public double AssetLoss { get; set; }

        [SimpleElement(Order = 440, LocalName = "固定资产报废损失")]
        public double FixedAssetScrap { get; set; }

        [SimpleElement(Order = 450, LocalName = "财务费用")]
        public double FinaceExpense { get; set; }

        [SimpleElement(Order = 460, LocalName = "投资损失")]
        public double InvestmentLoss { get; set; }

        [SimpleElement(Order = 470, LocalName = "递延税款贷项")]
        public double DeferredTaxLiability { get; set; }

        [SimpleElement(Order = 480, LocalName = "存货的减少")]
        public double InventoryDecrease { get; set; }

        [SimpleElement(Order = 490, LocalName = "经营性应收项目的减少")]
        public double OperationDecrease { get; set; }

        [SimpleElement(Order = 500, LocalName = "经营性应付项目的增加")]
        public double OperationIncrese { get; set; }

        [SimpleElement(Order = 510, LocalName = "其他")]
        public double Others { get; set; }

        [SimpleElement(Order = 520, LocalName = "经营活动产生的现金流量净额")]
        public double NetCashOperation { get; set; }

        [SimpleElement(Order = 540, LocalName = "债务转为资本")]
        public double ConvertedDebt { get; set; }

        [SimpleElement(Order = 550, LocalName = "一年内到期的可转换公司债券")]
        public double ConvertibleBond { get; set; }

        [SimpleElement(Order = 560, LocalName = "融资租入固定资产")]
        public double LeaseholdImprovement { get; set; }

        [SimpleElement(Order = 580, LocalName = "现金的期末余额")]
        public double CashEnd { get; set; }

        [SimpleElement(Order = 590, LocalName = "现金的期初余额")]
        public double CashBeg { get; set; }

        [SimpleElement(Order = 600, LocalName = "现金等价物的期末余额")]
        public double CashEquivalentEnd { get; set; }

        [SimpleElement(Order = 610, LocalName = "现金等价物的期初余额")]
        public double CashEquivalentBeg { get; set; }

        [SimpleElement(Order = 620, LocalName = "现金及等价物净增加额")]
        public double CashNetIncrease { get; set; }

    }
}
