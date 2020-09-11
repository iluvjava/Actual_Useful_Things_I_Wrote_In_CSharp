using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataStructure.UnionFind
{
    /// <summary>
    /// <para>
    ///     * Slower than array (different complexity class )
    ///     * Implemented using Dictionaries.
    ///     * The set representation is GENERIC!
    ///     * Join(a, b) is deterministic, and the representation of a will be set to b.
    ///         ** With path compression, but not tree rank. 
    /// </para> 
    /// <para>
    ///     Don't fucking put the default value
    /// </para>
    /// 
    /// </summary>
    public class DictionaryUnionFind<T>
    {

        protected Dictionary<T, T> the_map = new Dictionary<T, T>();
            
        public DictionaryUnionFind()
        {
            
        }

        /// <summary>
        ///     Get a representative for the given element. Add new elements here too
        /// </summary>
        /// <param name="element"></param>
        /// <returns>
        ///     The representative of the set for that element. 
        /// </returns>
        public T get(T element)
        {
            if (!the_map.ContainsKey(element))
            {
                the_map[element] = element;
                return element;
            }
            if (object.Equals(the_map[element], element)) // this is the root, the self loop
            {
                return element;
            }
            T Repr = get(the_map[element]);
            the_map[element] = Repr;
            return Repr;
        }

        public void join(T a, T b)
        {
            if (object.ReferenceEquals(a, b)) return;
            T ReprA = get(a), RepreB = get(b);
            if (object.ReferenceEquals(ReprA, RepreB))
            {
                return;
            }
            the_map[ReprA] = the_map[RepreB];
        }



    }
}
