// See https://aka.ms/new-console-template for more information

int countShip = new int(); int ship = new int();
string[] NullLine =   {" ", "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К"}; string vert = "|";
string[] NullColumn = { " |"," 1|"," 2|"," 3|"," 4|"," 5|"," 6|"," 7|"," 8|"," 9|","10|"};
bool test , player = true, begin = false, position = true;
int countOne = 0, countTwo = 0;
int[,] fieldPlayerOne = new int[12, 12];
int[,] fieldPlayerTwo = new int[12, 12];
void PrintField (int[,] field)
{
    for (int i = 0; i < field.GetLength(0) - 1; i++)
    {
        for (int j = 0; j < field.GetLength(1) - 1 ; j++)
        {
            if (begin)
            {
                if (i == 0) Console.Write($" {NullLine[ j ]} {vert}");
                    else if (j ==0) Console.Write($"{NullColumn[ i ]}");
                        else if ( field[ i, j] == 1 || field[ i, j] == 0) Console.Write("   |");
                            else if ( field[ i, j] == -1 ) Console.Write(" # |");
                                else if ( field[ i, j] == 2) Console.Write(" O |");
            }
            else 
                {
                    if (i == 0) Console.Write($" {NullLine[ j ]} {vert}");
                    else if (j ==0) Console.Write($"{NullColumn[ i ]}");
                        else if ( field[ i, j] == 0 ) Console.Write("   |");
                            else Console.Write($" {field[ i, j]} |");
                }
        }
        Console.WriteLine();
        Console.WriteLine("-------------------------------------------");
    }
}
int Ship ()
{
    if (countShip == 0) return 4;
    else if (countShip < 3) return 3;
    else if (countShip < 6) return 2;
    else if (countShip < 11) return 1;
    return 0;
}
void AddShip (int[,] field, int ship, bool position, int kordI, int kordJ)
{
    if(position)
    {
        for (int j = kordJ; j < kordJ + ship; j++) field[kordI, j] += 1;
    }
    else for (int i = kordI; i < kordI + ship; i++) field[i, kordJ] += 1;
}
void DeleteOldShip(int[,] field, int ship, bool position, int kordI, int kordJ)
{
    if(position)
    {
        for (int j = kordJ; j < kordJ + ship; j++) field[kordI, j] -= 1;
    }
    else for (int i = kordI; i < kordI + ship; i++) field[i, kordJ] -= 1;
}
bool Test(int[,] field, bool position, int kordI, int kordJ)
{
    int sum = 0;
    if (position)
    {
        for (int i = kordI - 1; i <= kordI + 1; i++)
        {
            for (int j = kordJ - 1; j <= kordJ + ship; j++) sum += field[i, j];
        }
    }
    else 
    {
        for (int i = kordI - 1; i <= kordI + ship; i++)
        {
            for (int j = kordJ - 1; j <= kordJ + 1; j++) sum += field[i, j];
        }
    }
    if (sum == ship) return true;
    else return false;
}
void TrafficShip(int[,] field)
{
    for(int n = 0; n  < 10; n++)
    {
        ship = Ship();
        countShip += 1;
        int i = 5, j = 5;
        AddShip(field, ship, position, i, j);
        Console.Clear();
        while(true)
        {
            PrintField(field);
            if (player == true) Console.WriteLine("Player first ");
            else Console.WriteLine("Player second ");
            DeleteOldShip(field, ship, position, i, j);
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.LeftArrow && j > 1)  j -= 1; 
            if (key == ConsoleKey.UpArrow && i > 1)  i -= 1;
            if (key == ConsoleKey.RightArrow && 
            ((j < field.GetLength(1) - 2 && position == false) ||
            (j + ship < field.GetLength(1) - 1 && position == true))) 
            j += 1;
            if (key == ConsoleKey.DownArrow && 
            ((i < field.GetLength(0) - 2 && position == true) || 
            ( i + ship < field.GetLength(0) - 1 && position == false))) 
            i += 1;
            if ((key == ConsoleKey.Spacebar) &&
            ((j + ship < field.GetLength(1)  && position == false) || 
            (i + ship < field.GetLength(0)  && position == true)))
            position = !position; 
            AddShip(field, ship, position, i, j);
            if (key == ConsoleKey.Enter && (test = Test(field, position, i, j)) == true) break;
            Console.Clear();
        }
    }
}
void DieShip (int[,] field, int korI, int korJ)
{
    int vertical = 3, horizontal = 3;
    int helpI = new int(), helpJ = new int();
    for (int i = korI + 1; i < korI + 4 ; i++)
    {   
        if (field[i, korJ] == -1) vertical += 1;
        else if (field[i, korJ] == 1) return;
        else if (field[i, korJ] == 0 || field[i, korJ] == 2) break;   
    }
    for (int j = korJ + 1; j < korJ + 4 ; j++)
    {
        if (field[korI, j] == -1) horizontal += 1;
        else if (field[korI, j] == 1) return;
        else if (field[korI, j] == 0 || field[korI, j] == 2) break; 
    } 
    for (int i = korI - 1; i > korI - 5 ; i--)
    {
        if (field[i, korJ] == -1) vertical += 1;
        else if (field[i, korJ] == 1) return;
        else if (field[i, korJ] == 0 || field[i, korJ] == 2) 
        {
            helpI = i; 
            break;
        }
    }
    for (int j = korJ - 1; j > korJ - 5 ; j--)
    {
        if (field[korI, j] == -1) horizontal += 1;
        else if (field[korI, j] == 1) return;
        else if (field[korI, j] == 0 || field[korI, j] == 2) 
        {
            helpJ = j ; 
            break;
        } 
    }
    for (int i = helpI; i < helpI + vertical; i++)
    {
        for (int j = helpJ; j < helpJ + horizontal; j++)
        {
            if (field[i, j] == 0) field[i, j] = 2;
        }
    }      
}
void Play(int[,] field, int i = 6, int j = 5, int n = 20, int m = 12 )
{
    begin = true;
    while(true)
    {
        PrintField(field);
        if (player) Console.WriteLine("Player first ");
        else Console.WriteLine("Player second ");
        Console.SetCursorPosition( n, m );
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.LeftArrow && j > 1) {  n -= 4; j -= 1;} 
        if (key == ConsoleKey.RightArrow && j < field.GetLength(1) - 2 ) {  n += 4; j += 1;}
        if (key == ConsoleKey.UpArrow && i > 1) { m -= 2; i -=1;} 
        if (key == ConsoleKey.DownArrow && i < field.GetLength(0) - 2 ) { m += 2; i += 1;}
        if (key == ConsoleKey.Spacebar) 
            {
                if ( field[i, j] == 0) { field[i, j] = 2; player = !player; break;}
                if ( field[i, j] == 1) 
                { 
                    field[i, j] = -1;
                    if (player) countOne++;
                    else  countTwo++;
                    DieShip (field, i, j);
                }
            }
        Console.Clear();
    }
}
TrafficShip(fieldPlayerOne);
countShip = 0; player = !player;
TrafficShip(fieldPlayerTwo);
player = !player;
while (countOne < 20 && countTwo < 20)
{
    Console.Clear();
    if (player == true) Play(fieldPlayerTwo);
    if (countOne == 20) break; 
    Console.Clear();
    if (player == false) Play(fieldPlayerOne);
}
if (countOne == 20) Console.WriteLine("Win player first");
if (countTwo == 20) Console.WriteLine("Win player second");