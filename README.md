# 5_PVPhongNTThangLTTrungNATu_THLTNET

## Hướng dẫn Generate Script File SQL và Import SQL File

Tạo script file SQL từ cơ sở dữ liệu để lấy data mới nhất sau đó tìm vào sửa data các câu lệnh insert (không sửa design table):

1. Mở SQL Server Management Studio (SSMS).
2. Kết nối đến cơ sở dữ liệu.
3. Right click on the database in SQL Server Management Studio
4. Tasks -> Generate Scripts
5. Script entire database and all database objects
6. Next
7. Click - Advanced
8. Scroll down to Types of data to script and set from Schema only -> Schema and data -> Ok
9. Save as script file (name it and save it where you want it)
10. Next
10. Next

Để import SQL file vào cơ sở dữ liệu:

1. Mở SQL Server Management Studio (SSMS).
2. Bấm Ctr + O hoặc Open file, tìm đến file sql
3. Bấm execute hoặc F5