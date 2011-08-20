using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EnchantMapEditor
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

			Application.Run(new MainForm());
		}

		static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			Application.ThreadException -= new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

			var builder = new System.Text.StringBuilder(e.Exception.Message);
			if (null != e.Exception.InnerException)
			{
				builder.AppendLine();
				builder.AppendLine("-----InnerException-----");
				builder.Append(e.Exception.InnerException.Message);
			}

			MessageBox.Show(e.Exception.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}
}
