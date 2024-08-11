

public static class Program
{
    private static int _Row = -1;

    private static int _Col = 0;

    public static void Main(string[] args)
    {

        for (int i = 0; i < 32 * 23; i++)
        {
            Console.WriteLine(GenerateLine(i));
        }

        Console.ReadKey();
    }

    public static string GenerateLine(int i)
    {
        if (i % 23 == 0)
        {
            _Col = 0;
            _Row++;
        }

        var wibble = $"<Button Grid.Column=\"{_Col}\" Grid.Row=\"{_Row}\" Background=\"{{Binding BackGroundColors[{i}]}}\" Command=\"{{Binding OnClick}}\" CommandParameter=\"{i + 1}\" Template=\"{{StaticResource NoHoverOverButton}}\"/>";
        _Col++;
        return wibble;
    }
}

