namespace EnchantMapEditor
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDownMapColumnCount = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMapRowCount = new System.Windows.Forms.NumericUpDown();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonLoadParts = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.numericUpDownPartsHeight = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownPartsWidth = new System.Windows.Forms.NumericUpDown();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.buttonChangeBackground = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.comboBoxZoomCanvas = new System.Windows.Forms.ComboBox();
			this.buttonHelp = new System.Windows.Forms.Button();
			this.buttonUnDo = new System.Windows.Forms.Button();
			this.buttonReDo = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.checkBoxPutFill = new System.Windows.Forms.CheckBox();
			this.comboBoxZoomParts = new System.Windows.Forms.ComboBox();
			this.buttonPutClear = new System.Windows.Forms.Button();
			this.pictureBoxSelectedParts = new System.Windows.Forms.PictureBox();
			this.buttonSetCollisionByPartKind = new System.Windows.Forms.Button();
			this.buttonReadCollision = new System.Windows.Forms.Button();
			this.buttonAddBackLayer = new System.Windows.Forms.Button();
			this.buttonUpLayer = new System.Windows.Forms.Button();
			this.buttonDownLayer = new System.Windows.Forms.Button();
			this.buttonAddForeLayer = new System.Windows.Forms.Button();
			this.buttonDeleteLayer = new System.Windows.Forms.Button();
			this.labelCursorPos = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.mapControlCanvas = new EnchantMapEditor.MapControl();
			this.tabControlMode = new System.Windows.Forms.TabControl();
			this.tabPagePutParts = new System.Windows.Forms.TabPage();
			this.labelPartsNo = new System.Windows.Forms.Label();
			this.mapControlParts = new EnchantMapEditor.MapControl();
			this.tabPageCollision = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkedListBoxLayer = new System.Windows.Forms.CheckedListBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMapColumnCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMapRowCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartsHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartsWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedParts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabControlMode.SuspendLayout();
			this.tabPagePutParts.SuspendLayout();
			this.tabPageCollision.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(17, 12);
			this.label3.TabIndex = 0;
			this.label3.Text = "縦";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(127, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 12);
			this.label4.TabIndex = 3;
			this.label4.Text = "横";
			// 
			// numericUpDownMapColumnCount
			// 
			this.numericUpDownMapColumnCount.Location = new System.Drawing.Point(150, 14);
			this.numericUpDownMapColumnCount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.numericUpDownMapColumnCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMapColumnCount.Name = "numericUpDownMapColumnCount";
			this.numericUpDownMapColumnCount.Size = new System.Drawing.Size(50, 19);
			this.numericUpDownMapColumnCount.TabIndex = 4;
			this.numericUpDownMapColumnCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip1.SetToolTip(this.numericUpDownMapColumnCount, "マップ横のマス数");
			this.numericUpDownMapColumnCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.numericUpDownMapColumnCount.ValueChanged += new System.EventHandler(this.numericUpDownMapColumnCount_ValueChanged);
			// 
			// numericUpDownMapRowCount
			// 
			this.numericUpDownMapRowCount.Location = new System.Drawing.Point(35, 14);
			this.numericUpDownMapRowCount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.numericUpDownMapRowCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMapRowCount.Name = "numericUpDownMapRowCount";
			this.numericUpDownMapRowCount.Size = new System.Drawing.Size(50, 19);
			this.numericUpDownMapRowCount.TabIndex = 1;
			this.numericUpDownMapRowCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip1.SetToolTip(this.numericUpDownMapRowCount, "マップ縦のマス数");
			this.numericUpDownMapRowCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.numericUpDownMapRowCount.ValueChanged += new System.EventHandler(this.numericUpDownMapRowCount_ValueChanged);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(487, 407);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(125, 23);
			this.buttonSave.TabIndex = 15;
			this.buttonSave.Text = "作成";
			this.toolTip1.SetToolTip(this.buttonSave, "現在のデータを元にコードの作成");
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonLoadParts
			// 
			this.buttonLoadParts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoadParts.Location = new System.Drawing.Point(509, 12);
			this.buttonLoadParts.Name = "buttonLoadParts";
			this.buttonLoadParts.Size = new System.Drawing.Size(58, 23);
			this.buttonLoadParts.TabIndex = 10;
			this.buttonLoadParts.Text = "読込";
			this.toolTip1.SetToolTip(this.buttonLoadParts, "マップパーツ画像の読込");
			this.buttonLoadParts.UseVisualStyleBackColor = true;
			this.buttonLoadParts.Click += new System.EventHandler(this.buttonLoadParts_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "gif";
			this.openFileDialog1.Filter = "GIF|*.gif";
			this.openFileDialog1.Title = "マップパーツを含む画像を指定してください";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(91, 17);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(23, 12);
			this.label5.TabIndex = 2;
			this.label5.Text = "マス";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(206, 17);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(23, 12);
			this.label6.TabIndex = 5;
			this.label6.Text = "マス";
			// 
			// numericUpDownPartsHeight
			// 
			this.numericUpDownPartsHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownPartsHeight.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numericUpDownPartsHeight.Location = new System.Drawing.Point(374, 14);
			this.numericUpDownPartsHeight.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.numericUpDownPartsHeight.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numericUpDownPartsHeight.Name = "numericUpDownPartsHeight";
			this.numericUpDownPartsHeight.Size = new System.Drawing.Size(50, 19);
			this.numericUpDownPartsHeight.TabIndex = 7;
			this.numericUpDownPartsHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip1.SetToolTip(this.numericUpDownPartsHeight, "マップパーツ一つの高さ");
			this.numericUpDownPartsHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			// 
			// numericUpDownPartsWidth
			// 
			this.numericUpDownPartsWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownPartsWidth.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numericUpDownPartsWidth.Location = new System.Drawing.Point(453, 14);
			this.numericUpDownPartsWidth.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.numericUpDownPartsWidth.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.numericUpDownPartsWidth.Name = "numericUpDownPartsWidth";
			this.numericUpDownPartsWidth.Size = new System.Drawing.Size(50, 19);
			this.numericUpDownPartsWidth.TabIndex = 9;
			this.numericUpDownPartsWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip1.SetToolTip(this.numericUpDownPartsWidth, "マップパーツ一つの幅");
			this.numericUpDownPartsWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
			// 
			// colorDialog1
			// 
			this.colorDialog1.Color = System.Drawing.Color.White;
			// 
			// buttonChangeBackground
			// 
			this.buttonChangeBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonChangeBackground.Location = new System.Drawing.Point(159, 333);
			this.buttonChangeBackground.Name = "buttonChangeBackground";
			this.buttonChangeBackground.Size = new System.Drawing.Size(80, 23);
			this.buttonChangeBackground.TabIndex = 2;
			this.buttonChangeBackground.Text = "背景色";
			this.toolTip1.SetToolTip(this.buttonChangeBackground, "背景色の変更");
			this.buttonChangeBackground.UseVisualStyleBackColor = true;
			this.buttonChangeBackground.Click += new System.EventHandler(this.buttonChangeBackground_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(430, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 12);
			this.label2.TabIndex = 8;
			this.label2.Text = "幅";
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(346, 17);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(25, 12);
			this.label10.TabIndex = 6;
			this.label10.Text = "高さ";
			// 
			// comboBoxZoomCanvas
			// 
			this.comboBoxZoomCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxZoomCanvas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxZoomCanvas.FormattingEnabled = true;
			this.comboBoxZoomCanvas.Items.AddRange(new object[] {
            "x1倍",
            "x2倍",
            "x3倍"});
			this.comboBoxZoomCanvas.Location = new System.Drawing.Point(245, 334);
			this.comboBoxZoomCanvas.Name = "comboBoxZoomCanvas";
			this.comboBoxZoomCanvas.Size = new System.Drawing.Size(80, 20);
			this.comboBoxZoomCanvas.TabIndex = 3;
			this.toolTip1.SetToolTip(this.comboBoxZoomCanvas, "マップの拡大表示");
			this.comboBoxZoomCanvas.SelectedIndexChanged += new System.EventHandler(this.comboBoxZoomCanvas_SelectedIndexChanged);
			// 
			// buttonHelp
			// 
			this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonHelp.Location = new System.Drawing.Point(589, 12);
			this.buttonHelp.Name = "buttonHelp";
			this.buttonHelp.Size = new System.Drawing.Size(23, 23);
			this.buttonHelp.TabIndex = 11;
			this.buttonHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip(this.buttonHelp, "ヘルプの表示");
			this.buttonHelp.UseVisualStyleBackColor = true;
			this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
			// 
			// buttonUnDo
			// 
			this.buttonUnDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonUnDo.Enabled = false;
			this.buttonUnDo.Location = new System.Drawing.Point(14, 407);
			this.buttonUnDo.Name = "buttonUnDo";
			this.buttonUnDo.Size = new System.Drawing.Size(75, 23);
			this.buttonUnDo.TabIndex = 13;
			this.buttonUnDo.Text = "元に戻す";
			this.toolTip1.SetToolTip(this.buttonUnDo, "編集を元に戻す");
			this.buttonUnDo.UseVisualStyleBackColor = true;
			this.buttonUnDo.Click += new System.EventHandler(this.buttonUnDo_Click);
			// 
			// buttonReDo
			// 
			this.buttonReDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonReDo.Enabled = false;
			this.buttonReDo.Location = new System.Drawing.Point(95, 407);
			this.buttonReDo.Name = "buttonReDo";
			this.buttonReDo.Size = new System.Drawing.Size(75, 23);
			this.buttonReDo.TabIndex = 14;
			this.buttonReDo.Text = "やり直し";
			this.toolTip1.SetToolTip(this.buttonReDo, "もとに戻した編集を再度適用");
			this.buttonReDo.UseVisualStyleBackColor = true;
			this.buttonReDo.Click += new System.EventHandler(this.buttonReDo_Click);
			// 
			// checkBoxPutFill
			// 
			this.checkBoxPutFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxPutFill.AutoSize = true;
			this.checkBoxPutFill.Location = new System.Drawing.Point(169, 136);
			this.checkBoxPutFill.Name = "checkBoxPutFill";
			this.checkBoxPutFill.Size = new System.Drawing.Size(72, 16);
			this.checkBoxPutFill.TabIndex = 3;
			this.checkBoxPutFill.Text = "塗りつぶし";
			this.toolTip1.SetToolTip(this.checkBoxPutFill, "マップパーツの配置方法\r\nON：連続するマスを塗りつぶす\r\nOFF：クリックまたはドラッグ範囲による配置");
			this.checkBoxPutFill.UseVisualStyleBackColor = true;
			this.checkBoxPutFill.CheckedChanged += new System.EventHandler(this.checkBoxPutFill_CheckedChanged);
			// 
			// comboBoxZoomParts
			// 
			this.comboBoxZoomParts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxZoomParts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxZoomParts.FormattingEnabled = true;
			this.comboBoxZoomParts.Items.AddRange(new object[] {
            "x1倍",
            "x2倍",
            "x3倍"});
			this.comboBoxZoomParts.Location = new System.Drawing.Point(169, 158);
			this.comboBoxZoomParts.Name = "comboBoxZoomParts";
			this.comboBoxZoomParts.Size = new System.Drawing.Size(80, 20);
			this.comboBoxZoomParts.TabIndex = 4;
			this.toolTip1.SetToolTip(this.comboBoxZoomParts, "マップパーツ一覧の拡大表示");
			this.comboBoxZoomParts.SelectedIndexChanged += new System.EventHandler(this.comboBoxZoomParts_SelectedIndexChanged);
			// 
			// buttonPutClear
			// 
			this.buttonPutClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPutClear.Location = new System.Drawing.Point(169, 107);
			this.buttonPutClear.Name = "buttonPutClear";
			this.buttonPutClear.Size = new System.Drawing.Size(80, 23);
			this.buttonPutClear.TabIndex = 2;
			this.buttonPutClear.Text = "空白";
			this.toolTip1.SetToolTip(this.buttonPutClear, "空白マップパーツの選択");
			this.buttonPutClear.UseVisualStyleBackColor = true;
			this.buttonPutClear.Click += new System.EventHandler(this.buttonPutClear_Click);
			// 
			// pictureBoxSelectedParts
			// 
			this.pictureBoxSelectedParts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxSelectedParts.Location = new System.Drawing.Point(169, 21);
			this.pictureBoxSelectedParts.Name = "pictureBoxSelectedParts";
			this.pictureBoxSelectedParts.Size = new System.Drawing.Size(80, 80);
			this.pictureBoxSelectedParts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxSelectedParts.TabIndex = 36;
			this.pictureBoxSelectedParts.TabStop = false;
			this.toolTip1.SetToolTip(this.pictureBoxSelectedParts, "選択したマップパーツのプレビュー");
			// 
			// buttonSetCollisionByPartKind
			// 
			this.buttonSetCollisionByPartKind.Location = new System.Drawing.Point(6, 35);
			this.buttonSetCollisionByPartKind.Name = "buttonSetCollisionByPartKind";
			this.buttonSetCollisionByPartKind.Size = new System.Drawing.Size(125, 23);
			this.buttonSetCollisionByPartKind.TabIndex = 1;
			this.buttonSetCollisionByPartKind.Text = "パーツ別に設定";
			this.toolTip1.SetToolTip(this.buttonSetCollisionByPartKind, "マップパーツの種類毎に衝突判定を設定");
			this.buttonSetCollisionByPartKind.UseVisualStyleBackColor = true;
			this.buttonSetCollisionByPartKind.Click += new System.EventHandler(this.buttonSetCollisionByPartKind_Click);
			// 
			// buttonReadCollision
			// 
			this.buttonReadCollision.Location = new System.Drawing.Point(6, 6);
			this.buttonReadCollision.Name = "buttonReadCollision";
			this.buttonReadCollision.Size = new System.Drawing.Size(125, 23);
			this.buttonReadCollision.TabIndex = 0;
			this.buttonReadCollision.Text = "取込";
			this.toolTip1.SetToolTip(this.buttonReadCollision, "衝突判定データの取込");
			this.buttonReadCollision.UseVisualStyleBackColor = true;
			this.buttonReadCollision.Click += new System.EventHandler(this.buttonReadCollision_Click);
			// 
			// buttonAddBackLayer
			// 
			this.buttonAddBackLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAddBackLayer.Location = new System.Drawing.Point(89, 81);
			this.buttonAddBackLayer.Name = "buttonAddBackLayer";
			this.buttonAddBackLayer.Size = new System.Drawing.Size(75, 23);
			this.buttonAddBackLayer.TabIndex = 4;
			this.buttonAddBackLayer.Text = "背景追加";
			this.toolTip1.SetToolTip(this.buttonAddBackLayer, "背景の追加");
			this.buttonAddBackLayer.UseVisualStyleBackColor = true;
			this.buttonAddBackLayer.Click += new System.EventHandler(this.buttonAddBackLayer_Click);
			// 
			// buttonUpLayer
			// 
			this.buttonUpLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonUpLayer.Location = new System.Drawing.Point(234, 18);
			this.buttonUpLayer.Name = "buttonUpLayer";
			this.buttonUpLayer.Size = new System.Drawing.Size(23, 23);
			this.buttonUpLayer.TabIndex = 1;
			this.buttonUpLayer.Text = "↑";
			this.toolTip1.SetToolTip(this.buttonUpLayer, "選択したレイヤーを前面に移動");
			this.buttonUpLayer.UseVisualStyleBackColor = true;
			this.buttonUpLayer.Click += new System.EventHandler(this.buttonUpLayer_Click);
			// 
			// buttonDownLayer
			// 
			this.buttonDownLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDownLayer.Location = new System.Drawing.Point(234, 47);
			this.buttonDownLayer.Name = "buttonDownLayer";
			this.buttonDownLayer.Size = new System.Drawing.Size(23, 23);
			this.buttonDownLayer.TabIndex = 2;
			this.buttonDownLayer.Text = "↓";
			this.toolTip1.SetToolTip(this.buttonDownLayer, "選択したレイヤーを背面に移動");
			this.buttonDownLayer.UseVisualStyleBackColor = true;
			this.buttonDownLayer.Click += new System.EventHandler(this.buttonDownLayer_Click);
			// 
			// buttonAddForeLayer
			// 
			this.buttonAddForeLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonAddForeLayer.Location = new System.Drawing.Point(6, 81);
			this.buttonAddForeLayer.Name = "buttonAddForeLayer";
			this.buttonAddForeLayer.Size = new System.Drawing.Size(75, 23);
			this.buttonAddForeLayer.TabIndex = 3;
			this.buttonAddForeLayer.Text = "前景追加";
			this.toolTip1.SetToolTip(this.buttonAddForeLayer, "前景の追加");
			this.buttonAddForeLayer.UseVisualStyleBackColor = true;
			this.buttonAddForeLayer.Click += new System.EventHandler(this.buttonAddForeLayer_Click);
			// 
			// buttonDeleteLayer
			// 
			this.buttonDeleteLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonDeleteLayer.Location = new System.Drawing.Point(170, 81);
			this.buttonDeleteLayer.Name = "buttonDeleteLayer";
			this.buttonDeleteLayer.Size = new System.Drawing.Size(48, 23);
			this.buttonDeleteLayer.TabIndex = 5;
			this.buttonDeleteLayer.Text = "削除";
			this.toolTip1.SetToolTip(this.buttonDeleteLayer, "選択したレイヤーを削除");
			this.buttonDeleteLayer.UseVisualStyleBackColor = true;
			this.buttonDeleteLayer.Click += new System.EventHandler(this.buttonDeleteLayer_Click);
			// 
			// labelCursorPos
			// 
			this.labelCursorPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelCursorPos.AutoSize = true;
			this.labelCursorPos.Location = new System.Drawing.Point(6, 338);
			this.labelCursorPos.Name = "labelCursorPos";
			this.labelCursorPos.Size = new System.Drawing.Size(67, 12);
			this.labelCursorPos.TabIndex = 1;
			this.labelCursorPos.Text = "カーソル位置";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(14, 41);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControlMode);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
			this.splitContainer1.Panel2MinSize = 225;
			this.splitContainer1.Size = new System.Drawing.Size(598, 360);
			this.splitContainer1.SplitterDistance = 331;
			this.splitContainer1.TabIndex = 12;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelCursorPos);
			this.groupBox1.Controls.Add(this.mapControlCanvas);
			this.groupBox1.Controls.Add(this.buttonChangeBackground);
			this.groupBox1.Controls.Add(this.comboBoxZoomCanvas);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(331, 360);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "マップ";
			// 
			// mapControlCanvas
			// 
			this.mapControlCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mapControlCanvas.AreaSelect = true;
			this.mapControlCanvas.AutoScroll = true;
			this.mapControlCanvas.BackColor = System.Drawing.Color.White;
			this.mapControlCanvas.BorderWidth = 0;
			this.mapControlCanvas.ColumnCount = 0;
			this.mapControlCanvas.Location = new System.Drawing.Point(3, 18);
			this.mapControlCanvas.Name = "mapControlCanvas";
			this.mapControlCanvas.PartsHeight = 0;
			this.mapControlCanvas.PartsWidth = 0;
			this.mapControlCanvas.RowCount = 0;
			this.mapControlCanvas.Size = new System.Drawing.Size(322, 309);
			this.mapControlCanvas.TabIndex = 0;
			this.mapControlCanvas.Zoom = 1;
			this.mapControlCanvas.SelectedItem += new System.Action<object, EnchantMapEditor.MapEventArgs>(this.mapControlCanvas_SelectedItem);
			this.mapControlCanvas.MoveCursor += new System.Action<object, EnchantMapEditor.MapEventArgs>(this.mapControlCanvas_MoveCursor);
			// 
			// tabControlMode
			// 
			this.tabControlMode.Controls.Add(this.tabPagePutParts);
			this.tabControlMode.Controls.Add(this.tabPageCollision);
			this.tabControlMode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlMode.Location = new System.Drawing.Point(0, 110);
			this.tabControlMode.Name = "tabControlMode";
			this.tabControlMode.SelectedIndex = 0;
			this.tabControlMode.Size = new System.Drawing.Size(263, 250);
			this.tabControlMode.TabIndex = 0;
			this.tabControlMode.SelectedIndexChanged += new System.EventHandler(this.tabControlMode_SelectedIndexChanged);
			// 
			// tabPagePutParts
			// 
			this.tabPagePutParts.Controls.Add(this.labelPartsNo);
			this.tabPagePutParts.Controls.Add(this.checkBoxPutFill);
			this.tabPagePutParts.Controls.Add(this.comboBoxZoomParts);
			this.tabPagePutParts.Controls.Add(this.mapControlParts);
			this.tabPagePutParts.Controls.Add(this.buttonPutClear);
			this.tabPagePutParts.Controls.Add(this.pictureBoxSelectedParts);
			this.tabPagePutParts.Location = new System.Drawing.Point(4, 22);
			this.tabPagePutParts.Name = "tabPagePutParts";
			this.tabPagePutParts.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePutParts.Size = new System.Drawing.Size(255, 224);
			this.tabPagePutParts.TabIndex = 0;
			this.tabPagePutParts.Text = "パーツを配置";
			this.tabPagePutParts.UseVisualStyleBackColor = true;
			// 
			// labelPartsNo
			// 
			this.labelPartsNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelPartsNo.AutoSize = true;
			this.labelPartsNo.Location = new System.Drawing.Point(169, 6);
			this.labelPartsNo.Name = "labelPartsNo";
			this.labelPartsNo.Size = new System.Drawing.Size(29, 12);
			this.labelPartsNo.TabIndex = 1;
			this.labelPartsNo.Text = "空白";
			// 
			// mapControlParts
			// 
			this.mapControlParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mapControlParts.AreaSelect = false;
			this.mapControlParts.AutoScroll = true;
			this.mapControlParts.BackColor = System.Drawing.Color.White;
			this.mapControlParts.BorderWidth = 1;
			this.mapControlParts.ColumnCount = 0;
			this.mapControlParts.Location = new System.Drawing.Point(6, 6);
			this.mapControlParts.Name = "mapControlParts";
			this.mapControlParts.PartsHeight = 0;
			this.mapControlParts.PartsWidth = 0;
			this.mapControlParts.RowCount = 0;
			this.mapControlParts.Size = new System.Drawing.Size(157, 212);
			this.mapControlParts.TabIndex = 0;
			this.mapControlParts.Zoom = 2;
			this.mapControlParts.SelectedItem += new System.Action<object, EnchantMapEditor.MapEventArgs>(this.mapControlParts_SelectedItem);
			// 
			// tabPageCollision
			// 
			this.tabPageCollision.Controls.Add(this.buttonSetCollisionByPartKind);
			this.tabPageCollision.Controls.Add(this.buttonReadCollision);
			this.tabPageCollision.Location = new System.Drawing.Point(4, 22);
			this.tabPageCollision.Name = "tabPageCollision";
			this.tabPageCollision.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCollision.Size = new System.Drawing.Size(255, 224);
			this.tabPageCollision.TabIndex = 1;
			this.tabPageCollision.Text = "衝突判定の設定";
			this.tabPageCollision.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.buttonAddBackLayer);
			this.groupBox3.Controls.Add(this.checkedListBoxLayer);
			this.groupBox3.Controls.Add(this.buttonUpLayer);
			this.groupBox3.Controls.Add(this.buttonDownLayer);
			this.groupBox3.Controls.Add(this.buttonAddForeLayer);
			this.groupBox3.Controls.Add(this.buttonDeleteLayer);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(263, 110);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "レイヤー";
			// 
			// checkedListBoxLayer
			// 
			this.checkedListBoxLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBoxLayer.FormattingEnabled = true;
			this.checkedListBoxLayer.IntegralHeight = false;
			this.checkedListBoxLayer.Location = new System.Drawing.Point(6, 18);
			this.checkedListBoxLayer.Name = "checkedListBoxLayer";
			this.checkedListBoxLayer.Size = new System.Drawing.Size(222, 58);
			this.checkedListBoxLayer.TabIndex = 0;
			this.checkedListBoxLayer.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxLayer_ItemCheck);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 442);
			this.Controls.Add(this.buttonReDo);
			this.Controls.Add(this.buttonUnDo);
			this.Controls.Add(this.buttonHelp);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.buttonLoadParts);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.numericUpDownPartsWidth);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.numericUpDownPartsHeight);
			this.Controls.Add(this.numericUpDownMapRowCount);
			this.Controls.Add(this.numericUpDownMapColumnCount);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.DoubleBuffered = true;
			this.MinimumSize = new System.Drawing.Size(620, 440);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "EnchantMapEditor.Net";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMapColumnCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMapRowCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartsHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPartsWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedParts)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabControlMode.ResumeLayout(false);
			this.tabPagePutParts.ResumeLayout(false);
			this.tabPagePutParts.PerformLayout();
			this.tabPageCollision.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonUpLayer;
		private System.Windows.Forms.Button buttonDownLayer;
		private System.Windows.Forms.Button buttonAddForeLayer;
		private System.Windows.Forms.Button buttonDeleteLayer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericUpDownMapColumnCount;
		private System.Windows.Forms.NumericUpDown numericUpDownMapRowCount;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonLoadParts;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numericUpDownPartsHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownPartsWidth;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button buttonChangeBackground;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.PictureBox pictureBoxSelectedParts;
		private System.Windows.Forms.Button buttonPutClear;
		private System.Windows.Forms.CheckedListBox checkedListBoxLayer;
		private MapControl mapControlParts;
		private MapControl mapControlCanvas;
		private System.Windows.Forms.ComboBox comboBoxZoomParts;
		private System.Windows.Forms.ComboBox comboBoxZoomCanvas;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button buttonAddBackLayer;
		private System.Windows.Forms.Button buttonHelp;
		private System.Windows.Forms.Button buttonReadCollision;
		private System.Windows.Forms.CheckBox checkBoxPutFill;
		private System.Windows.Forms.Button buttonUnDo;
		private System.Windows.Forms.Button buttonReDo;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabControl tabControlMode;
		private System.Windows.Forms.TabPage tabPagePutParts;
		private System.Windows.Forms.TabPage tabPageCollision;
		private System.Windows.Forms.Button buttonSetCollisionByPartKind;
		private System.Windows.Forms.Label labelCursorPos;
		private System.Windows.Forms.Label labelPartsNo;
	}
}

