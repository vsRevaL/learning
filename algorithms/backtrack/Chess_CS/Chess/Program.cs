#region Constants
Console.SetWindowSize(30, 12);
Console.OutputEncoding = System.Text.Encoding.Unicode;
const string ROCK = "♖";
const string QUEEN = "♕";
#endregion
Console.WriteLine("\n****** Backtrack algorithm ******\n");

int SIZE;

void Print(int[][] board)
{
    for (int i = 0; i < SIZE; i++)
    {
        Console.Write("   +");
        for (int c = 0; c < SIZE; c++) Console.Write("---+");
        Console.WriteLine();
        Console.Write(" " + (SIZE - i) + " |");
        for (int j = 0; j < SIZE; j++)
        {
            if (board[i][j] == 1)
            {
                Console.Write(" " + QUEEN + " |");
            }
            else
            {
                Console.Write("   |");
            }
        }
        Console.WriteLine();
    }
    Console.Write("   +");
    for (int c = 0; c < SIZE; c++) Console.Write("---+");
    Console.WriteLine();
    Console.WriteLine("     A   B   C   D");
}

Console.WriteLine("Enter the board size:");
string line = Console.ReadLine();
if (!int.TryParse(line, out SIZE))
{
    SIZE = 4;
}

int[][] board = new int[SIZE][];
for (int i = 0; i < SIZE; i++) board[i] = new int[SIZE];

Console.WriteLine();

bool CanPlace(int[][] board, int row, int rank)
{
    //row to the left
    for (int i = 0; i < rank; i++)
    {
        if (board[row][i] == 1) return false;
    }

    //lower left diagonal
    for (int i = row, j = rank; i >= 0 && j >= 0; i--, j--)
    {
        if (board[i][j] == 1) return false;
    }

    //upper left diagonal
    for (int i = row, j = rank; i < SIZE && j >= 0; i++, j--)
    {
        if (board[i][j] == 1) return false;
    }

    return true;
}

bool Solve(int[][] board, int rank)
{
    Console.ForegroundColor = ConsoleColor.White;
    if (rank >= SIZE) return true;
    for (int row = 0; row < SIZE; row++)
    {
        if (CanPlace(board, row, rank))
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press SPACE to Continue");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
            {
                Console.WriteLine("Press SPACE to Continue");
            }
            Console.ForegroundColor = ConsoleColor.Green;

            board[row][rank] = 1;
            Print(board);

            if (Solve(board, rank + 1)) return true;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Press SPACE to Continue");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
            {
                Console.WriteLine("Press SPACE to Continue");
            }
            Print(board);
            board[row][rank] = 0; //Backtrack
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Press SPACE to Continue");
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar)
            {
                Console.WriteLine("Press SPACE to Continue");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            board[row][rank] = 1;
            Print(board);
            board[row][rank] = 0;

        }
    }

    return false;
}

bool canBeSolved = Solve(board, 0);
if (canBeSolved)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("True");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("True");
}

for (int i = 0; i < SIZE; i++)
{
    for (int j = 0; j < SIZE; j++)
    {
        Console.Write(board[i][j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("Program finished. Press X to close");
string key = Console.ReadLine();
while (key.Trim() != "x" && key.Trim() != "X")
{
    Console.WriteLine("Program finished. Press X to close");
    key = Console.ReadLine();
}

