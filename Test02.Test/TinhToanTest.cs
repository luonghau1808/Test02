namespace Test02.Test
{
    [TestFixture]
    internal class TinhToanTest
    {
        private TinhToan tinhtoan = null;

        [SetUp]
        public void Setup()
        {
            tinhtoan = new TinhToan();
        }

        // =========================
        // PHÂN VÙNG TƯƠNG ĐƯƠNG (EP)
        // =========================

        // EP - Nhóm hợp lệ: số chẵn dương
        [Test]
        public void Chan_Duong()
            => Assert.That(tinhtoan.KiemTraChanLe(2), Is.True);

        // EP - Nhóm không hợp lệ: số lẻ dương
        [Test]
        public void Le_Duong()
            => Assert.That(tinhtoan.KiemTraChanLe(1), Is.False);

        // EP - Nhóm hợp lệ: số chẵn âm
        [Test]
        public void Chan_Am()
            => Assert.That(tinhtoan.KiemTraChanLe(-2), Is.True);

        // EP - Nhóm không hợp lệ: số lẻ âm
        [Test]
        public void Le_Am()
            => Assert.That(tinhtoan.KiemTraChanLe(-9), Is.False);

        // =========================
        // PHÂN VÙNG BIÊN (BV)
        // =========================

        // BV - Giá trị biên giữa số âm và số dương
        // 0 là trường hợp đặc biệt và là số chẵn
        [Test]
        public void So0_Chan()
            => Assert.That(tinhtoan.KiemTraChanLe(0), Is.True);

    }
}
