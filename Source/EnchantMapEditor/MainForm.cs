using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EnchantMapEditor
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		List<List<bool>> collisionMap = new List<List<bool>>();
		List<Image> partsImages = new List<Image>();
		LayerItem partsData = new LayerItem();

		int MapColumnCount { get; set; }
		int MapRowCount { get; set; }

		int SelectedPartsID = -1;

		List<EditData> undoStack = new List<EditData>();
		int undoIndex = -1;
		bool bExecutingUndo = false;

		private void Form1_Load(object sender, EventArgs e)
		{
			MapRowCount = Convert.ToInt32(numericUpDownMapRowCount.Value);
			MapColumnCount = Convert.ToInt32(numericUpDownMapColumnCount.Value);
			SetPartsSize();

			checkedListBoxLayer.BeginUpdate();
			try
			{
				var layerData = new LayerData() { IsForeground = true, Name = "前景1" };
				var layerItem = new LayerItem() { Data = layerData };
				checkedListBoxLayer.Items.Add(layerItem);

				layerData = new LayerData() { IsForeground = false, Name = "背景1" };
				layerItem = new LayerItem() { Data = layerData };
				checkedListBoxLayer.Items.Add(layerItem, true);

				checkedListBoxLayer.SelectedItem = layerItem;
			}
			finally
			{
				checkedListBoxLayer.EndUpdate();
			}
			partsData.Data = new LayerData();

			openFileDialog1.InitialDirectory = Application.StartupPath;
			openFileDialog1.FileName = "map1.gif";

			LoadParts();
			comboBoxZoomParts.SelectedIndex = 0;
			SetupIDMap(true);
			SetupCollisionMap(true);

			comboBoxZoomCanvas.SelectedIndex = 0;

			buttonHelp.Image = SystemIcons.Question.ToBitmap().GetThumbnailImage(16, 16, null, IntPtr.Zero);

			PushEditData();
		}

		private void buttonChangeBackground_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog(this) == DialogResult.OK)
			{
				mapControlCanvas.BackColor = colorDialog1.Color;
				mapControlParts.BackColor = colorDialog1.Color;
				PushEditData();
			}
		}

		private void buttonUpLayer_Click(object sender, EventArgs e)
		{
			if (checkedListBoxLayer.Items.Count <= 1) return;

			int selectedIndex = checkedListBoxLayer.SelectedIndex;
			if (0 == selectedIndex) return;

			var selectedLayerData = checkedListBoxLayer.SelectedItem as LayerItem;
			var prevLayerData = checkedListBoxLayer.Items[selectedIndex - 1] as LayerItem;
			if (selectedLayerData.Data.IsForeground != prevLayerData.Data.IsForeground) return;

			bool isShow = checkedListBoxLayer.GetItemChecked(selectedIndex);
			bool isShowPrev = checkedListBoxLayer.GetItemChecked(selectedIndex - 1);

			checkedListBoxLayer.Items.RemoveAt(selectedIndex - 1);
			checkedListBoxLayer.Items.RemoveAt(selectedIndex - 1);
			checkedListBoxLayer.Items.Insert(selectedIndex - 1, selectedLayerData);
			if (isShow)
			{
				checkedListBoxLayer.SetItemChecked(selectedIndex - 1, true);
			}
			checkedListBoxLayer.Items.Insert(selectedIndex, prevLayerData);
			if (isShowPrev)
			{
				checkedListBoxLayer.SetItemChecked(selectedIndex, true);
			}

			checkedListBoxLayer.SelectedIndex = selectedIndex - 1;

			MakeCanvas();

			PushEditData();
		}

		private void buttonDownLayer_Click(object sender, EventArgs e)
		{
			if (checkedListBoxLayer.Items.Count <= 1) return;

			int selectedIndex = checkedListBoxLayer.SelectedIndex;
			if (checkedListBoxLayer.Items.Count <= selectedIndex + 1) return;

			var selectedLayerData = checkedListBoxLayer.SelectedItem as LayerItem;
			var nextLayerData = checkedListBoxLayer.Items[selectedIndex + 1] as LayerItem;
			if (selectedLayerData.Data.IsForeground != nextLayerData.Data.IsForeground) return;

			bool isShow = checkedListBoxLayer.GetItemChecked(selectedIndex);
			bool isShowNext = checkedListBoxLayer.GetItemChecked(selectedIndex + 1);

			checkedListBoxLayer.Items.RemoveAt(selectedIndex);
			checkedListBoxLayer.Items.RemoveAt(selectedIndex);
			checkedListBoxLayer.Items.Insert(selectedIndex, nextLayerData);
			if (isShowNext)
			{
				checkedListBoxLayer.SetItemChecked(selectedIndex, true);
			}
			checkedListBoxLayer.Items.Insert(selectedIndex + 1, selectedLayerData);
			if (isShow)
			{
				checkedListBoxLayer.SetItemChecked(selectedIndex + 1, true);
			}

			checkedListBoxLayer.SelectedIndex = selectedIndex + 1;

			MakeCanvas();

			PushEditData();
		}

		private void buttonAddForeLayer_Click(object sender, EventArgs e)
		{
			var idMap = ReadIDMap(true);
			if (null == idMap) return;

			int count = 0;
			string name;
			do
			{
				count++;
				name = string.Format("前景{0}", count);
			} while (0 <= checkedListBoxLayer.FindString(name));

			var layerData = new LayerData() { IsForeground = true, Name = name };
			layerData.IDMap.AddRange(idMap);
			layerData.SetupIDMap(MapRowCount, MapColumnCount);
			var layerItem = new LayerItem() { Data = layerData };
			MakeLayerImage(layerItem);

			checkedListBoxLayer.Items.Insert(0, layerItem);
			checkedListBoxLayer.SetItemChecked(0, true);
			checkedListBoxLayer.SetSelected(0, true);

			MakeCanvas();

			PushEditData();
		}

		private void buttonAddBackLayer_Click(object sender, EventArgs e)
		{
			var idMap = ReadIDMap(true);
			if (null == idMap) return;

			int count = 0;
			string name;
			do
			{
				count++;
				name = string.Format("背景{0}", count);
			} while (0 <= checkedListBoxLayer.FindString(name));

			var layerData = new LayerData() { IsForeground = false, Name = name };
			layerData.IDMap.AddRange(idMap);
			layerData.SetupIDMap(MapRowCount, MapColumnCount);
			var layerItem = new LayerItem() { Data = layerData };
			MakeLayerImage(layerItem);

			int index = checkedListBoxLayer.Items.Add(layerItem, true);
			checkedListBoxLayer.SetSelected(index, true);

			MakeCanvas();

			PushEditData();
		}

		private void buttonDeleteLayer_Click(object sender, EventArgs e)
		{
			var layerItem = checkedListBoxLayer.SelectedItem as LayerItem;
			if (null == layerItem)
			{
				MessageBox.Show(this, "削除する項目を選択してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (MessageBox.Show(this, string.Format("レイヤー「{0}」を削除します。\nよろしいですか?", layerItem.Data.Name), "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK) return;

			layerItem.Dispose();

			int selectedIndex = checkedListBoxLayer.SelectedIndex;
			checkedListBoxLayer.Items.Remove(layerItem);
			if (checkedListBoxLayer.Items.Count <= selectedIndex)
			{
				selectedIndex = checkedListBoxLayer.Items.Count - 1;
			}
			checkedListBoxLayer.SelectedIndex = selectedIndex;

			MakeCanvas();

			PushEditData();
		}

		private void buttonLoadParts_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				SetPartsSize();
				LoadParts();
				InitializePartsList();
				SetupIDMap(true);
				SetupCollisionMap(true);
				MakeCanvas();

				undoStack.Clear();
				undoIndex = -1;
				PushEditData();
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			string filePath = openFileDialog1.FileName;
			if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
			{
				MessageBox.Show(this, "パーツファイルが未設定です。", "警告");
				return;
			}

			CodeWorker worker = new CodeWorker()
			{
				MapColumnCount = mapControlCanvas.ColumnCount,
				MapRowCount = mapControlCanvas.RowCount,
				FileName = Path.GetFileName(filePath),
				PartsWidth = mapControlCanvas.PartsWidth,
				PartsHeight = mapControlCanvas.PartsHeight
			};

			#region 入力データ取得

			foreach (LayerItem layerItem in checkedListBoxLayer.Items.Cast<LayerItem>().Reverse())
			{
				if (layerItem.Data.IsForeground)
				{
					worker.ForeLayers.Add(layerItem.Data);
				}
				else
				{
					worker.BackLayers.Add(layerItem.Data);
				}
			}

			#endregion

			worker.CollisionMap.AddRange(collisionMap);

			using (var form = new TextForm())
			{
				form.Text = "コードを作成しました。コピーして貼りつけてください。";
				form.Mode = TextForm.ModeEnum.Make;
				form.DataText = worker.Make();
				form.ShowDialog(this);
			}
		}

		private void buttonPutClear_Click(object sender, EventArgs e)
		{
			SelectedPartsID = -1;
			ChangeSelectedParts();
			mapControlParts.ClearMask();
			mapControlParts.UpdateImage();
		}

		private void checkedListBoxLayer_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			List<LayerItem> layerItems = new List<LayerItem>();
			for (int i = 0; i < checkedListBoxLayer.Items.Count; i++)
			{
				bool isChecked;
				if (i == e.Index)
				{
					isChecked = e.NewValue == CheckState.Checked;
				}
				else
				{
					isChecked = checkedListBoxLayer.GetItemChecked(i);
				}

				if (isChecked)
				{
					layerItems.Add(checkedListBoxLayer.Items[i] as LayerItem);
				}
			}
			MakeCanvas(layerItems);
		}

		private void mapControlParts_SelectedItem(object sender, MapEventArgs e)
		{
			mapControlParts.ClearMask();
			mapControlParts.SetMask(e.RowIndex, e.ColumnIndex);
			mapControlParts.UpdateImage();

			SelectedPartsID = mapControlParts.GetID(e.RowIndex, e.ColumnIndex);
			ChangeSelectedParts();
		}

		private void mapControlCanvas_SelectedItem(object sender, MapEventArgs e)
		{
			if (tabControlMode.SelectedTab == tabPagePutParts)
			{
				#region パーツ配置

				var layerItem = checkedListBoxLayer.SelectedItem as LayerItem;
				if (null == layerItem)
				{
					MessageBox.Show(this, "レイヤーが選択されていません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}
				if (!checkedListBoxLayer.GetItemChecked(checkedListBoxLayer.SelectedIndex))
				{
					checkedListBoxLayer.SetItemChecked(checkedListBoxLayer.SelectedIndex, true);
				}

				if (checkBoxPutFill.Checked)
				{
					int currentID = layerItem.Data.IDMap[e.RowIndex][e.ColumnIndex];
					if (currentID != SelectedPartsID)
					{
						PutFill(layerItem.Data.IDMap, e.RowIndex, e.ColumnIndex, currentID, SelectedPartsID);
					}
				}
				else
				{
					for (int r = 0; r < e.RowCount; r++)
					{
						for (int c = 0; c < e.ColumnCount; c++)
						{
							layerItem.Data.IDMap[e.RowIndex + r][e.ColumnIndex + c] = SelectedPartsID;
						}
					}
				}
				MakeLayerImage(layerItem);
				MakeCanvas();

				#endregion
			}
			else if (tabControlMode.SelectedTab == tabPageCollision)
			{
				#region 衝突判定配置

				if (checkBoxPutFill.Checked)
				{
					bool currentValue = collisionMap[e.RowIndex][e.ColumnIndex];
					PutFill(collisionMap, e.RowIndex, e.ColumnIndex, currentValue, !currentValue);
				}
				else
				{
					for (int r = 0; r < e.RowCount; r++)
					{
						for (int c = 0; c < e.ColumnCount; c++)
						{
							collisionMap[e.RowIndex + r][e.ColumnIndex + c] = !collisionMap[e.RowIndex + r][e.ColumnIndex + c];
						}
					}
				}

				SetCollisionMask();
				mapControlCanvas.UpdateImage();

				#endregion
			}
			PushEditData();
		}

		private void numericUpDownMapRowCount_ValueChanged(object sender, EventArgs e)
		{
			if (bExecutingUndo) return;
			MapRowCount = Convert.ToInt32(numericUpDownMapRowCount.Value);

			SetupIDMap(false);
			SetupCollisionMap(false);
			MakeCanvas();

			PushEditData();
		}

		private void numericUpDownMapColumnCount_ValueChanged(object sender, EventArgs e)
		{
			if (bExecutingUndo) return;
			MapColumnCount = Convert.ToInt32(numericUpDownMapColumnCount.Value);

			SetupIDMap(false);
			SetupCollisionMap(false);
			MakeCanvas();

			PushEditData();
		}

		private void comboBoxZoomParts_SelectedIndexChanged(object sender, EventArgs e)
		{
			mapControlParts.Zoom = comboBoxZoomParts.SelectedIndex + 1;
			InitializePartsList();
		}

		private void comboBoxZoomCanvas_SelectedIndexChanged(object sender, EventArgs e)
		{
			mapControlCanvas.Zoom = comboBoxZoomCanvas.SelectedIndex + 1;

			SetCollisionMask();

			checkedListBoxLayer.Items.Cast<LayerItem>()
				.ToList()
				.ForEach(li => MakeLayerImage(li));
			MakeCanvas();
		}

		private void buttonHelp_Click(object sender, EventArgs e)
		{
			using (var form = new TextForm())
			{
				form.Text = "ヘルプ";
				form.Mode = TextForm.ModeEnum.Explain;
				form.DataText = File.ReadAllText(Path.Combine(Application.StartupPath, "readme.txt"));
				form.ShowDialog(this);
			}
		}

		private void buttonReadCollision_Click(object sender, EventArgs e)
		{
			var idMap = ReadIDMap(false);
			if (null == idMap) return;

			collisionMap.Clear();
			collisionMap.AddRange(idMap.Select(row => row.Select(id => id == 1).ToList()));
			SetupCollisionMap(false);

			SetCollisionMask();
			MakeCanvas();

			PushEditData();
		}

		private void checkBoxPutFill_CheckedChanged(object sender, EventArgs e)
		{
			mapControlCanvas.AreaSelect = !checkBoxPutFill.Checked;
		}

		private void buttonUnDo_Click(object sender, EventArgs e)
		{
			PopEditData();
		}

		private void buttonReDo_Click(object sender, EventArgs e)
		{
			undoIndex += 2;
			PopEditData();
		}

		private void SetCollisionMask()
		{
			mapControlCanvas.ClearMask();
			if (tabControlMode.SelectedTab == tabPageCollision)
			{
				for (int rowIndex = 0; rowIndex < collisionMap.Count; rowIndex++)
				{
					var row = collisionMap[rowIndex];
					for (int columnIndex = 0; columnIndex < row.Count; columnIndex++)
					{
						if (collisionMap[rowIndex][columnIndex])
						{
							mapControlCanvas.SetMask(rowIndex, columnIndex);
						}
					}
				}
			}
		}

		private void LoadParts()
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				#region パーツデータの初期化

				partsImages.ForEach(image => image.Dispose());
				partsImages.Clear();

				partsData.Data.IDMap.Clear();

				#endregion

				string filePath = openFileDialog1.FileName;
				if (File.Exists(filePath))
				{
					#region ファイルを読み込み

					using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
					{
						using (var image = Bitmap.FromStream(fs))
						{
							mapControlParts.RowCount = image.Height / mapControlParts.PartsHeight;
							mapControlParts.ColumnCount = image.Width / mapControlParts.PartsWidth;

							var partsSize = new Size(mapControlParts.PartsWidth, mapControlParts.PartsHeight);
							var srcRect = new Rectangle(Point.Empty, partsSize);

							for (int rowIndex = 0; rowIndex < mapControlParts.RowCount; rowIndex++)
							{
								partsData.Data.IDMap.Add(Enumerable.Repeat(-1, mapControlParts.ColumnCount).ToList());
								for (int columnIndex = 0; columnIndex < mapControlParts.ColumnCount; columnIndex++)
								{
									partsData.Data.IDMap[rowIndex][columnIndex] = partsImages.Count;

									var partsImage = new Bitmap(partsSize.Width, partsSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
									using (var g = Graphics.FromImage(partsImage))
									{
										g.Clear(Color.Transparent);
										srcRect.X = columnIndex * mapControlParts.PartsWidth;
										srcRect.Y = rowIndex * mapControlParts.PartsHeight;
										g.DrawImage(image, 0, 0, srcRect, GraphicsUnit.Pixel);
									}
									partsImages.Add(partsImage);
								}
							}
						}
					}

					#endregion
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void InitializePartsList()
		{
			mapControlParts.MakeLayerImage(partsData, partsImages);

			mapControlParts.ClearMask();
			if (SelectedPartsID != -1)
			{
				bool bSet = false;
				for (int rowIndex = 0; rowIndex < partsData.Data.IDMap.Count; rowIndex++)
				{
					var row = partsData.Data.IDMap[rowIndex];
					for (int columnIndex = 0; columnIndex < row.Count; columnIndex++)
					{
						if (row[columnIndex] == SelectedPartsID)
						{
							mapControlParts.SetMask(rowIndex, columnIndex);
							bSet = true;
							break;
						}
					}
					if (bSet) break;
				}
			}

			mapControlParts.Clear();
			mapControlParts.SetLayer(partsData);
			mapControlParts.UpdateImage();
		}

		private void SetupIDMap(bool bClear)
		{
			foreach (LayerItem layerItem in checkedListBoxLayer.Items)
			{
				if (bClear)
				{
					layerItem.Data.IDMap.Clear();
				}
				layerItem.Data.SetupIDMap(MapRowCount, MapColumnCount);
				MakeLayerImage(layerItem);
			}
		}

		private void SetupCollisionMap(bool bClear)
		{
			if (bClear)
			{
				collisionMap.Clear();
			}

			if (MapRowCount < collisionMap.Count)
			{
				collisionMap.RemoveRange(MapRowCount, collisionMap.Count - MapRowCount);
			}
			else if (collisionMap.Count < MapRowCount)
			{
				int addCount = MapRowCount - collisionMap.Count;
				for (int i = 0; i < addCount; i++)
				{
					collisionMap.Add(Enumerable.Repeat(false, MapColumnCount).ToList());
				}
			}

			foreach (var row in collisionMap)
			{
				if (MapColumnCount < row.Count)
				{
					row.RemoveRange(MapColumnCount, row.Count - MapColumnCount);
				}
				else if (row.Count < MapColumnCount)
				{
					row.AddRange(Enumerable.Repeat(false, MapColumnCount - row.Count));
				}
			}
		}

		private void MakeLayerImage(LayerItem layerItem)
		{
			mapControlCanvas.MakeLayerImage(layerItem, partsImages);
		}

		private void ChangeSelectedParts()
		{
			if (SelectedPartsID == -1)
			{
				pictureBoxSelectedParts.Image = null;
			}
			else
			{
				pictureBoxSelectedParts.Image = partsImages[SelectedPartsID];
			}
		}

		private void MakeCanvas()
		{
			var layerItems = checkedListBoxLayer.CheckedItems
								.Cast<LayerItem>()
								.ToList();
			MakeCanvas(layerItems);
		}

		private void MakeCanvas(List<LayerItem> layerItems)
		{
			mapControlCanvas.RowCount = MapRowCount;
			mapControlCanvas.ColumnCount = MapColumnCount;
			
			mapControlCanvas.Clear();
			layerItems.Reverse();
			layerItems.ForEach(ld => mapControlCanvas.SetLayer(ld));
			mapControlCanvas.UpdateImage();
		}

		private List<List<int>> ReadIDMap(bool bReadLayer)
		{
			CodeWorker worker = new CodeWorker();
			using (var form = new TextForm())
			{
				form.Text = bReadLayer
							 ? "マップデータを入力するか、無い場合は空のままOKを押してください。"
							 : "衝突判定データを入力してください。";
				form.Mode = TextForm.ModeEnum.Read;
				form.CheckParse += dataText =>
				{
					try
					{
						return worker.ParseIDMap(dataText);
					}
					catch (Exception ex)
					{
						StringBuilder builder = new StringBuilder(ex.Message);
						builder.AppendLine();
						builder.AppendLine();
						builder.AppendLine("-----書式例-----");
						if (bReadLayer)
						{
							builder.AppendLine("[ -1, -1, -1, -1, -1],");
							builder.AppendLine("[ -1, -1, -1, -1, -1],");
							builder.AppendLine("[ -1, -1, -1, -1, -1],");
							builder.AppendLine("[ -1, -1, -1, -1, -1]");
						}
						else
						{
							builder.AppendLine("[  0,  0,  0,  0,  0],");
							builder.AppendLine("[  0,  0,  0,  0,  0],");
							builder.AppendLine("[  0,  0,  0,  0,  0],");
							builder.AppendLine("[  0,  0,  0,  0,  0]");
						}
						builder.AppendLine();
						builder.Append("※空白・改行については書式に合わせなくても取り込めます。");
						MessageBox.Show(form, builder.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return false;
					}
				};
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					return worker.LayerParts;
				}
				else
				{
					return null;
				}
			}
		}

		class PutPair : IEquatable<PutPair>
		{
			public int row;
			public int column;
			public bool valid = true;

			public bool Equals(PutPair other)
			{
				return row == other.row && column == other.column;
			}
		}

		private void PutFill<T>(List<List<T>> idMap, int rowIndex, int columnIndex, T srcID, T dstID) where T : struct
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				var putPairs = new List<PutPair>();
				Action<int, int> addPutPair = (r, c) =>
				{
					var p = new PutPair() { row = r, column = c };
					if (!putPairs.Contains(p)) putPairs.Add(p);
				};

				addPutPair(rowIndex, columnIndex);

				while (true)
				{
					var putPair = putPairs.FirstOrDefault(p => p.valid);
					if (putPair == null) break;

					var rows = idMap[putPair.row];
					if (rows[putPair.column].Equals(srcID))
					{
						rows[putPair.column] = dstID;

						if (0 < putPair.row)
						{
							addPutPair(putPair.row - 1, putPair.column);
						}
						if (putPair.row + 1 < idMap.Count)
						{
							addPutPair(putPair.row + 1, putPair.column);
						}
						if (0 < putPair.column)
						{
							addPutPair(putPair.row, putPair.column - 1);
						}
						if (putPair.column + 1 < idMap[putPair.row].Count)
						{
							addPutPair(putPair.row, putPair.column + 1);
						}
					}
					putPair.valid = false;
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void PushEditData()
		{
			undoStack = undoStack.Take(undoIndex + 1).ToList();

			var editData = new EditData()
			{
				MapColumnCount = MapColumnCount,
				MapRowCount = MapRowCount,
				LayerDatas = checkedListBoxLayer.Items.Cast<LayerItem>().Select(li => li.Data.Clone() as LayerData).ToList(),
				CollisionMap = collisionMap.Select(row => row.ToArray().ToList()).ToList(),
				BackgroundColor = mapControlCanvas.BackColor
			};

			undoStack.Add(editData);
			undoIndex++;

			UpdateUndoRedoButton();
		}

		private void PopEditData()
		{
			if (undoIndex == 0) return;

			bExecutingUndo = true;
			try
			{
				undoIndex--;

				var editData = undoStack[undoIndex];

				MapRowCount = editData.MapRowCount;
				MapColumnCount = editData.MapColumnCount;
				checkedListBoxLayer.BeginUpdate();
				try
				{
					string oldSelectedName = null;
					if (null != checkedListBoxLayer.SelectedItem)
					{
						oldSelectedName = checkedListBoxLayer.SelectedItem.ToString();
					}

					var oldCheckedItems = checkedListBoxLayer.CheckedItems.Cast<LayerItem>().Select(li => li.Data.Name).ToList();

					checkedListBoxLayer.Items.Cast<LayerItem>().ToList().ForEach(li => li.Dispose());
					checkedListBoxLayer.Items.Clear();
					foreach (LayerData layerData in editData.LayerDatas)
					{
						var layerItem = new LayerItem() { Data = layerData.Clone() as LayerData };
						MakeLayerImage(layerItem);

						int index = checkedListBoxLayer.Items.Add(layerItem, oldCheckedItems.Contains(layerItem.Data.Name));
						if (0 == string.Compare(layerData.Name, oldSelectedName))
						{
							checkedListBoxLayer.SetSelected(index, true);
						}
					}
				}
				finally
				{
					checkedListBoxLayer.EndUpdate();
				}
				collisionMap = editData.CollisionMap.Select(row => row.ToList()).ToList();

				colorDialog1.Color = editData.BackgroundColor;
				mapControlCanvas.BackColor = editData.BackgroundColor;
				mapControlParts.BackColor = editData.BackgroundColor;

				numericUpDownMapRowCount.Value = MapRowCount;
				numericUpDownMapColumnCount.Value = MapColumnCount;

				SetCollisionMask();
				MakeCanvas();

				UpdateUndoRedoButton();
			}
			finally
			{
				bExecutingUndo = false;
			}
		}

		private void UpdateUndoRedoButton()
		{
			buttonUnDo.Enabled = 0 < undoIndex;
			buttonReDo.Enabled = undoIndex + 1 < undoStack.Count;
		}

		private void SetPartsSize()
		{
			mapControlCanvas.PartsWidth =
			mapControlParts.PartsWidth = Convert.ToInt32(numericUpDownPartsWidth.Value);
			mapControlCanvas.PartsHeight =
			mapControlParts.PartsHeight = Convert.ToInt32(numericUpDownPartsHeight.Value);
		}

		private void tabControlMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetCollisionMask();
			mapControlCanvas.UpdateImage();
		}

		private void buttonSetCollisionByPartKind_Click(object sender, EventArgs e)
		{
			using (var form = new SetCollisionByMapKindForm())
			{
				form.Parts = partsImages;
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					foreach (LayerItem layerItem in checkedListBoxLayer.Items)
					{
						for (int row = 0; row < MapRowCount; row++)
						{
							var rowCollisions = collisionMap[row];
							var rowIDs = layerItem.Data.IDMap[row];
							for (int column = 0; column < MapColumnCount; column++)
							{
								int id = rowIDs[column];
								if (id < 0) continue;//透明部分

								switch (form.Results[id])
								{
									case CheckState.Checked: rowCollisions[column] = true; break;
									case CheckState.Unchecked: rowCollisions[column] = false; break;
								}
							}
						}
					}

					SetCollisionMask();
					mapControlCanvas.UpdateImage();
				}
			}
		}
	}
}
