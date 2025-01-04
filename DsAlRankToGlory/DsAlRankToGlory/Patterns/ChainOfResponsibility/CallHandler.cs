namespace DsAlRankToGlory.Patterns.ChainOfResponsibility;

public abstract class CallHandler
{
    public bool Busy { get; set; }

    protected CallHandler? AvailableHandler;

    public void NextEscalationEmployee(CallHandler handler)
    {
        AvailableHandler = handler;
    }

    public abstract void AnswerTheCall(Call call);
}