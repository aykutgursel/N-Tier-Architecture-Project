using System;
using System.Collections.Generic;

namespace web.GurselFramework.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<LogParameter> Parameters { get; set; }
    }
}
