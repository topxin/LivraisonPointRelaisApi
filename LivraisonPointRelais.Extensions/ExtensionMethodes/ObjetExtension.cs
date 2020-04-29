using System;

namespace LivraisonPointRelais.Extensions.ExtensionMethodes
{
    public static class ObjetExtension
    {
        public static Object ThrowExceptionIfNull(this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj;
        }
    }
}