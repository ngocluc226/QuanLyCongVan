## Plan: Xử lý Luồng Công Văn Đi & Quản Lý

Implement luồng tạo, duyệt và phát hành Công văn đi theo từng bước cùng cải tiến chức năng quản lý danh sách.

**Steps**
1. **Cập nhật Database & DTO** *(Tạo nền tảng dữ liệu)*
   - Cập nhật định nghĩa bảng `CongVanDi` trong cơ sở dữ liệu để chứa các trường: `GhiChu` (Lý do từ chối/yêu cầu sửa), `NguoiDuyetId` (Mã người lãnh đạo duyệt).
   - Thêm các thuộc tính tương ứng vào lớp `DTO.CongVanDi`.
2. **Cập nhật DAL & BLL** *(Xử lý truy xuất và nghiệp vụ)*
   - Thêm phương thức lấy danh sách Lãnh đạo trong `UserDAL`.
   - Cập nhật `CongVanDiDAL` (thêm Insert/Update với các trường mới, cập nhật `UpdateTrangThai()`, v.v.).
   - Xây dựng phương thức gửi email dùng `System.Net.Mail` (SMTP) để gửi thông báo.
3. **Luồng Nhân Viên: Tạo & Gửi Duyệt** *(Cập nhật `formCongVanDiCreate`)*
   - Thêm chức năng cho phép lưu file dưới trạng thái **"Soạn thảo"**.
   - Thêm ComboBox chọn Lãnh đạo cần gửi duyệt.
   - Thêm nút **"Gửi duyệt"**: chuyển trạng thái thành **"Chờ duyệt"**, lưu `NguoiDuyetId` và dùng `EmailService` kích hoạt việc gửi thư điện tử tới Lãnh đạo.
4. **Luồng Lãnh Đạo: Phê Duyệt CV**
   - Xây dựng màn hình/Tab cho Lãnh Đạo xem danh sách CV đang **"Chờ duyệt"**.
   - Thêm các nút:
     - **Duyệt**: Trạng thái -> **"Đã duyệt"**.
     - **Từ chối**: Trạng thái -> **"Bị từ chối"**.
     - **Yêu cầu chỉnh sửa**: Hiển thị ô nhập `GhiChu` (lý do sửa), Trạng thái -> **"Yêu cầu chỉnh sửa"**. Khi này, hệ thống sẽ đẩy CV lại cho nhân viên.
5. **Luồng Văn Thư: Phát Hành**
   - Lọc phân loại hiển thị các CV ở trạng thái **"Đã duyệt"** cho Văn Thư.
   - Giao diện có form để nhập **Ngày gửi (Ngày phát hành)** và **Nơi nhận**.
   - Cập nhật thông tin và đổi trạng thái tới -> **"Đã phát hành"**.
6. **Hoàn thiện List Quản Lý CV Đi** *(Cập nhật `formCongVanDiList`)*
   - Thêm `DateTimePicker` (Tu ngày - Đến ngày) để lọc danh sách theo Khoảng Thời Gian.
   - Thêm Textbox `Tìm kiếm` chung.
   - Bổ sung logic Sửa/Xóa CV: chặn Xóa/Sửa đối với nhưng CV đã ở trạng thái **Đã phát hành**.

**Relevant files**
- [DTO/CongVanDi.cs](DTO/CongVanDi.cs) — Thêm trường `GhiChu`, `NguoiDuyetId`.
- [DAL/CongVanDiDAL.cs](DAL/CongVanDiDAL.cs) — Cập nhật các câu Query Insert/Update/Get tương ứng với luồng phê duyệt.
- [UI/formCongVanDiCreate.cs](UI/formCongVanDiCreate.cs) — Thêm UI cho chức năng gửi Lãnh Đạo và Update luồng trạng thái (`Soạn thảo`, `Chờ duyệt`...).
- [UI/formCongVanDiList.cs](UI/formCongVanDiList.cs) — Cập nhật tính năng search, Date Range Picker và quản lý danh sách.
- [UI/formSendMail.cs](UI/formSendMail.cs) — Implement Service SMTP gửi mail tự động cho sếp (`SendMailToLeader(...)`).

**Verification**
1. Test lưu bình thường với thông tin sơ bộ => Database phải là trạng thái *Soạn thảo*.
2. Nhấn *Gửi duyệt* => Test email xem có tới hộp thư Lãnh đạo qua SMTP không.
3. Chức năng Lãnh đạo: Test chèn Ghi Chú và ấn *Từ chối* xem DB có thu lại logic *Yêu cầu chỉnh sửa* đúng hay không.
4. Chức năng Văn thư: Cho Văn thư duyệt => nhập vị trí => lưu => trạng thái đổi thành Đã phát hành.
5. Kiểm tra tính năng lọc list khoảng thời gian hiển thị đúng UI lưới grid.

**Decisions**
- Thêm cột `GhiChu` và `NguoiDuyetId` vào bảng Database `CongVanDi`.
- Dùng tài khoản Email App Password (như của Gmail) để hệ thống gửi tự động không gặp cấu hình giới hạn IP.