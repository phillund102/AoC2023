using System.Text.RegularExpressions;

namespace Day4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = [.. File.ReadAllLines("in.txt")];
            var copies = new int[lines.Length];
            var result = 0;

            foreach (var line in lines)
            {
                var game = line.Split(":")[1];
                var winningNumbers = game.Split("|")[0];
                winningNumbers = winningNumbers.Trim();
                winningNumbers = Regex.Replace(winningNumbers, @"\s+", " ");
                var validNumbers = winningNumbers.Split(" ");
                var validNums = validNumbers.Select(int.Parse).ToArray();

                var pickedNumbers = game.Split("|")[1];
                pickedNumbers = Regex.Replace(pickedNumbers, @"\s+", " ");
                pickedNumbers = pickedNumbers.Trim();
                var numbers = pickedNumbers.Split(" ");
                var pickedNums = numbers.Select(int.Parse).ToArray();

                var matches = 0;
                foreach (var number in pickedNums)
                {
                    if (validNums.Contains(number))
                    {
                        matches = matches == 0 ? 1 : matches * 2;
                    }
                }
                result += matches;
            }
            Console.WriteLine(result);
            
        }
    }
}
