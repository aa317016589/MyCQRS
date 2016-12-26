using System;
// ReSharper disable once CheckNamespace
namespace Dapper.Contrib.Linq2Dapper.Exceptions
{
    public class InvalidCacheItemException : Exception
    {
        public InvalidCacheItemException(string message) : base(message)
        {
        }
    }
}
