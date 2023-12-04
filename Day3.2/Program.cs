namespace Day3._2
{
    internal class Program
    {

        public class Node
        {
            public int adjNumbers;
            public int row;
            public int col;
            public int ratio;
        }
        public static List<Node> nodes = [];
        static void Main(string[] args)
        {
            string[] lines = [.. File.ReadAllLines("in.txt")];
            var result = 0;
            var arr = Create2DArray(lines);

            for (int i = 0; i < lines.Length; i++) //row
            {
                int j = 0;
                while (j < lines[i].Length)  //col
                {
                    if (char.IsDigit(arr[i, j]))
                    {
                        int k = 1; //length of number
                        string number = arr[i, j].ToString();
                        while (true)
                        {
                            try
                            {
                                if (char.IsDigit(arr[i, j + k]))
                                {
                                    number += arr[i, j + k].ToString();
                                    k++;
                                }
                                else { break; }
                            }
                            catch
                            {
                                break;
                            }

                        }
                        IsPartNumber(arr, i, j, k, number);

                        j += k;
                    }
                    else
                    {
                        j++;
                    }

                }
            }
            foreach(Node node in nodes)
            {
                if(node.adjNumbers == 2)
                    result += node.ratio;
            }

            Console.WriteLine(result);
        }

        static void IsPartNumber(char[,] arr, int row, int start, int length, string value)
        {
            for (int i = 0; i < 3; i++) //Raden över, samma rad, raden under
            {
                for (var j = 0; j < length + 2; j++) // längden plus 1 tecken på vardera sida (diagonalen)
                {
                    try
                    {
                        var ch = arr[row - 1 + i, start - 1 + j];
                        if (ch == '*' )
                        {
                            var node = nodes.FirstOrDefault(obj => obj.row == row - 1 + i && obj.col == start - 1 + j);
                            if(node != null)
                            {
                                node.adjNumbers += 1;
                                node.ratio *= int.Parse(value);
                            }
                            else
                            {
                                var newNode = new Node()
                                {
                                    row = row - 1 + i,
                                    col = start - 1 + j,
                                    adjNumbers = 1,
                                    ratio = int.Parse(value)
                                };
                                nodes.Add(newNode);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        static char[,] Create2DArray(string[] lines)
        {
            int rows = lines.Length;
            int cols = lines[0].Length;

            char[,] arr = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = lines[i][j];
                }
            }

            return arr;
        }
    }
}
