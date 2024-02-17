namespace GondorsLegacy.Services.HotelInformation.Constants;


/// <summary>
/// Oda türünü belirten enum.
/// </summary>
public record RoomType
{
    public string Type { get; init; }

    private RoomType(string type)
    {
        Type = type;
    }

    public static RoomType Single { get; } = new RoomType("Single");
    public static RoomType Double { get; } = new RoomType("Double");
    public static RoomType Suite { get; } = new RoomType("Suite");
    public static RoomType Family { get; } = new RoomType("Family");
    public static RoomType King { get; } = new RoomType("King");
    public static RoomType Twin { get; } = new RoomType("Twin");
    public static RoomType Deluxe { get; } = new RoomType("Deluxe");
    public static RoomType Connecting { get; } = new RoomType("Connecting");
    public static RoomType HandicapAccessible { get; } = new RoomType("HandicapAccessible");
    public static RoomType SeaView { get; } = new RoomType("SeaView");

    public override string ToString() => Type;
}
