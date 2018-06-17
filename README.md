 <h><img src="https://scontent.fsgn3-1.fna.fbcdn.net/v/t1.0-9/35525254_656148371391663_6837399850024173568_n.jpg?_nc_cat=0&oh=5173f5e1d9cf4791e031a2946766f2e2&oe=5BA0747C"></h>
 
 # ỨNG DỤNG LAN CHAT
 <p>
 Hiện nay các phòng máy tại trường Đại học công nghệ thông tin, nhóm thấy được sự bất tiện khi cần phải nộp bài cho thầy qua kênh học tập moodle, gữi file giữa các sinh viên và trao đổi trong khi học vì mạng trường không ổn định khi đi ra internet và khi trao đổi thường gây ra sự khó chịu cho những người xung quanh.
 
 Để giải quyết sự khó khăn và những bất cập trên, nhóm quyết định chọn thực hiện ứng dụng Lan Chat vì những ưu điểm sau: tiết kiệm băng thông ra internet, tốc độ cao hơn so với các ứng dụng chat online, khả năng bảo mật cao vì dữ liệu không được di chuyển ra ngoài internet phù hợp với các mô hình tổ chức cục bộ như các phòng máy trong các trường học, các phòng ban trong cơ quan xí nghiệp, công ty.</p>
 # Chức năng chính
 - Chat riêng giữa hai người
 - Gởi file 
 - Xem lịch sử chat riêng
 - Cập nhập avatar
 - Tạo nhóm chat
 - Chat nhóm
 - xem lịch sử chat nhóm
 # Kiến thức áp dụng
 - Ngôn ngữ lập trình C#
 - Winform
 - Kết nối SQL server với ứng dụng winform
 - Chuyển data giữa các form
 - Phân quyền người dùng trên ứng dụng
 - kết nối client, server
 - Truyền, nhận dữ liệu qua lại giữa các client , server 
 # Nền tản xây dựng
<h4>- Sơ lượt về C#.Net, SQl server và mô hình MVC:</h4>
<ul><h4>C#.Net</h4>

<p>C#, theo một hướng nào đó, là ngôn ngữ lập trình phản ánh trực tiếp nhất đến.NET Framework mà tất cả các chương trình.NET chạy, và nó phụ thuộc mạnh mẽ vào Framework này. Mọi dữ liệu cơ sở đều là đối tượng, được cấp phát và hủy bỏ bởi trình dọn rác Garbage-Collector (GC), và nhiều kiểu trừu tượng khác chẳng hạn như class, delegate, interface, exception, v.v, phản ánh rõ ràng những đặc trưng của.NET runtime.</p>
<p>Mọi thứ trong C# đều Object oriented. Kể cả kiểu dữ liệu cơ bản. Chỉ cho phép đơn kế thừa. Dùng interface để khắc phục. Lớp Object là cha của tất cả các lớp. Mọi lớp đều dẫn xuất từ Object. Cho phép chia chương trình thành các thành phần nhỏ độc lập nhau. Mỗi lớp gói gọn trong một file, không cần file header như C/C++. Bổ sung khái niệm namespace để gom nhóm các lớp. Bổ sung khái niệm “property” cho các lớp. Khái niệm delegate & event</p>
<p>.NET runtime sẽ phổ biến và được cài trong máy client. Việc cài đặt App C# như là tái phân phối các thành phần .NET Nhiều App thương mại sẽ được cài đặt bằng C#.</p>
<p>C# tạo cơ hội cho tổ chức xây dựng các App Client/Server n-tier. Kết nối ADO.NET cho phép truy cập nhanh chóng & dễ dàng với SQL Server, Oracle… Cách tổ chức .NET cho phép hạn chế những vấn đề phiên bản.</p>
</ul>

<ul><h4>SQL server</h4>
<p>Hệ quản trị cơ sở dữ liệu SQL Server là một hệ thống quản lý cơ sở dữ liệu (Relational Database Management Server System (RDBMS)) sử dụng Transact-SQL để trao đổi dữ liệu giữa Client computer và SQL server computer. Một RDBMS bao gồm database, database angine và các ứng dụng dùng để quản lý dữ liệu và các bộ phận khác nhau trong RDBMS. SQL server được tối ưu để có thể chạy trên môi trường cơ sở dữ liệu rất lớn lên đến TB và cso thể phụ vụ cùng lúc chô hàng ngàn user. Transact-SQL (còn gọi là T-SQL) là một ngôn ngữ lập trình database hướng thủ tục độc quyền của Microsoft sử dụng trong SQL Server. Ngôn ngữ thủ tục được thiết kế để mở rộng khả năng của SQL trong khi có khả năng tích hợp tốt với SQL. Một số tính năng như các biến địa phương và xử lý chuỗi/dữ liệu được thêm vào.</p>
</ul>
<ul><h4>Mô hình MVC</h4> 
<p>MVC là viết tắt của Model – View – Controller. Là một kiến trúc phần mềm hay mô hình thiết kế được sử dụng trong kỹ thuật phần mềm. Nói cho dễ hiểu, nó là mô hình phân bố source code thành 3 phần, mỗi thành phần có một nhiệm vụ riêng biệt và độc lập với các thành phần khác.<p>
	- Controller
<p>Giữ nhiệm vụ nhận điều hướng các yêu cầu từ người dùng và gọi đúng những phương thức xử lý chúng… Chẳng hạn thành phần này sẽ nhận request từ url và form để thao tác trực tiếp với Model.</p>
	- Model
<p>Đây là thành phần chứa tất cả các nghiệp vụ logic, phương thức xử lý, truy xuất database, đối tượng mô tả dữ liệu như các Class, hàm xử lý…</p>
	- View
<p>Đảm nhận việc hiển thị thông tin, tương tác với người dùng, nơi chứa tất cả các đối tượng GUI như textbox, images… Hiểu một cách đơn giản, nó là tập hợp các form hoặc các file HTML.</p>
</ul>
 <h4>- Nền tản xây dựng:</h4>
<ul>
 <p>-Visual studio 2017</p>
 <p>-SQL server 2014</p>
 </ul>


# Môi trường cài đặt
- Phần mềm chạy được trên những máy tính có cấu hình từ trung bình trở lên, và không yêu cầu quá cao vào phần cứng


# Thành viên
- Nguyễn Bảo Duy	 (***14520219@gm.uit.edu.vn***)
- Hoàng Thùy Trang (***16521277@gm.uit.edu.vn***)
- Trần Thị Thu Tình (***16521250@gm.uit.edu.vn***)


