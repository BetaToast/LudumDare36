using System.Collections.Generic;

namespace LD36.Managers
{
	public class Manager<T>
		where T : class
	{
		protected readonly Dictionary<string, T> Items = new Dictionary<string, T>();

		public T this[string itemName] => Get(itemName);

		public virtual T Load(string itemName)
		{
			var item = ArchaicGame.ContentManager.Load<T>(itemName);
			return Load(itemName, item);
		}

		public virtual T Load(string itemName, T item)
		{
			if (Items.ContainsKey(itemName))
			{
				Items[itemName] = item;
			}
			else
			{
				Items.Add(itemName, item);
			}
			return item;
		}

		public virtual T Get(string itemName)
		{
			var ret = Items[itemName];
			return ret;
		}
	}
}
