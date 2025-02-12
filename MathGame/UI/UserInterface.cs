using Spectre.Console;
using MathGame.Enums;

namespace MathGame.UI;

internal class UserInterface
{
    #region CONST

    private static readonly Color EASY_DIFFICULTY_COLOR = Color.Green;
    private static readonly Color MEDIUM_DIFFICULTY_COLOR = Color.Yellow;
    private static readonly Color HARD_DIFFICULTY_COLOR = Color.Red;
    private static readonly Color EXTREME_DIFFICULTY_COLOR = Color.Purple;
    private static readonly Color CORRECT_RESULT_COLOR = Color.Green;
    private static readonly Color WRONG_RESULT_COLOR = Color.Red;
    private static readonly Color NEUTRAL_INDICATOR_COLOR = Color.Blue;

    #endregion

    internal string Name;
    private Color _DifficultyColor;
    private int _MinValue;
    private int _MaxValue;
    private Random _RandomNumber = new Random();
    public void MainMenu()
    {
        MenuOptions gamemodeChoice;
        DifficultyOption difficultyChoice;

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"[Bold {NEUTRAL_INDICATOR_COLOR}]Welcome to MathGame ![/]");
        AnsiConsole.WriteLine();

        AnsiConsole.Clear();
        Name = AnsiConsole.Ask<string>($"Enter your [{NEUTRAL_INDICATOR_COLOR}]name[/] : ");

