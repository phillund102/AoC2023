string[] lines = [.. File.ReadAllLines("in.txt")];
var result = 0;
var arr = Create2DArray(lines);

for(int i = 0; i < lines.Length; i++) //row
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
            if(isPartNumber(arr, i, j, k))
            {
                result += int.Parse(number);
            }
            j += k;
        }
        else
        {
            j++;
        }

    }
}

Console.WriteLine(result);

static bool isPartNumber(char[,] arr, int row, int start, int length)
{     
    for(int i = 0; i < 3; i++) //Raden över, samma rad, raden under
    {
        for(var j = 0; j < length + 2; j++) // längden plus 1 tecken på vardera sida (diagonalen)
        {
            try
            {
                var ch = arr[row - 1 + i, start - 1 + j];
                if (ch != '.' && !char.IsDigit(ch))
                {
                    return true;
                }
            }
            catch
            {

            }
        }
    }
    
    return false;
}


static char[,] Create2DArray(string[] lines)
{
    int rows = lines.Length;
    int cols = lines[0].Length;

    char[,] arr = new char[rows, cols];

    for(int i = 0; i < rows; i++)
    {
        for(int j = 0; j < cols; j++)
        {
            arr[i, j] = lines[i][j];
        }
    }

    return arr;
}