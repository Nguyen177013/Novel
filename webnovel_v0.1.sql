CREATE DATABASE WebNovel
GO
use WebNovel
go


--Table Tai Khoan
drop table TaiKhoan
create table TaiKhoan(
TaiKhoan_ma INT IDENTITY PRIMARY KEY,
TaiKhoan_tenDN varchar(50),
TaiKhoan_hoTen nvarchar(50),
TaiKhoan_matKhau nvarchar(120),
TaiKhoan_sdt varchar(12),
TaiKhoan_email nvarchar(55),
)
--Table Thể Loại
drop table TheLoai
CREATE TABLE TheLoai
(
	TheLoai_ma INT IDENTITY PRIMARY KEY,
	TheLoai_ten NVARCHAR(50) NOT NULL
)

--Table Sách
drop table Sach
CREATE TABLE Sach
(	
	Sach_ma INT IDENTITY PRIMARY KEY,			
	Sach_ten NVARCHAR(200) NOT NULL,
	Sach_TacGia NVARCHAR(100) NOT NULL,												
	Sach_ngaySanXuat DATE NOT NULL DEFAULT GETDATE(),
	Sach_anh VARCHAR(60),
	Sach_LuotDoc int,
	Sach_TinhTrang bit,
	Sach_TomTat nvarchar(max),
	Sach_gia decimal(18,0),
	TheLoai_ma int foreign key(TheLoai_ma) REFERENCES TheLoai(TheLoai_ma)	
)

--Table Nội Dung Sách
drop table NoiDungSach
create table NoiDungSach(
	NoiDungSach_ma INT IDENTITY PRIMARY KEY,
	Sach_ma int foreign key(Sach_ma) REFERENCES Sach(Sach_ma),
	NoiDungSach_Ten nvarchar(100),
	NoiDungSach_Tap int,
	NoiDungSach_NoiDung nvarchar(max),
	NoiDungSach_ngayUp date
)

--Table Sách Yêu Thích
drop table Sach_YeuThich
create table Sach_YeuThich(
	Sach_YeuThich_ma INT IDENTITY PRIMARY KEY,
	Sach_ma int foreign key(Sach_ma) REFERENCES Sach(Sach_ma),
	TaiKhoan_ma int foreign key (TaiKhoan_ma) REFERENCES TaiKhoan(TaiKhoan_ma)
)
drop table LichSu_Doc
create table LichSu_Doc(
LichSu_ma INT IDENTITY PRIMARY KEY,
TaiKhoan_ma int foreign key (TaiKhoan_ma) REFERENCES TaiKhoan(TaiKhoan_ma),
Sach_ma int foreign key(Sach_ma) REFERENCES Sach(Sach_ma),
NoiDungSach_ma int foreign key (NoiDungSach_ma) REFERENCES NoiDungSach(NoiDungSach_ma),
LichSu_dong nvarchar(100)
)
drop table ThanhToan
create table ThanhToan(
ThanhToan_ma INT IDENTITY PRIMARY KEY,
Sach_ma INT foreign key (Sach_ma) REFERENCES Sach,
TaiKhoan_ma int foreign key (TaiKhoan_ma) REFERENCES TaiKhoan(TaiKhoan_ma),
ThanhToan_ngay date
)
drop table ctThanhToan
create table ctThanhToan(
ThanhToan_ma int foreign key(ThanhToan_ma) REFERENCES ThanhToan(ThanhToan_ma),
ctThanhToan_tien decimal(18,0),
primary key(ThanhToan_ma)
)
drop table DanhGia
create table DanhGia(
Sach_ma INT foreign key (Sach_ma) REFERENCES Sach,
TaiKhoan_ma int foreign key (TaiKhoan_ma) REFERENCES TaiKhoan(TaiKhoan_ma),
DanhGia_Sao int,
DanhGia_ngay date,
primary key(TaiKhoan_ma,Sach_ma)
)
insert into TheLoai (TheLoai_ten) values(N'Drama')
insert into TheLoai (TheLoai_ten) values(N'Fantasy')
insert into TheLoai (TheLoai_ten) values(N'Tình Cảm')
insert into TheLoai (TheLoai_ten) values(N'Hành Động')
insert into TheLoai (TheLoai_ten) values(N'Echi')
insert into TheLoai (TheLoai_ten) values(N'Isekai')

