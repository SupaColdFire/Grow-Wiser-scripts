using System;
using System.Collections.Generic;
using System.Linq;

namespace KG.Utility
{
    public class FisherYatesShuffle<T>
    {
        private Random _random;
        private List<T> _source;
        private int _borderIndex;

        public int Count
        {
            get { return _source.Count; }
        }

        public FisherYatesShuffle(List<T> source = null)
        {
            if (source == null)
            {
                _source = new List<T>();
            }
            else
            {
                _source = source.ToList();
            }

            _random = new Random();

            Reset();
        }

        public void Reset()
        {
            _borderIndex = _source.Count;
        }

        public void Add(T element)
        {
            _source.Add(element);
            Reset();
        }

        public T GetRandomValue()
        {
            var result = default(T);
            if (HasRandomValue())
            {
                var index = _random.Next(0, _borderIndex);
                _borderIndex -= 1;
                result = _source[index];
                _source[index] = _source[_borderIndex];
                _source[_borderIndex] = result;
            }

            return result;
        }

        public bool HasRandomValue()
        {
            return _borderIndex > 0;
        }
    }
}