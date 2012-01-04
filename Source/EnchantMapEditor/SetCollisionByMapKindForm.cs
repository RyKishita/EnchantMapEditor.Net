using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnchantMapEditor
{
	public partial class SetCollisionByMapKindForm : Form
	{
		public SetCollisionByMapKindForm()
		{
			InitializeComponent();
		}

		public List<Image> Parts { get; set; }
		public List<CheckState> Results { get; private set; }

		private void SetCollisionByMapKindForm_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < Parts.Count; i++)
			{
				int index = imageList1.Images.Count;
				imageList1.Images.Add(Parts[i]);

				var addItem = listView1.Items.Add(i.ToString());
				addItem.SubItems.Add(string.Empty);
				addItem.ImageIndex = index;
				addItem.Tag = CheckState.Indeterminate;
			}
			SetState();
		}

		void SetState()
		{
			foreach (ListViewItem item in listView1.Items)
			{
				string stateText;
				switch((CheckState)item.Tag)
				{
					case CheckState.Checked: stateText = "ON"; break;
					case CheckState.Unchecked: stateText = "OFF"; break;
					case CheckState.Indeterminate: stateText = "未設定"; break;
					default: throw new NotImplementedException();
				}
				item.SubItems[1].Text = stateText;
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			Results = new List<CheckState>();

			foreach (ListViewItem item in listView1.Items)
			{
				Results.Add((CheckState)item.Tag);
			}

			DialogResult = DialogResult.OK;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SetAllItem(CheckState.Checked);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			SetAllItem(CheckState.Unchecked);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			SetAllItem(CheckState.Indeterminate);
		}

		void SetAllItem(CheckState state)
		{
			foreach (ListViewItem item in listView1.SelectedItems)
			{
				item.Tag = state;
			}
			SetState();
		}
	}
}
