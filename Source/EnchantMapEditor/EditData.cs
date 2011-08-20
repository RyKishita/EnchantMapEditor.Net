using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnchantMapEditor
{
	class EditData
	{
		public int MapColumnCount { get; set; }
		public int MapRowCount { get; set; }
		public List<LayerData> LayerDatas { get; set; }
		public List<List<bool>> CollisionMap { get; set; }
		public System.Drawing.Color BackgroundColor { get; set; }
	}
}
