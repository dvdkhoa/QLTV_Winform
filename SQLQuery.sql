CREATE DATABASE QLTV
GO

USE QLTV
GO

--Sach
CREATE TABLE Sach(
MaSach varchar(20) ,
TenSach varchar(50),
MaLoaiSach varchar(20),
SoLuong int,
MaTG varchar(20)
)
--LoaiSach
CREATE TABLE LoaiSach(
MaLoaiSach varchar(20),
TenLoaiSach varchar(50),
KieuSach varchar(50)
)
--Nguoi muon
CREATE TABLE NguoiMuon(
MaNM varchar(20),
TenNM varchar(50),
Lop varchar(50),
Khoa varchar(50)
)
--TacGia
CREATE TABLE TacGia(
MaTG varchar(20),
TenTG varchar(50),
)
-- Muon tra sach
CREATE TABLE MuonTraSach(
MaNM varchar(20),
MaSach varchar(20),
SoLuong int,
NgayMuon datetime,
NgayHenTra datetime,
NgayTra datetime
)

--SET KHOA
ALTER TABLE LOAISACH
MODIFY MaLoaiSach VARCHAR(20) NOT NULL
ADD CONSTRAINT pk_ls PRIMARY KEY (MaLoaiSach)

------------------------Them du lieu----------------------------
INSERT INTO LoaiSach VALUES('LS1','Tieu thuyet','khong biet')
INSERT INTO LoaiSach VALUES('LS2','Truyen tranh','khong biet')
INSERT INTO LoaiSach VALUES('LS3','Manga','khong biet')
INSERT INTO LoaiSach VALUES('LS4','Ngon tinh','khong biet')
INSERT INTO LoaiSach VALUES('LS5','Bao chi','khong biet')
INSERT INTO LoaiSach VALUES('LS6','Quang cao','khong biet')
INSERT INTO LoaiSach VALUES('LS7','Co tich','khong biet')
INSERT INTO LoaiSach VALUES('LS8','khong biet luon','khong biet')
