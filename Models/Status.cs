namespace Airport.Models
{
    public enum Status
    {
        Planned = 0,
        Delayed = 1,
        Canceled = 2,

        PreparingForLanding = 3,
        Landed = 4,
        BaggageOnBelt = 5,

        Boarding = 6,
        GateClosed = 7,
        GateOpened = 8,
        GateChanged = 9
    }
}
