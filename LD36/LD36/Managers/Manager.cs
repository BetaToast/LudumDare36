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
			var ret = ArchaicGame.ContentManager.Load<T>(itemName);
			Items.Add(itemName, ret);
			return ret;
		}

		public virtual T Get(string itemName)
		{
			var ret = Items[itemName];
			return ret;
		}
	}
}
