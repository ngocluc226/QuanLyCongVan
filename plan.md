## Plan: Xây dựng chức năng Công Văn Đi

Triển khai Công Văn Đi tuân thủ chuẩn kiến trúc 3 lớp (DTO, DAL, BLL) và Singleton pattern từ Công Văn Đến, nhưng luồng hoạt động sẽ đi theo chiều ngược lại: Nhân viên (Dự thảo) -> Trưởng phòng (Duyệt) -> Lãnh Đạo (Ký duyệt) -> Văn Thư (Cấp số, Ban hành).

**Steps**
1. **Thiết lập Data Transfer Objects (DTO) và Constants**
   - Tạo bộ hằng số trạng thái cho Công Văn Đi (ví dụ như `TrangThaiCongVanDi.cs`).
   - Cập nhật entity `DTO/CongVanDi.cs` với các metadata phù hợp (Nơi nhận, Người ký, v.v.).
2. **Xây dựng Data/Business Layers (DAL & BLL)** *depends on 1*
   - Viết các hàm CRUD và bộ lọc theo Role vào `DAL/CongVanDiDAL.cs`.
   - Viết logic trình duyệt, phê duyệt, ban hành và ghi log sự kiện trong `BLL/CongVanDiBLL.cs`.
3. **Phát triển UI: Màn hình Nhân Viên** *depends on 2*
   - Cập nhật `formNhanVienCVDi` cho việc soạn thảo và nộp phê duyệt.
   - Bổ sung đính kèm file dự thảo.
4. **Phát triển UI: Màn Hình Cấp Quản Lý** *depends on 3*
   - Cập nhật `formTruongPhongCVDi` (Duyệt/Từ chối cấp phòng).
   - Cập nhật `formLanhDaoCVDi` (Duyệt ký cấp cao nhất).
5. **Phát triển UI: Màn Hình Văn Thư** *depends on 4*
   - Hoàn thiện `formCongVanDiCreate` & `formCongVanDiList` (Văn thư đóng dấu, cấp số và ban hành Công Văn Đi chính thức).

**Relevant files**
- `DTO/CongVanDi.cs` & `DTO/TrangThaiCongVanDi.cs` — Khai báo thực thể.
- `DAL/CongVanDiDAL.cs` & `BLL/CongVanDiBLL.cs` — Móc nối CSDL & Logic các trạng thái duyệt.
- `UI/formNhanVienCVDi.cs`, `UI/formTruongPhongCVDi.cs`, `UI/formLanhDaoCVDi.cs` — Flow duyệt.
- `UI/formCongVanDiCreate.cs`, `UI/formCongVanDiList.cs` — Xử lý nghiệp vụ cuối.

**Verification**
1. Đăng nhập qua các role khác nhau đẩy thành công 1 flow: Draft -> Chờ Duyệt Trưởng Phòng -> Chờ Ký Lãnh Đạo -> Đã Ban Hành.
2. Kiểm tra thao tác xem trước/tải file đính kèm với `formFileViewer`.
3. Kiểm tra DB có log đầy đủ tại từng mốc chuyển đổi của `CongVanDi`.

**Decisions**
- Luồng duyệt ngược từ nhân viên lên, khác với từ lãnh đạo xuống của CV Đến. 
- Giữ vững Singleton pattern và gọi `LogBLL` tại mọi sự kiện `BLL/CongVanDiBLL.cs`.

**Further Considerations**
1. Chúng ta có cần bổ sung trạng thái "TỪ CHỐI" (trả về cho nhân viên làm lại) không? 
2. Về việc cấp "Số Số Văn Bản" mới, bạn muốn hệ thống tự tăng tự động hay Văn thư sẽ tự điền tay trước khi bấm "Ban Hành"?

---

**Decisions & Hoàn thiện thêm (Cập nhật)**
1. **Trạng thái "TỪ CHỐI":** **SẼ THÊM.** Việc thêm trạng thái `TỪ CHỐI` là bắt buộc trong luồng công việc đa cấp. Nó giúp Lãnh Đạo hoặc Trưởng Phòng có quyền trả văn bản nháp về lại cho Nhân viên khi nội dung chưa đạt. Nhân viên sẽ căn cứ vào đây để sửa và "Nộp duyệt" lại. Trạng thái này sẽ hiển thị lên lưới dữ liệu của Nhân viên.
2. **Cấp số công văn mới:** **Nhập tay trước khi phát hành.** Giữ đúng nguyên lý thực tế của nghiệp vụ văn thư (khớp sổ lấy số tại thời điểm đóng dấu đỏ). Hệ thống sẽ không tự tăng (auto-increment) số này. Màn hình của Văn Thư sẽ lấy danh sách các công văn có trạng thái là `Chờ cấp số, ban hành` và điền số định danh trước khi chốt đổi trạng thái sang `Đã ban hành`.

---

## Plan: Nâng cấp Nghiệp vụ Hệ thống (Chuyên sâu)
Triển khai bổ sung 2 nghiệp vụ quan trọng nhằm đưa hệ thống phần mềm sát với thực tiễn các hệ thống lớn:

