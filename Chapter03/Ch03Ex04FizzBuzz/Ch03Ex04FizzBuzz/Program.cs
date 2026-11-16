string result = string.Empty;

for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        result += "FizzBuzz, ";
    }
    else if (i % 3 == 0)
    {
        result += "Fizz, ";
    }
    else if (i % 5 == 0)
    {
        result += "Buzz, ";
    }
    else
    {
        result += i.ToString() + ", ";
    }
}
result = result[..^2];

WriteLine(result);
