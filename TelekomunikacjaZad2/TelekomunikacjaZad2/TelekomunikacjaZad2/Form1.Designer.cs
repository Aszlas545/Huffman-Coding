using System.Net;
using System.Net.Sockets;

namespace TelekomunikacjaZad2
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
            components = new System.ComponentModel.Container();
            ReadButton = new Button();
            SendButton = new Button();
            DecodeButton = new Button();
            SaveButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ErrorComms = new TextBox();
            ComInfo = new TextBox();
            StringInfo = new TextBox();
            StringText = new RichTextBox();
            BitInfo = new TextBox();
            BitText = new RichTextBox();
            DicionaryText = new RichTextBox();
            DictionaryInfo = new TextBox();
            CodeButton = new Button();
            RecieveButton = new Button();
            SenderIP = new TextBox();
            RecieverIP = new TextBox();
            IPAddr1 = new TextBox();
            IPAddr2 = new TextBox();
            Port1 = new TextBox();
            Port2 = new TextBox();
            RecieveTreeButton = new Button();
            SendTreeButton = new Button();
            SuspendLayout();
            // 
            // ReadButton
            // 
            ReadButton.BackColor = SystemColors.ActiveCaption;
            ReadButton.Location = new Point(12, 12);
            ReadButton.Name = "ReadButton";
            ReadButton.Size = new Size(210, 134);
            ReadButton.TabIndex = 1;
            ReadButton.Text = "Wczytaj plik";
            ReadButton.UseVisualStyleBackColor = false;
            ReadButton.Click += ReadButton_Click;
            // 
            // SendButton
            // 
            SendButton.BackColor = SystemColors.ActiveCaption;
            SendButton.Location = new Point(444, 12);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(210, 134);
            SendButton.TabIndex = 2;
            SendButton.Text = "Wyślij plik";
            SendButton.UseVisualStyleBackColor = false;
            SendButton.Click += SendButton_Click;
            // 
            // DecodeButton
            // 
            DecodeButton.BackColor = SystemColors.ActiveCaption;
            DecodeButton.Location = new Point(977, 12);
            DecodeButton.Name = "DecodeButton";
            DecodeButton.Size = new Size(210, 134);
            DecodeButton.TabIndex = 3;
            DecodeButton.Text = "Odkoduj plik";
            DecodeButton.UseVisualStyleBackColor = false;
            DecodeButton.Click += DecodeButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = SystemColors.ActiveCaption;
            SaveButton.Location = new Point(1193, 12);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(210, 134);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Zapisz plik";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // ErrorComms
            // 
            ErrorComms.BackColor = SystemColors.ButtonHighlight;
            ErrorComms.Location = new Point(12, 238);
            ErrorComms.Name = "ErrorComms";
            ErrorComms.ReadOnly = true;
            ErrorComms.Size = new Size(1403, 23);
            ErrorComms.TabIndex = 6;
            // 
            // ComInfo
            // 
            ComInfo.BackColor = Color.MediumTurquoise;
            ComInfo.Location = new Point(12, 209);
            ComInfo.Name = "ComInfo";
            ComInfo.ReadOnly = true;
            ComInfo.Size = new Size(80, 23);
            ComInfo.TabIndex = 1;
            ComInfo.Text = "Komunikaty:";
            // 
            // StringInfo
            // 
            StringInfo.BackColor = Color.MediumTurquoise;
            StringInfo.Location = new Point(12, 267);
            StringInfo.Name = "StringInfo";
            StringInfo.ReadOnly = true;
            StringInfo.Size = new Size(91, 23);
            StringInfo.TabIndex = 7;
            StringInfo.Text = "Text jako string:";
            // 
            // StringText
            // 
            StringText.BackColor = SystemColors.ButtonHighlight;
            StringText.Location = new Point(12, 296);
            StringText.Name = "StringText";
            StringText.ReadOnly = true;
            StringText.Size = new Size(426, 541);
            StringText.TabIndex = 8;
            StringText.Text = "";
            // 
            // BitInfo
            // 
            BitInfo.BackColor = Color.MediumTurquoise;
            BitInfo.Location = new Point(493, 267);
            BitInfo.Name = "BitInfo";
            BitInfo.ReadOnly = true;
            BitInfo.Size = new Size(82, 23);
            BitInfo.TabIndex = 9;
            BitInfo.Text = "Text binarnie:";
            // 
            // BitText
            // 
            BitText.BackColor = SystemColors.ButtonHighlight;
            BitText.Location = new Point(493, 296);
            BitText.Name = "BitText";
            BitText.ReadOnly = true;
            BitText.Size = new Size(426, 541);
            BitText.TabIndex = 10;
            BitText.Text = "";
            // 
            // DicionaryText
            // 
            DicionaryText.BackColor = SystemColors.ButtonHighlight;
            DicionaryText.Location = new Point(977, 296);
            DicionaryText.Name = "DicionaryText";
            DicionaryText.ReadOnly = true;
            DicionaryText.Size = new Size(426, 541);
            DicionaryText.TabIndex = 11;
            DicionaryText.Text = "";
            // 
            // DictionaryInfo
            // 
            DictionaryInfo.BackColor = Color.MediumTurquoise;
            DictionaryInfo.Location = new Point(977, 267);
            DictionaryInfo.Name = "DictionaryInfo";
            DictionaryInfo.ReadOnly = true;
            DictionaryInfo.Size = new Size(101, 23);
            DictionaryInfo.TabIndex = 12;
            DictionaryInfo.Text = "Słownik kodowy:";
            // 
            // CodeButton
            // 
            CodeButton.BackColor = SystemColors.ActiveCaption;
            CodeButton.Location = new Point(228, 12);
            CodeButton.Name = "CodeButton";
            CodeButton.Size = new Size(210, 134);
            CodeButton.TabIndex = 13;
            CodeButton.Text = "Zakoduj plik";
            CodeButton.UseVisualStyleBackColor = false;
            CodeButton.Click += CodeButton_Click;
            // 
            // RecieveButton
            // 
            RecieveButton.BackColor = SystemColors.ActiveCaption;
            RecieveButton.Location = new Point(761, 12);
            RecieveButton.Name = "RecieveButton";
            RecieveButton.Size = new Size(210, 134);
            RecieveButton.TabIndex = 14;
            RecieveButton.Text = "Odbierz plik";
            RecieveButton.UseVisualStyleBackColor = false;
            RecieveButton.Click += RecieveButtonClick;
            // 
            // SenderIP
            // 
            SenderIP.BackColor = Color.MediumTurquoise;
            SenderIP.Location = new Point(444, 152);
            SenderIP.Name = "SenderIP";
            SenderIP.ReadOnly = true;
            SenderIP.Size = new Size(210, 23);
            SenderIP.TabIndex = 15;
            SenderIP.Text = "Podaj IP odbiorcy i nr portu:";
            // 
            // RecieverIP
            // 
            RecieverIP.BackColor = Color.MediumTurquoise;
            RecieverIP.Location = new Point(761, 152);
            RecieverIP.Name = "RecieverIP";
            RecieverIP.ReadOnly = true;
            RecieverIP.Size = new Size(210, 23);
            RecieverIP.TabIndex = 16;
            RecieverIP.Text = "IP odbiorcy i nr portu:";
            // 
            // IPAddr1
            // 
            IPAddr1.BackColor = Color.Yellow;
            IPAddr1.Location = new Point(444, 181);
            IPAddr1.Name = "IPAddr1";
            IPAddr1.Size = new Size(210, 23);
            IPAddr1.TabIndex = 17;
            IPAddr1.Text = "ip";
            // 
            // IPAddr2
            // 
            IPAddr2.BackColor = SystemColors.ButtonHighlight;
            IPAddr2.Location = new Point(761, 181);
            IPAddr2.Name = "IPAddr2";
            IPAddr2.ReadOnly = true;
            IPAddr2.Size = new Size(210, 23);
            IPAddr2.TabIndex = 18;
            // 
            // Port1
            // 
            Port1.BackColor = Color.Yellow;
            Port1.Location = new Point(444, 210);
            Port1.Name = "Port1";
            Port1.Size = new Size(210, 23);
            Port1.TabIndex = 19;
            Port1.Text = "port";
            // 
            // Port2
            // 
            Port2.BackColor = SystemColors.ButtonHighlight;
            Port2.Location = new Point(761, 209);
            Port2.Name = "Port2";
            Port2.Size = new Size(210, 23);
            Port2.TabIndex = 20;
            // 
            // RecieveTreeButton
            // 
            RecieveTreeButton.BackColor = SystemColors.ActiveCaption;
            RecieveTreeButton.Location = new Point(977, 152);
            RecieveTreeButton.Name = "RecieveTreeButton";
            RecieveTreeButton.Size = new Size(210, 80);
            RecieveTreeButton.TabIndex = 22;
            RecieveTreeButton.Text = "Odbierz drzewo";
            RecieveTreeButton.UseVisualStyleBackColor = false;
            RecieveTreeButton.Click += RecieveTreeButton_Click;
            // 
            // SendTreeButton
            // 
            SendTreeButton.BackColor = SystemColors.ActiveCaption;
            SendTreeButton.Location = new Point(228, 151);
            SendTreeButton.Name = "SendTreeButton";
            SendTreeButton.Size = new Size(210, 80);
            SendTreeButton.TabIndex = 23;
            SendTreeButton.Text = "Wyślij drzewo";
            SendTreeButton.UseVisualStyleBackColor = false;
            SendTreeButton.Click += SendTreeButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1427, 849);
            Controls.Add(SendTreeButton);
            Controls.Add(RecieveTreeButton);
            Controls.Add(Port2);
            Controls.Add(Port1);
            Controls.Add(IPAddr2);
            Controls.Add(IPAddr1);
            Controls.Add(RecieverIP);
            Controls.Add(SenderIP);
            Controls.Add(RecieveButton);
            Controls.Add(CodeButton);
            Controls.Add(DictionaryInfo);
            Controls.Add(DicionaryText);
            Controls.Add(BitText);
            Controls.Add(BitInfo);
            Controls.Add(StringText);
            Controls.Add(StringInfo);
            Controls.Add(ComInfo);
            Controls.Add(ErrorComms);
            Controls.Add(SaveButton);
            Controls.Add(DecodeButton);
            Controls.Add(SendButton);
            Controls.Add(ReadButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ReadButton;
        private Button SendButton;
        private Button DecodeButton;
        private Button SaveButton;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox ErrorComms;
        private TextBox ComInfo;
        private TextBox StringInfo;
        private RichTextBox StringText;
        private TextBox BitInfo;
        private RichTextBox BitText;
        private RichTextBox DicionaryText;
        private TextBox DictionaryInfo;
        private Button CodeButton;
        private Button RecieveButton;
        private TextBox SenderIP;
        private TextBox RecieverIP;
        private TextBox IPAddr1;
        private TextBox IPAddr2;
        private TextBox Port1;
        private TextBox Port2;
        private Button RecieveTreeButton;
        private Button SendTreeButton;
    }
}