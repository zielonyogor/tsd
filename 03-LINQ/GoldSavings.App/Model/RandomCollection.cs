using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldSavings.App.Model
{
	public class RandomCollection<T>
	{
		private List<T> _items = new List<T>();

		public void Add(T item)
		{
			_items.Add(item);
		}

		public T Get(int index)
		{
			if( index < 0 || index >= _items.Count )
				throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
			var randomIndex = new Random().Next(0, index);
			return _items[randomIndex];
		}

		public bool isEmpty()
		{
			return _items.Count == 0;
		}	
	}
}
