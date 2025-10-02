# Homework/Day06 (Validate - Anotation)

## Yêu cầu

Sinh viên Tạo dự án Net Core MVC mới hoặc kế thừa các bài trúc

Khai báo 2 model là Category (Danh mục) và Product (Sản phẩm)

Model Category gồm

- int Id, string Name

Model Product gồm

- int Id, string Name, string Image, float Price, float SalePrice, string Description

**Tất cả các thuộc tính bắt buộc nhập, ngoài ra validate thêm:**

Thuộc tính Name ít nhất là 6 ký tự, nhiều nhất là 150 ký tự.

Thuộc tính Price phải nhỏ hơn 100000, kiểu dữ liệu text.

Thuộc tính SalePrice không âm và phải nhỏ hơn giá chuẩn 10%.

Thuộc tính Image phải được chọn và upload vào thư mục wwwroot/products.

Thuộc tính CategoryId phải có trong danh sách là các đối tượng của Category gồm các thuộc tính: int Id, string Name.

Thuộc tính Description không vượt quá 1500 ký tự, không chứa các từ nhạy cảm (tùy chọn, VD: die, admin, fack...)

Tiếp theo sinh viên thực hiện CRUD (Create, Read, Update, Delete): danh sách, form thêm mới, form chỉnh sửa, xem chi tiết, xóa... cho Model Product.

Trên form có mục (CategoryId) được chọn từ ComboBox (Select option) là các đối tượng của Category trên.

**Lưu ý**: nội dung các tin nhắn thông báo lỗi phải được thông báo bằng tiếng Việt rõ ràng và dễ hiểu.

## Chạy

```bash
dotnet run
```