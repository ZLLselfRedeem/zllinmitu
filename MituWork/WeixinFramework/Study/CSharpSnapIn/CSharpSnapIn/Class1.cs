using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonSnappable;
using System.Windows.Forms;

namespace CSharpSnapIn
{
    [CompanyInfo(CompanyName = "My Company", CompanyUrl = "www.MyCompany.com")]
    public class CSharpModule : IAppFunctionality
    {
        //显式实现接口，把DoIt()方法隐藏起来
        void IAppFunctionality.DoIt()
        {
            MessageBox.Show("You have just used the C# snap un!");
        }
    }
}
