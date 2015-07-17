﻿using System;
using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using System.Data;
using System.Text;

namespace YJC.Toolkit.Accounting
{
    public class ReportObjectData
    {
        public static readonly ReadSettings ReadSettings = new ReadSettings { DateTimeFormat = "yyyyMM" };
        private static readonly ReadSettings DbSettings = new ReadSettings { Encoding = Encoding.Default };

        public ReportObjectData(string companyId, string reportName)
        {
            Info = new ReportInfo() { Company = companyId, ReportName = reportName };
            Object = new ObjectContainer(null);
            CallerInfo = new DynamicObjectBag();
        }

        public ReportObjectData(DataRow row, Object obj)
        {
            Info = new ReportInfo();
            Info.ReadFromDataRow(row, ReadSettings);
            string xml = row["ReportData"].ToString();
            if (!string.IsNullOrEmpty(xml))
            {
                obj.ReadXml(xml, DbSettings, QName.ToolkitNoNS);
                Object = new ObjectContainer(obj);
            }
            else
                Object = new ObjectContainer(null);

            CallerInfo = new DynamicObjectBag();
        }

        public ReportInfo Info { get; private  set;}

        public ObjectContainer Object { get; private set; }

        public dynamic CallerInfo { get; private set; }
    }
}
