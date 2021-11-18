using Android.Runtime;
using Kotlin.Jvm.Functions;
using System;

namespace NamiML
{

    public class KtFunc0<T> : Java.Lang.Object, IFunction0
        where T : Java.Lang.Object
    {
        private readonly Func<T> OnInvoked;

        public KtFunc0(Func<T> onInvoked)
        {
            OnInvoked = onInvoked;
        }

        public Java.Lang.Object Invoke()
        {
            return OnInvoked?.Invoke();
        }
    }

    public class KtFunc1<A> : Java.Lang.Object, IFunction1
        where A : class, IJavaObject
    {
        private readonly Action<A> OnInvoked;

        public KtFunc1(Action<A> onInvoked)
        {
            OnInvoked = onInvoked;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object parameter)
        {
            OnInvoked?.Invoke(parameter.JavaCast<A>());
            return null;
        }
    }

    public class KtFunc4<A, B, C, D> : Java.Lang.Object, IFunction4
        where A : class, IJavaObject
        where B : class, IJavaObject
        where C : class, IJavaObject
        where D : class, IJavaObject
    {
        private readonly Action<A, B, C, D> OnInvoked;

        public KtFunc4(Action<A, B, C, D> onInvoked)
        {
            OnInvoked = onInvoked;
        }

        public Java.Lang.Object Invoke(
            Java.Lang.Object p0,
            Java.Lang.Object p1,
            Java.Lang.Object p2,
            Java.Lang.Object p3)
        {
            OnInvoked?.Invoke(
                p0.JavaCast<A>(),
                p1.JavaCast<B>(),
                p2.JavaCast<C>(),
                p2.JavaCast<D>());
            return null;
        }
    }

}
