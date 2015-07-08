namespace SupplyChainManagementUI
{
    partial class InputXmlForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.xmlText = new System.Windows.Forms.RichTextBox();
            this.loadXmlFileButton = new System.Windows.Forms.Button();
            this.firstPeriodCheckbox = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(494, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Weiter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Paste Input XML";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // xmlText
            // 
            this.xmlText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlText.Enabled = false;
            this.xmlText.Location = new System.Drawing.Point(12, 73);
            this.xmlText.Name = "xmlText";
            this.xmlText.Size = new System.Drawing.Size(557, 268);
            this.xmlText.TabIndex = 16;
            this.xmlText.Text = "";
            // 
            // loadXmlFileButton
            // 
            this.loadXmlFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadXmlFileButton.Enabled = false;
            this.loadXmlFileButton.Location = new System.Drawing.Point(380, 347);
            this.loadXmlFileButton.Name = "loadXmlFileButton";
            this.loadXmlFileButton.Size = new System.Drawing.Size(108, 23);
            this.loadXmlFileButton.TabIndex = 17;
            this.loadXmlFileButton.Text = "Open XML file";
            this.loadXmlFileButton.UseVisualStyleBackColor = true;
            this.loadXmlFileButton.Click += new System.EventHandler(this.loadXmlFileButton_Click);
            // 
            // firstPeriodCheckbox
            // 
            this.firstPeriodCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.firstPeriodCheckbox.AutoSize = true;
            this.firstPeriodCheckbox.Checked = true;
            this.firstPeriodCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.firstPeriodCheckbox.Location = new System.Drawing.Point(294, 351);
            this.firstPeriodCheckbox.Name = "firstPeriodCheckbox";
            this.firstPeriodCheckbox.Size = new System.Drawing.Size(78, 17);
            this.firstPeriodCheckbox.TabIndex = 18;
            this.firstPeriodCheckbox.Text = "First Period";
            this.firstPeriodCheckbox.UseVisualStyleBackColor = true;
            this.firstPeriodCheckbox.CheckedChanged += new System.EventHandler(this.firstPeriodCheckbox_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "English",
            "Deutsch"});
            this.comboBox1.Location = new System.Drawing.Point(138, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Select Language";
            // 
            // InputXmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 382);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.firstPeriodCheckbox);
            this.Controls.Add(this.loadXmlFileButton);
            this.Controls.Add(this.xmlText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "InputXmlForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.InputXmlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox xmlText;
        private System.Windows.Forms.Button loadXmlFileButton;
        private System.Windows.Forms.CheckBox firstPeriodCheckbox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
    }
}