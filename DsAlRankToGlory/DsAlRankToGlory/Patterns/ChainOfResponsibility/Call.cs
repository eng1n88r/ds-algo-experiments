namespace DsAlRankToGlory.Patterns.ChainOfResponsibility;

public abstract class Call(CallHandler handler)
{
    public required string Status { get; set; }

    public CallHandler HandlerOfTheCall { get; set; } = handler;
}