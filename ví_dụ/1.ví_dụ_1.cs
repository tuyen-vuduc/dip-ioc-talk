namespace ví_dụ_1;

class Nguồn_Điện {
    public void Phát_Điện() {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Bắt đầu phát điện");
        Console.ResetColor();
    }

    public void Dừng() {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Dừng phát điện");
        Console.ResetColor();
    }
}

class Bóng_Điện {
    const bool BẬT = true;
    const bool TẮT = false;

    Nguồn_Điện nguồn_điện;

    bool trạng_thái = TẮT;

    public Bóng_Điện()
    {
        nguồn_điện = new Nguồn_Điện();
    }



    public void Bật_Tắt() {
        trạng_thái = trạng_thái == TẮT
            ? BẬT
            : TẮT;

        var trạng_thái_bằng_chữ = trạng_thái == TẮT
            ? nameof(TẮT)
            : nameof(BẬT);
        

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Đèn: {trạng_thái_bằng_chữ}");
        Console.ResetColor();

        if (trạng_thái == TẮT) {
            nguồn_điện.Dừng();
        } else {
            nguồn_điện.Phát_Điện();
        }
    }
}
