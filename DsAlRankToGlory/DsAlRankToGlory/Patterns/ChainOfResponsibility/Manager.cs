namespace DsAlRankToGlory.Patterns.ChainOfResponsibility;

public class Manager : CallHandler, IEmployee
{
    public override void AnswerTheCall(Call call)
    {
        if (Busy && AvailableHandler != null)
        {
            call.Status = "Respondent is busy. Call was transferred";

            AvailableHandler.AnswerTheCall(call);
        }
        else
        {
            call.HandlerOfTheCall = this;
            call.Status = "Call was answered by Manager.";
        }
    }
}