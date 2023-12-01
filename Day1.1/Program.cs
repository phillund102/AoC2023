using System.Text.RegularExpressions;

try
{
    string[] lines = File.ReadLines("In.txt").ToArray();
    int result = 0;

    foreach (string line in lines)
    {
        string res = Regex.Replace(line, "[^0-9]", "");
        if(res.Length == 1)
        {
            char onlyDigit = res[0];
            string coord = $"{onlyDigit}{onlyDigit}";
            result += int.Parse(coord);
        }
        else
        {
            char first = res[0];
            char second = res[^1];
            string coord = $"{first}{second}";
            result += int.Parse(coord);
        }
    }
    Console.WriteLine(result);
}
catch (Exception ex)
{
    Console.WriteLine($"An error occured: {ex.Message}");
}
