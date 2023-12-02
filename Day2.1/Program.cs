string[] lines = [.. File.ReadAllLines("in.txt")];

var result = 0;

foreach (var line in lines)
{
    var game = line.Split(':');
    var draws = game[1].Split(";");
    var possible = true;

    foreach (var draw in draws) 
    {
        var balls = draw.Split(",");
        foreach(var ball in balls) 
        {
            if (possible)
            {            
                if(ball.Contains("blue"))
                {
                    var number = new string(ball.Where(char.IsDigit).ToArray());
                    possible = isPossible(number, 0);
                }
                else if(ball.Contains("red"))
                {
                    var number = new string(ball.Where(char.IsDigit).ToArray());
                    possible = isPossible(number, 1);
                }
                else if(ball.Contains("green"))
                {
                    var number = new string(ball.Where(char.IsDigit).ToArray());
                    possible = isPossible(number, 2);
                }
            }
        }
    }
    if (possible)
    {
        var number = new string(game[0].Where(char.IsDigit).ToArray());
        result += int.Parse(number);
    }
}

Console.WriteLine(result);

static bool isPossible(string number, int color)
{
    switch(color)
    {
        case 0:
            if(int.Parse(number) > 14)
                return false;
            return true;
        case 1:
            if (int.Parse(number) > 12)
                return false;
            return true;
        case 2:
            if (int.Parse(number) > 13)
                return false;
            return true;
        default:
            return false;
    }
}