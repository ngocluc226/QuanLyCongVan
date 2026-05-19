# Tài Liệu Triển Khai Luồng Công Văn Đi (PBL3_QLCV)

Tài liệu này giải thích chi tiết các thành phần đã được thêm vào mã nguồn nhằm hoàn thiện luồng nghiệp vụ của chức năng **Công Văn Đi** theo đúng chuẩn mô hình kiến trúc 3 lớp (3-tier architecture: DTO, DAL, BLL).

---

## 1. DTO (Data Transfer Objects) - Chuẩn Hóa Trạng Thái

**File sửa đổi/thêm:** `DTO/TrangThaiCongVanDi.cs`

**Đã thêm:**
Tạo một class tĩnh chứa các biến hằng (constant) định nghĩa các trạng thái của một công văn đi.
- `DRAFT` (Dự thảo)
- `CHO_DUYET_TP` (Chờ duyệt Trưởng phòng)
- `CHO_KY_LD` (Chờ ký Lãnh đạo)
- `CHO_BAN_HANH` (Chờ ban hành - Đã ký nhưng chưa cấp số)
- `DA_BAN_HANH` (Đã ban hành)
- `TU_CHOI` (Từ chối)

**Lý giải:**
- Tránh lỗi hardcode chuỗi (magic strings) rải rác khắp nơi ở các form giao diện hoặc BLL, gây khó khăn khi muốn đổi tên trạng thái.
- Đảm bảo tính nhất quán (Consistency) trong luồng dữ liệu của DB. 
- Giúp các lập trình viên khác khi đọc code dễ dàng auto-complete thông qua `DTO.TrangThaiCongVanDi.xxx` thay vì phải gõ lại chuỗi.

---

## 2. DAL & BLL (Data / Business Logic Layer) - Xử Lý Nghiệp Vụ & Cơ Sở Dữ Liệu

**File sửa đổi/thêm:** `DAL/CongVanDiDAL.cs` & `BLL/CongVanDiBLL.cs`

**Đã thêm:**
- **Trong DAL:** Các hàm `Update(CongVanDi cv)`, `UpdateStatus(int id, string trangThai)`, và `GetByTrangThai(string trangThai)`.
- **Trong BLL:** Tương ứng là các hàm kết nối lên UI và đặc biệt là hàm nghiệp vụ `ChuyenTrangThai(int id, string trangThaiMoi, string ghiChu)`.

**Lý giải:**
- **Tách biệt Update toàn phần và Update 1 phần:** Hàm `UpdateStatus` thực thi truy vấn SQL rất nhẹ nhàng (chỉ SET cột `TrangThai`) dùng cho hành động Duyệt/Từ chối, trong khi `Update` lưu toàn bộ dữ liệu (Số văn bản, File đính kèm) dùng cho Văn Thư khi cần cập nhật thông tin cuối.
- **Hàm GetByTrangThai:** Cực kỳ quan trọng để phân quyền hiển thị (Nhân viên chỉ thấy DRAFT, Lãnh đạo chỉ thấy các file cần duyệt, Văn thư chỉ thấy file chờ ban hành).
- **Hàm BLL.ChuyenTrangThai:** Gom nhóm (Encapsulate) logic chuyển trạng thái và **Ghi Log** (`LogBLL.Instance.WriteLog`) lại vào cùng 1 transaction (ở mức Business Logic). Việc này giúp UI chỉ cần gọi một hàm duy nhất và bảo đảm hệ thống luôn luôn lưu lại lịch sử Audit Trail của User đang thao tác.

---

## 3. Tầng UI - Giao Diện Phân Quyền Xử Lý

### A. Màn hình Nhân Viên Soạn Thảo (`formNhanVienCVDi.cs`)
**Đã thêm:** DataGridView hiển thị danh sách công văn DRAFT và các nút thao tác `Thêm dự thảo`, `Nộp duyệt`.
**Lý giải:** 
Là điểm bắt đầu của luồng quy trình (Initiator). Nhân viên cần phải tự chuẩn bị xong xuôi dự thảo mới ấn "Nộp Trưởng Phòng". Thao tác này gọi `ChuyenTrangThai` thành `CHO_DUYET_TP`.

