using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Test02.Test
{
    [TestFixture]
    public class SanPhamServicesTest
    {
        private SanPhamServices _svc = null;

        [SetUp]
        public void SetUp() => _svc = new SanPhamServices();

        // =========================
        // KIEM TRA MA TON TAI
        // =========================

        // EP - Phân vùng tương đương hợp lệ:
        // Mã sản phẩm tồn tại trong hệ thống
        [Test]
        public void KiemTraMaDaTonTai_True()
            => Assert.That(_svc.KiemTraMaDaTonTai("SP001"), Is.True);

        // EP - Phân vùng tương đương không hợp lệ:
        // Mã sản phẩm không tồn tại
        [Test]
        public void KiemTraMaDaTonTai_False()
            => Assert.That(_svc.KiemTraMaDaTonTai("SP99"), Is.False);
        // =========================
        // SUA SAN PHAM THANH CONG
        // =========================

        // EP - Dữ liệu hợp lệ (valid partition)
        // Tất cả thuộc tính đúng -> cập nhật thành công
        [Test]
        public void SuaSanPham_ThanhCong()
        {
            var sp = new SanPham
            {
                Ma = "SP001",
                Ten = "Laptop Dell XPS 15",
                NamBaoHanh = 36,
                Gia = 2000,
                SoLuong = 5,
                DanhMuc = "Laptop"
            };

            var ok = _svc.SuaSanPham(sp);

            Assert.That(ok, Is.True);

            var after = _svc.GetByMa("SP001");

            Assert.That(after.Ten, Is.EqualTo("Laptop Dell XPS 15"));
            Assert.That(after.NamBaoHanh, Is.EqualTo(36));
            Assert.That(after.Gia, Is.EqualTo(2000));
            Assert.That(after.SoLuong, Is.EqualTo(5));
        }

        // =========================
        // CAC TRUONG HOP THAT BAI
        // =========================

        // EP - Phân vùng không hợp lệ:
        // Mã sản phẩm không tồn tại
        [Test]
        public void SuaSanPham_ThatBai_MaKhongTonTai()
        {
            var sp = new SanPham
            {
                Ma = "SP99",
                Ten = "Laptop Dell XPS 15",
                NamBaoHanh = 36,
                Gia = 2000,
                SoLuong = 5,
                DanhMuc = "Laptop"
            };

            Assert.That(_svc.SuaSanPham(sp), Is.False);
        }

        // BV - Phân vùng biên thấp:
        // Giá < 0 (vượt biên dưới hợp lệ)
        [Test]
        public void SuaSanPham_ThatBai_GiaAm()
        {
            var sp = new SanPham
            {
                Ma = "SP001",
                Ten = "Laptop Dell XPS 15",
                NamBaoHanh = 36,
                Gia = -2000,
                SoLuong = 5,
                DanhMuc = "Laptop"
            };

            Assert.That(_svc.SuaSanPham(sp), Is.False);
        }

        // BV - Phân vùng biên thấp:
        // Số lượng < 0 (ngoài miền giá trị cho phép)
        [Test]
        public void SuaSanPham_ThatBai_SoLuongAm()
        {
            var sp = new SanPham
            {
                Ma = "SP001",
                Ten = "Laptop Dell XPS 15",
                NamBaoHanh = 36,
                Gia = 2000,
                SoLuong = -5,
                DanhMuc = "Laptop"
            };

            Assert.That(_svc.SuaSanPham(sp), Is.False);
        }

        // EP - Phân vùng không hợp lệ:
        // Input null hoặc mã rỗng
        [Test]
        public void SuaSanPham_ThatBai_MaRong()
        {
            Assert.That(_svc.SuaSanPham(null!), Is.False);

            Assert.That(
                _svc.SuaSanPham(new SanPham
                {
                    Ma = "",
                    Ten = "Laptop Dell XPS 15",
                    NamBaoHanh = 36,
                    Gia = 2000,
                    SoLuong = 5,
                    DanhMuc = "Laptop"
                }),
                Is.False);
        }
    }
}