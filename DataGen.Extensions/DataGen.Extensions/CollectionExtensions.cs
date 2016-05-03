using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions
{
    public static class CollectionExtensions
    {
        public static T Previous<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            CheckIfCollectionArgumentIsNull(collection);
            CheckIfPredicateArgumentIsNull(predicate);

            return collection.TakeWhile(x => !predicate(x)).Last();
        }

        public static T Next<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            CheckIfCollectionArgumentIsNull(collection);
            CheckIfPredicateArgumentIsNull(predicate);

            return collection.SkipWhile(x => !predicate(x)).Skip(1).First();
        }

        private static void CheckIfPredicateArgumentIsNull<T>(Func<T, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
        }

        private static void CheckIfCollectionArgumentIsNull<T>(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
        }
    }
}
