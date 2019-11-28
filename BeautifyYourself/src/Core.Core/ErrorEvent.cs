using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Core.Core
{
    public class ErrorEvent : IDisposable
    {
        private static List<ErrorEventContainer> _domainEventContainer;

        public void AddError(string message, string details = null, [CallerMemberName] string callerMemberName = null)
        {
            if (_domainEventContainer == null) _domainEventContainer = new List<ErrorEventContainer>();
            _domainEventContainer.Add(new ErrorEventContainer(message, details, callerMemberName));
        }

        public void Dispose()
        {
            _domainEventContainer = new List<ErrorEventContainer>();
            GC.SuppressFinalize(this);
        }

        public ErrorEventContainer[] GetErrorMessages()
        {
            return _domainEventContainer.ToArray();
        }

        public bool IsError()
        {
            return _domainEventContainer?.Any() ?? false;
        }
    }

    public class ErrorEventContainer
    {
        public ErrorEventContainer(string message, string details, string method)
        {
            Message = message;
            Details = details;
            Method = method;
        }
        public string Message { get; }
        public string Details { get; set; }
        public string Method { get; }
    }
}
