namespace giải_pháp;

interface Ổ_Cắm {
    void Cắm(Nguồn_Điện có_điện);

    void Tháo();
}

interface Nguồn_Điện {
    bool Có_Điện();

    void Tháo(Ổ_Cắm ổ_cắm);

    void Cắm(Ổ_Cắm ổ_cắm);
}

class Máy_Phát_Điện_Gió : Nguồn_Điện {
    const bool PHÁT = true;
    const bool NGƯNG = false;

    private readonly IList<Ổ_Cắm> danh_sách_ổ_cắm
        = new List<Ổ_Cắm>();

    private bool trạng_thái;

    public void Cắm(Ổ_Cắm ổ_cắm) {
        if (danh_sách_ổ_cắm.Contains(ổ_cắm)) return;
        danh_sách_ổ_cắm.Add(ổ_cắm);

        ổ_cắm.Cắm(this);
    }

    public void Tháo(Ổ_Cắm ổ_cắm) {
        if (!danh_sách_ổ_cắm.Contains(ổ_cắm)) return;
        danh_sách_ổ_cắm.Remove(ổ_cắm);

        ổ_cắm.Tháo();
    }

    public void Phát_Điện() {
        trạng_thái = PHÁT;

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Bắt đầu phát điện");
        Console.ResetColor();
    }

    public void Hiển_Thị_Thiết_Bị() {
        Console.WriteLine("=====Danh sách thiết bị=====");
        foreach (var ổ_cắm in danh_sách_ổ_cắm) {
            Console.WriteLine(ổ_cắm);
        }
        Console.WriteLine("==========");
    }

    public void Dừng() {
        trạng_thái = NGƯNG;

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Dừng phát điện");
        Console.ResetColor();
    }

    public bool Có_Điện()
    {
        return trạng_thái;   
    }
}

class Bóng_Điện : Ổ_Cắm {
    const bool BẬT = true;
    const bool TẮT = false;

    bool trạng_thái = TẮT;

    public string Trạng_Thái_Bằng_Chữ 
        => trạng_thái == TẮT
            ? nameof(TẮT)
            : nameof(BẬT);
    
    public Guid Id { get; init; }

    public Bóng_Điện() => Id = Guid.NewGuid();

    public void Bật() {
        trạng_thái = BẬT;

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Đèn-{Id}: {Trạng_Thái_Bằng_Chữ}");
        Console.ResetColor();
    }

    public void Tắt() {
        trạng_thái = TẮT;

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Đèn-{Id}: {Trạng_Thái_Bằng_Chữ}");
        Console.ResetColor();
    }

    private Nguồn_Điện? nguồn_điện;
    public void Cắm(Nguồn_Điện nguồn_điện)
    {
        nguồn_điện.Cắm(this);
        
        this.nguồn_điện = nguồn_điện;

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"Đèn-{Id}: Được cắm");
        Console.ResetColor();
    }

    public override string ToString()
    {
        var trạng_thái_có_điện = nguồn_điện?.Có_Điện() == true
            ? "CÓ ĐIỆN"
            : "KHÔNG CÓ ĐIỆN";

        return $"Đèn-{Id}: {Trạng_Thái_Bằng_Chữ} . {trạng_thái_có_điện}";
    }

    public void Tháo()
    {
        nguồn_điện?.Tháo(this);

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"Đèn-{Id}: Được tháo");
        Console.ResetColor();
        nguồn_điện = null;
    }
}