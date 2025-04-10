namespace Determ_con_comp_of_a_graph
{
    partial class Form1
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
            label = new Label();
            inputPanel = new Panel();
            textBox = new TextBox();
            errorLabel = new Label();
            btnLoad = new Button();
            btnSave = new Button();
            tablePanel = new FlowLayoutPanel();
            btnCalc = new Button();
            labelResult = new Label();
            messageLabel = new Label();
            inputPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.BackColor = SystemColors.Control;
            label.Location = new Point(25, 0);
            label.Name = "label";
            label.Size = new Size(166, 20);
            label.TabIndex = 1;
            label.Text = "Размерность матрицы";
            // 
            // inputPanel
            // 
            inputPanel.Controls.Add(textBox);
            inputPanel.Controls.Add(label);
            inputPanel.Location = new Point(36, 34);
            inputPanel.Name = "inputPanel";
            inputPanel.Size = new Size(214, 55);
            inputPanel.TabIndex = 2;
            // 
            // textBox
            // 
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Cursor = Cursors.IBeam;
            textBox.Location = new Point(7, 23);
            textBox.MaxLength = 2;
            textBox.Name = "textBox";
            textBox.Size = new Size(196, 27);
            textBox.TabIndex = 2;
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.TextChanged += textBox_TextChanged;
            // 
            // errorLabel
            // 
            errorLabel.AutoEllipsis = true;
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(268, 34);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 20);
            errorLabel.TabIndex = 3;
            // 
            // btnLoad
            // 
            btnLoad.Cursor = Cursors.Hand;
            btnLoad.Location = new Point(43, 223);
            btnLoad.Margin = new Padding(0);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(200, 29);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Загрузить";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Cursor = Cursors.Hand;
            btnSave.Location = new Point(43, 194);
            btnSave.Margin = new Padding(0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 29);
            btnSave.TabIndex = 6;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // tablePanel
            // 
            tablePanel.Location = new Point(268, 70);
            tablePanel.Margin = new Padding(0);
            tablePanel.Name = "tablePanel";
            tablePanel.Size = new Size(60, 60);
            tablePanel.TabIndex = 5;
            // 
            // btnCalc
            // 
            btnCalc.Cursor = Cursors.Hand;
            btnCalc.Location = new Point(43, 95);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new Size(200, 50);
            btnCalc.TabIndex = 4;
            btnCalc.Text = "Определить компонент связности графа";
            btnCalc.UseVisualStyleBackColor = true;
            btnCalc.Click += btnCalc_Click;
            // 
            // labelResult
            // 
            labelResult.BorderStyle = BorderStyle.FixedSingle;
            labelResult.Location = new Point(43, 148);
            labelResult.Margin = new Padding(0);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(200, 25);
            labelResult.TabIndex = 6;
            // 
            // messageLabel
            // 
            messageLabel.AutoEllipsis = true;
            messageLabel.BackColor = SystemColors.Control;
            messageLabel.ForeColor = Color.Lime;
            messageLabel.Location = new Point(43, 264);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(150, 40);
            messageLabel.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 502);
            Controls.Add(messageLabel);
            Controls.Add(errorLabel);
            Controls.Add(btnLoad);
            Controls.Add(labelResult);
            Controls.Add(btnCalc);
            Controls.Add(btnSave);
            Controls.Add(tablePanel);
            Controls.Add(inputPanel);
            Name = "Form1";
            Text = "Form1";
            inputPanel.ResumeLayout(false);
            inputPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label;
        private Panel inputPanel;
        private TextBox textBox;
        private Label errorLabel;
        private FlowLayoutPanel tablePanel;
        private Button btnCalc;
        private Button btnSave;
        private Button btnLoad;
        private Label labelResult;
        private Label messageLabel;
    }
}
