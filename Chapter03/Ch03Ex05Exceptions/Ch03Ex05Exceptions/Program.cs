string? firstNumber;
string? secondNumber;
double parsedFirstNumber = 0;
double parsedSecondNumber = 0;
bool isInRange;

do
{
    WriteLine("Enter a number between 0 and 255: ");
    firstNumber = ReadLine();

    try
    {
        parsedFirstNumber = double.Parse(firstNumber!);
    }
    catch (ArgumentNullException)
    {
        WriteLine("No input string was entered.");
    }
    catch (FormatException)
    {
        WriteLine("Input string was not in a correct format.");
    }
    catch (OverflowException)
    {
        WriteLine("The input was not in the correct range (0 - 255).");
    }

    isInRange = parsedFirstNumber >= 0 && parsedFirstNumber <= 255;

    if (!isInRange)
    {
        WriteLine("The number entered is out of the range (0 - 255)");
    }
} while (!isInRange);

do
{
    WriteLine("Enter another number between 0 and 255: ");
    secondNumber = ReadLine();

    try
    {
        parsedSecondNumber = double.Parse(secondNumber!);
    }
    catch (ArgumentNullException)
    {
        WriteLine("No input string was entered.");
    }
    catch (FormatException)
    {
        WriteLine("Input string was not in a correct format.");
    }
    catch (OverflowException) when (parsedSecondNumber < 0 || parsedSecondNumber > 255)
    {
        WriteLine("The input was not in the correct range (0 - 255).");
    }

    isInRange = parsedSecondNumber >= 0 && parsedSecondNumber <= 255;

    if (!isInRange)
    {
        WriteLine("The number entered is out of the range (0 - 255)");
    }
} while (!isInRange);

Console.WriteLine($"{firstNumber} divided by {secondNumber} is {parsedFirstNumber / parsedSecondNumber}");
