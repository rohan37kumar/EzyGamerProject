public interface ILevelObserver
{
    void OnLevelChanged(Level newLevel);
    void OnAnswerSelected(string selectedOption, bool isCorrect);
}
