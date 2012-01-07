using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnchantMapEditor
{
	public partial class MapControl : UserControl
	{
		public MapControl()
		{
			InitializeComponent();
			Zoom = 1;
		}

		public int RowCount { get; set; }
		public int ColumnCount { get; set; }
		public int PartsWidth { get; set; }
		public int PartsHeight { get; set; }
		public int BorderWidth { get; set; }
		public int Zoom { get; set; }
		public bool AreaSelect { get; set; }

		public event Action<object, MapEventArgs> SelectedItem;
		public event Action<object, MapEventArgs> MoveCursor;

		Image bufferImage = null;
		int BlockWidth { get { return PartsWidth + BorderWidth * 2; } }
		int BlockHeight { get { return PartsHeight + BorderWidth * 2; } }
		List<List<int>> idMap = new List<List<int>>();

		const int alpa = 100;

		SolidBrush maskBrush = new SolidBrush(Color.FromArgb(alpa, Color.Red));
		SolidBrush dragBrush = new SolidBrush(Color.FromArgb(alpa, Color.AliceBlue));

		Image maskImage = null;

		Image dragImage = null;
		bool bDragStart = false;
		bool bDraging = false;
		int dragStartRowIndex = 0;
		int dragStartColumnIndex = 0;
		int currentRowIndex = 0;
		int currentColumnIndex = 0;

		public void Clear()
		{
			if (null != bufferImage)
			{
				pictureBox1.Image = null;
				bufferImage.Dispose();
				bufferImage = null;
			}
		}

		public void SetLayer(LayerItem layerItem)
		{
			bool bInitialize = (null == bufferImage);
			if (bInitialize)
			{
				bufferImage = new Bitmap(
					ColumnCount * BlockWidth,
					RowCount * BlockHeight,
					System.Drawing.Imaging.PixelFormat.Format32bppArgb);

				idMap.Clear();
			}

			using (var g = Graphics.FromImage(bufferImage))
			{
				if (bInitialize)
				{
					g.Clear(Color.Transparent);
				}

				for (int rowIndex = 0; rowIndex < layerItem.Data.IDMap.Count; rowIndex++)
				{
					List<int> row = layerItem.Data.IDMap[rowIndex];
					for (int columnIndex = 0; columnIndex < row.Count; columnIndex++)
					{
						int id = row[columnIndex];

						if (idMap.Count <= rowIndex)
						{
							idMap.Add(Enumerable.Repeat(-1, ColumnCount).ToList());
						}

						idMap[rowIndex][columnIndex] = id;
					}
				}

				if (null != layerItem.Image)
				{
					g.DrawImage(layerItem.Image, Point.Empty);
				}
			}
		}

		public void UpdateImage()
		{
			if (null == bufferImage)
			{
				pictureBox1.Image = null;
				return;
			}

			pictureBox1.Width = bufferImage.Width * Zoom;
			pictureBox1.Height = bufferImage.Height * Zoom;

			Image image = new Bitmap(bufferImage);
			if (null != maskImage || null != dragImage)
			{
				using (var g = Graphics.FromImage(image))
				{
					if (null != maskImage)
					{
						g.DrawImage(maskImage, Point.Empty);
					}
					if (null != dragImage)
					{
						g.DrawImage(dragImage, Point.Empty);
					}
				}
			}

			var oldImage = pictureBox1.Image;
			pictureBox1.Image = image;
			if (null != oldImage)
			{
				oldImage.Dispose();
				oldImage = null;
			}
		}

		public int GetID(int rowIndex, int columnIndex)
		{
			if (columnIndex < 0 || ColumnCount <= columnIndex) return -1;
			if (rowIndex < 0 || RowCount <= rowIndex) return -1;

			return idMap[rowIndex][columnIndex];
		}

		public void SetMask(int rowIndex, int columnIndex)
		{
			if (null == maskImage ||
				maskImage.Width != ColumnCount * BlockWidth ||
				maskImage.Height != RowCount * BlockHeight)
			{
				if (null != maskImage)
				{
					maskImage.Dispose();
					maskImage = null;
				}
				maskImage = new Bitmap(ColumnCount * BlockWidth, RowCount * BlockHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			}

			using (var g = Graphics.FromImage(maskImage))
			{
				g.FillRectangle(maskBrush,
					columnIndex * BlockWidth,
					rowIndex * BlockHeight,
					BlockWidth,
					BlockHeight);
			}
		}

		public void ClearMask()
		{
			if (null != maskImage)
			{
				using (var g = Graphics.FromImage(maskImage))
				{
					g.Clear(Color.Transparent);
				}
			}
		}

		public void MakeLayerImage(LayerItem layerItem, List<Image> partsImages)
		{
			int canvasWidth = BlockWidth * ((0 == layerItem.Data.IDMap.Count) ? 1 : layerItem.Data.IDMap[0].Count);
			int canvasHeight = BlockHeight * ((0 == layerItem.Data.IDMap.Count) ? 1 : layerItem.Data.IDMap.Count);
			if (null == layerItem.Image ||
				layerItem.Image.Width != canvasWidth ||
				layerItem.Image.Height != canvasHeight)
			{
				if (null != layerItem.Image)
				{
					layerItem.Image.Dispose();
					layerItem.Image = null;
				}
				layerItem.Image = new Bitmap(canvasWidth, canvasHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			}

			using (var g = Graphics.FromImage(layerItem.Image))
			{
				g.Clear(Color.Transparent);

				for (int rowIndex = 0; rowIndex < layerItem.Data.IDMap.Count; rowIndex++)
				{
					var row = layerItem.Data.IDMap[rowIndex];

					for (int columnIndex = 0; columnIndex < row.Count; columnIndex++)
					{
						int id = row[columnIndex];
						if (id < 0 || partsImages.Count <= id) continue;

						g.DrawImage(partsImages[id],
							columnIndex * BlockWidth + BorderWidth,
							rowIndex * BlockHeight + BorderWidth);
					}
				}
			}
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (null == SelectedItem) return;

				ClearDraging();
				bDragStart = true;

				int rowIndex = Math.Max(0, Math.Min(RowCount - 1, e.Y / (BlockHeight * Zoom)));
				int columnIndex = Math.Max(0, Math.Min(ColumnCount - 1, e.X / (BlockWidth * Zoom)));
				dragStartRowIndex = rowIndex;
				dragStartColumnIndex = columnIndex;
				currentRowIndex = rowIndex;
				currentColumnIndex = columnIndex;
			}
			else if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				ClearDraging();
			}
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			int rowIndex = Math.Max(0, Math.Min(RowCount - 1, e.Y / (BlockHeight * Zoom)));
			int columnIndex = Math.Max(0, Math.Min(ColumnCount - 1, e.X / (BlockWidth * Zoom)));

			if (bDragStart && AreaSelect)
			{
				if (bDraging)
				{
					if (currentRowIndex == rowIndex &&
						currentColumnIndex == columnIndex) return;
				}
				else
				{
					if (dragStartRowIndex == rowIndex &&
						dragStartColumnIndex == rowIndex) return;

					bDraging = true;
				}
				currentRowIndex = rowIndex;
				currentColumnIndex = columnIndex;
			}
			else
			{
				if (currentRowIndex == rowIndex &&
					currentColumnIndex == columnIndex) return;

				dragStartRowIndex =
				currentRowIndex = rowIndex;
				dragStartColumnIndex =
				currentColumnIndex = columnIndex;
			}

			MakeDragImage();
			UpdateImage();

			if (null != MoveCursor)
			{
				MoveCursor(this, MakeEventArgs());
			}
		}

		MapEventArgs MakeEventArgs()
		{
			MapEventArgs data = new MapEventArgs();
			if (AreaSelect)
			{
				data.RowIndex = Math.Min(dragStartRowIndex, currentRowIndex);
				data.ColumnIndex = Math.Min(dragStartColumnIndex, currentColumnIndex);
				data.RowCount = Math.Max(dragStartRowIndex, currentRowIndex) - data.RowIndex + 1;
				data.ColumnCount = Math.Max(dragStartColumnIndex, currentColumnIndex) - data.ColumnIndex + 1;
			}
			else
			{
				data.RowIndex = currentRowIndex;
				data.ColumnIndex = currentColumnIndex;
				data.RowCount = 1;
				data.ColumnCount = 1;
			}
			return data;
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (!bDragStart) return;

			var data = MakeEventArgs();

			ClearDraging();
			SelectedItem(this, data);
			Focus();
		}

		private void MakeDragImage()
		{
			if (null == dragImage ||
				dragImage.Width != ColumnCount * BlockWidth ||
				dragImage.Height != RowCount * BlockHeight)
			{
				if (null != dragImage)
				{
					dragImage.Dispose();
					dragImage = null;
				}
				dragImage = new Bitmap(
								ColumnCount * BlockWidth,
								RowCount * BlockHeight,
								System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			}
			using (var g = Graphics.FromImage(dragImage))
			{
				g.Clear(Color.Transparent);

				int rowIndex = Math.Min(dragStartRowIndex, currentRowIndex);
				int columnIndex = Math.Min(dragStartColumnIndex, currentColumnIndex);
				int rowCount = Math.Max(dragStartRowIndex, currentRowIndex) - rowIndex + 1;
				int columnCount = Math.Max(dragStartColumnIndex, currentColumnIndex) - columnIndex + 1;

				Rectangle rect = new Rectangle(
										columnIndex * BlockWidth,
										rowIndex * BlockWidth,
										columnCount * BlockWidth - BorderWidth,
										rowCount * BlockHeight - BorderWidth);

				g.FillRectangle(dragBrush, rect);
				g.DrawRectangle(Pens.Blue, rect);
			}
		}

		private void ClearDraging()
		{
			bDraging = false;
			bDragStart = false;
			dragStartRowIndex =
			currentRowIndex =
			dragStartColumnIndex =
			currentColumnIndex = -1;
			if (null != dragImage)
			{
				using (var g = Graphics.FromImage(dragImage))
				{
					g.Clear(Color.Transparent);
				}
			}
			UpdateImage();
		}

		private void pictureBox1_MouseLeave(object sender, EventArgs e)
		{
			ClearDraging();
			if (null != MoveCursor)
			{
				MoveCursor(this, MakeEventArgs());
			}
		}
	}
}
