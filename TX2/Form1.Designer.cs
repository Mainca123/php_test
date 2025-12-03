namespace TX2
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
            this.label1 = new System.Windows.Forms.Label();
            this.manvTXT = new System.Windows.Forms.TextBox();
            this.them = new System.Windows.Forms.Button();
            this.bangNhanVien = new System.Windows.Forms.DataGridView();
            this.manv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.diachiTXT = new System.Windows.Forms.TextBox();
            this.tenTXT = new System.Windows.Forms.TextBox();
            this.hoTXT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sua = new System.Windows.Forms.Button();
            this.xoa = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.Button();
            this.lamMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bangNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(476, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hệ thống quản lý";
            // 
            // manvTXT
            // 
            this.manvTXT.Location = new System.Drawing.Point(218, 90);
            this.manvTXT.Name = "manvTXT";
            this.manvTXT.Size = new System.Drawing.Size(914, 22);
            this.manvTXT.TabIndex = 1;
            // 
            // them
            // 
            this.them.Location = new System.Drawing.Point(1168, 89);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(160, 82);
            this.them.TabIndex = 2;
            this.them.Text = "Thêm";
            this.them.UseVisualStyleBackColor = true;
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // bangNhanVien
            // 
            this.bangNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bangNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.manv,
            this.ho,
            this.ten,
            this.diachi});
            this.bangNhanVien.Location = new System.Drawing.Point(73, 283);
            this.bangNhanVien.Name = "bangNhanVien";
            this.bangNhanVien.RowHeadersWidth = 51;
            this.bangNhanVien.RowTemplate.Height = 24;
            this.bangNhanVien.Size = new System.Drawing.Size(1059, 407);
            this.bangNhanVien.TabIndex = 3;
            this.bangNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bangNhanVien_CellClick);
            // 
            // manv
            // 
            this.manv.HeaderText = "Mã nhân viên";
            this.manv.MinimumWidth = 6;
            this.manv.Name = "manv";
            this.manv.Width = 125;
            // 
            // ho
            // 
            this.ho.HeaderText = "Họ";
            this.ho.MinimumWidth = 6;
            this.ho.Name = "ho";
            this.ho.Width = 150;
            // 
            // ten
            // 
            this.ten.HeaderText = "Tên";
            this.ten.MinimumWidth = 6;
            this.ten.Name = "ten";
            this.ten.Width = 125;
            // 
            // diachi
            // 
            this.diachi.HeaderText = "Địa chỉ";
            this.diachi.MinimumWidth = 6;
            this.diachi.Name = "diachi";
            this.diachi.Width = 450;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Họ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên";
            // 
            // diachiTXT
            // 
            this.diachiTXT.Location = new System.Drawing.Point(218, 228);
            this.diachiTXT.Name = "diachiTXT";
            this.diachiTXT.Size = new System.Drawing.Size(914, 22);
            this.diachiTXT.TabIndex = 8;
            // 
            // tenTXT
            // 
            this.tenTXT.Location = new System.Drawing.Point(218, 182);
            this.tenTXT.Name = "tenTXT";
            this.tenTXT.Size = new System.Drawing.Size(914, 22);
            this.tenTXT.TabIndex = 9;
            // 
            // hoTXT
            // 
            this.hoTXT.Location = new System.Drawing.Point(218, 136);
            this.hoTXT.Name = "hoTXT";
            this.hoTXT.Size = new System.Drawing.Size(914, 22);
            this.hoTXT.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 27);
            this.label5.TabIndex = 11;
            this.label5.Text = "Địa chỉ";
            // 
            // sua
            // 
            this.sua.Location = new System.Drawing.Point(1168, 186);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(160, 82);
            this.sua.TabIndex = 12;
            this.sua.Text = "Sửa";
            this.sua.UseVisualStyleBackColor = true;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // xoa
            // 
            this.xoa.Location = new System.Drawing.Point(1168, 283);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(160, 82);
            this.xoa.TabIndex = 13;
            this.xoa.Text = "Xóa";
            this.xoa.UseVisualStyleBackColor = true;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // tim
            // 
            this.tim.Location = new System.Drawing.Point(1168, 380);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(160, 82);
            this.tim.TabIndex = 14;
            this.tim.Text = "Tìm";
            this.tim.UseVisualStyleBackColor = true;
            this.tim.Click += new System.EventHandler(this.tim_Click);
            // 
            // lamMoi
            // 
            this.lamMoi.Location = new System.Drawing.Point(1168, 477);
            this.lamMoi.Name = "lamMoi";
            this.lamMoi.Size = new System.Drawing.Size(160, 82);
            this.lamMoi.TabIndex = 15;
            this.lamMoi.Text = "Load trang";
            this.lamMoi.UseVisualStyleBackColor = true;
            this.lamMoi.Click += new System.EventHandler(this.lamMoi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 728);
            this.Controls.Add(this.lamMoi);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.xoa);
            this.Controls.Add(this.sua);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hoTXT);
            this.Controls.Add(this.tenTXT);
            this.Controls.Add(this.diachiTXT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bangNhanVien);
            this.Controls.Add(this.them);
            this.Controls.Add(this.manvTXT);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bangNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox manvTXT;
        private System.Windows.Forms.Button them;
        private System.Windows.Forms.DataGridView bangNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox diachiTXT;
        private System.Windows.Forms.TextBox tenTXT;
        private System.Windows.Forms.TextBox hoTXT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button sua;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.Button tim;
        private System.Windows.Forms.Button lamMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn manv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ho;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachi;
    }
}

