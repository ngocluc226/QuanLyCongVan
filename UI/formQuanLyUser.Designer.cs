namespace UI
{
    partial class formQuanLyUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formQuanLyUser));
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.colMaNguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenPhongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPhongBan = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbQuyen = new System.Windows.Forms.ComboBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtManguoidung = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfullname = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNguoiDung,
            this.colTenNguoiDung,
            this.colTenDangNhap,
            this.colQuyen,
            this.colSDT,
            this.colEmail,
            this.colTenPhongBan});
            this.dgvTaiKhoan.Location = new System.Drawing.Point(20, 323);
            this.dgvTaiKhoan.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersWidth = 51;
            this.dgvTaiKhoan.RowTemplate.Height = 24;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(853, 213);
            this.dgvTaiKhoan.TabIndex = 14;
            // 
            // colMaNguoiDung
            // 
            this.colMaNguoiDung.DataPropertyName = "MaNguoiDung";
            this.colMaNguoiDung.HeaderText = "Mã người dùng";
            this.colMaNguoiDung.MinimumWidth = 6;
            this.colMaNguoiDung.Name = "colMaNguoiDung";
            // 
            // colTenNguoiDung
            // 
            this.colTenNguoiDung.DataPropertyName = "TenNguoiDung";
            this.colTenNguoiDung.HeaderText = "Tên người dùng";
            this.colTenNguoiDung.MinimumWidth = 6;
            this.colTenNguoiDung.Name = "colTenNguoiDung";
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.DataPropertyName = "TenDangNhap";
            this.colTenDangNhap.HeaderText = "Tên đăng nhập";
            this.colTenDangNhap.MinimumWidth = 6;
            this.colTenDangNhap.Name = "colTenDangNhap";
            // 
            // colQuyen
            // 
            this.colQuyen.DataPropertyName = "Quyen";
            this.colQuyen.HeaderText = "Quyền";
            this.colQuyen.MinimumWidth = 6;
            this.colQuyen.Name = "colQuyen";
            // 
            // colSDT
            // 
            this.colSDT.DataPropertyName = "SDT";
            this.colSDT.HeaderText = "Số điện thoại";
            this.colSDT.MinimumWidth = 6;
            this.colSDT.Name = "colSDT";
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            // 
            // colTenPhongBan
            // 
            this.colTenPhongBan.DataPropertyName = "TenPhongBan";
            this.colTenPhongBan.HeaderText = "Phòng Ban";
            this.colTenPhongBan.MinimumWidth = 6;
            this.colTenPhongBan.Name = "colTenPhongBan";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.cbPhongBan);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbQuyen);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtSdt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtManguoidung);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtfullname);
            this.groupBox1.Location = new System.Drawing.Point(17, 67);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(856, 170);
            this.groupBox1.TabIndex = 92;
            this.groupBox1.TabStop = false;
            // 
            // cbPhongBan
            // 
            this.cbPhongBan.FormattingEnabled = true;
            this.cbPhongBan.Location = new System.Drawing.Point(607, 34);
            this.cbPhongBan.Name = "cbPhongBan";
            this.cbPhongBan.Size = new System.Drawing.Size(193, 27);
            this.cbPhongBan.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(604, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = " Phòng ban*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(604, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Quyền*";
            // 
            // cbQuyen
            // 
            this.cbQuyen.FormattingEnabled = true;
            this.cbQuyen.Items.AddRange(new object[] {
            "VanThu",
            "NhanVienXuLy",
            "LanhDao",
            "TruongPhong",
            "Admin"});
            this.cbQuyen.Location = new System.Drawing.Point(608, 91);
            this.cbQuyen.Margin = new System.Windows.Forms.Padding(2);
            this.cbQuyen.Name = "cbQuyen";
            this.cbQuyen.Size = new System.Drawing.Size(192, 27);
            this.cbQuyen.TabIndex = 6;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(356, 15);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(126, 20);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Tên đăng nhập*";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(356, 72);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(87, 20);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Mật khẩu*";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(36, 147);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(151, 26);
            this.txtEmail.TabIndex = 7;
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(356, 147);
            this.txtSdt.Margin = new System.Windows.Forms.Padding(2);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(151, 26);
            this.txtSdt.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 128);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Email";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(356, 34);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(151, 26);
            this.txtUsername.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Mã người dùng*";
            // 
            // txtManguoidung
            // 
            this.txtManguoidung.Location = new System.Drawing.Point(36, 34);
            this.txtManguoidung.Margin = new System.Windows.Forms.Padding(2);
            this.txtManguoidung.Name = "txtManguoidung";
            this.txtManguoidung.Size = new System.Drawing.Size(151, 26);
            this.txtManguoidung.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(356, 128);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "Số điện thoại*";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(356, 91);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(151, 26);
            this.txtPassword.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tên người dùng*";
            // 
            // txtfullname
            // 
            this.txtfullname.Location = new System.Drawing.Point(36, 91);
            this.txtfullname.Margin = new System.Windows.Forms.Padding(2);
            this.txtfullname.Name = "txtfullname";
            this.txtfullname.Size = new System.Drawing.Size(151, 26);
            this.txtfullname.TabIndex = 4;
            // 
            // cbSearch
            // 
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "Mã người dùng",
            "Tên người dùng",
            "Tên đăng nhập",
            "Email",
            "Quyền",
            "Phòng ban",
            "SĐT"});
            this.cbSearch.Location = new System.Drawing.Point(529, 35);
            this.cbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(126, 27);
            this.cbSearch.TabIndex = 85;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(655, 34);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(141, 22);
            this.txtSearch.TabIndex = 84;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.Location = new System.Drawing.Point(505, 247);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(46, 52);
            this.btnReturn.TabIndex = 83;
            this.btnReturn.Text = "Thoát";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnHuy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHuy.BackgroundImage")));
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(411, 247);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(50, 52);
            this.btnHuy.TabIndex = 82;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.BtnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(227, 248);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(50, 52);
            this.btnLuu.TabIndex = 81;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.BtnLuu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 304);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 80;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTimkiem.BackgroundImage")));
            this.btnTimkiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTimkiem.Location = new System.Drawing.Point(800, 22);
            this.btnTimkiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(39, 39);
            this.btnTimkiem.TabIndex = 79;
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnXoa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.BackgroundImage")));
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(321, 247);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(53, 51);
            this.btnXoa.TabIndex = 78;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnCapNhat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Location = new System.Drawing.Point(141, 248);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(50, 51);
            this.btnCapNhat.TabIndex = 77;
            this.btnCapNhat.Text = "Sửa";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.BtnCapNhat_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(56, 247);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(50, 52);
            this.btnThem.TabIndex = 76;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(288, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 25);
            this.label1.TabIndex = 75;
            this.label1.Text = "QUẢN LÝ  NGƯỜI DÙNG ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(596, 247);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(46, 52);
            this.btnRefresh.TabIndex = 94;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // formQuanLyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(910, 587);
            this.Controls.Add(this.dgvTaiKhoan);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formQuanLyUser";
            this.Text = "formQuanLyUser";
            this.Load += new System.EventHandler(this.formQuanLyUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbQuyen;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtManguoidung;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtfullname;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPhongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNguoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNguoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenPhongBan;
        private System.Windows.Forms.Button btnRefresh;
    }
}