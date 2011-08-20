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
	public partial class TextForm : Form
	{
		public TextForm()
		{
			InitializeComponent();
		}

		public enum ModeEnum
		{
			Read,
			Make,
			Explain
		}

		public ModeEnum Mode { get; set; }

		public string DataText
		{
			get { return textBox1.Text; }
			set { textBox1.Text = value; }
		}

		public event Func<string, bool> CheckParse;

		private void Form2_Load(object sender, EventArgs e)
		{
			switch(Mode)
			{
				case ModeEnum.Read:
					buttonClipbord.Text = "クリップボードから貼付け";
					break;
				case ModeEnum.Make:
					buttonClipbord.Text = "クリップボードにコピー";
					buttonOK.Visible = false;
					buttonCancel.Text = "閉じる";
					textBox1.ReadOnly = true;
					break;
				case ModeEnum.Explain:
					buttonClipbord.Visible = false;
					buttonOK.Visible = false;
					buttonCancel.Text = "閉じる";
					textBox1.ReadOnly = true;
					textBox1.SelectionStart = 0;//選択の解除
					break;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				switch(Mode)
				{
					case ModeEnum.Read:
						DataText = Clipboard.GetText().Replace("\n", "\r\n");
						break;
					case ModeEnum.Make:
						Clipboard.SetText(DataText, TextDataFormat.UnicodeText);
						MessageBox.Show(this, "コピーしました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					default: throw new NotImplementedException();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (Mode != ModeEnum.Read) throw new NotImplementedException();
			if (null != CheckParse && !CheckParse(DataText)) return;
			DialogResult = DialogResult.OK;
		}
	}
}
