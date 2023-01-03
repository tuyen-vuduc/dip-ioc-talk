namespace ví_dụ_2;

class Nguồn_Điện {
    Bóng_Điện bóng_điện;

    public Nguồn_Điện() {
        bóng_điện = new Bóng_Điện();
    }

    public void Phát_Điện() {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Phát điện");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Đèn sáng");
        
        Console.ResetColor();
    }

    public void Dừng() {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Dừng phát điện");
        
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Đèn tắt");

        Console.ResetColor();
    }
}

class Bóng_Điện {
    // const bool BẬT = true;
    // const bool TẮT = false;

    // bool trạng_thái = TẮT;

    // public string Trạng_Thái_Bằng_Chữ 
    //     => trạng_thái == TẮT
    //         ? nameof(TẮT)
    //         : nameof(BẬT);
    
    // public void Bật() {
    //     trạng_thái = BẬT;

    //     Console.ForegroundColor = ConsoleColor.DarkGreen;
    //     Console.WriteLine($"Đèn: {Trạng_Thái_Bằng_Chữ}");
    //     Console.ResetColor();
    // }

    // public void Tắt() {
    //     trạng_thái = TẮT;

    //     Console.ForegroundColor = ConsoleColor.DarkGreen;
    //     Console.WriteLine($"Đèn: {Trạng_Thái_Bằng_Chữ}");
    //     Console.ResetColor();
    // }
}