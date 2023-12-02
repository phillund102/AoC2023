string[] lines = [.. File.ReadAllLines("in.txt")];

var result = 0;

foreach (var line in lines) //en runda
{
    var game = line.Split(':');
    var draws = game[1].Split(";");
    var red = 0;
    var blue = 0;
    var green = 0;

    foreach (var draw in draws) //dragningar
    {
        var balls = draw.Split(",");
        foreach (var ball in balls) //varje färg
        {

            if (ball.Contains("blue"))
            {
                var number = int.Parse(new string(ball.Where(char.IsDigit).ToArray()));
                blue = number > blue ? number : blue;
            }
            else if (ball.Contains("red"))
            {
                var number = int.Parse(new string(ball.Where(char.IsDigit).ToArray()));
                red = number > red ? number : red;
            }
            else if (ball.Contains("green"))
            {
                var number = int.Parse(new string(ball.Where(char.IsDigit).ToArray()));
                green = number > green ? number : green;
            }
        }
    }
    result += red * blue * green;
}

Console.WriteLine(result);