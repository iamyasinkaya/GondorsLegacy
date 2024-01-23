namespace GondorsLegacy.Services.Reservation.Authorization;

public static class AuthorizationPolicyNames
{
    public const string GetReservationsPolicy = "GetReservationsPolicy";
    public const string GetReservationPolicy = "GetReservationPolicy";
    public const string AddReservationPolicy = "AddReservationPolicy";
    public const string UpdateReservationPolicy = "UpdateReservationPolicy";
    public const string DeleteReservationPolicy = "DeleteReservationPolicy";
    public const string GetReservationAuditLogsPolicy = "GetReservationAuditLogsPolicy";

    public static IEnumerable<string> GetPolicyNames()
    {
        yield return GetReservationsPolicy;
        yield return GetReservationPolicy;
        yield return AddReservationPolicy;
        yield return UpdateReservationPolicy;
        yield return DeleteReservationPolicy;
        yield return GetReservationAuditLogsPolicy;
    }
}
