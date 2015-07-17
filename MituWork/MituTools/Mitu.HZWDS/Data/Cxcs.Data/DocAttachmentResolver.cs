using YJC.Toolkit.Data;

namespace Cxcs.Data
{
    [Resolver(Author = "YJC", CreateDate = "2014-07-07",
        Description = "财税附件表(CS_DOC_ATTACHMENT)的数据访问层类")]
    class DocAttachmentResolver : Tk5TableResolver
    {
        internal const string DATAXML = "CXCS/DocAttachment.xml";

        public DocAttachmentResolver(IDbDataSource source)
            : base(DATAXML, source)
        {
            AutoUpdateKey = true;
        }
    }
}
