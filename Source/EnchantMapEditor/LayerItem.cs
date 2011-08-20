using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EnchantMapEditor
{
	public class LayerItem : IDisposable
	{
		public LayerItem()
		{
		}

		public LayerData Data { get; set; }
		public Bitmap Image { get; set; }

		public override string ToString()
		{
			return Data.Name;
		}

		public override int GetHashCode()
		{
			return Data.Name.GetHashCode();
		}

		public void Dispose()
		{
			if (Image != null)
			{
				Image.Dispose();
				Image = null;
			}
		}
	}
}