insert into Sach(TheLoai_ma,Sach_ten,Sach_TacGia,Sach_anh,Sach_ngaySanXuat,Sach_LuotDoc,Sach_TinhTrang,Sach_TomTat) 
values(1,N'Hige o soru. Soshite joshi kōsei o hirou','Shimesaba','/Content/img/anh1.jpg','1/2/2018',0,1,N'
Thất tình và say xỉn, Yoshida, một nhân viên văn phòng 26 tuổi, bắt gặp một nữ sinh trung học bỏ nhà đi bụi trên đường về nhà từ quán rượu.
"Này, nhóc. JK."
"Nhóc đang làm cái quái gì ở đây vậy. Về nhà đi."
"Ông chú, cho cháu ở lại nhà qua đêm nhé."
"Nếu ông chú cho cháu ở lại thì sẽ được làm việc đó đấy."
"Nhóc không đùa như vậy được đâu."
"Cháu không đùa. Cháu ổn với điều đó."
"Vậy cho phép tôi nói rằng tôi không có hứng thú với mấy đứa nhóc."
"Hmm?"
"Vậy thì cứ cho cháu ở lại đi."')

insert into Sach(TheLoai_ma,Sach_ten,Sach_TacGia,Sach_anh,Sach_ngaySanXuat,Sach_LuotDoc,Sach_TinhTrang,Sach_TomTat) 
values(2,N'Date A Live Fragments: Date A Bullet',N'Higashide Yuuichirou','/Content/img/anh2.jpg','11/13/2020',0,1,
N'Hiện tại Lân Giới tỉnh lại, thiếu nữ đánh mất ký ức Empty, cùng Tokisaki Kurumi gặp nhau. Bị nàng mang theo tới đây, là một phòng học trong trường. 
Là vì giết nhau mà tập hợp, các thiếu nữ được xưng là Chuẩn Tinh Linh.
GO——
Chúng ta bắt đầu chiến ',0)

insert into Sach(TheLoai_ma,Sach_ten,Sach_TacGia,Sach_anh,Sach_ngaySanXuat,Sach_LuotDoc,Sach_TinhTrang,Sach_TomTat) 
values(5,N'Sau khi mối tình đầu và cũng là người bạn cùng lớp của tôi trở thành gia đình cùng nhau, bạn thời thơ ấu của tôi đang dần trở nên hư hỏng','Yayoi Shirou','/Content/img/anh4.jpg','11/2/2021',0,0,
N'
Trong trường tôi có một cô gái xinh đẹp được mệnh danh là 『Nữ thần hoa hướng dương』. Cô ấy là một chủ tịch hội học sinh được mọi người thừa nhận, một học sinh danh dự được tất cả yêu mến. Một cô gái mà gần như chẳng bao giờ nghĩ tới chuyện hẹn hò. Và rồi――cô gái ấy, dường như đã trở thành chị em một nhà với tôi.',0)

insert into Sach(TheLoai_ma,Sach_ten,Sach_TacGia,Sach_anh,Sach_ngaySanXuat,Sach_LuotDoc,Sach_TinhTrang,Sach_TomTat) 
values(6,N'Mushoku Tensei - Isekai Ittara Honki Dasu',N'Rifujin na Magonote','/Content/img/anh5.jpg','11/22/2012',0,0,N'Một otaku vô công rồi nghề 34 tuổi bị đuổi ra khỏi nhà bởi chính gia đình của mình. Nhận ra cuộc đời của bản thân đã lâm vào ngõ cụt cũng như là sự rác rưởi, vô dụng của bản thân; anh ta ước rằng phải chi bản thân khi xưa vượt qua được giai đoạn đen tối của cuộc đời thì bây giờ có lẽ mọi chuyện đã khác. Đúng vào khoảnh khắc hối tiếc đó, anh thấy 1 chiếc xe tải chạy với vận tốc lớn đang lao đến 3 học sinh trung học gần đó. Gom tất cả sức lực còn lại, anh ta cứu được 3 học sinh kia tuy nhiên lại phải bỏ mạng của chính bản thân mình dưới bánh chiếc xe tải đó. Khi mở mắt ra, anh nhận ra rằng mình đã được đầu thai ở thế giới của gươm giáo và phép thuật song hành tồn tại dưới cái tên Rudeus Greyrat. Dưới hình hài mới ở một thế giới mới, Rudeus tự khẳng định với bản thân " Lần này mình sẽ thực sự sống đến tận cùng cuộc sống này mà không hề tiếc nuối". Và như thế, cuộc hành trình của anh bắt đầu.',0)

insert into Sach(TheLoai_ma,Sach_ten,Sach_TacGia,Sach_anh,Sach_ngaySanXuat,Sach_LuotDoc,Sach_TinhTrang,Sach_TomTat) 
values(1,N'JK Haru là Gái Bán Dâm ở Thế Giới Khác','shimano','/Content/img/anh6.jpg','11/22/2012',0,0,N'Yep, là tôi đấy. Bạn hẳn đang thắc mắc vì sao tôi lại rơi vào tình cảnh đó. Không phải do tôi chọn đâu, cam đoan đấy! Mọi chuyện bắt đầu khi tên bạn cùng lớp lập dị Chiba cố cứu tôi khỏi một chiếc xe tải đang lao đến và cả hai cùng chết. Thằng ngu. Thế rồi chúng tôi được chuyển đến một thế giới khác, kiểu mà như giấc mơ thành sự thật của mấy thằng otaku ấy, đại loại vậy. Chiba thì có mấy cái năng lực cheat, còn tôi có gì? Không gì hết! Hên thật, thế là tôi phải đi bán dâm. Dù gì vẫn phải kiếm ăn mà, nhưng bởi đằng nào cũng phải làm, tôi sẽ làm cho ra ngô ra khoai. Thế giới này đối xử với phụ nữ còn tệ hơn cả thế giới cũ của tôi, nên mọi thứ cũng có hơi... khó khăn chút. Dù vậy, tôi vẫn kết bạn được với mấy đứa con gái làm cùng, và nếu tôi có thể lợi dụng được sự ngu dốt của Chiba và cảm xúc của trai tân Sumo cùng với đủ thứ bệnh hoạn mà khách hàng làm với tôi, thì chắc mọi chuyển sẽ ổn thôi mà... phải không?',0)

insert into Sach(TheLoai_ma,Sach_ten,Sach_TacGia,Sach_anh,Sach_ngaySanXuat,Sach_LuotDoc,Sach_TinhTrang,Sach_TomTat) 
values(2,N'Tanya Chiến Ký','Carlo Zen','/Content/img/anh7.jpg','10/31/2012',0,0,N'Trên tiền tuyến của cuộc chiến, có một cô gái nhỏ bé. Tóc vàng, mắt xanh và làn da trắng như gốm sứ, cô bé chỉ huy đội quân với giọng nói phát âm còn chưa rõ . Tên của cô là Tanya Degurechaff. Nhưng thực tế thì cô bé là một trong những nhân viên văn phòng ưu tú nhất của Nhật Bản, được hồi sinh trong hình hài của một bé gái sau khi đã chọc giận sinh vật bí ẩn X , kẻ tự nhận là "Thiên Chúa". Và cô gái bé bỏng này, luôn dành ưu tiên cho sự hiệu quả và sự nghiệp của mình hơn tất cả mọi thứ khác, sẽ trở thành người nguy hiểm nhất trong số các pháp sư của quân đội đế quốc...',0)


select Sach_TomTat from sach a where a.Sach_TomTat LIKE N'Thất tình và%'
select * from NoiDungSach

select AVG(a.DanhGia_Sao) AS'Danh Gia' from DanhGia a 




select SUM(b.ctThanhToan_tien),MONTH(a.ThanhToan_ngay)
from ThanhToan a, ctThanhToan b 
where YEAR(a.ThanhToan_ngay) = 2022
GROUP BY MONTH(a.ThanhToan_ngay)

select a.Sach_ten, COUNT(a.Sach_ten)
from Sach a, Sach_YeuThich b 
where a.Sach_ma = b.Sach_ma 
group by a.Sach_ten
order by COUNT(b.Sach_ma) desc

select a.Sach_ma,COUNT(a.Sach_ma) from Sach_YeuThich a
group by a.Sach_ma
order by COUNT(a.Sach_ma) desc


select a.Sach_ma, avg(a.DanhGia_Sao)
from DanhGia a 
group by a.Sach_ma
order by  avg(a.DanhGia_Sao) desc
select *
from DanhGia a 