using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> collection, int pageNumber, int pageSize)
        {
            CheckIfCollectionArgumentIsNull(collection);
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException("pageNumber");
            }

            var elementsOffset = pageSize * (pageNumber - 1);

            return collection.Skip(elementsOffset).Take(pageSize);
        }

        public static T Previous<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            CheckIfCollectionArgumentIsNull(collection);
            CheckIfPredicateArgumentIsNull(predicate);

            if (collection.Any(predicate))
            {
                return collection.TakeWhile(x => !predicate(x)).Last();
            }

            return collection.TakeWhile(x => predicate(x)).Last();
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
