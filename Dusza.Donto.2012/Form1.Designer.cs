namespace Dusza.Donto._2012
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.postFixTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.converToPostfixBtn = new System.Windows.Forms.Button();
            this.infixTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.evaluateBtn = new System.Windows.Forms.Button();
            this.processBtn = new System.Windows.Forms.Button();
            this.postFixInputTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.aValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.operatorTextBox = new System.Windows.Forms.TextBox();
            this.expectedResultTextBox = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchResultTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(596, 300);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.postFixTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.converToPostfixBtn);
            this.tabPage1.Controls.Add(this.infixTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(588, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Infix kifejezés postfix formára hozása";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // postFixTextBox
            // 
            this.postFixTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.postFixTextBox.Location = new System.Drawing.Point(106, 68);
            this.postFixTextBox.Name = "postFixTextBox";
            this.postFixTextBox.ReadOnly = true;
            this.postFixTextBox.Size = new System.Drawing.Size(476, 20);
            this.postFixTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Postfix kifejezés:";
            // 
            // converToPostfixBtn
            // 
            this.converToPostfixBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.converToPostfixBtn.Location = new System.Drawing.Point(442, 39);
            this.converToPostfixBtn.Name = "converToPostfixBtn";
            this.converToPostfixBtn.Size = new System.Drawing.Size(140, 23);
            this.converToPostfixBtn.TabIndex = 2;
            this.converToPostfixBtn.Text = "Postfix formára alakítás!";
            this.converToPostfixBtn.UseVisualStyleBackColor = true;
            this.converToPostfixBtn.Click += new System.EventHandler(this.converToPostfixBtn_Click);
            // 
            // infixTextBox
            // 
            this.infixTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infixTextBox.Location = new System.Drawing.Point(106, 13);
            this.infixTextBox.Name = "infixTextBox";
            this.infixTextBox.Size = new System.Drawing.Size(476, 20);
            this.infixTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Infix kifejezés:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.evaluateBtn);
            this.tabPage2.Controls.Add(this.processBtn);
            this.tabPage2.Controls.Add(this.postFixInputTextBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.resultTextBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cValue);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.bValue);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.aValue);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(588, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Postfix formula kiértékelése";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // evaluateBtn
            // 
            this.evaluateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.evaluateBtn.Enabled = false;
            this.evaluateBtn.Location = new System.Drawing.Point(442, 138);
            this.evaluateBtn.Name = "evaluateBtn";
            this.evaluateBtn.Size = new System.Drawing.Size(140, 23);
            this.evaluateBtn.TabIndex = 26;
            this.evaluateBtn.Text = "Kiértékel!";
            this.evaluateBtn.UseVisualStyleBackColor = true;
            this.evaluateBtn.Click += new System.EventHandler(this.evaluateBtn_Click);
            // 
            // processBtn
            // 
            this.processBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.processBtn.Location = new System.Drawing.Point(442, 32);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(140, 23);
            this.processBtn.TabIndex = 25;
            this.processBtn.Text = "Feldolgoz!";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // postFixInputTextBox
            // 
            this.postFixInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.postFixInputTextBox.Location = new System.Drawing.Point(106, 6);
            this.postFixInputTextBox.Name = "postFixInputTextBox";
            this.postFixInputTextBox.Size = new System.Drawing.Size(476, 20);
            this.postFixInputTextBox.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Postfix kifejezés:";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTextBox.Location = new System.Drawing.Point(106, 172);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(476, 20);
            this.resultTextBox.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Eredmény:";
            // 
            // cValue
            // 
            this.cValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cValue.Location = new System.Drawing.Point(106, 112);
            this.cValue.Name = "cValue";
            this.cValue.ReadOnly = true;
            this.cValue.Size = new System.Drawing.Size(476, 20);
            this.cValue.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "c =";
            // 
            // bValue
            // 
            this.bValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bValue.Location = new System.Drawing.Point(106, 86);
            this.bValue.Name = "bValue";
            this.bValue.ReadOnly = true;
            this.bValue.Size = new System.Drawing.Size(476, 20);
            this.bValue.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "b =";
            // 
            // aValue
            // 
            this.aValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aValue.Location = new System.Drawing.Point(106, 60);
            this.aValue.Name = "aValue";
            this.aValue.ReadOnly = true;
            this.aValue.Size = new System.Drawing.Size(476, 20);
            this.aValue.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "a =";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.searchResultTextBox);
            this.tabPage3.Controls.Add(this.searchBtn);
            this.tabPage3.Controls.Add(this.expectedResultTextBox);
            this.tabPage3.Controls.Add(this.operatorTextBox);
            this.tabPage3.Controls.Add(this.numberTextBox);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(588, 274);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Műveleti sorrend";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Számok:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Műveleti jelek:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Elvárt eredmény:";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberTextBox.Location = new System.Drawing.Point(99, 11);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(483, 20);
            this.numberTextBox.TabIndex = 3;
            // 
            // operatorTextBox
            // 
            this.operatorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operatorTextBox.Location = new System.Drawing.Point(99, 39);
            this.operatorTextBox.Name = "operatorTextBox";
            this.operatorTextBox.Size = new System.Drawing.Size(483, 20);
            this.operatorTextBox.TabIndex = 4;
            // 
            // expectedResultTextBox
            // 
            this.expectedResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expectedResultTextBox.Location = new System.Drawing.Point(99, 67);
            this.expectedResultTextBox.Name = "expectedResultTextBox";
            this.expectedResultTextBox.Size = new System.Drawing.Size(483, 20);
            this.expectedResultTextBox.TabIndex = 5;
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBtn.Location = new System.Drawing.Point(452, 93);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(130, 23);
            this.searchBtn.TabIndex = 6;
            this.searchBtn.Text = "Megoldás keresése!";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // searchResultTextBox
            // 
            this.searchResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResultTextBox.Location = new System.Drawing.Point(99, 126);
            this.searchResultTextBox.Name = "searchResultTextBox";
            this.searchResultTextBox.ReadOnly = true;
            this.searchResultTextBox.Size = new System.Drawing.Size(483, 20);
            this.searchResultTextBox.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Eredmény:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 324);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Dusza 2012 döntő";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox infixTextBox;
        private System.Windows.Forms.TextBox postFixTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button converToPostfixBtn;
        private System.Windows.Forms.TextBox postFixInputTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox bValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox aValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button evaluateBtn;
        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox expectedResultTextBox;
        private System.Windows.Forms.TextBox operatorTextBox;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox searchResultTextBox;
    }
}