### B. Màn hình Lãnh Đạo Duyệt / Ký (`formLanhDaoCVDi.cs`)
**Đã thêm:** DataGridView lọc công văn đang ở `CHO_DUYET_TP` cùng nút `Duyệt/Ký` và `Từ chối`.
**Lý giải:** 
Lãnh đạo đóng vai trò là "Cửa ngõ quyết định" trước khi văn bản có hiệu lực.
- Nếu đồng ý, công văn chuyển trạng thái thành `CHO_BAN_HANH` thay vì `DA_BAN_HANH`. 
*Tại sao không thành Đã Ban Hành luôn?* Vì thực tế, Lãnh đạo chỉ ký nội dung, người đóng dấu mộc đỏ và lấy "Số Văn Bản" lưu vào sổ sách phải là Văn Thư. Nên phải có trạng thái đệm là `Chờ ban hành`.

### C. Màn hình Văn Thư Cấp Số (`formCongVanDiCreate.cs`)
**Đã thêm:** 
- Nâng cấp màn hình tạo mới thành màn hình đa năng: Vừa hỗ trợ tạo mới (Bypass flow), vừa hỗ trợ xử lý công văn được chuyển từ Lãnh Đạo xuống.
- Khung danh sách (Grid) chứa các file `CHO_BAN_HANH`. Khi click chọn, sẽ cho phép sửa/nhập "Số văn bản", ngày ban hành thực tế.
- Chỉnh sửa hàm `btnSave_Click` để kiểm tra: Nếu là đang xử lý một công văn có sẵn thì gọi hàm `Update` thay vì `Insert`.

**Lý giải:**
- Văn thư là bước cuối cùng (Finisher) khép kín quy trình. Việc tái sử dụng lại `formCongVanDiCreate` giúp UI đồng bộ, tránh phải tạo thêm 1 màn hình dư thừa. 
- Văn thư sẽ lấy thông tin chuẩn từ bản cứng đã đóng dấu (Số công văn) và điền vào form, sau đó bấm Lưu để cập nhật thành `Đã ban hành`.

---

## Tóm Tắt Luồng Chảy Của Hệ Thống (Workflow Diagram)

1. **Nhân Viên** (Tạo mới) ➡️ Trạng thái: `DRAFT` (Dự thảo)
2. **Nhân Viên** (Nhấn nộp duyệt) ➡️ Trạng thái: `CHO_DUYET_TP` (Chờ duyệt Trưởng phòng)
3. **Lãnh Đạo** (Vào xem & nhấn Duyệt) ➡️ Trạng thái: `CHO_BAN_HANH` (Chờ cấp số, ban hành)
4. **Văn Thư** (Nhập "Số công văn", Ngày đi thực tế & Lưu) ➡️ Trạng thái cuối: `DA_BAN_HANH` (Chính thức được phát hành).

*Lưu ý: Bất kỳ bước nào trong quy trình trên xảy ra, hệ thống BLL đều ngầm bắt lấy `DTO.Session.CurrentUser` để ghi Log hành động vào CSDL (nhờ hàm `LogBLL.Instance.WriteLog`), đáp ứng yêu cầu nghiệp vụ lưu vết (Traceability).*

---

## 5. Quyết định hoàn thiện thêm cấu trúc & Ý nghĩa (Cập nhật)

