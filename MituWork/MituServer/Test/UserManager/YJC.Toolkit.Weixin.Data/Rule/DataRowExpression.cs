using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Rule
{
    [ParamExpression(":", Author = "YJC", CreateDate = "2014-03-16",
        Description = "DataRow的ParamExpression，要求参数中传入DataRow(:)")]
    class DataRowExpression : IParamExpression, ICustomData
    {
        private DataRow fDataRow;

        #region IParamExpression 成员

        public string Execute(string parameter)
        {
            try
            {
                return fDataRow[parameter].ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion

        #region ICustomData 成员

        public void SetData(params object[] args)
        {
            fDataRow = ObjectUtil.ConfirmQueryObject<DataRow>(this, args);
            //TkDebug.AssertNotNull(fDataRow, "参数宏(:)需要DataRow对象，但是没有从外部对象中找到", this);
        }

        #endregion
    }
}
