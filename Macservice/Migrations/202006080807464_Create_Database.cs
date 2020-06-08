namespace Macservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bangchamcong",
                c => new
                    {
                        Mabangcong = c.Int(nullable: false, identity: true),
                        Thangchamcong = c.Int(),
                        Nam = c.Int(),
                    })
                .PrimaryKey(t => t.Mabangcong);
            
            CreateTable(
                "dbo.Chitietbangcong",
                c => new
                    {
                        Machitietbangcong = c.Int(nullable: false, identity: true),
                        Manv = c.Int(),
                        Mabangcong = c.Int(),
                        Sogiolam = c.Double(),
                        Sogiolamthemngayhtuong = c.Double(),
                        Sogiolamthemngaynghi = c.Double(),
                        Sogiolamthemngayle = c.Double(),
                        Songaynghiphep = c.Double(),
                        Maphongban = c.Int(),
                    })
                .PrimaryKey(t => t.Machitietbangcong)
                .ForeignKey("dbo.Bangchamcong", t => t.Mabangcong)
                .ForeignKey("dbo.Phongban", t => t.Maphongban)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .Index(t => t.Manv)
                .Index(t => t.Mabangcong)
                .Index(t => t.Maphongban);
            
            CreateTable(
                "dbo.Phongban",
                c => new
                    {
                        Maphongban = c.Int(nullable: false, identity: true),
                        Tenphongban = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Maphongban);
            
            CreateTable(
                "dbo.Chitietphongban",
                c => new
                    {
                        Machitietphongban = c.Int(nullable: false, identity: true),
                        Manv = c.Int(),
                        Maphongban = c.Int(),
                        Tungay = c.DateTime(storeType: "date"),
                        Denngay = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Machitietphongban)
                .ForeignKey("dbo.Phongban", t => t.Maphongban)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .Index(t => t.Manv)
                .Index(t => t.Maphongban);
            
            CreateTable(
                "dbo.Thongtinnhansu",
                c => new
                    {
                        Manv = c.Int(nullable: false, identity: true),
                        Hoten = c.String(nullable: false, maxLength: 50),
                        Ngaysinh = c.DateTime(storeType: "date"),
                        SDT = c.String(maxLength: 50),
                        Gioitinh = c.String(maxLength: 50),
                        Email = c.String(maxLength: 100),
                        Dantoc = c.String(maxLength: 50),
                        Noisinh = c.String(maxLength: 250),
                        Hokhauthuongtru = c.String(maxLength: 250),
                        Noiohientai = c.String(maxLength: 250),
                        CMND = c.Int(),
                        Noicap = c.String(maxLength: 50),
                        Ngaycap = c.DateTime(storeType: "date"),
                        Maphongban = c.Int(),
                        Machucvu = c.Int(),
                        Matrinhdochuyenmon = c.Int(),
                    })
                .PrimaryKey(t => t.Manv)
                .ForeignKey("dbo.Trinhdo_chuyenmon", t => t.Matrinhdochuyenmon)
                .ForeignKey("dbo.Chucvu", t => t.Machucvu)
                .ForeignKey("dbo.Phongban", t => t.Maphongban)
                .Index(t => t.Maphongban)
                .Index(t => t.Machucvu)
                .Index(t => t.Matrinhdochuyenmon);
            
            CreateTable(
                "dbo.Chitietbaohiem",
                c => new
                    {
                        Machitietbaohiem = c.Int(nullable: false, identity: true),
                        Mabaohiem = c.Int(),
                        Manv = c.Int(),
                        Tungay = c.DateTime(storeType: "date"),
                        Denngay = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Machitietbaohiem)
                .ForeignKey("dbo.Baohiem", t => t.Mabaohiem)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .Index(t => t.Mabaohiem)
                .Index(t => t.Manv);
            
            CreateTable(
                "dbo.Baohiem",
                c => new
                    {
                        Mabaohiem = c.Int(nullable: false, identity: true),
                        Tenbaohiem = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Mabaohiem);
            
            CreateTable(
                "dbo.Chitietchucvu",
                c => new
                    {
                        Machitietchucvu = c.Int(nullable: false, identity: true),
                        Manv = c.Int(),
                        Machucvu = c.Int(),
                        Tungay = c.DateTime(storeType: "date"),
                        Denngay = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Machitietchucvu)
                .ForeignKey("dbo.Chucvu", t => t.Machucvu)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .Index(t => t.Manv)
                .Index(t => t.Machucvu);
            
            CreateTable(
                "dbo.Chucvu",
                c => new
                    {
                        Machucvu = c.Int(nullable: false, identity: true),
                        Tenchucvu = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Machucvu);
            
            CreateTable(
                "dbo.Lichtrinhcongtac",
                c => new
                    {
                        Malichtrinhcongtac = c.Int(nullable: false, identity: true),
                        Manv = c.Int(),
                        Maphongban = c.Int(),
                        Machucvu = c.Int(),
                        Matrinhdochuyenmon = c.Int(),
                        Tungay = c.DateTime(storeType: "date"),
                        Denngay = c.DateTime(storeType: "date"),
                        Noicongtac = c.String(maxLength: 50),
                        Noidungcongtac = c.String(maxLength: 250),
                        Trocap = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Malichtrinhcongtac)
                .ForeignKey("dbo.Chucvu", t => t.Machucvu)
                .ForeignKey("dbo.Phongban", t => t.Maphongban)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .ForeignKey("dbo.Trinhdo_chuyenmon", t => t.Matrinhdochuyenmon)
                .Index(t => t.Manv)
                .Index(t => t.Maphongban)
                .Index(t => t.Machucvu)
                .Index(t => t.Matrinhdochuyenmon);
            
            CreateTable(
                "dbo.Trinhdo_chuyenmon",
                c => new
                    {
                        Matrinhdochuyenmon = c.Int(nullable: false, identity: true),
                        Tentrinhdochuyenmon = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Matrinhdochuyenmon);
            
            CreateTable(
                "dbo.Chitiettrinhdo_chuyenmon",
                c => new
                    {
                        Machitiettrinhdo_chuyenmon = c.Int(nullable: false, identity: true),
                        Manv = c.Int(),
                        Matrinhdochuyenmon = c.Int(),
                        Tungay = c.DateTime(storeType: "date"),
                        Denngay = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Machitiettrinhdo_chuyenmon)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .ForeignKey("dbo.Trinhdo_chuyenmon", t => t.Matrinhdochuyenmon)
                .Index(t => t.Manv)
                .Index(t => t.Matrinhdochuyenmon);
            
            CreateTable(
                "dbo.Quatrinhluong",
                c => new
                    {
                        Maquatrinhluong = c.Int(nullable: false, identity: true),
                        Manv = c.Int(),
                        Maphongban = c.Int(),
                        Machucvu = c.Int(),
                        Thoigian = c.DateTime(storeType: "date"),
                        Luongcoban = c.Decimal(precision: 18, scale: 0),
                        Trocapchucvu = c.Decimal(precision: 18, scale: 0),
                        Phucapkhac = c.Decimal(precision: 18, scale: 0),
                        Noidung = c.String(maxLength: 50),
                        Luongdoanhso = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Maquatrinhluong)
                .ForeignKey("dbo.Chucvu", t => t.Machucvu)
                .ForeignKey("dbo.Phongban", t => t.Maphongban)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .Index(t => t.Manv)
                .Index(t => t.Maphongban)
                .Index(t => t.Machucvu);
            
            CreateTable(
                "dbo.Chitietkhenthuong",
                c => new
                    {
                        Machitietkhenthuong = c.Int(nullable: false, identity: true),
                        Manv = c.Int(),
                        Makhenthuong = c.Int(),
                        Lydokhenthuong = c.String(maxLength: 250),
                        Tienthuong = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Machitietkhenthuong)
                .ForeignKey("dbo.Khenthuong", t => t.Makhenthuong)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .Index(t => t.Manv)
                .Index(t => t.Makhenthuong);
            
            CreateTable(
                "dbo.Khenthuong",
                c => new
                    {
                        Makhenthuong = c.Int(nullable: false, identity: true),
                        Tenkhenthuong = c.String(maxLength: 50),
                        Noidung = c.String(maxLength: 250),
                        Quyetdinh = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Makhenthuong);
            
            CreateTable(
                "dbo.Chitietkyluat",
                c => new
                    {
                        Machitietkyluat = c.Int(nullable: false, identity: true),
                        Manv = c.Int(),
                        Makyluat = c.Int(),
                        Lydokyluat = c.String(maxLength: 50),
                        Tienphat = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Machitietkyluat)
                .ForeignKey("dbo.Kyluat", t => t.Makyluat)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .Index(t => t.Manv)
                .Index(t => t.Makyluat);
            
            CreateTable(
                "dbo.Kyluat",
                c => new
                    {
                        Makyluat = c.Int(nullable: false, identity: true),
                        Tenkyluat = c.String(maxLength: 50),
                        Noidung = c.String(maxLength: 250),
                        Quyetdinh = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Makyluat);
            
            CreateTable(
                "dbo.Hopdong",
                c => new
                    {
                        Mahopdong = c.Int(nullable: false, identity: true),
                        Manv = c.Int(),
                        Maloaihopdong = c.Int(),
                        Ngaykiket = c.DateTime(storeType: "date"),
                        Ngayketthuc = c.DateTime(storeType: "date"),
                        Luongcoban = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.Mahopdong)
                .ForeignKey("dbo.Loaihopdong", t => t.Maloaihopdong)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .Index(t => t.Manv)
                .Index(t => t.Maloaihopdong);
            
            CreateTable(
                "dbo.Loaihopdong",
                c => new
                    {
                        Maloaihopdong = c.Int(nullable: false, identity: true),
                        Tenloaihopdong = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Maloaihopdong);
            
            CreateTable(
                "dbo.Nghiphep",
                c => new
                    {
                        Manghiphep = c.Int(nullable: false, identity: true),
                        Manv = c.Int(),
                        Ngaynghi = c.DateTime(storeType: "date"),
                        Thoigiannghi = c.Double(),
                        Lydo = c.String(maxLength: 50),
                        Nghicoluong = c.Boolean(),
                        Nghỉkhongluong = c.Boolean(),
                    })
                .PrimaryKey(t => t.Manghiphep)
                .ForeignKey("dbo.Thongtinnhansu", t => t.Manv)
                .Index(t => t.Manv);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.Taikhoan",
                c => new
                    {
                        Mataikhoan = c.Int(nullable: false, identity: true),
                        Tendangnhap = c.String(maxLength: 50),
                        Matkhau = c.String(maxLength: 50),
                        Phanquyen = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Mataikhoan);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thongtinnhansu", "Maphongban", "dbo.Phongban");
            DropForeignKey("dbo.Nghiphep", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Hopdong", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Hopdong", "Maloaihopdong", "dbo.Loaihopdong");
            DropForeignKey("dbo.Chitietphongban", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Chitietkyluat", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Chitietkyluat", "Makyluat", "dbo.Kyluat");
            DropForeignKey("dbo.Chitietkhenthuong", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Chitietkhenthuong", "Makhenthuong", "dbo.Khenthuong");
            DropForeignKey("dbo.Chitietchucvu", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Thongtinnhansu", "Machucvu", "dbo.Chucvu");
            DropForeignKey("dbo.Quatrinhluong", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Quatrinhluong", "Maphongban", "dbo.Phongban");
            DropForeignKey("dbo.Quatrinhluong", "Machucvu", "dbo.Chucvu");
            DropForeignKey("dbo.Thongtinnhansu", "Matrinhdochuyenmon", "dbo.Trinhdo_chuyenmon");
            DropForeignKey("dbo.Lichtrinhcongtac", "Matrinhdochuyenmon", "dbo.Trinhdo_chuyenmon");
            DropForeignKey("dbo.Chitiettrinhdo_chuyenmon", "Matrinhdochuyenmon", "dbo.Trinhdo_chuyenmon");
            DropForeignKey("dbo.Chitiettrinhdo_chuyenmon", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Lichtrinhcongtac", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Lichtrinhcongtac", "Maphongban", "dbo.Phongban");
            DropForeignKey("dbo.Lichtrinhcongtac", "Machucvu", "dbo.Chucvu");
            DropForeignKey("dbo.Chitietchucvu", "Machucvu", "dbo.Chucvu");
            DropForeignKey("dbo.Chitietbaohiem", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Chitietbaohiem", "Mabaohiem", "dbo.Baohiem");
            DropForeignKey("dbo.Chitietbangcong", "Manv", "dbo.Thongtinnhansu");
            DropForeignKey("dbo.Chitietphongban", "Maphongban", "dbo.Phongban");
            DropForeignKey("dbo.Chitietbangcong", "Maphongban", "dbo.Phongban");
            DropForeignKey("dbo.Chitietbangcong", "Mabangcong", "dbo.Bangchamcong");
            DropIndex("dbo.Nghiphep", new[] { "Manv" });
            DropIndex("dbo.Hopdong", new[] { "Maloaihopdong" });
            DropIndex("dbo.Hopdong", new[] { "Manv" });
            DropIndex("dbo.Chitietkyluat", new[] { "Makyluat" });
            DropIndex("dbo.Chitietkyluat", new[] { "Manv" });
            DropIndex("dbo.Chitietkhenthuong", new[] { "Makhenthuong" });
            DropIndex("dbo.Chitietkhenthuong", new[] { "Manv" });
            DropIndex("dbo.Quatrinhluong", new[] { "Machucvu" });
            DropIndex("dbo.Quatrinhluong", new[] { "Maphongban" });
            DropIndex("dbo.Quatrinhluong", new[] { "Manv" });
            DropIndex("dbo.Chitiettrinhdo_chuyenmon", new[] { "Matrinhdochuyenmon" });
            DropIndex("dbo.Chitiettrinhdo_chuyenmon", new[] { "Manv" });
            DropIndex("dbo.Lichtrinhcongtac", new[] { "Matrinhdochuyenmon" });
            DropIndex("dbo.Lichtrinhcongtac", new[] { "Machucvu" });
            DropIndex("dbo.Lichtrinhcongtac", new[] { "Maphongban" });
            DropIndex("dbo.Lichtrinhcongtac", new[] { "Manv" });
            DropIndex("dbo.Chitietchucvu", new[] { "Machucvu" });
            DropIndex("dbo.Chitietchucvu", new[] { "Manv" });
            DropIndex("dbo.Chitietbaohiem", new[] { "Manv" });
            DropIndex("dbo.Chitietbaohiem", new[] { "Mabaohiem" });
            DropIndex("dbo.Thongtinnhansu", new[] { "Matrinhdochuyenmon" });
            DropIndex("dbo.Thongtinnhansu", new[] { "Machucvu" });
            DropIndex("dbo.Thongtinnhansu", new[] { "Maphongban" });
            DropIndex("dbo.Chitietphongban", new[] { "Maphongban" });
            DropIndex("dbo.Chitietphongban", new[] { "Manv" });
            DropIndex("dbo.Chitietbangcong", new[] { "Maphongban" });
            DropIndex("dbo.Chitietbangcong", new[] { "Mabangcong" });
            DropIndex("dbo.Chitietbangcong", new[] { "Manv" });
            DropTable("dbo.Taikhoan");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Nghiphep");
            DropTable("dbo.Loaihopdong");
            DropTable("dbo.Hopdong");
            DropTable("dbo.Kyluat");
            DropTable("dbo.Chitietkyluat");
            DropTable("dbo.Khenthuong");
            DropTable("dbo.Chitietkhenthuong");
            DropTable("dbo.Quatrinhluong");
            DropTable("dbo.Chitiettrinhdo_chuyenmon");
            DropTable("dbo.Trinhdo_chuyenmon");
            DropTable("dbo.Lichtrinhcongtac");
            DropTable("dbo.Chucvu");
            DropTable("dbo.Chitietchucvu");
            DropTable("dbo.Baohiem");
            DropTable("dbo.Chitietbaohiem");
            DropTable("dbo.Thongtinnhansu");
            DropTable("dbo.Chitietphongban");
            DropTable("dbo.Phongban");
            DropTable("dbo.Chitietbangcong");
            DropTable("dbo.Bangchamcong");
        }
    }
}
