Dictionary<string, char> numberMap = new()
{
    {"one", '1'},
    {"two", '2'},
    {"three", '3'},
    {"four", '4'},
    {"five", '5'},
    {"six", '6'},
    {"seven", '7'},
    {"eight", '8'},
    {"nine", '9'}
};

string[] lines = File.ReadAllLines("in.txt").ToArray();
int result = 0;

foreach (string line in lines)
{
    var firstDigit = GetFirstIndex(line, numberMap);
    var lastDigit = GetLastIndex(line, numberMap);
    var number = $"{firstDigit}{lastDigit}";
    result += int.Parse(number);
}
Console.WriteLine(result);

static char? GetFirstIndex(string input, Dictionary<string, char> numberMap)
{
    int firstIndex = 999;
    
    foreach (var entry in numberMap)
    {
        var index = input.IndexOf(entry.Key);
        if(index != -1 && index < firstIndex)
        {
            firstIndex = index;
        }
    }
    var firstDigitIndex = FindFirstDigitIndex(input);
    if (firstDigitIndex != -1 && firstDigitIndex <= firstIndex)
    {
        return input[firstDigitIndex];
    }
    else
    {
        return FindCharacterAt(firstIndex, input, numberMap) ?? null;
    }
}

static char? GetLastIndex(string input, Dictionary<string, char> numberMap)
{
    int firstIndex = 0;
    foreach (var entry in numberMap)
    {
        var index = input.LastIndexOf(entry.Key);
        if (index != -1 && index > firstIndex)
        {
            firstIndex = index;
        }
    }
    var firstDigitIndex = FindLastDigitIndex(input);
    if (firstDigitIndex != -1 && firstDigitIndex >= firstIndex)
    {
        return input[firstDigitIndex];
    }
    else
    {
        return FindCharacterAt(firstIndex, input, numberMap) ?? null;
    }
}


static int FindFirstDigitIndex(string input)
{
    for (int i = 0; i < input.Length; i++)
    {
        if (char.IsDigit(input[i]))
        {
            return i;
        }
    }

    return 999;
}

static int FindLastDigitIndex(string input)
{
    for (int i = input.Length - 1; i >= 0; i--)
    {
        if (char.IsDigit(input[i]))
        {
            return i;
        }
    }


    return 0;
}

static char? FindCharacterAt(int index, string input, Dictionary<string, char> dictionary)
{
    foreach (var kvp in dictionary)
    {
        string word = kvp.Key;
        char character = kvp.Value;

        if (index + word.Length <= input.Length && input.Substring(index, word.Length) == word)
        {
            return character;
        }
    }

    return null; 
}