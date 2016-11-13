using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.Collection
{
    public static class CollectionExtensions
    {

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> collection)
        {
            return collection ?? Enumerable.Empty<T>();
        }

        public static Page<T> Page<T>(this IEnumerable<T> collection, int pageNumber, int pageSize)
        {
            CheckIfCollectionArgumentIsNull(collection);
            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException("pageNumber");
            }

            var elementsOffset = pageSize * (pageNumber - 1);

            var page = new Page<T>()
            {
                
                ElementsCount = collection.Count(),
                PagesCount = (int)Math.Ceiling((decimal)collection.Count() / (decimal)pageSize)
            };
            page.AddRange(collection.Skip(elementsOffset).Take(pageSize));

            return page;
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

        public static IOrderedEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            var random = new Random();
            return collection.OrderBy(x => random.Next());
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
