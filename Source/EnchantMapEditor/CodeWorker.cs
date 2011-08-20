using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EnchantMapEditor
{
	class CodeWorker
	{
		public CodeWorker()
		{
			BackLayers = new List<LayerData>();
			ForeLayers = new List<LayerData>();
			CollisionMap = new List<List<bool>>();
		}

		public string FileName { get; set; }
		public List<LayerData> BackLayers { get; private set; }
		public List<LayerData> ForeLayers { get; private set; }
		public List<List<bool>> CollisionMap { get; private set; }
		public int MapColumnCount { get; set; }
		public int MapRowCount { get; set; }
		public int PartsWidth { get; set; }
		public int PartsHeight { get; set; }

		public string Make()
		{
			StringBuilder builder = new StringBuilder();

			Action<IEnumerable<int>> MakeRow = r =>
			{
				#region

				builder.Append("    [");
				bool bFirstColumn = true;
				foreach (int id in r)
				{
					if (bFirstColumn)
					{
						bFirstColumn = false;
					}
					else
					{
						builder.Append(',');
					}
					builder.AppendFormat("{0,3}", id);
				}
				builder.Append("]");

				#endregion
			};

			bool bFirstMap = true;

			Action<LayerData> MakeMap = layer =>
			{
				if (bFirstMap)
				{
					bFirstMap = false;
				}
				else
				{
					builder.AppendLine("],[");
				}

				#region

				bool bFirstRow = true;
				foreach (List<int> rowOrg in layer.IDMap.Take(MapRowCount))
				{
					if (bFirstRow)
					{
						bFirstRow = false;
					}
					else
					{
						builder.AppendLine(",");
					}

					var row = new List<int>(rowOrg);
					if (row.Count < MapColumnCount)
					{
						row.AddRange(Enumerable.Repeat(-1, MapColumnCount - row.Count));
					}
					MakeRow(row.Take(MapColumnCount));
				}

				if (layer.IDMap.Count < MapRowCount)
				{
					Enumerable.Repeat(-1, MapRowCount - layer.IDMap.Count)
						.ToList()
						.ForEach(id =>
						{
							if (bFirstRow)
							{
								bFirstRow = false;
							}
							else
							{
								builder.AppendLine(",");
							}
							MakeRow(Enumerable.Repeat(id, MapColumnCount));
						});
				}

				#endregion
				builder.AppendLine();
			};

			if (0 < BackLayers.Count)
			{
				#region BackgroundMap

				builder.AppendFormat("var map = new Map({0}, {1});", PartsWidth, PartsHeight);
				builder.AppendLine();

				builder.AppendFormat("map.image = game.assets['{0}'];", FileName);
				builder.AppendLine();

				builder.AppendLine("map.loadData([");

				bFirstMap = true;
				BackLayers.ForEach(l => MakeMap(l));

				builder.AppendLine("]);");

				#endregion

				if (0 < CollisionMap.Count)
				{
					#region CollisionData

					builder.AppendLine("map.collisionData = [");

					bool bFirstRow = true;
					foreach (List<bool> rowOrg in CollisionMap.Take(MapRowCount))
					{
						if (bFirstRow)
						{
							bFirstRow = false;
						}
						else
						{
							builder.AppendLine(",");
						}

						var row = rowOrg.Select(b => b ? 1 : 0).ToList();
						if (row.Count < MapColumnCount)
						{
							row.AddRange(Enumerable.Repeat(0, MapColumnCount - row.Count));
						}
						MakeRow(row.Take(MapColumnCount));
					}

					if (CollisionMap.Count < MapRowCount)
					{
						Enumerable.Repeat(0, MapRowCount - CollisionMap.Count)
							.ToList()
							.ForEach(id =>
							{
								if (bFirstRow)
								{
									bFirstRow = false;
								}
								else
								{
									builder.AppendLine(",");
								}
								MakeRow(Enumerable.Repeat(id, MapColumnCount));
							});
					}

					builder.AppendLine();

					builder.AppendLine("];");

					#endregion
				}
			}

			if (0 < ForeLayers.Count)
			{
				builder.AppendLine();

				#region ForegroundMap

				builder.AppendFormat("var foregroundMap = new Map({0}, {1});", PartsWidth, PartsHeight);
				builder.AppendLine();

				builder.AppendFormat("foregroundMap.image = game.assets['{0}'];", FileName);
				builder.AppendLine();

				builder.AppendLine("foregroundMap.loadData([");

				bFirstMap = true;
				ForeLayers.ForEach(l => MakeMap(l));

				builder.AppendLine("]);");

				#endregion
			}

			return builder.ToString();
		}

		public List<List<int>> LayerParts { get; private set; }

		public bool ParseIDMap(string dataText)
		{
			LayerParts = dataText
							.Split('[', ']')
							.Select(s => s.Trim())
							.Where(s => !string.IsNullOrEmpty(s) && s != ",")
							.Select(s => s.Split(',').ToList())
							.Select(row => row.Select(s => int.Parse(s)).ToList())
							.ToList();
			return true;
		}
	}
}