Việc ra quyết định bổ sung trạng thái **TỪ CHỐI** và quy định **Văn thư tự điền tay Số Công Văn** mang ý nghĩa vô cùng quan trọng cho sự hoàn thiện của phần mềm:
- **Ý nghĩa của trạng thái TỪ CHỐI:** Khép kín và thực tế hoá quy trình phản hồi ngược (Feedback loop). Nếu không có trạng thái này, khi một bản nháp sai sót sẽ bị kẹt hoặc phải xóa làm lại từ đầu. Giờ đây, Lãnh đạo/Trưởng phòng có thể từ chối đi kèm lý do ghi lỗi, trả tài liệu thẳng về màn hình của người khởi tạo để sửa chữa trên chính ID cũ, giúp tiết kiệm bộ nhớ, hạn chế rác dữ liệu DB và đảm bảo tính liên tục của lịch sử nháp/duyệt trong LogHeThong.
- **Ý nghĩa của việc Văn thư nhập Số Văn Bản thủ công thay vì Tự Sinh (Auto Sinh):** Tránh hiện tượng nhảy số không logic, sai lệch giữa phần mềm và sổ giấy. Quá trình xử lý sẽ tuân thủ khớp hoàn toàn thực tế cơ quan nhà nước, bảo chứng rằng khi số văn bản được lưu thì chắc chắn đã đóng dấu xác thực. Lỗi hủy số/cấp nhầm cũng sẽ bị triệt tiêu do con người kiểm tra trước khi bấm nút Ban Hành cuối cùng.
- **Cập nhật thêm lưu đồ Workflow:** Bổ sung bước Trưởng Phòng duyệt (bước trung gian) và rẽ nhánh nhánh `Từ chối`.
---

## 4. Cập Nhật Nâng Cấp Quy Trình Đa Cấp & Khắc Phục Lỗi Giao Diện

Nhằm chuẩn hóa hoàn toàn nghiệp vụ duyệt công văn đa cấp từ Nhân Viên lên Trưởng Phòng rồi đến Lãnh Đạo, các thành phần sau đã được nâng cấp hệ thống:

### A. Chuẩn Hóa Bộ Mã Trạng Thái Mới (Vietnamese Snake Case)
Đã thực hiện chuẩn hóa lớp `DTO/TrangThaiCongVanDi.cs` theo đúng phong cách thuần Việt, tường minh của Công văn đến:
- `DU_THAO` = "Dự thảo" (Thay thế cho `DRAFT`).
- `CHO_DUYET_TRUONG_PHONG` = "Chờ duyệt trưởng phòng" (Thay thế cho `CHO_DUYET_TP`).
- `CHO_KY_LANH_DAO` = "Chờ ký lãnh đạo" (Thay thế cho `CHO_KY_LD`).
Các màn hình Nhân viên, Trưởng phòng, Lãnh đạo và Văn thư đã được cập nhật tự động để tương thích hoàn toàn với bộ từ điển trạng thái mới này.

### B. Tối Ưu & Tái Sử Dụng Form Nhập Liệu (`formCongVanDiCreate.cs`)
- **Lý giải:** Tránh tạo thừa thãi Form giao diện mới. Đã thực hiện nâng cấp `formCongVanDiCreate.cs` thành một "Smart Form" có khả năng tự biến đổi giao diện động theo Role đang đăng nhập.
- **Đối với Nhân Viên:**
  * Tự động ẩn bảng Grid danh sách chờ ở dưới.
  * Vô hiệu hóa (Disable) các trường thuộc độc quyền của Văn Thư như `Số văn bản`, `Ngày ban hành`.
  * Khi nhấn "Lưu": Thực hiện Insert/Update xuống DB dưới dạng `Dự thảo` và tự động đóng Dialog.
- **Đối với Văn Thư:** Giữ nguyên luồng nạp danh sách các bản thảo từ Lãnh Đạo chuyển xuống để thực hiện "Cấp Số" và đẩy lên trạng thái `Đã ban hành`.

