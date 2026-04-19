namespace ElliPAINTT
{
    partial class ElliPaintForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Canvas = new PictureBox();
            BrushOptionsTabs = new TabControl();
            BrushTypeTab = new TabPage();
            EraserBrush = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            makeCustomButton = new Button();
            TriangleBrush = new Button();
            SquareBrush = new Button();
            CircleBrush = new Button();
            BrushSizeTab = new TabPage();
            colorButton = new Button();
            ScrollSizeButton = new CheckBox();
            BrushHeightLabel = new Label();
            BrushWidthLabel = new Label();
            BrushHeight = new TrackBar();
            BrushWidth = new TrackBar();
            CanvasOptionsTab = new TabPage();
            RenameFilePanel = new Panel();
            SaveConfirmButton = new Button();
            FileNameLabel = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            LoadPreviousButton = new Button();
            clearCanvasButton = new Button();
            SaveButton = new Button();
            display = new TabPage();
            sendToMatrix = new Button();
            heightLabel = new Label();
            widthLabel = new Label();
            heightEntered = new TextBox();
            widthEntered = new TextBox();
            ledDisplay = new PictureBox();
            scaleDown = new Button();
            tabPage1 = new TabPage();
            testPictureBox = new PictureBox();
            colorDialog1 = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            sendProgressBar = new ProgressBar();
            animateOptions = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)Canvas).BeginInit();
            BrushOptionsTabs.SuspendLayout();
            BrushTypeTab.SuspendLayout();
            BrushSizeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BrushHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BrushWidth).BeginInit();
            CanvasOptionsTab.SuspendLayout();
            RenameFilePanel.SuspendLayout();
            display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ledDisplay).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)testPictureBox).BeginInit();
            SuspendLayout();
            // 
            // Canvas
            // 
            Canvas.Location = new Point(12, 26);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(430, 398);
            Canvas.TabIndex = 0;
            Canvas.TabStop = false;
            Canvas.MouseClick += Canvas_MouseClick;
            Canvas.MouseDown += Canvas_MouseDown;
            Canvas.MouseMove += Canvas_MouseMove;
            Canvas.MouseUp += Canvas_MouseUp;
            // 
            // BrushOptionsTabs
            // 
            BrushOptionsTabs.Controls.Add(BrushTypeTab);
            BrushOptionsTabs.Controls.Add(BrushSizeTab);
            BrushOptionsTabs.Controls.Add(CanvasOptionsTab);
            BrushOptionsTabs.Controls.Add(display);
            BrushOptionsTabs.Controls.Add(tabPage1);
            BrushOptionsTabs.Location = new Point(482, 53);
            BrushOptionsTabs.Name = "BrushOptionsTabs";
            BrushOptionsTabs.SelectedIndex = 0;
            BrushOptionsTabs.Size = new Size(278, 338);
            BrushOptionsTabs.TabIndex = 2;
            // 
            // BrushTypeTab
            // 
            BrushTypeTab.Controls.Add(EraserBrush);
            BrushTypeTab.Controls.Add(label2);
            BrushTypeTab.Controls.Add(comboBox1);
            BrushTypeTab.Controls.Add(makeCustomButton);
            BrushTypeTab.Controls.Add(TriangleBrush);
            BrushTypeTab.Controls.Add(SquareBrush);
            BrushTypeTab.Controls.Add(CircleBrush);
            BrushTypeTab.Location = new Point(4, 24);
            BrushTypeTab.Name = "BrushTypeTab";
            BrushTypeTab.Padding = new Padding(3);
            BrushTypeTab.Size = new Size(270, 310);
            BrushTypeTab.TabIndex = 0;
            BrushTypeTab.Text = "Type";
            BrushTypeTab.UseVisualStyleBackColor = true;
            // 
            // EraserBrush
            // 
            EraserBrush.Location = new Point(96, 258);
            EraserBrush.Name = "EraserBrush";
            EraserBrush.Size = new Size(75, 23);
            EraserBrush.TabIndex = 3;
            EraserBrush.Text = "Eraser";
            EraserBrush.UseVisualStyleBackColor = true;
            EraserBrush.Click += EraserBrush_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 195);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 7;
            label2.Text = "Saved Custom Shapes";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(75, 213);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // makeCustomButton
            // 
            makeCustomButton.Location = new Point(96, 156);
            makeCustomButton.Name = "makeCustomButton";
            makeCustomButton.Size = new Size(75, 23);
            makeCustomButton.TabIndex = 5;
            makeCustomButton.Text = "Custom";
            makeCustomButton.UseVisualStyleBackColor = true;
            makeCustomButton.Click += makeCustomButton_Click;
            // 
            // TriangleBrush
            // 
            TriangleBrush.Location = new Point(96, 118);
            TriangleBrush.Name = "TriangleBrush";
            TriangleBrush.Size = new Size(75, 23);
            TriangleBrush.TabIndex = 4;
            TriangleBrush.Text = "Triangle";
            TriangleBrush.UseVisualStyleBackColor = true;
            TriangleBrush.Click += TriangleBrush_Click;
            // 
            // SquareBrush
            // 
            SquareBrush.Location = new Point(96, 80);
            SquareBrush.Name = "SquareBrush";
            SquareBrush.Size = new Size(75, 23);
            SquareBrush.TabIndex = 3;
            SquareBrush.Text = "Square";
            SquareBrush.UseVisualStyleBackColor = true;
            SquareBrush.Click += SquareBrush_Click;
            // 
            // CircleBrush
            // 
            CircleBrush.Location = new Point(96, 42);
            CircleBrush.Name = "CircleBrush";
            CircleBrush.Size = new Size(75, 23);
            CircleBrush.TabIndex = 0;
            CircleBrush.Text = "Circle";
            CircleBrush.UseVisualStyleBackColor = true;
            CircleBrush.Click += CircleBrush_Click;
            // 
            // BrushSizeTab
            // 
            BrushSizeTab.Controls.Add(colorButton);
            BrushSizeTab.Controls.Add(ScrollSizeButton);
            BrushSizeTab.Controls.Add(BrushHeightLabel);
            BrushSizeTab.Controls.Add(BrushWidthLabel);
            BrushSizeTab.Controls.Add(BrushHeight);
            BrushSizeTab.Controls.Add(BrushWidth);
            BrushSizeTab.Location = new Point(4, 24);
            BrushSizeTab.Name = "BrushSizeTab";
            BrushSizeTab.Padding = new Padding(3);
            BrushSizeTab.Size = new Size(270, 310);
            BrushSizeTab.TabIndex = 1;
            BrushSizeTab.Text = "Size & Color";
            BrushSizeTab.UseVisualStyleBackColor = true;
            // 
            // colorButton
            // 
            colorButton.Location = new Point(94, 228);
            colorButton.Name = "colorButton";
            colorButton.Size = new Size(75, 23);
            colorButton.TabIndex = 9;
            colorButton.Text = "Color ";
            colorButton.UseVisualStyleBackColor = true;
            colorButton.Click += colorButton_Click;
            // 
            // ScrollSizeButton
            // 
            ScrollSizeButton.AutoSize = true;
            ScrollSizeButton.Location = new Point(47, 86);
            ScrollSizeButton.Name = "ScrollSizeButton";
            ScrollSizeButton.Size = new Size(106, 19);
            ScrollSizeButton.TabIndex = 8;
            ScrollSizeButton.Text = "Lock both sizes";
            ScrollSizeButton.UseVisualStyleBackColor = true;
            // 
            // BrushHeightLabel
            // 
            BrushHeightLabel.AutoSize = true;
            BrushHeightLabel.Location = new Point(6, 178);
            BrushHeightLabel.Name = "BrushHeightLabel";
            BrushHeightLabel.Size = new Size(41, 15);
            BrushHeightLabel.TabIndex = 7;
            BrushHeightLabel.Text = "height";
            // 
            // BrushWidthLabel
            // 
            BrushWidthLabel.AutoSize = true;
            BrushWidthLabel.Location = new Point(6, 130);
            BrushWidthLabel.Name = "BrushWidthLabel";
            BrushWidthLabel.Size = new Size(37, 15);
            BrushWidthLabel.TabIndex = 6;
            BrushWidthLabel.Text = "width";
            // 
            // BrushHeight
            // 
            BrushHeight.Location = new Point(47, 162);
            BrushHeight.Maximum = 50;
            BrushHeight.Minimum = 5;
            BrushHeight.Name = "BrushHeight";
            BrushHeight.Size = new Size(185, 45);
            BrushHeight.TabIndex = 3;
            BrushHeight.Value = 25;
            BrushHeight.Scroll += BrushWidth_Scroll;
            // 
            // BrushWidth
            // 
            BrushWidth.Location = new Point(47, 111);
            BrushWidth.Maximum = 50;
            BrushWidth.Minimum = 5;
            BrushWidth.Name = "BrushWidth";
            BrushWidth.Size = new Size(185, 45);
            BrushWidth.TabIndex = 4;
            BrushWidth.Value = 25;
            BrushWidth.Scroll += BrushWidth_Scroll;
            // 
            // CanvasOptionsTab
            // 
            CanvasOptionsTab.Controls.Add(RenameFilePanel);
            CanvasOptionsTab.Controls.Add(label1);
            CanvasOptionsTab.Controls.Add(LoadPreviousButton);
            CanvasOptionsTab.Controls.Add(clearCanvasButton);
            CanvasOptionsTab.Controls.Add(SaveButton);
            CanvasOptionsTab.Location = new Point(4, 24);
            CanvasOptionsTab.Name = "CanvasOptionsTab";
            CanvasOptionsTab.Padding = new Padding(3);
            CanvasOptionsTab.Size = new Size(270, 310);
            CanvasOptionsTab.TabIndex = 2;
            CanvasOptionsTab.Text = "Canvas Options";
            CanvasOptionsTab.UseVisualStyleBackColor = true;
            // 
            // RenameFilePanel
            // 
            RenameFilePanel.BackColor = Color.Transparent;
            RenameFilePanel.Controls.Add(SaveConfirmButton);
            RenameFilePanel.Controls.Add(FileNameLabel);
            RenameFilePanel.Controls.Add(textBox1);
            RenameFilePanel.Location = new Point(39, 150);
            RenameFilePanel.Name = "RenameFilePanel";
            RenameFilePanel.Size = new Size(200, 100);
            RenameFilePanel.TabIndex = 7;
            RenameFilePanel.Visible = false;
            // 
            // SaveConfirmButton
            // 
            SaveConfirmButton.Location = new Point(54, 69);
            SaveConfirmButton.Name = "SaveConfirmButton";
            SaveConfirmButton.Size = new Size(75, 23);
            SaveConfirmButton.TabIndex = 2;
            SaveConfirmButton.Text = "Confirm";
            SaveConfirmButton.UseVisualStyleBackColor = true;
            SaveConfirmButton.Click += SaveConfirmButton_Click;
            // 
            // FileNameLabel
            // 
            FileNameLabel.AutoSize = true;
            FileNameLabel.Location = new Point(52, 22);
            FileNameLabel.Name = "FileNameLabel";
            FileNameLabel.Size = new Size(60, 15);
            FileNameLabel.TabIndex = 1;
            FileNameLabel.Text = "File Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(52, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 169);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 6;
            label1.Text = "Load Previous Saved";
            // 
            // LoadPreviousButton
            // 
            LoadPreviousButton.Location = new Point(97, 187);
            LoadPreviousButton.Name = "LoadPreviousButton";
            LoadPreviousButton.Size = new Size(75, 23);
            LoadPreviousButton.TabIndex = 5;
            LoadPreviousButton.Text = "Prev. Saved";
            LoadPreviousButton.UseVisualStyleBackColor = true;
            LoadPreviousButton.Click += LoadPreviousButton_Click;
            // 
            // clearCanvasButton
            // 
            clearCanvasButton.Location = new Point(97, 74);
            clearCanvasButton.Name = "clearCanvasButton";
            clearCanvasButton.Size = new Size(75, 23);
            clearCanvasButton.TabIndex = 3;
            clearCanvasButton.Text = "Clear";
            clearCanvasButton.UseVisualStyleBackColor = true;
            clearCanvasButton.Click += clearCanvasButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(97, 121);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // display
            // 
            display.Controls.Add(sendToMatrix);
            display.Controls.Add(heightLabel);
            display.Controls.Add(widthLabel);
            display.Controls.Add(heightEntered);
            display.Controls.Add(widthEntered);
            display.Controls.Add(ledDisplay);
            display.Controls.Add(scaleDown);
            display.Location = new Point(4, 24);
            display.Name = "display";
            display.Padding = new Padding(3);
            display.Size = new Size(270, 310);
            display.TabIndex = 3;
            display.Text = "Display";
            display.UseVisualStyleBackColor = true;
            // 
            // sendToMatrix
            // 
            sendToMatrix.Location = new Point(98, 284);
            sendToMatrix.Name = "sendToMatrix";
            sendToMatrix.Size = new Size(75, 23);
            sendToMatrix.TabIndex = 6;
            sendToMatrix.Text = "Send";
            sendToMatrix.UseVisualStyleBackColor = true;
            sendToMatrix.Click += sendToMatrix_Click;
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.Location = new Point(79, 40);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(46, 15);
            heightLabel.TabIndex = 5;
            heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            widthLabel.AutoSize = true;
            widthLabel.Location = new Point(79, 9);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new Size(42, 15);
            widthLabel.TabIndex = 4;
            widthLabel.Text = "Width:";
            // 
            // heightEntered
            // 
            heightEntered.Location = new Point(157, 37);
            heightEntered.Name = "heightEntered";
            heightEntered.Size = new Size(36, 23);
            heightEntered.TabIndex = 3;
            // 
            // widthEntered
            // 
            widthEntered.Location = new Point(157, 6);
            widthEntered.Name = "widthEntered";
            widthEntered.Size = new Size(36, 23);
            widthEntered.TabIndex = 2;
            // 
            // ledDisplay
            // 
            ledDisplay.Location = new Point(44, 95);
            ledDisplay.Name = "ledDisplay";
            ledDisplay.Size = new Size(184, 186);
            ledDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            ledDisplay.TabIndex = 1;
            ledDisplay.TabStop = false;
            // 
            // scaleDown
            // 
            scaleDown.Location = new Point(79, 66);
            scaleDown.Name = "scaleDown";
            scaleDown.Size = new Size(114, 23);
            scaleDown.TabIndex = 0;
            scaleDown.Text = "Scale down";
            scaleDown.UseVisualStyleBackColor = true;
            scaleDown.Click += scaleDown_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(testPictureBox);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(270, 310);
            tabPage1.TabIndex = 4;
            tabPage1.Text = "Test";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // testPictureBox
            // 
            testPictureBox.Location = new Point(53, 65);
            testPictureBox.Name = "testPictureBox";
            testPictureBox.Size = new Size(175, 175);
            testPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            testPictureBox.TabIndex = 0;
            testPictureBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "png";
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // sendProgressBar
            // 
            sendProgressBar.Location = new Point(486, 401);
            sendProgressBar.Name = "sendProgressBar";
            sendProgressBar.Size = new Size(270, 23);
            sendProgressBar.TabIndex = 3;
            // 
            // animateOptions
            // 
            animateOptions.Location = new Point(833, 90);
            animateOptions.Name = "animateOptions";
            animateOptions.Size = new Size(75, 23);
            animateOptions.TabIndex = 4;
            animateOptions.Text = "Animation";
            animateOptions.UseVisualStyleBackColor = true;
            //animateOptions.Click += animateOptions_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(789, 119);
            panel1.Name = "panel1";
            panel1.Size = new Size(172, 292);
            panel1.TabIndex = 5;
            // 
            // ElliPaintForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1085, 466);
            Controls.Add(panel1);
            Controls.Add(animateOptions);
            Controls.Add(sendProgressBar);
            Controls.Add(BrushOptionsTabs);
            Controls.Add(Canvas);
            Name = "ElliPaintForm";
            Text = "Elli Paint";
            Load += ElliPaintForm_Load;
            ((System.ComponentModel.ISupportInitialize)Canvas).EndInit();
            BrushOptionsTabs.ResumeLayout(false);
            BrushTypeTab.ResumeLayout(false);
            BrushTypeTab.PerformLayout();
            BrushSizeTab.ResumeLayout(false);
            BrushSizeTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BrushHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)BrushWidth).EndInit();
            CanvasOptionsTab.ResumeLayout(false);
            CanvasOptionsTab.PerformLayout();
            RenameFilePanel.ResumeLayout(false);
            RenameFilePanel.PerformLayout();
            display.ResumeLayout(false);
            display.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ledDisplay).EndInit();
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)testPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Canvas;
        private TabControl BrushOptionsTabs;
        private TabPage BrushTypeTab;
        private TabPage BrushSizeTab;
        private Button SquareBrush;
        private Button CircleBrush;
        private Button TriangleBrush;
        private TrackBar BrushHeight;
        private TrackBar BrushWidth;
        private Label BrushWidthLabel;
        private Label BrushHeightLabel;
        private CheckBox ScrollSizeButton;
        private ColorDialog colorDialog1;
        private Button colorButton;
        private Button clearCanvasButton;
        private Button SaveButton;
        private Button LoadPreviousButton;
        private TabPage CanvasOptionsTab;
        private Label label1;
        private Panel RenameFilePanel;
        private Label FileNameLabel;
        private TextBox textBox1;
        private Button SaveConfirmButton;
        private OpenFileDialog openFileDialog1;
        private ComboBox comboBox1;
        private Button makeCustomButton;
        private Label label2;
        private Button EraserBrush;
        private TabPage display;
        private Button scaleDown;
        private PictureBox ledDisplay;
        private Label heightLabel;
        private Label widthLabel;
        private TextBox heightEntered;
        private TextBox widthEntered;
        private Button sendToMatrix;
        private TabPage tabPage1;
        private PictureBox testPictureBox;
        private ProgressBar sendProgressBar;
        private Button animateOptions;
        private Panel panel1;
    }
}
