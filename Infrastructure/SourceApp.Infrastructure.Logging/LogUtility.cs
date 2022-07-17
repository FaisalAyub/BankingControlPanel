using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MCN.Infrastructure.Logging
{
   public class LogUtility
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public LogUtility()
        {
            this.httpContextAccessor = new HttpContextAccessor();
        }
        public string BuildExceptionMessage(Exception x)
       {
           Exception logException = ExceptionExtensions.GetInnermostException(x);
           string strErrorMsg = Environment.NewLine + "Error in Path :";
            try
            {
                if (httpContextAccessor != null && httpContextAccessor.HttpContext.Request != null)
                    strErrorMsg += httpContextAccessor.HttpContext.Request.Path;
            }
            catch (Exception)
            {
            }            
            if (logException != null)
            {
                // Get the QueryString along with the Virtual Path
                strErrorMsg += Environment.NewLine + "Raw Url :";
                try
                {
                    if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.Request != null)
                    {
                       if(!string.IsNullOrEmpty(httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Referer]))
                            strErrorMsg += Environment.NewLine + "URL Refer:" + httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Referer];
                        if (!string.IsNullOrEmpty(httpContextAccessor.HttpContext.Request.Headers[HeaderNames.URL]))
                            strErrorMsg += Environment.NewLine + "URL:" + httpContextAccessor.HttpContext.Request.Headers[HeaderNames.URL];
                    }
                }
                catch (Exception)
                {
                }             
                // Get the error message
                strErrorMsg += Environment.NewLine + "Message :" + logException.Message;
                // Source of the message
                strErrorMsg += Environment.NewLine + "Source :" + logException.Source;
                // Stack Trace of the error
                strErrorMsg += Environment.NewLine + "Stack Trace :" + logException.StackTrace;
                // Method where the error occurred
                strErrorMsg += Environment.NewLine + "TargetSite :" + logException.TargetSite;
                if (logException.Message.ToLower().StartsWith(UserMessages.ReferenceOnDeleteStartWith.ToLower()))
                {
                    strErrorMsg += Environment.NewLine + UserMessages.ReferenceOnDelete;
                }
                else if (logException.Message.ToLower().StartsWith(UserMessages.UpdateInsertStartWith.ToLower()))
                {
                    strErrorMsg += Environment.NewLine + UserMessages.UpdateInsertMessage + ". " + (GetUpdateInsertDuplicateMessage(logException.Message)).Trim();
                }
            }
            return strErrorMsg;
       }
        private static string GetUpdateInsertDuplicateMessage(string InnerExceptionMsg)
        {
            InnerExceptionMsg = InnerExceptionMsg.Substring(InnerExceptionMsg.IndexOf(".") + 1, (InnerExceptionMsg.Length - (InnerExceptionMsg.IndexOf(".") + 1)));
            InnerExceptionMsg = InnerExceptionMsg.Substring(InnerExceptionMsg.IndexOf(".") + 1, (InnerExceptionMsg.Length - (InnerExceptionMsg.IndexOf(".") + 1)));
            InnerExceptionMsg = InnerExceptionMsg.Substring(InnerExceptionMsg.IndexOf(".") + 1, (InnerExceptionMsg.Length - (InnerExceptionMsg.IndexOf(".") + 1)));
            InnerExceptionMsg = InnerExceptionMsg.Substring(0, InnerExceptionMsg.IndexOf(".") + 1);
            return InnerExceptionMsg;
        }
    }
    public class UserMessages
    {
        public static string UserRights = "You don't have a sufficient permission to perform this operation. Contact your system administrator.";
        //Start Exception Messages
        public static string Exp_ErrorInPath = "Error in Path :";
        public static string Exp_RawUrl = "Raw Url :";
        public static string Exp_Message = "Message :";
        public static string Exp_Source = "Source :";
        public static string Exp_StackTrace = "Stack Trace :";
        public static string Exp_TargetSite = "TargetSite :";
        public static string Exp_DetailMessage = "Detail Message :";
        //End Exception Messages
        public static string ReferenceOnDeleteStartWith = "The DELETE statement conflicted with the REFERENCE constraint";
        public static string ReferenceOnDelete = "This record could not be deleted because of an association";
        public static string UpdateInsertStartWith = "Violation of UNIQUE KEY constraint";
        public static string UpdateInsertMessage = "Cannot insert duplicate key in object";
        public static string ValidationErrorMessage = "Validation Error";
        public static string UnauthorizedUserErrorMessage = "Unauthorized User";
        public static string FileFormatMessage = "File format is not correct";

    }
    public static class HeaderNames
    {
        public const string Accept = "Accept";
        public const string IfMatch = "If-Match";
        public const string IfModifiedSince = "If-Modified-Since";
        public const string IfNoneMatch = "If-None-Match";
        public const string IfRange = "If-Range";
        public const string IfUnmodifiedSince = "If-Unmodified-Since";
        public const string LastModified = "Last-Modified";
        public const string Location = "Location";
        public const string MaxForwards = "Max-Forwards";
        public const string Method = ":method";
        public const string Origin = "Origin";
        public const string Path = ":path";
        public const string Pragma = "Pragma";
        public const string ProxyAuthenticate = "Proxy-Authenticate";
        public const string ProxyAuthorization = "Proxy-Authorization";
        public const string Host = "Host";
        public const string Range = "Range";
        public const string RetryAfter = "Retry-After";
        public const string Scheme = ":scheme";
        public const string Server = "Server";
        public const string SetCookie = "Set-Cookie";
        public const string Status = ":status";
        public const string StrictTransportSecurity = "Strict-Transport-Security";
        public const string TE = "TE";
        public const string Trailer = "Trailer";
        public const string TransferEncoding = "Transfer-Encoding";
        public const string Upgrade = "Upgrade";
        public const string UserAgent = "User-Agent";
        public const string Vary = "Vary";
        public const string Via = "Via";
        public const string Warning = "Warning";
        public const string Referer = "Referer";
        public const string From = "From";
        public const string Expect = "Expect";
        public const string Expires = "Expires";
        public const string AcceptCharset = "Accept-Charset";
        public const string AcceptEncoding = "Accept-Encoding";
        public const string AcceptLanguage = "Accept-Language";
        public const string AcceptRanges = "Accept-Ranges";
        public const string AccessControlAllowCredentials = "Access-Control-Allow-Credentials";
        public const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";
        public const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        public const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        public const string AccessControlExposeHeaders = "Access-Control-Expose-Headers";
        public const string AccessControlMaxAge = "Access-Control-Max-Age";
        public const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        public const string AccessControlRequestMethod = "Access-Control-Request-Method";
        public const string Age = "Age";
        public const string Allow = "Allow";
        public const string Authority = ":authority";
        public const string Authorization = "Authorization";
        public const string CacheControl = "Cache-Control";
        public const string ETag = "ETag";
        public const string Date = "Date";
        public const string Cookie = "Cookie";
        public const string ContentType = "Content-Type";
        public const string ContentSecurityPolicyReportOnly = "Content-Security-Policy-Report-Only";
        public const string ContentSecurityPolicy = "Content-Security-Policy";
        public const string WebSocketSubProtocols = "Sec-WebSocket-Protocol";
        public const string ContentRange = "Content-Range";
        public const string ContentLocation = "Content-Location";
        public const string ContentLength = "Content-Length";
        public const string ContentLanguage = "Content-Language";
        public const string ContentEncoding = "Content-Encoding";
        public const string ContentDisposition = "Content-Disposition";
        public const string Connection = "Connection";
        public const string ContentMD5 = "Content-MD5";
        public const string WWWAuthenticate = "WWW-Authenticate";
        public const string URL = "URL";
        
    }
}
