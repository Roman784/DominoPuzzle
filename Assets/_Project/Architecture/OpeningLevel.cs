public static class OpeningLevel
{
    public static int Number { get; private set; } = 1;

    public static void SetNumber(int number)
    {
        Number = number;
    }

    public static void Next()
    {
        Number += 1;
    }
}
