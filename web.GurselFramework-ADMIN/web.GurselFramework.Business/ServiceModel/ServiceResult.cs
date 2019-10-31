using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace web.GurselFramework.Business.ServiceModel
{
    [DataContract, Serializable]
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            IsValid = false;
            Errors = new List<Error>();
            ValidMessages = new List<string>();
        }
        [DataMember]
        public T Value { get; set; }

        [DataMember]
        public bool IsValid { get; set; }

        [DataMember]
        public List<string> ValidMessages { get; set; }

        [DataMember]
        public int TotalRowsCount { get; set; }

        [DataMember]
        public int AffectedRowsCount { get; set; }

        [DataMember]
        public List<Error> Errors { get; set; }

        [DataMember]
        public string ApiVersion { get; set; }

        [DataMember]
        public HttpStatusCode StatusCode { get; set; }
    }

    [DataContract]
    public class Error
    {
        [DataMember]
        public string ErrorCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public string ErrorSource { get; set; }

        [DataMember]
        public bool ErrorStatus { get; set; }

        [DataMember]
        public object Entitiy { get; set; }
    }
}