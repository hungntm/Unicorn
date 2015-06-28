﻿using System;
using System.Collections.Generic;
using Rainbow.Model;
using Sitecore.Diagnostics;
using Unicorn.Data;

namespace Unicorn.Evaluators
{
	public static class EvaluatorUtility
	{
		/// <summary>
		/// Recycles a whole tree of items and reports their progress
		/// </summary>
		/// <param name="items">The item(s) to delete. Note that their children will be deleted before them, and also be reported upon.</param>
		/// <param name="sourceStore"></param>
		/// <param name="deleteMessage">The status message to write for each deleted item</param>
		public static void RecycleItems(IEnumerable<ISerializableItem> items, ISourceDataStore sourceStore, Action<ISerializableItem> deleteMessage)
		{
			Assert.ArgumentNotNull(items, "items");

			foreach (var item in items)
				RecycleItem(item, sourceStore, deleteMessage);
		}

		/// <summary>
		/// Deletes an item from the source data provider
		/// </summary>
		private static void RecycleItem(ISerializableItem item, ISourceDataStore sourceStore, Action<ISerializableItem> deleteMessage)
		{
			var children = sourceStore.GetChildren(item.Id, item.DatabaseName);

			RecycleItems(children, sourceStore, deleteMessage);

			deleteMessage(item);

			sourceStore.Remove(item.Id, item.DatabaseName);
		}
	}
}
