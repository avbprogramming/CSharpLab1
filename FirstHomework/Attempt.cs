namespace FirstHomework;

public class Attempt
{
    private readonly int errorCount;

    public int ErrorCount
    {
        get { return errorCount; }
    }

    public TimeSpan Duration
    {
        get { return duration; }
    }

    public int TextNumber
    {
        get {return textNumber;}
    } 

    private readonly TimeSpan duration;
    private readonly int textNumber;
    private readonly Languages language;
    
    public Attempt(int errorCount, TimeSpan duration, int textNumber, Languages language)
    {
        if (errorCount < 0)
            throw new ArgumentException("Error count should not be negative");

        this.errorCount = errorCount;
        this.duration = duration;
        this.textNumber = textNumber;
        this.language = language;
    }

    public int typingSpeed
    {
        get { return Text.GetText(textNumber, language).Length / duration.Seconds; }
    }
    
}