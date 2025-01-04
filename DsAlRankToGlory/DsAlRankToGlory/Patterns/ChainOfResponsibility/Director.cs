namespace DsAlRankToGlory.Patterns.ChainOfResponsibility;

public class Director : CallHandler, IEmployee
{
    public override void AnswerTheCall(Call call)
    {
        if (Busy && AvailableHandler == null)
        {
            call.Status = "Call could not be answered. Director is busy.";
        }
        else
        {
            call.HandlerOfTheCall = this;
            call.Status = "Call was answered by Director.";
        }
    }
}