using System.ComponentModel;

namespace web.GurselFramework.Framework.Enums
{
    public enum ValidationTypeEnum
    {
        [Description("error")]
        Error = 1,
        [Description("success")]
        Success = 2,
        [Description("info")]
        Info = 3,
        [Description("warning")]
        Warning = 4
    }
}