### C. Xây dựng Dashboard & Màn hình duyệt cho Trưởng Phòng
- **Tạo `formTruongPhong.cs`:** Giải quyết triệt để lỗi Trưởng phòng khi đăng nhập chỉ hiển thị độc lập module Công văn đến. Cung cấp Menu Tab chuyển đổi tiện lợi.
- **Tạo `formTruongPhongCVDi.cs`:** Lọc danh sách đang ở trạng thái `Chờ duyệt trưởng phòng` cho phép Trưởng phòng:
  1. **Duyệt cấp phòng:** Ký duyệt sơ bộ và đẩy tiếp lên trạng thái cao hơn là `Chờ ký lãnh đạo`.
  2. **Từ chối:** Đẩy trả ngược về trạng thái `Từ chối` để chuyển trả về cho Nhân viên xử lý lại.

### D. Khớp Nối Luồng Trạng Thái & Dữ Liệu (Data Flow)
- Cập nhật logic tải dữ liệu tại `formLanhDaoCVDi.cs`: Chỉ hiển thị các công văn đã qua cửa ải Trưởng phòng kiểm duyệt (Trạng thái: `Chờ ký lãnh đạo`).
- Nâng cấp khả năng truy vấn DAL/BLL: Bổ sung hàm `GetByTrangThais(params string[] list)` giúp tải song song nhiều trạng thái trong 1 query một cách an toàn. Cho phép màn hình Nhân viên hiển thị đầy đủ cả Bản nháp lẫn Bản bị từ chối để thuận tiện xử lý công việc.

---

// csdl
-- 1. Khởi tạo Database
CREATE DATABASE QUANLYCONGVAN;
GO
USE QUANLYCONGVAN;
GO

-- 2. Tạo bảng Phòng Ban
CREATE TABLE PhongBan (
    MaPhongBan NVARCHAR(50) PRIMARY KEY,
    TenPhongBan NVARCHAR(255) NOT NULL
);

-- 3. Tạo bảng Người Dùng
CREATE TABLE NguoiDung (
    MaNguoiDung NVARCHAR(50) PRIMARY KEY,
    TenNguoiDung NVARCHAR(255) NOT NULL,
    TenDangNhap NVARCHAR(100) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    Quyen NVARCHAR(50) NOT NULL, -- Admin, VanThu, LanhDao, TruongPhong, NhanVien
    MaPhongBan NVARCHAR(50) NULL,
    SDT NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    CONSTRAINT FK_NguoiDung_PhongBan FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan) ON DELETE SET NULL
);

-- 4. Tạo bảng Công Văn Đến
CREATE TABLE CongVanDen (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SoDen NVARCHAR(50) NOT NULL UNIQUE,
    SoVanBan NVARCHAR(50) NULL,
    NgayDen DATETIME NOT NULL DEFAULT GETDATE(),
    NgayBanHanh DATETIME NULL,
    NoiGui NVARCHAR(255) NULL,
    NguoiKy NVARCHAR(255) NULL,
    TrichYeu NVARCHAR(MAX) NULL,
    DoKhan NVARCHAR(50) NULL,
    DoMat NVARCHAR(50) NULL,
    FileDinhKem NVARCHAR(MAX) NULL,
    TrangThai NVARCHAR(100) NOT NULL DEFAULT N'Mới tiếp nhận'
);

-- 5. Tạo bảng Công Văn Đi
CREATE TABLE CongVanDi (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SoDi NVARCHAR(50) NOT NULL UNIQUE,
    SoVanBan NVARCHAR(50) NULL,
    NgayDi DATETIME NOT NULL DEFAULT GETDATE(),
    NgayBanHanh DATETIME NULL,
    NoiNhan NVARCHAR(255) NULL,
    NguoiKy NVARCHAR(255) NULL,
    TrichYeu NVARCHAR(MAX) NULL,
    DoKhan NVARCHAR(50) NULL,
    DoMat NVARCHAR(50) NULL,
    FileDinhKem NVARCHAR(MAX) NULL,
    TrangThai NVARCHAR(100) NOT NULL DEFAULT N'Dự thảo'
);

