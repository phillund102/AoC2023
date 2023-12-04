using System.Text.RegularExpressions;

namespace Day4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = [.. File.ReadAllLines("in.txt")];
            var copies = new int[lines.Length];
            var result = 0;
            var index = 0;
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
                        matches += 1;
                    }
                }

                for (int i = index + 1; i < matches + index + 1; i++)
                {
                    copies[i] = copies[i] + copies[index] + 1;
                }
                index++;
            }
            var k = 0;

            foreach (var copy in copies)
            {
                copies[k] += 1;
                result += copies[k];
                k++;
            }
            Console.WriteLine("res: " + result);
        }
    }
}
