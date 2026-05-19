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