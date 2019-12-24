using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Lqn.Knowledge.DesingPattern
{
    public class Singleton
    {

    }

    /// <summary>
    /// 懒汉线程非安全式单例
    /// </summary>
    public class SingletonOne
    {
        private static SingletonOne instance;

        public static SingletonOne GetInstance()
        {
            if(instance == null)
            {
                instance = new SingletonOne();
            }
            return instance;
        }
    }

    /// <summary>
    /// 懒汉式线程安全的单例
    /// </summary>
    public class SingletonTwo
    {
        private static SingletonTwo instance;

        public static SingletonTwo GetInstance()
        {
            if(instance == null)
            {
                lock (instance)
                {
                    if (instance == null)
                    {
                        instance = new SingletonTwo();
                    }
                    return instance;
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// 饿汉式单例（类加载时直接实例化）
    /// </summary>
    public class SingletonThree
    {
        private static SingletonThree instance = new SingletonThree();
        private SingletonThree() { }

        public static SingletonThree GetInstance()
        {
            return instance;
        }
    }
}
