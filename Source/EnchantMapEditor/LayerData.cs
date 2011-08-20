using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EnchantMapEditor
{
	public class LayerData : ICloneable
	{
		public LayerData()
		{
			IDMap = new List<List<int>>();
		}

		public LayerData(LayerData src)
			: this()
		{
			Name = src.Name.Clone() as string;
			IDMap.AddRange(src.IDMap.Select(row => row.ToList()).ToList());
			IsForeground = src.IsForeground;
		}

		public string Name { get; set; }
		public List<List<int>> IDMap { get; private set; }
		public bool IsForeground { get; set; }

		public void SetupIDMap(int rowNum, int columnNum)
		{
			if (rowNum < IDMap.Count)
			{
				IDMap.RemoveRange(rowNum, IDMap.Count - rowNum);
			}
			else if (IDMap.Count < rowNum)
			{
				int addCount = rowNum - IDMap.Count;
				for (int i = 0; i < addCount; i++)
				{
					IDMap.Add(Enumerable.Repeat(-1, columnNum).ToList());
				}
			}

			foreach (var row in IDMap)
			{
				if (columnNum < row.Count)
				{
					row.RemoveRange(columnNum, row.Count - columnNum);
				}
				else if (row.Count < columnNum)
				{
					row.AddRange(Enumerable.Repeat(-1, columnNum - row.Count));
				}
			}
		}

		public object Clone()
		{
			return new LayerData(this);
		}
	}
}
