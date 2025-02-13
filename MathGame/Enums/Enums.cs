using System.ComponentModel;
namespace MathGame.Enums;

internal enum MenuOptions
{
    Addition,
    Soustration,
    Multiplication,
    Division,
    [Description("View History")]
    ViewHistory
}

internal enum DifficultyOption
{
    Easy,
    Medium,
    Hard,
    Extreme
}