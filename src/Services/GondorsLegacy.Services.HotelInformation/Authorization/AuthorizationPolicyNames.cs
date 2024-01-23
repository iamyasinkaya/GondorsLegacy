namespace GondorsLegacy.Services.HotelInformation.Authorization;

public static class AuthorizationPolicyNames
{
    public const string GetHotelsPolicy = "GetHotelsPolicy";
    public const string GetHotelPolicy = "GetHotelPolicy";
    public const string AddHotelPolicy = "AddHotelPolicy";
    public const string UpdateHotelPolicy = "UpdateHotelPolicy";
    public const string DeleteHotelPolicy = "DeleteHotelPolicy";
    public const string GetHotelAuditLogsPolicy = "GetHotelAuditLogsPolicy";

    public static IEnumerable<string> GetPolicyNames()
    {
        yield return GetHotelsPolicy;
        yield return GetHotelPolicy;
        yield return AddHotelPolicy;
        yield return UpdateHotelPolicy;
        yield return DeleteHotelPolicy;
        yield return GetHotelAuditLogsPolicy;
    }
}
