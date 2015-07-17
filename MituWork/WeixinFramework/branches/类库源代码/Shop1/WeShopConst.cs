namespace YJC.Toolkit.Weixin.Shop
{
    public static class WeShopConst
    {
        public const string LIST_NAME_MODEL = "ListConvert";
        public const string GROUP_INFO = "group_info";
        public const string GROUP_INFOS = "group_infos";

        public const string ADD_PRODUCT_URL =
            "https://api.weixin.qq.com/merchant/create?access_token={0}";
        public const string DELETE_PRODUCT_URL =
            "https://api.weixin.qq.com/merchant/del?access_token={0}";
        public const string UPDATE_PRODUCT_URL =
            "https://api.weixin.qq.com/merchant/update?access_token={0}";
        public const string QUERY_PRODUCT_URL =
            "https://api.weixin.qq.com/merchant/get?access_token={0}";
        public const string PRODUCT_STATUS_URL =
            "https://api.weixin.qq.com/merchant/getbystatus?access_token={0}";
        public const string PRODUCT_SHELF_URL =
            "https://api.weixin.qq.com/merchant/modproductstatus?access_token={0}";
        public const string ALL_SUB_CATE_URL =
            "https://api.weixin.qq.com/merchant/category/getsub?access_token={0}";
        public const string ALL_SKU_URL =
            "https://api.weixin.qq.com/merchant/category/getsku?access_token={0}";
        public const string ALL_PROPERTY_URL =
            "https://api.weixin.qq.com/merchant/category/getproperty?access_token={0}";

        public const string ADD_STOCK_URL =
            "https://api.weixin.qq.com/merchant/stock/add?access_token={0}";
        public const string REDUCE_STOCK_URL =
            "https://api.weixin.qq.com/merchant/stock/reduce?access_token={0}";

        public const string ADD_TEMPLATE_URL =
            "https://api.weixin.qq.com/merchant/express/add?access_token={0}";
        public const string DELETE_TEMPLATE_URL =
            "https://api.weixin.qq.com/merchant/express/del?access_token={0}";
        public const string UPDATE_TEMPLATE_URL =
            "https://api.weixin.qq.com/merchant/express/update?access_token={0}";
        public const string TEMPLATE_ID_URL =
            "https://api.weixin.qq.com/merchant/express/getbyid?access_token={0}";
        public const string ALL_TEMPLATE_URL =
            "https://api.weixin.qq.com/merchant/express/getall?access_token={0}";

        public const string ADD_GROUP_URL =
            "https://api.weixin.qq.com/merchant/group/add?access_token={0}";
        public const string DELETE_GROUP_URL =
            "https://api.weixin.qq.com/merchant/group/del?access_token={0}";
        public const string UPDATE_GROUP_PROPERTY_URL =
            "https://api.weixin.qq.com/merchant/group/propertymod?access_token={0}";
        public const string UPDATE_GROUP_PRODUCT_URL =
            "https://api.weixin.qq.com/merchant/group/productmod?access_token={0}";
        public const string ALL_GROUP_URL =
            "https://api.weixin.qq.com/merchant/group/getall?access_token={0}";
        public const string GROUP_ID_URL =
            "https://api.weixin.qq.com/merchant/group/getbyid?access_token={0}";

        public const string ADD_SHELF_URL =
            "https://api.weixin.qq.com/merchant/shelf/add?access_token={0}";
        public const string DELETE_SHELF_URL =
            "https://api.weixin.qq.com/merchant/shelf/del?access_token={0}";
        public const string UPDATE_SHELF_URL =
            "https://api.weixin.qq.com/merchant/shelf/mod?access_token={0}";
        public const string ALL_SHELF_URL =
            "https://api.weixin.qq.com/merchant/shelf/getall?access_token={0}";
        public const string SHELF_ID_URL =
            "https://api.weixin.qq.com/merchant/shelf/getbyid?access_token={0}";

        public const string BILL_ID_URL =
            "https://api.weixin.qq.com/merchant/order/getbyid?access_token={0}";
        public const string BILL_STATUS_URL =
            "https://api.weixin.qq.com/merchant/order/getbyfilter?access_token={0}";
        public const string SET_DELIVERY_URL =
            "https://api.weixin.qq.com/merchant/order/setdelivery?access_token={0}";
        public const string CLOSE_BILL_URL =
            "https://api.weixin.qq.com/merchant/order/close?access_token={0}";

        public const string UPLOAD_IMG_URL =
            "https://api.weixin.qq.com/merchant/common/upload_img?access_token={0}&filename={1}";
    }
}
