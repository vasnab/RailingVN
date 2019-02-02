namespace RailingVN
{
    partial class RailingUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPickRailingPoints = new System.Windows.Forms.Button();
            this.lblMaxStep = new System.Windows.Forms.Label();
            this.lblStartOffset = new System.Windows.Forms.Label();
            this.lblEndOffset = new System.Windows.Forms.Label();
            this.lblOverrideStep = new System.Windows.Forms.Label();
            this.groupDividingOptions = new System.Windows.Forms.GroupBox();
            this.rbAllOverride = new System.Windows.Forms.RadioButton();
            this.rbAllEqual = new System.Windows.Forms.RadioButton();
            this.groupLeftoverOptions = new System.Windows.Forms.GroupBox();
            this.rbBothSteps = new System.Windows.Forms.RadioButton();
            this.rbLastStep = new System.Windows.Forms.RadioButton();
            this.rbFirstStep = new System.Windows.Forms.RadioButton();
            this.rbBothOffsets = new System.Windows.Forms.RadioButton();
            this.rbEndOffset = new System.Windows.Forms.RadioButton();
            this.rbStartOffset = new System.Windows.Forms.RadioButton();
            this.groupStepRoundingOptions = new System.Windows.Forms.GroupBox();
            this.rbToBaseOfTen = new System.Windows.Forms.RadioButton();
            this.rbToBaseOfFive = new System.Windows.Forms.RadioButton();
            this.rbClosestInteger = new System.Windows.Forms.RadioButton();
            this.rbNoRounding = new System.Windows.Forms.RadioButton();
            this.nudMaxStep = new System.Windows.Forms.NumericUpDown();
            this.nudOverrideStep = new System.Windows.Forms.NumericUpDown();
            this.nudStartOffset = new System.Windows.Forms.NumericUpDown();
            this.nudEndOffset = new System.Windows.Forms.NumericUpDown();
            this.groupDividingOptions.SuspendLayout();
            this.groupLeftoverOptions.SuspendLayout();
            this.groupStepRoundingOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverrideStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPickRailingPoints
            // 
            this.btnPickRailingPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPickRailingPoints.Location = new System.Drawing.Point(12, 392);
            this.btnPickRailingPoints.Name = "btnPickRailingPoints";
            this.btnPickRailingPoints.Size = new System.Drawing.Size(121, 22);
            this.btnPickRailingPoints.TabIndex = 0;
            this.btnPickRailingPoints.Text = "Pick Railing Points";
            this.btnPickRailingPoints.UseVisualStyleBackColor = true;
            this.btnPickRailingPoints.Click += new System.EventHandler(this.btnPickRailingPoints_Click);
            // 
            // lblMaxStep
            // 
            this.lblMaxStep.AutoSize = true;
            this.lblMaxStep.Location = new System.Drawing.Point(40, 36);
            this.lblMaxStep.Name = "lblMaxStep";
            this.lblMaxStep.Size = new System.Drawing.Size(52, 13);
            this.lblMaxStep.TabIndex = 1;
            this.lblMaxStep.Text = "Max Step";
            this.lblMaxStep.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblStartOffset
            // 
            this.lblStartOffset.AutoSize = true;
            this.lblStartOffset.Location = new System.Drawing.Point(34, 106);
            this.lblStartOffset.Name = "lblStartOffset";
            this.lblStartOffset.Size = new System.Drawing.Size(60, 13);
            this.lblStartOffset.TabIndex = 3;
            this.lblStartOffset.Text = "Start Offset";
            // 
            // lblEndOffset
            // 
            this.lblEndOffset.AutoSize = true;
            this.lblEndOffset.Location = new System.Drawing.Point(34, 132);
            this.lblEndOffset.Name = "lblEndOffset";
            this.lblEndOffset.Size = new System.Drawing.Size(57, 13);
            this.lblEndOffset.TabIndex = 5;
            this.lblEndOffset.Text = "End Offset";
            // 
            // lblOverrideStep
            // 
            this.lblOverrideStep.AutoSize = true;
            this.lblOverrideStep.Location = new System.Drawing.Point(20, 69);
            this.lblOverrideStep.Name = "lblOverrideStep";
            this.lblOverrideStep.Size = new System.Drawing.Size(72, 13);
            this.lblOverrideStep.TabIndex = 7;
            this.lblOverrideStep.Text = "Override Step";
            this.lblOverrideStep.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupDividingOptions
            // 
            this.groupDividingOptions.Controls.Add(this.rbAllOverride);
            this.groupDividingOptions.Controls.Add(this.rbAllEqual);
            this.groupDividingOptions.Location = new System.Drawing.Point(37, 197);
            this.groupDividingOptions.Name = "groupDividingOptions";
            this.groupDividingOptions.Size = new System.Drawing.Size(126, 86);
            this.groupDividingOptions.TabIndex = 5;
            this.groupDividingOptions.TabStop = false;
            this.groupDividingOptions.Text = "Dividing Options";
            this.groupDividingOptions.Enter += new System.EventHandler(this.groupDividingOptions_Enter);
            // 
            // rbAllOverride
            // 
            this.rbAllOverride.AutoSize = true;
            this.rbAllOverride.Location = new System.Drawing.Point(6, 51);
            this.rbAllOverride.Name = "rbAllOverride";
            this.rbAllOverride.Size = new System.Drawing.Size(79, 17);
            this.rbAllOverride.TabIndex = 7;
            this.rbAllOverride.Text = "All Override";
            this.rbAllOverride.UseVisualStyleBackColor = true;
            this.rbAllOverride.CheckedChanged += new System.EventHandler(this.rbAllOverride_CheckedChanged);
            // 
            // rbAllEqual
            // 
            this.rbAllEqual.AutoSize = true;
            this.rbAllEqual.Checked = true;
            this.rbAllEqual.Location = new System.Drawing.Point(6, 28);
            this.rbAllEqual.Name = "rbAllEqual";
            this.rbAllEqual.Size = new System.Drawing.Size(66, 17);
            this.rbAllEqual.TabIndex = 6;
            this.rbAllEqual.TabStop = true;
            this.rbAllEqual.Text = "All Equal";
            this.rbAllEqual.UseVisualStyleBackColor = true;
            this.rbAllEqual.CheckedChanged += new System.EventHandler(this.rbAllEqual_CheckedChanged);
            // 
            // groupLeftoverOptions
            // 
            this.groupLeftoverOptions.Controls.Add(this.rbBothSteps);
            this.groupLeftoverOptions.Controls.Add(this.rbLastStep);
            this.groupLeftoverOptions.Controls.Add(this.rbFirstStep);
            this.groupLeftoverOptions.Controls.Add(this.rbBothOffsets);
            this.groupLeftoverOptions.Controls.Add(this.rbEndOffset);
            this.groupLeftoverOptions.Controls.Add(this.rbStartOffset);
            this.groupLeftoverOptions.Location = new System.Drawing.Point(353, 197);
            this.groupLeftoverOptions.Name = "groupLeftoverOptions";
            this.groupLeftoverOptions.Size = new System.Drawing.Size(102, 185);
            this.groupLeftoverOptions.TabIndex = 13;
            this.groupLeftoverOptions.TabStop = false;
            this.groupLeftoverOptions.Text = "Leftover Options";
            // 
            // rbBothSteps
            // 
            this.rbBothSteps.AutoSize = true;
            this.rbBothSteps.Location = new System.Drawing.Point(13, 150);
            this.rbBothSteps.Name = "rbBothSteps";
            this.rbBothSteps.Size = new System.Drawing.Size(77, 17);
            this.rbBothSteps.TabIndex = 19;
            this.rbBothSteps.Text = "Both Steps";
            this.rbBothSteps.UseVisualStyleBackColor = true;
            // 
            // rbLastStep
            // 
            this.rbLastStep.AutoSize = true;
            this.rbLastStep.Location = new System.Drawing.Point(12, 127);
            this.rbLastStep.Name = "rbLastStep";
            this.rbLastStep.Size = new System.Drawing.Size(70, 17);
            this.rbLastStep.TabIndex = 18;
            this.rbLastStep.Text = "Last Step";
            this.rbLastStep.UseVisualStyleBackColor = true;
            // 
            // rbFirstStep
            // 
            this.rbFirstStep.AutoSize = true;
            this.rbFirstStep.Location = new System.Drawing.Point(13, 104);
            this.rbFirstStep.Name = "rbFirstStep";
            this.rbFirstStep.Size = new System.Drawing.Size(69, 17);
            this.rbFirstStep.TabIndex = 17;
            this.rbFirstStep.Text = "First Step";
            this.rbFirstStep.UseVisualStyleBackColor = true;
            // 
            // rbBothOffsets
            // 
            this.rbBothOffsets.AutoSize = true;
            this.rbBothOffsets.Checked = true;
            this.rbBothOffsets.Location = new System.Drawing.Point(13, 81);
            this.rbBothOffsets.Name = "rbBothOffsets";
            this.rbBothOffsets.Size = new System.Drawing.Size(83, 17);
            this.rbBothOffsets.TabIndex = 16;
            this.rbBothOffsets.TabStop = true;
            this.rbBothOffsets.Text = "Both Offsets";
            this.rbBothOffsets.UseVisualStyleBackColor = true;
            // 
            // rbEndOffset
            // 
            this.rbEndOffset.AutoSize = true;
            this.rbEndOffset.Location = new System.Drawing.Point(13, 56);
            this.rbEndOffset.Name = "rbEndOffset";
            this.rbEndOffset.Size = new System.Drawing.Size(75, 17);
            this.rbEndOffset.TabIndex = 15;
            this.rbEndOffset.Text = "End Offset";
            this.rbEndOffset.UseVisualStyleBackColor = true;
            // 
            // rbStartOffset
            // 
            this.rbStartOffset.AutoSize = true;
            this.rbStartOffset.Location = new System.Drawing.Point(13, 33);
            this.rbStartOffset.Name = "rbStartOffset";
            this.rbStartOffset.Size = new System.Drawing.Size(78, 17);
            this.rbStartOffset.TabIndex = 14;
            this.rbStartOffset.Text = "Start Offset";
            this.rbStartOffset.UseVisualStyleBackColor = true;
            this.rbStartOffset.CheckedChanged += new System.EventHandler(this.rbStartOffset_CheckedChanged);
            // 
            // groupStepRoundingOptions
            // 
            this.groupStepRoundingOptions.Controls.Add(this.rbToBaseOfTen);
            this.groupStepRoundingOptions.Controls.Add(this.rbToBaseOfFive);
            this.groupStepRoundingOptions.Controls.Add(this.rbClosestInteger);
            this.groupStepRoundingOptions.Controls.Add(this.rbNoRounding);
            this.groupStepRoundingOptions.Location = new System.Drawing.Point(196, 197);
            this.groupStepRoundingOptions.Name = "groupStepRoundingOptions";
            this.groupStepRoundingOptions.Size = new System.Drawing.Size(106, 143);
            this.groupStepRoundingOptions.TabIndex = 8;
            this.groupStepRoundingOptions.TabStop = false;
            this.groupStepRoundingOptions.Text = "Step Rounding Options";
            this.groupStepRoundingOptions.Enter += new System.EventHandler(this.groupStepRoundingOptions_Enter);
            // 
            // rbToBaseOfTen
            // 
            this.rbToBaseOfTen.AutoSize = true;
            this.rbToBaseOfTen.Location = new System.Drawing.Point(6, 106);
            this.rbToBaseOfTen.Name = "rbToBaseOfTen";
            this.rbToBaseOfTen.Size = new System.Drawing.Size(91, 17);
            this.rbToBaseOfTen.TabIndex = 12;
            this.rbToBaseOfTen.Text = "To base of 10";
            this.rbToBaseOfTen.UseVisualStyleBackColor = true;
            // 
            // rbToBaseOfFive
            // 
            this.rbToBaseOfFive.AutoSize = true;
            this.rbToBaseOfFive.Location = new System.Drawing.Point(6, 83);
            this.rbToBaseOfFive.Name = "rbToBaseOfFive";
            this.rbToBaseOfFive.Size = new System.Drawing.Size(85, 17);
            this.rbToBaseOfFive.TabIndex = 11;
            this.rbToBaseOfFive.Text = "To base of 5";
            this.rbToBaseOfFive.UseVisualStyleBackColor = true;
            // 
            // rbClosestInteger
            // 
            this.rbClosestInteger.AutoSize = true;
            this.rbClosestInteger.Location = new System.Drawing.Point(6, 60);
            this.rbClosestInteger.Name = "rbClosestInteger";
            this.rbClosestInteger.Size = new System.Drawing.Size(94, 17);
            this.rbClosestInteger.TabIndex = 10;
            this.rbClosestInteger.Text = "Closest integer";
            this.rbClosestInteger.UseVisualStyleBackColor = true;
            this.rbClosestInteger.CheckedChanged += new System.EventHandler(this.rbClosestInteger_CheckedChanged);
            // 
            // rbNoRounding
            // 
            this.rbNoRounding.AutoSize = true;
            this.rbNoRounding.Checked = true;
            this.rbNoRounding.Location = new System.Drawing.Point(6, 37);
            this.rbNoRounding.Name = "rbNoRounding";
            this.rbNoRounding.Size = new System.Drawing.Size(83, 17);
            this.rbNoRounding.TabIndex = 9;
            this.rbNoRounding.TabStop = true;
            this.rbNoRounding.Text = "No rounding";
            this.rbNoRounding.UseVisualStyleBackColor = true;
            this.rbNoRounding.CheckedChanged += new System.EventHandler(this.rbNoRounding_CheckedChanged);
            // 
            // nudMaxStep
            // 
            this.nudMaxStep.Location = new System.Drawing.Point(98, 34);
            this.nudMaxStep.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxStep.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMaxStep.Name = "nudMaxStep";
            this.nudMaxStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudMaxStep.Size = new System.Drawing.Size(75, 20);
            this.nudMaxStep.TabIndex = 1;
            this.nudMaxStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMaxStep.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudMaxStep.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.nudMaxStep.ValueChanged += new System.EventHandler(this.nudMaxStep_ValueChanged);
            // 
            // nudOverrideStep
            // 
            this.nudOverrideStep.Location = new System.Drawing.Point(100, 66);
            this.nudOverrideStep.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudOverrideStep.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudOverrideStep.Name = "nudOverrideStep";
            this.nudOverrideStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudOverrideStep.Size = new System.Drawing.Size(75, 20);
            this.nudOverrideStep.TabIndex = 2;
            this.nudOverrideStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudOverrideStep.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudOverrideStep.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudOverrideStep.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // nudStartOffset
            // 
            this.nudStartOffset.Location = new System.Drawing.Point(100, 104);
            this.nudStartOffset.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudStartOffset.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudStartOffset.Name = "nudStartOffset";
            this.nudStartOffset.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudStartOffset.Size = new System.Drawing.Size(75, 20);
            this.nudStartOffset.TabIndex = 3;
            this.nudStartOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudStartOffset.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudStartOffset.Value = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudStartOffset.ValueChanged += new System.EventHandler(this.nudStartOffset_ValueChanged);
            // 
            // nudEndOffset
            // 
            this.nudEndOffset.Location = new System.Drawing.Point(100, 130);
            this.nudEndOffset.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudEndOffset.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.nudEndOffset.Name = "nudEndOffset";
            this.nudEndOffset.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudEndOffset.Size = new System.Drawing.Size(75, 20);
            this.nudEndOffset.TabIndex = 4;
            this.nudEndOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudEndOffset.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nudEndOffset.Value = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudEndOffset.ValueChanged += new System.EventHandler(this.nudEndOffset_ValueChanged);
            // 
            // RailingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(507, 426);
            this.Controls.Add(this.nudEndOffset);
            this.Controls.Add(this.nudStartOffset);
            this.Controls.Add(this.nudOverrideStep);
            this.Controls.Add(this.nudMaxStep);
            this.Controls.Add(this.groupStepRoundingOptions);
            this.Controls.Add(this.groupLeftoverOptions);
            this.Controls.Add(this.groupDividingOptions);
            this.Controls.Add(this.lblOverrideStep);
            this.Controls.Add(this.lblEndOffset);
            this.Controls.Add(this.lblStartOffset);
            this.Controls.Add(this.lblMaxStep);
            this.Controls.Add(this.btnPickRailingPoints);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RailingUI";
            this.Text = "RailingVN";
            this.Load += new System.EventHandler(this.RailingUIForm_Load);
            this.groupDividingOptions.ResumeLayout(false);
            this.groupDividingOptions.PerformLayout();
            this.groupLeftoverOptions.ResumeLayout(false);
            this.groupLeftoverOptions.PerformLayout();
            this.groupStepRoundingOptions.ResumeLayout(false);
            this.groupStepRoundingOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOverrideStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPickRailingPoints;
        private System.Windows.Forms.Label lblMaxStep;
        private System.Windows.Forms.Label lblStartOffset;
        private System.Windows.Forms.Label lblEndOffset;
        private System.Windows.Forms.Label lblOverrideStep;
        private System.Windows.Forms.GroupBox groupDividingOptions;
        private System.Windows.Forms.RadioButton rbAllOverride;
        private System.Windows.Forms.RadioButton rbAllEqual;
        private System.Windows.Forms.GroupBox groupStepRoundingOptions;
        private System.Windows.Forms.RadioButton rbBothSteps;
        private System.Windows.Forms.RadioButton rbLastStep;
        private System.Windows.Forms.RadioButton rbFirstStep;
        private System.Windows.Forms.RadioButton rbBothOffsets;
        private System.Windows.Forms.RadioButton rbEndOffset;
        private System.Windows.Forms.RadioButton rbStartOffset;
        private System.Windows.Forms.RadioButton rbToBaseOfTen;
        private System.Windows.Forms.RadioButton rbToBaseOfFive;
        private System.Windows.Forms.RadioButton rbClosestInteger;
        private System.Windows.Forms.RadioButton rbNoRounding;
        private System.Windows.Forms.NumericUpDown nudMaxStep;
        private System.Windows.Forms.NumericUpDown nudOverrideStep;
        private System.Windows.Forms.NumericUpDown nudStartOffset;
        private System.Windows.Forms.NumericUpDown nudEndOffset;
        private System.Windows.Forms.GroupBox groupLeftoverOptions;
    }
}

