namespace _23330159
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
            button1_SignIn = new Button();
            label1 = new Label();
            button2_SignUp = new Button();
            label2 = new Label();
            userNameBox = new TextBox();
            PassWordBox = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1_SignIn
            // 
            button1_SignIn.BackColor = Color.Pink;
            button1_SignIn.ImageAlign = ContentAlignment.BottomRight;
            button1_SignIn.Location = new Point(404, 413);
            button1_SignIn.Margin = new Padding(4, 4, 4, 4);
            button1_SignIn.Name = "button1_SignIn";
            button1_SignIn.Size = new Size(115, 35);
            button1_SignIn.TabIndex = 0;
            button1_SignIn.Text = "登录";
            button1_SignIn.UseVisualStyleBackColor = false;
            button1_SignIn.Click += btn_signIn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft YaHei UI", 15F);
            label1.Location = new Point(252, 229);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 39);
            label1.TabIndex = 2;
            label1.Text = "用户名";
            label1.Click += label1_Click;
            // 
            // button2_SignUp
            // 
            button2_SignUp.BackColor = Color.Pink;
            button2_SignUp.Location = new Point(602, 413);
            button2_SignUp.Margin = new Padding(4, 4, 4, 4);
            button2_SignUp.Name = "button2_SignUp";
            button2_SignUp.Size = new Size(115, 35);
            button2_SignUp.TabIndex = 0;
            button2_SignUp.Text = "注册";
            button2_SignUp.UseVisualStyleBackColor = false;
            button2_SignUp.Click += btn_signUp_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft YaHei UI", 15F);
            label2.Location = new Point(268, 317);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(77, 39);
            label2.TabIndex = 2;
            label2.Text = "密码";
            label2.Click += label1_Click;
            // 
            // userNameBox
            // 
            userNameBox.BackColor = Color.MistyRose;
            userNameBox.Location = new Point(367, 229);
            userNameBox.Margin = new Padding(4, 4, 4, 4);
            userNameBox.Name = "userNameBox";
            userNameBox.Size = new Size(448, 30);
            userNameBox.TabIndex = 3;
            // 
            // PassWordBox
            // 
            PassWordBox.BackColor = Color.MistyRose;
            PassWordBox.Location = new Point(367, 317);
            PassWordBox.Margin = new Padding(4, 4, 4, 4);
            PassWordBox.Name = "PassWordBox";
            PassWordBox.Size = new Size(448, 30);
            PassWordBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft YaHei UI", 25F);
            label3.ForeColor = Color.Purple;
            label3.Location = new Point(287, 99);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(505, 65);
            label3.TabIndex = 10;
            label3.Text = "Nyanners的奶茶小铺";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources._1680e13cb39a9bb5a74655a28553d023;
            ClientSize = new Size(875, 550);
            Controls.Add(label3);
            Controls.Add(PassWordBox);
            Controls.Add(userNameBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2_SignUp);
            Controls.Add(button1_SignIn);
            Font = new Font("Microsoft YaHei UI", 9F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1_SignIn;
        private Label label1;
        private Button button2_SignUp;
        private Label label2;
        private TextBox userNameBox;
        private TextBox PassWordBox;
        private Label label3;
    }
}
