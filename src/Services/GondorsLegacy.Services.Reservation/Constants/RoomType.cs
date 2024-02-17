namespace GondorsLegacy.Services.Reservation.Constants;
public record RoomType(int Value, string Description)
{
    public static RoomType Standard { get; } = new RoomType(1, "Standart oda tipi, temel konfora sahip.");
    public static RoomType Deluxe { get; } = new RoomType(2, "Deluxe oda tipi, lüks ve ekstra olanaklara sahip.");
    public static RoomType Suite { get; } = new RoomType(3, "Süit oda tipi, geniş ve lüks alanlar sunar.");
    public static RoomType Villa { get; } = new RoomType(4, "Villa oda tipi, genellikle bağımsız ve lüks bir konaklama birimi.");
    public static RoomType Family { get; } = new RoomType(5, "Aile oda tipi, büyük aileler veya gruplar için uygun.");
    public static RoomType Business { get; } = new RoomType(6, "İş oda tipi, iş seyahatleri için uygun, çalışma alanlarına sahip.");
    public static RoomType SeaView { get; } = new RoomType(7, "Deniz manzaralı oda tipi, deniz manzaralı odalar için.");
    public static RoomType PoolView { get; } = new RoomType(8, "Havuz manzaralı oda tipi, havuz manzaralı odalar için.");
    public static RoomType MountainView { get; } = new RoomType(9, "Dağ manzaralı oda tipi, dağ manzaralı odalar için.");
    public static RoomType Jacuzzi { get; } = new RoomType(10, "Jakuzili oda tipi, jakuzi içeren lüks odalar için.");

    public static implicit operator int(RoomType type) => type.Value;
    public static implicit operator RoomType(int value) => value switch
    {
        1 => RoomType.Standard,
        2 => RoomType.Deluxe,
        3 => RoomType.Suite,
        4 => RoomType.Villa,
        5 => RoomType.Family,
        6 => RoomType.Business,
        7 => RoomType.SeaView,
        8 => RoomType.PoolView,
        9 => RoomType.MountainView,
        10 => RoomType.Jacuzzi,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Geçersiz değer")
    };

    public override string ToString() => Description;
}
