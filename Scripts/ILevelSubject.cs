public interface ILevelSubject
{
    void AddObserver(ILevelObserver observer);
    void RemoveObserver(ILevelObserver observer);
    void NotifyLevelChanged(Level newLevel);
    void NotifyAnswerSelected(string optionString);
}
