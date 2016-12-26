using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace MyCQRS.ApplicationHelper.Threading
{
    /// <summary>
    /// 通过一个使用一个来控制同步范围
    /// </summary>
    public static class SuperveneHelper
    {
        private static readonly ConcurrentDictionary<String, Object>
            SuperveneDictionary = new ConcurrentDictionary<String, Object>();

        private static readonly ConcurrentDictionary<String, SemaphoreSlim>
            AsyncSuperveneConcurrentDictionary = new ConcurrentDictionary<String, SemaphoreSlim>();

        /// <summary>
        /// 并发控制
        /// </summary>
        /// <param name="lockObj"></param>
        /// <param name="action"></param>
        public static void Invoke(Object lockObj, Action action)
        {
            lock (GetLockObj(lockObj))
            {
                action();
            }
        }

        /// <summary>
        /// 针对异步架构的线程同步
        /// </summary>
        /// <param name="lockObj"></param>
        /// <param name="asyncAction"></param>
        /// <returns></returns>
        public static async Task InvokeAsync(Object lockObj, Func<Task> asyncAction)
        {
            var asyncLock = GetAsyncLockObj(lockObj);
            await asyncLock.WaitAsync();
            try
            {
                await asyncAction();
            }
            finally
            {
                asyncLock.Release();
            }
        }

        /// <summary>
        /// 获取一个锁对象，会针对字符串类型的输入提供特殊的逻辑
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Object GetLockObj(Object target)
        {
            var key = target as String;

            return String.IsNullOrEmpty(key)  ? target : SuperveneDictionary.GetOrAdd(key, k => new Object());
        }

        /// <summary>
        /// 获取一个异步线程锁
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static SemaphoreSlim GetAsyncLockObj(Object target)
        {
            var key = target as String;
            key = key ?? target.GetHashCode().ToString();
            return AsyncSuperveneConcurrentDictionary.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
        }
    }
}