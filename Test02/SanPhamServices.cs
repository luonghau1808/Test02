namespace Test02
{
    public class SanPhamServices
    {
        private List<SanPham> ds = new List<SanPham>()
        {
            new SanPham{Ma = "SP001", Ten = "Laptop Dell XPS 13", NamBaoHanh = 24, Gia = 1500, SoLuong = 10, DanhMuc = "Laptop"},
            new SanPham{Ma = "SP002", Ten = "Điện thoại Samsung Galaxy S21", NamBaoHanh = 12, Gia = 800, SoLuong = 20, DanhMuc = "Điện thoại" }
    };
        public bool KiemTraMaDaTonTai  (string ma) => ds.Any(x=>x.Ma == ma) ;
        public bool SuaSanPham(SanPham sp)
        {
            if (sp == null || string.IsNullOrWhiteSpace(sp.Ma)) return false;

            var spCu = ds.FirstOrDefault(x => x.Ma == sp.Ma);
            if (spCu == null)
                return false;

            if (sp.Gia < 0 || sp.SoLuong < 0) return false;

            spCu.Ten = sp.Ten;
            spCu.Gia = sp.Gia;
            spCu.SoLuong = sp.SoLuong;
            spCu.NamBaoHanh = sp.NamBaoHanh;
            spCu.DanhMuc = sp.DanhMuc ?? spCu.DanhMuc;

            return true;
        }
        public SanPham? GetByMa(string ma)
        {
            return ds.FirstOrDefault(x => x.Ma == ma);
        }


    }
}
