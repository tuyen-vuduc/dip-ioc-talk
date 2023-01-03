Console.WriteLine("Ví dụ về sự phụ thuộc");

// // Ví dụ 1
// var bóng_điện = new ví_dụ_1.Bóng_Điện();

// bóng_điện.Bật_Tắt();

// await Task.Delay(5000);

// bóng_điện.Bật_Tắt();















































// // Ví dụ 2
// var nguồn_điện = new ví_dụ_2.Nguồn_Điện();

// nguồn_điện.Phát_Điện();

// await Task.Delay(5000);

// nguồn_điện.Dừng();









































// Giải pháp
var nguồn_điện = new giải_pháp.Máy_Phát_Điện_Gió();
var bóng_điện1 = new giải_pháp.Bóng_Điện();
var bóng_điện2 = new giải_pháp.Bóng_Điện();
var bóng_điện3 = new giải_pháp.Bóng_Điện();

bóng_điện2.Bật();

nguồn_điện.Cắm(bóng_điện1);
nguồn_điện.Cắm(bóng_điện2);
nguồn_điện.Cắm(bóng_điện3);

nguồn_điện.Phát_Điện();

nguồn_điện.Hiển_Thị_Thiết_Bị();

bóng_điện2.Tắt();

nguồn_điện.Hiển_Thị_Thiết_Bị();

bóng_điện1.Bật();

nguồn_điện.Hiển_Thị_Thiết_Bị();

nguồn_điện.Tháo(bóng_điện2);

nguồn_điện.Hiển_Thị_Thiết_Bị();

Console.WriteLine(bóng_điện2);

nguồn_điện.Cắm(bóng_điện2);

bóng_điện1.Tháo();

nguồn_điện.Hiển_Thị_Thiết_Bị();
