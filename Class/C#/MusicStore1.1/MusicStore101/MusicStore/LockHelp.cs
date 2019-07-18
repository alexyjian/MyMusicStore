using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace MusicStore
{
    /// <summary>
    /// 对内存中Guid的值进行加锁处理，防止进程互斥
    /// </summary>
    public class LockHelp
    {
        public static Mutex _Mutext = new Mutex();
        private static readonly Dictionary<Guid, SemaphoreSlim> _Slim = new Dictionary<Guid, SemaphoreSlim>();
        private static readonly Dictionary<Guid, int> _Count = new Dictionary<Guid, int>();

        /// <summary>
        /// 加锁
        /// </summary>
        /// <param name="id">主键</param>
        public static void ThreadLocked(Guid id)
        {
            _Mutext.WaitOne();
            SemaphoreSlim slim;
            if (!_Slim.TryGetValue(id, out slim))
            {
                slim = new SemaphoreSlim(1);
                _Slim.Add(id, slim);
                _Count.Add(id, 0);
            }

            _Count[id]++;
            _Mutext.ReleaseMutex();
            slim.Wait();
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="id">主键</param>
        public static void ThreadUnLocked(Guid id)
        {
            var slim = _Slim[id];
            if (_Count[id] == 1)
            {
                _Count.Remove(id);
                _Slim.Remove(id);
            }
            else _Count[id]--;
            slim.Release();
        }
    }
}