**Steps**
1. **Liên kết Công Văn Đến - Đi (Traceability)**
   - **Mục đích:** Cho phép thiết lập 1 văn bản Đi là kết quả trả lời của 1 văn bản Đến. 
   - **CSDL:** Cập nhật bảng `CongVanDi` thêm trường `LienKetCongVanDenId` (int, nullable). 
   - **Tầng BLL/DAL:** Cập nhật DTO `CongVanDi`, bổ sung DAL Update/Insert. Thêm hàm lấy danh sách công văn đến rút gọn để ComboBox/Dropdown có thể select.
   - **Tầng UI:** Tại `formNhanVienCVDi` / `formCongVanDiCreate`, thêm phần giao diện chọn "Trả lời cho văn bản nhận (nếu có)".

2. **Quản lý Phiên bản File đính kèm (Version Control)**
   - **Mục đích:** Khi Quản lý từ chối và yêu cầu sửa, nhân viên cập nhật bản thảo mới sẽ không đè mất file thiết kế cũ.
   - **CSDL:** Thêm bảng `CongVanDi_Attachment` (Id, CongVanId, FilePath, Version, ThoiGian, NguoiUp).
   - **Tầng BLL/DAL:** Chuyển logic lưu cột `FileDinhKem` (trong CongVanDi) thành thao tác lưu lịch sử file trên bảng mới.
   - **Tầng UI:** Nâng cấp `formFileViewer` hoặc tạo form cho phép xem lại các bản nháp lịch sử của 1 công văn (version list). 
3. Ủy Quyền Xử Lý (Delegation / Thay thế)
Sẽ ra sao nếu Lãnh đạo đi công tác 1 tuần và không thể vào phần mềm để bấm "Duyệt/Ký"?

Nghiệp vụ cần thêm: Chức năng Ủy quyền (Bảng UyQuyen (NguoiUyQuyen, NguoiDuocUyQuyen, TuNgay, DenNgay, QuyenHan)).
Cách hoạt động: Phó Giám Đốc hoặc một Trưởng phòng khác sẽ thấy công văn này trong lưới hiển thị của mình với tag [Ký thay]. Lúc này CSDL Log phải ghi chú là NguyenVanB (Ký thay) duyệt.
4. Logic "Ký Số Điện Tử" (Digital Signature - CA)
Phần mềm hiện tại chỉ duyệt bằng thao tác "Click chuột" (Ký nháy điện tử - e-Approval). Ở các dự án lớn, Công Văn Đi phải có giá trị pháp lý thông qua Ký Số (Token USB, HSM, hay SmartCA).

Nghiệp vụ cần thêm:
Lãnh đạo ký số: Nhúng chữ ký số (hình ảnh chữ ký + chứng thư số) vào chính giữa file PDF.
Văn thư ký số: Đóng mộc đỏ (con dấu cơ quan số) và mác Time-stamp (ngày ban hành) lên file PDF chứng nhận trước khi phát hành.
5. Quản Lý Nơi Nhận & Chi Tiết Trạng Thái Theo Nơi (Distribution)
Bảng CongVanDi hiện tại chỉ có 1 trường NoiNhan NVARCHAR(255). Điều này không đủ vì 1 công văn có thể gửi cho 50 cơ quan / chi nhánh khác nhau.

Nghiệp vụ cần thêm:
Hỗ trợ gửi trong nội bộ hệ thống (Gửi cho các phòng ban trong cùng DB).
Vết gửi (Tracking): Bên nhận đã xem chưa? (Trạng thái Da_Nhan, Chua_Nhan, Da_Doc).
Hệ thống (DB): Loại bỏ trường NoiNhan, tạo ra bảng ChiTietNoiNhan (CongVanId, DoiTuongNhan_Duyet, LoaiNhan (NoiBo/BenNgoai), ThoiGianDoc).
6. Xử Lý Liên Kết "Công Văn Đến - Công Văn Đi" (Traceability)
90% Công văn đi được sinh ra để trả lời cho một Công văn đến trước đó.

Nghiệp vụ cần thêm: Khi nhân viên tạo mới Dự thảo, hệ thống cho phép chọn "Trả lời cho văn bản Đến số X".
Lý do thực tiễn: Điều này giúp tạo ra một Flow liên kết vòng tròn. Khi tra cứu 1 Công văn đến, người ta thấy ngay Công văn đi trả lời. (Cần thêm cột/bảng LienKetCongVan).
7. Thiết Lập Hạn Xử Lý (Deadline - SLA)
Nghiệp vụ cần thêm: Khi giao việc soạn thảo hoặc chuyển duyệt, hệ thống áp đặt Deadline (ví dụ: Trưởng phòng phải duyệt trong 8 giờ, Lãnh đạo duyệt trong 24 giờ).
Lý do thực tiễn: Đánh giá KPI của nhân sự. Hiển thị cảnh báo màu Đỏ (Quá hạn) trên DataGridView của người bị trễ.
TỔNG KẾT BƯỚC ĐI TIẾP THEO CHO BẠN:
Nếu đồ án/dự án của bạn có đủ thời gian, bạn có thể triển khai thêm ngay 2 nghiệp vụ cốt lõi nhất để làm nổi bật sự khác biệt với các nhóm khác:

Liên kết Công văn đến - đi: (Rất dễ làm, chỉ cần thêm 1 Dropdown chọn Mã Công văn đến vào form tạo Công văn đi).
Quản lý Phiên bản File đính kèm: Để nhân viên update file n-lần không bị đè mất file cũ. Lãnh đạo có thể tải xem bản cũ và bản mới.
Bạn muốn đào sâu vào thiết kế Code / DB cho phần nào trong 7 tính năng tôi liệt kê ở trên?
/// cvdi2