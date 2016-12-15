using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace MyCQRS.ApplicationHelper
{
    /// <summary>
    /// 副本
    /// </summary>
    public class Duplicate
    {
        #region 单一实例

        /// <summary>
        /// 单一实例
        /// </summary>
        private static Duplicate _instance = null;

        public static Duplicate Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new ArgumentNullException("Null");
                }

                return _instance;

            }
            private set
            {
                _instance = value;
            }
        }

        #endregion

        private IContainer Container { get; set; }

        private Duplicate() { }

        public static void Create(IContainer container)
        {
            if (_instance != null)
            {
                return;
            }

            Duplicate autofacDuplicate = new Duplicate();

            autofacDuplicate.Container = container;

            Instance = autofacDuplicate;
        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }


        public T Resolve<T>(Type type) where T : class
        {
            return (T)Container.Resolve(type);
        }
    }
}