-- 6. Tạo bảng Trình Lãnh Đạo (Luồng xét duyệt công văn đến)
CREATE TABLE TrinhLanhDao (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CongVanId INT NOT NULL,
    NguoiTrinhId NVARCHAR(50) NOT NULL,
    LanhDaoId NVARCHAR(50) NOT NULL,
    NgayTrinh DATETIME NOT NULL DEFAULT GETDATE(),
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'ChoDuyet',
    CONSTRAINT FK_Trinh_CongVan FOREIGN KEY (CongVanId) REFERENCES CongVanDen(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Trinh_NguoiTrinh FOREIGN KEY (NguoiTrinhId) REFERENCES NguoiDung(MaNguoiDung),
    CONSTRAINT FK_Trinh_LanhDao FOREIGN KEY (LanhDaoId) REFERENCES NguoiDung(MaNguoiDung)
);

-- 7. Tạo bảng Phân Công Công Văn
CREATE TABLE PhanCongCongVan (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CongVanId INT NOT NULL,
    MaNguoiDung NVARCHAR(50) NULL,
    MaPhongBan NVARCHAR(50) NULL,
    YKienChiDao NVARCHAR(MAX) NULL,
    TrangThai NVARCHAR(100) NULL,
    NguoiGiao NVARCHAR(100) NULL,
    CapPhanCong NVARCHAR(50) NULL, -- LANH_DAO, TRUONG_PHONG
    NgayPhanCong DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_PhanCong_CongVan FOREIGN KEY (CongVanId) REFERENCES CongVanDen(Id) ON DELETE CASCADE,
    CONSTRAINT FK_PhanCong_User FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    CONSTRAINT FK_PhanCong_PhongBan FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan)
);

-- 8. Tạo bảng Log Hệ Thống
CREATE TABLE LogHeThong (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    HanhDong NVARCHAR(MAX) NOT NULL,
    NguoiThucHien NVARCHAR(100) NOT NULL,
    ThoiGian DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-----------------------------------------------------
-- 🎁 DỮ LIỆU MẪU Đ
-- 1. Khởi tạo Database
CREATE DATABASE QUANLYCONGVAN;
GO
USE QUANLYCONGVAN;
GO

-- 2. Tạo bảng Phòng Ban
CREATE TABLE PhongBan (
    MaPhongBan NVARCHAR(50) PRIMARY KEY,
    TenPhongBan NVARCHAR(255) NOT NULL
);

-- 3. Tạo bảng Người Dùng
CREATE TABLE NguoiDung (
    MaNguoiDung NVARCHAR(50) PRIMARY KEY,
    TenNguoiDung NVARCHAR(255) NOT NULL,
    TenDangNhap NVARCHAR(100) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    Quyen NVARCHAR(50) NOT NULL, -- Admin, VanThu, LanhDao, TruongPhong, NhanVien
    MaPhongBan NVARCHAR(50) NULL,
    SDT NVARCHAR(20) NULL,
    Email NVARCHAR(100) NULL,
    CONSTRAINT FK_NguoiDung_PhongBan FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan) ON DELETE SET NULL
);

-- 4. Tạo bảng Công Văn Đến
CREATE TABLE CongVanDen (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SoDen NVARCHAR(50) NOT NULL UNIQUE,
    SoVanBan NVARCHAR(50) NULL,
    NgayDen DATETIME NOT NULL DEFAULT GETDATE(),
    NgayBanHanh DATETIME NULL,
    NoiGui NVARCHAR(255) NULL,
    NguoiKy NVARCHAR(255) NULL,
    TrichYeu NVARCHAR(MAX) NULL,
    DoKhan NVARCHAR(50) NULL,
    DoMat NVARCHAR(50) NULL,
    FileDinhKem NVARCHAR(MAX) NULL,
    TrangThai NVARCHAR(100) NOT NULL DEFAULT N'Mới tiếp nhận'
);

