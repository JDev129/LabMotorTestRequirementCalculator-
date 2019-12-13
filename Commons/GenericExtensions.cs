using System;

namespace Commons
{
    public static class GenericExtensions
    {
        public static T ApplyTo<T>(
            this T @this,
            Action<T> apply)
        {
            apply(@this);
            return @this;
        }
    }
}
