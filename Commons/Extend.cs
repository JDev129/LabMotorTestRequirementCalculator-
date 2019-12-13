using System;

namespace Commons
{
    public static class Extend
    {
        public static T ActThenReturn<T>(
            Action action,
            Func<T> returner)
        {
            action();
            return returner();
        }
    }
}