        while (true)
        {
            AnsiConsole.Clear();

            gamemodeChoice = AnsiConsole.Prompt(new SelectionPrompt<MenuOptions>().Title($"Choose a [{NEUTRAL_INDICATOR_COLOR}]gamemode[/]").AddChoices(Enum.GetValues<MenuOptions>()));
            difficultyChoice = AnsiConsole.Prompt(new SelectionPrompt<DifficultyOption>().Title($"Choose a [{NEUTRAL_INDICATOR_COLOR}]difficulty[/] setting").AddChoices(Enum.GetValues<DifficultyOption>()));

            switch (gamemodeChoice)
            {
                case MenuOptions.Addition:
                    StartAdditionGamemode(difficultyChoice);
                    break;
                case MenuOptions.Soustration:
                    StartSoustractionGamemode(difficultyChoice);
                    break;
                case MenuOptions.Multiplication:
                    StartMultiplicationGamemode(difficultyChoice);
                    break;
                case MenuOptions.Division:                    
                    StartDivisionGamemode(difficultyChoice);
                    break;
                case MenuOptions.Random:
                    break;                    
            }
        }
    }

    private void SetDifficulty(DifficultyOption difficultyOption)
    {
        switch (difficultyOption)
        {
            case DifficultyOption.Easy:
                _DifficultyColor = EASY_DIFFICULTY_COLOR;
                _MinValue = 1;
                _MaxValue = 11;
                break;
            case DifficultyOption.Medium:
                _DifficultyColor = MEDIUM_DIFFICULTY_COLOR;    
                _MinValue = 11;
                _MaxValue = 51;            
                break;
            case DifficultyOption.Hard:
                _DifficultyColor = HARD_DIFFICULTY_COLOR;
                _MinValue = 11;
                _MaxValue = 1000;
                break;
            case DifficultyOption.Extreme:
                _DifficultyColor = EXTREME_DIFFICULTY_COLOR;
                _MinValue = 101;
                _MaxValue = 10000;
                break;
        }
    }

    private void StartAdditionGamemode(DifficultyOption difficultyOption)
    {
        SetDifficulty(difficultyOption);

        bool shouldContinue = true;

        while(shouldContinue)
        {
            int randomNumber1 = _RandomNumber.Next(_MinValue, _MaxValue);
            int randomNumber2 = _RandomNumber.Next(_MinValue, _MaxValue);
            int correctResult = randomNumber1 + randomNumber2;

            AnsiConsole.MarkupLine($"[{_DifficultyColor}]{difficultyOption.ToString()}[/] level calculations :");
            AnsiConsole.WriteLine();

            int playerResult = AnsiConsole.Ask<int>($"What is the [{NEUTRAL_INDICATOR_COLOR}]result[/] for : [{NEUTRAL_INDICATOR_COLOR}]{randomNumber1} + {randomNumber2}[/] = ");

            if (!CheckResults(playerResult, correctResult))
            {
                AnsiConsole.Clear();
                break;
            }
            AnsiConsole.Clear();
        }
    }

    private void StartSoustractionGamemode(DifficultyOption difficultyOption)
    {
        SetDifficulty(difficultyOption);

        bool shouldContinue = true;

        while(shouldContinue)
        {
            int randomNumber1 = _RandomNumber.Next(_MinValue, _MaxValue);
            int randomNumber2 = _RandomNumber.Next(_MinValue, _MaxValue);
            int correctResult = randomNumber1 - randomNumber2;

            AnsiConsole.MarkupLine($"[{_DifficultyColor}]{difficultyOption.ToString()}[/] level calculations :");
            AnsiConsole.WriteLine();

            int playerResult = AnsiConsole.Ask<int>($"What is the [{NEUTRAL_INDICATOR_COLOR}]result[/] for : [{NEUTRAL_INDICATOR_COLOR}]{randomNumber1} - {randomNumber2}[/] = ");

            if (!CheckResults(playerResult, correctResult))
            {
                AnsiConsole.Clear();
                break;
            }
            AnsiConsole.Clear();
        }
    }

    private void StartMultiplicationGamemode(DifficultyOption difficultyOption)
    {
        SetDifficulty(difficultyOption);

        bool shouldContinue = true;

        while(shouldContinue)
        {
            int randomNumber1 = _RandomNumber.Next(_MinValue, _MaxValue);
            int randomNumber2 = _RandomNumber.Next(_MinValue, _MaxValue);
            int correctResult = randomNumber1 * randomNumber2;

            AnsiConsole.MarkupLine($"[{_DifficultyColor}]{difficultyOption.ToString()}[/] level calculations :");
            AnsiConsole.WriteLine();

            int playerResult = AnsiConsole.Ask<int>($"What is the [{NEUTRAL_INDICATOR_COLOR}]result[/] for : [{NEUTRAL_INDICATOR_COLOR}]{randomNumber1} * {randomNumber2}[/] = ");

            if (!CheckResults(playerResult, correctResult))
            {
                AnsiConsole.Clear();
                break;
            }
            AnsiConsole.Clear();
        }
    }

    private void StartDivisionGamemode(DifficultyOption difficultyOption)
    {
        SetDifficulty(difficultyOption);

        bool shouldContinue = true;

        while(shouldContinue)
        {
            int randomNumber1 = _RandomNumber.Next(_MinValue, _MaxValue);
            int randomNumber2 = _RandomNumber.Next(_MinValue, _MaxValue);
            int correctResult = randomNumber1 / randomNumber2;

            AnsiConsole.MarkupLine($"[{_DifficultyColor}]{difficultyOption.ToString()}[/] level calculations :");
            AnsiConsole.WriteLine();

            int playerResult = AnsiConsole.Ask<int>($"What is the [{NEUTRAL_INDICATOR_COLOR}]result[/] for : [{NEUTRAL_INDICATOR_COLOR}]{randomNumber1} / {randomNumber2}[/] = ");

            if (!CheckResults(playerResult, correctResult))
            {
                AnsiConsole.Clear();
                break;
            }
            AnsiConsole.Clear();
        }
    }

    private bool CheckResults(int playerResult, int correctResult)
    {
        if (playerResult == correctResult)
        {
            AnsiConsole.MarkupLine($"[{CORRECT_RESULT_COLOR}]Correct ![/]");

            //TODO : History                
        }
        else
        {
            AnsiConsole.MarkupLine($"[{WRONG_RESULT_COLOR}]Wrong ![/], the correct answer was : [{NEUTRAL_INDICATOR_COLOR}]{correctResult}[/]");

            //TODO : History
        }

        return AnsiConsole.Confirm($"Do you want to [{NEUTRAL_INDICATOR_COLOR}]continue[/] ? : ");
    }
}
