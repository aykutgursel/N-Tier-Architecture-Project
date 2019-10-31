using System.ComponentModel;

namespace web.GurselFramework.Framework.Helper
{
    public enum ExcellDataTypeEnum
    {
        [Description("stringFormat")]
        String = 1,
        [Description("numberFormat")]
        Number = 2,
        [Description("decimalFormat")]
        Decimal = 3,
        [Description("dateFormat")]
        Date = 4
    }
}