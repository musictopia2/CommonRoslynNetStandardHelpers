using CommonRoslynNetStandardHelpers.AdvancedGeneralFunctionsAndProcesses.Misc;
using System.Collections;
namespace CommonRoslynNetStandardHelpers.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
public static class Lists
{
    extension<T>(Dictionary<int, T> list)
    {
        public void Add(T item)
        {
            list.Add(list.Count + 1, item);
        }

    }
    
    extension<T>(IEnumerable<T> list)
    {
        //was going to do as property but not since the ToList was method, i think makes sense to keep as method here too.
        
        public int Count
        {
            get
            {
                if (list is IList c)
                {
                    return c.Count;
                }
                return list.Count();
            }
        }

        public void ForEach(Action<T> action)
        {
            switch (list)
            {
                case List<T> l:
                    l.ForEach(action);
                    break;
                
                default:
                    foreach (var item in list)
                    {
                        action(item);
                    }
                    break;
            }
        }
        
    }
    
    extension<T>(IList<T> list)
    {
        //could not be under ienumerable because otherwise, does not know whether to use my custom or standard.
        public bool Contains(T value) =>
            list switch
            {
                null => false,
                List<T> l => l.Contains(value),
                _ => list.Any(item => EqualityComparer<T>.Default.Equals(item, value))
            };
        public void RemoveGivenList(IEnumerable<T> remove)
        {
            var removeSet = new HashSet<T>(remove);
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (removeSet.Contains(list[i]))
                {
                    list.RemoveAt(i);
                }
            }
        }
        public void AddRange(IEnumerable<T> adds)
        {
            switch (list)
            {
                case List<T> l:
                    l.AddRange(adds);
                    break;
                default:
                    foreach (var item in adds)
                    {
                        list.Add(item);
                    }
                    break;
            }
        }
    }
    
    extension<TSource, TKey>(IEnumerable<TSource> source)
    {
        public bool HasDuplicates(Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = [];
            foreach (var item in source)
            {
                if (seenKeys.Add(keySelector(item)) == false)
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasOnlyOne(Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = [];
            if (source.Count == 0)
            {
                return false; //because there are none.
            }
            foreach (var item in source)
            {
                seenKeys.Add(keySelector(item));
                if (seenKeys.Count > 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
    extension<TKey, TSource>(IEnumerable<TSource> source)
    {
        public IOrderedEnumerable<IGrouping<TKey, TSource>> GroupOrderDescending(Func<TSource, TKey> keySelector)
        {
            return source.GroupBy(keySelector).OrderByDescending(Items => Items.Count());
        }
        public IOrderedEnumerable<IGrouping<TKey, TSource>> GroupOrderAscending(Func<TSource, TKey> keySelector)
        {
            return source.GroupBy(keySelector).OrderBy(Items => Items.Count());
        }
    }
    extension<TSource, TKey>(IEnumerable<TSource> source)
    {
        
        public bool DoesReconcile(IEnumerable<TSource> other, Func<TSource, TKey> keySelector)
        {
            if (source.Count() != other.Count())
            {
                return false; //because not even the same count.
            }
            HashSet<TKey> seenKeys = [];
            foreach (var item in source)
            {
                seenKeys.Add(keySelector(item));
            }
            foreach (var item in other)
            {
                if (seenKeys.Add(keySelector(item)))
                {
                    return false;
                }
            }
            return true;
        }
        public int DistinctCount(Func<TSource, TKey> keySelector)
        {
            int count = 0;
            HashSet<TKey> seenKeys = [];
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    count++;
                }
            }
            return count;
        }
    }
    extension<TSource>(IEnumerable<TSource> source)
    {
        
        public string Join(string delimiter)
        {
            StrCat cats = new();
            foreach (var item in source)
            {
                if (item is null)
                {
                    cats.AddToString("", delimiter);
                }
                else
                {
                    cats.AddToString(item.ToString()!, delimiter);
                }
            }
            return cats.GetInfo();
        }   
    }
}