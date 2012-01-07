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

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public override string ToString()
		{
			var builder = new StringBuilder("カーソル位置：");
			if (RowIndex < 0 || ColumnIndex < 0)
			{
				builder.Append("範囲外");
			}
			else
			{
				builder.AppendFormat("{0},{1}", ColumnIndex, RowIndex);
				if (1 < RowCount || 1 < ColumnCount)
				{
					builder.AppendFormat(" サイズ：{0}x{1}", ColumnCount, RowCount);
				}
			}
			return builder.ToString();
		}
	}
}