-- 5. Tạo bảng Công Văn Đi
CREATE TABLE CongVanDi (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SoDi NVARCHAR(50) NOT NULL UNIQUE,
    SoVanBan NVARCHAR(50) NULL,
    NgayDi DATETIME NOT NULL DEFAULT GETDATE(),
    NgayBanHanh DATETIME NULL,
    NoiNhan NVARCHAR(255) NULL,
    NguoiKy NVARCHAR(255) NULL,
    TrichYeu NVARCHAR(MAX) NULL,
    DoKhan NVARCHAR(50) NULL,
    DoMat NVARCHAR(50) NULL,
    FileDinhKem NVARCHAR(MAX) NULL,
    TrangThai NVARCHAR(100) NOT NULL DEFAULT N'Dự thảo'
);

-- 6. Tạo bảng Trình Lãnh Đạo
CREATE TABLE TrinhLanhDao (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CongVanId INT NOT NULL,
    NguoiTrinhId NVARCHAR(50) NOT NULL,
    LanhDaoId NVARCHAR(50) NOT NULL,
    NgayTrinh DATETIME NOT NULL DEFAULT GETDATE(),
    TrangThai NVARCHAR(50) NOT NULL DEFAULT 'ChoDuyet',
    CONSTRAINT FK_Trinh_CongVan FOREIGN KEY (CongVanId) REFERENCES CongVanDen(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Trinh_NguoiTrinh FOREIGN KEY (NguoiTrinhId) REFERENCES NguoiDung(MaNguoiDung),
    CONSTRAINT FK_Trinh_LanhDao FOREIGN KEY (LanhDaoId) REFERENCES NguoiDung(MaNguoiDung)
);

-- 7. Tạo bảng Phân Công Công Văn
CREATE TABLE PhanCongCongVan (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CongVanId INT NOT NULL,
    MaNguoiDung NVARCHAR(50) NULL,
    MaPhongBan NVARCHAR(50) NULL,
    YKienChiDao NVARCHAR(MAX) NULL,
    TrangThai NVARCHAR(100) NULL,
    NguoiGiao NVARCHAR(100) NULL,
    CapPhanCong NVARCHAR(50) NULL, -- LANH_DAO, TRUONG_PHONG
    NgayPhanCong DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_PhanCong_CongVan FOREIGN KEY (CongVanId) REFERENCES CongVanDen(Id) ON DELETE CASCADE,
    CONSTRAINT FK_PhanCong_User FOREIGN KEY (MaNguoiDung) REFERENCES NguoiDung(MaNguoiDung),
    CONSTRAINT FK_PhanCong_PhongBan FOREIGN KEY (MaPhongBan) REFERENCES PhongBan(MaPhongBan)
);

-- 8. Tạo bảng Log Hệ Thống
CREATE TABLE LogHeThong (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    HanhDong NVARCHAR(MAX) NOT NULL,
    NguoiThucHien NVARCHAR(100) NOT NULL,
    ThoiGian DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- 🎁 9. Thêm Dữ liệu mẫu (Đăng nhập kiểm tra thử)
-- Chèn Phòng ban
INSERT INTO PhongBan (MaPhongBan, TenPhongBan) VALUES 
('HCNS', N'Phòng Hành chính Nhân sự'),
('IT', N'Phòng Công nghệ Thông tin'),
('KT', N'Phòng Kế toán');

-- Chèn Người dùng mẫu (Mật khẩu thô để bạn test trực tiếp trên UI)
INSERT INTO NguoiDung (MaNguoiDung, TenNguoiDung, TenDangNhap, MatKhau, Quyen, MaPhongBan) VALUES
('U001', N'Quản trị viên', 'admin', '123', 'Admin', NULL),
('U002', N'Nguyễn Văn Thư', 'vanthu', '123', 'VanThu', 'HCNS'),
('U003', N'Trần Lãnh Đạo', 'lanhdao', '123', 'LanhDao', NULL),
('U004', N'Lê Trưởng Phòng IT', 'truongphong', '123', 'TruongPhong', 'IT'),
('U005', N'Phạm Chuyên Viên IT', 'nhanvien', '123', 'NhanVien', 'IT');
GO