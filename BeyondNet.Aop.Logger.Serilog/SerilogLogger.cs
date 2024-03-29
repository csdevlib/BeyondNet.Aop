using BeyondNet.Aop.Aspects.Models;
using BeyondNet.Aop.Aspects.Interfaces;
using BeyondNet.Aop.Core.Interfaces;
using SeriLog = Serilog;

namespace BeyondNet.Aop.Logger.Serilog
{
    public class SerilogLogger : ILogger
    {
        public readonly string OnExceptionTemplate = "[{ClassName}, {MethodName}] Exception.";

        public readonly string OnExceptionTemplateWithRequestId = "[{ClassName}, {MethodName}, {Id}] Exception.";

        public readonly string OnEntryTemplate = "[{ClassName}, {MethodName}] Start Call.";

        public readonly string OnEntryTemplateWithRequestId = "[{ClassName}, {MethodName}, {Id}] Start Call.";

        public readonly string OnExitTemplateWithDuration = "[{ClassName}, {MethodName}] End Call. Took {Duration} ms.";

        public readonly string OnExitTemplate = "[{ClassName}, {MethodName}] End Call.";

        public readonly string OnExitTemplateWithDurationAndRequestId = "[{ClassName}, {MethodName}, {Id}] End Call. Took {Duration} ms.";

        public readonly string OnExitTemplateWithRequestId = "[{ClassName}, {MethodName}, {Id}] End Call.";

        public void OnExit(IJoinPoint joinpoint, Return @return, string requestid, long duration)
        {
            var log = SeriLog.Log.ForContext("Return", @return, true);
            if (!string.IsNullOrWhiteSpace(requestid))
            {
                log.Debug(OnExitTemplateWithDurationAndRequestId, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name, requestid, duration);
            }
            else
            {
                log.Debug(OnExitTemplateWithDuration, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name, duration);
            }
        }

        public void OnEntry(IJoinPoint joinpoint, Argument[] arguments, string requestid)
        {
            if (!string.IsNullOrWhiteSpace(requestid))
            {
                if (arguments != null && arguments.Length>0)
                {
                    var log = SeriLog.Log.ForContext("Arguments", arguments, true);
                    log.Debug(OnEntryTemplateWithRequestId, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name, requestid);
                }
                else
                {
                    SeriLog.Log.Debug(OnEntryTemplateWithRequestId, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name, requestid);
                }
            }
            else
            {
                if (arguments != null && arguments.Length > 0)
                {
                    var log = SeriLog.Log.ForContext("Arguments", arguments, true);
                    log.Debug(OnEntryTemplate, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name);
                }
                else
                {
                    SeriLog.Log.Debug(OnEntryTemplate, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name);
                }
            }
        }

        public void OnException(IJoinPoint joinpoint, string requestid, Exception ex)
        {
            if (!string.IsNullOrWhiteSpace(requestid))
            {
                SeriLog.Log.Error(ex, OnExceptionTemplateWithRequestId, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name, requestid);
            }
            else
            {
                SeriLog.Log.Error(ex, OnExceptionTemplate, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name);
            }
        }

        public void OnExit(IJoinPoint joinpoint, string requestid, long duration)
        {
            if (!string.IsNullOrWhiteSpace(requestid))
            {
                SeriLog.Log.Debug(OnExitTemplateWithDurationAndRequestId, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name, requestid, duration);
            }
            else
            {
                SeriLog.Log.Debug(OnExitTemplateWithDuration, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name, duration);
            }
        }

        public void OnExit(IJoinPoint joinpoint, Return @return, string requestid)
        {
            var log = SeriLog.Log.ForContext("Return", @return, true);
            if (!string.IsNullOrWhiteSpace(requestid))
            {
                log.Debug(OnExitTemplateWithRequestId, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name, requestid);
            }
            else
            {
                log.Debug(OnExitTemplate, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name);
            }
        }

        public void OnExit(IJoinPoint joinpoint, string requestid)
        {
            if (!string.IsNullOrWhiteSpace(requestid))
            {
                SeriLog.Log.Debug(OnExitTemplateWithRequestId, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name, requestid);
            }
            else
            {
                SeriLog.Log.Debug(OnExitTemplate, joinpoint.TargetType.Name, joinpoint.MethodInfo.Name);
            }
        }
    }
}
