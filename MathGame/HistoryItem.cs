using MathGame.Enums;

namespace MathGame;

internal class HistoryItem
{
    public int CorrectResult { get; set;}
    public int PlayerResult { get; set; }
    public MenuOptions OperationType { get; set; }

    internal HistoryItem(int correctResult, int playerResult, MenuOptions operationType)
    {
        CorrectResult = correctResult;
        PlayerResult = playerResult;
        OperationType = operationType;
    }
}