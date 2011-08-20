using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnchantMapEditor
{
	public class MapEventArgs : EventArgs
	{
		public int RowIndex { get; set; }
		public int ColumnIndex { get; set; }
		public int RowCount { get; set; }
		public int ColumnCount { get; set; }
	}
}
