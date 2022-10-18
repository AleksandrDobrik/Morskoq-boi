// See https://aka.ms/new-console-template for more information

Console.WriteLine();
int deckShip;
int positionShip;
int countFourDeck = 1; int countThreeDeck = 2; int countTwoDeck = 3; int countOneDeck = 4;
string[] NullLine =   {"  |", " А |", " Б |", " В |", " Г |", " Д |", " Е |", " Ж |", " З |", " И |", " К |"};
string[] NullColumn = { " |"," 1|"," 2|"," 3|"," 4|"," 5|"," 6|"," 7|"," 8|"," 9|","10|"};
bool test , player = true;
int countOne = 0, countTwo = 0;
int[,] fieldPlayerOne = {
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
};
int[,] fieldPlayerTwo = {
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
};
void PrintField (int[,] field)
{
    
    for (int i = 0; i < field.GetLength(0) - 1; i++)
    {
        for (int j = 0; j < field.GetLength(1) - 1 ; j++)
        {
            if (i == 0) Console.Write($"{NullLine[ j ]}");
            else if (j ==0) Console.Write($"{NullColumn[ i ]}");
                else if ( field[ i, j] == 1 || field[ i, j] == 2) Console.Write(" # |");
                    else if ( field[ i, j] == 0) Console.Write("   |");
        }
        Console.WriteLine();
        Console.WriteLine("-------------------------------------------");
    }
}

void PrintFieldGame (int[,] field)
{
    
    for (int i = 0; i < field.GetLength(0) - 1; i++)
    {
        for (int j = 0; j < field.GetLength(1) - 1 ; j++)
        {
            if (i == 0) Console.Write($"{NullLine[ j ]}");
            else if (j ==0) Console.Write($"{NullColumn[ i ]}");
                else if ( field[ i, j] == 1 || field[ i, j] == 0) Console.Write("   |");
                    else if ( field[ i, j] == -1 ) Console.Write(" # |");
                        else if ( field[ i, j] == 2) Console.Write(" O |");
        }
        Console.WriteLine();
        Console.WriteLine("-------------------------------------------");
    }
}

void NewShip(int[,] field)
{
    while(true)
    {
        positionShip = 0;
        Console.WriteLine("Choose  1, 2, 3, 4 deck ship");
        deckShip = Convert.ToInt32(Console.ReadLine());
        if (deckShip == 1 && countOneDeck > 0) {field[5, 5] += 1; countOneDeck -=1; break;}
            else if (deckShip == 2 && countTwoDeck > 0) {field[5, 5] += 1; field[6, 5] += 1; countTwoDeck -=1; break;}
                else if (deckShip == 3 && countThreeDeck > 0) {field[5, 5] += 1; field[6, 5] += 1; field[7, 5] += 1; countThreeDeck -=1; break;}
                    else if (deckShip == 4 && countFourDeck > 0) {field[5, 5] += 1; field[6, 5] += 1; field[7, 5] += 1; field[8, 5] += 1; countFourDeck -= 1; break;}
                        else Console.WriteLine($"You can use OneDeck {countOneDeck}, TwoDeck {countTwoDeck}, ThreeDeck {countThreeDeck}, OneFour {countFourDeck}, ");
    }
}

void TurnShip(int[,] field, int kordI, int kordJ)
{
    if ( positionShip == 0 )
    {
        if (kordJ < field.GetLength(1) - deckShip )
        {
            positionShip = 1;
            for (int j = kordJ + 1; j < kordJ + deckShip; j++) field[kordI, j] += 1;
            for (int i = kordI + 1; i < kordI + deckShip; i++) field[i, kordJ] -= 1;
        }
    }
    else
    {
        if (kordI < field.GetLength(0) - deckShip )
        {
            positionShip = 0;
            for (int j = kordJ + 1; j < kordJ + deckShip; j++) field[kordI, j] -= 1;
            for (int i = kordI + 1; i < kordI + deckShip; i++) field[i, kordJ] += 1;
        }
    } 
}

bool Test(int[,] field, int kordI, int kordJ)
{
    int sum = 0;
    if (positionShip == 0)
    {
        for (int i = kordI - 1; i <= kordI + deckShip; i++)
        {
            for (int j = kordJ - 1; j <= kordJ + 1; j++) sum += field[i, j];
        }
    }
    else 
    {
        for (int i = kordI - 1; i <= kordI + 1; i++)
        {
            for (int j = kordJ - 1; j <= kordJ + deckShip; j++) sum += field[i, j];
        }
    }
    if (sum == deckShip) return true;
    else return false;
}

void RightShip (int[,] field, int kordI, int kordJ)
{
    if ( positionShip == 0)
        {
            for ( int i = kordI; i < kordI + deckShip; i++ ) field[ i, kordJ + 1 ] += 1;
            for ( int i = kordI; i < kordI + deckShip; i++ ) field[ i, kordJ ] -= 1;
        }
    else  {field[ kordI, kordJ ] -= 1; field[ kordI, kordJ + deckShip ] += 1;}
}

void LeftShip (int[,] field, int kordI, int kordJ)
{
    if ( positionShip == 0)
        {
            for ( int i = kordI; i < kordI + deckShip; i++ ) field[ i, kordJ - 1 ] += 1;
            for ( int i = kordI; i < kordI + deckShip; i++ ) field[ i, kordJ ] -= 1;
        }
    else  {field[ kordI, kordJ + deckShip - 1 ] -= 1; field[ kordI, kordJ - 1 ] += 1;}
}

void UpShip (int[,] field, int kordI, int kordJ)
{
    if ( positionShip == 1)
        {
            for ( int j = kordJ; j < kordJ + deckShip; j++ ) field[ kordI - 1, j  ] += 1;
            for ( int j = kordJ; j < kordJ + deckShip; j++ ) field[ kordI, j ] -= 1;
        }
    else  {field[ kordI + deckShip - 1, kordJ ] -= 1; field[ kordI - 1, kordJ ] += 1;}
}

void DownShip (int[,] field, int kordI, int kordJ)
{
    if ( positionShip == 1)
        {
            for ( int j = kordJ; j < kordJ + deckShip; j++ ) field[ kordI + 1, j  ] += 1;
            for ( int j = kordJ; j < kordJ + deckShip; j++ ) field[ kordI, j ] -= 1;
        }
    else  {field[ kordI + deckShip , kordJ ] += 1; field[ kordI , kordJ ] -= 1;}
}

void TrafficShip(int[,] field, int i = 5, int j = 5)
{
    for(int n = 0; n  < 10; n++)
    {
        NewShip(field); i = 5; j = 5;
        Console.Clear();
        PrintField(field);
        while(true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.LeftArrow && j > 1) { LeftShip(field, i, j); j -= 1;} 
            if (key == ConsoleKey.RightArrow && ((j < field.GetLength(1) - 2 && positionShip == 0) || (j + deckShip < field.GetLength(1) - 1 && positionShip == 1))) 
            { RightShip(field, i, j);  j += 1;}
            if (key == ConsoleKey.UpArrow && i > 1) {UpShip(field, i, j); i -= 1;} 
            if (key == ConsoleKey.DownArrow && ((i < field.GetLength(0) - 2 && positionShip == 1) || ( i + deckShip < field.GetLength(0) - 1 && positionShip == 0))) 
            {DownShip(field, i, j); i += 1;}
            if (key == ConsoleKey.Spacebar) TurnShip(field, i, j); 
            if (key == ConsoleKey.Enter && (test = Test(field, i, j)) == true) break;
            Console.Clear();
            PrintField(field);
        }
    }
}

bool TestDieShip (int[,] field, int korI, int korJ)
{
    bool testUp = false, testDown = false, testLeft = false, testRight = false;
    for (int i = korI; i < korI + 5 ; i++)
    {
        if (field[i, korJ] == 0 || field[i, korJ] == 2) {testDown = true; break;}
        if (field[i, korJ] == 1) {testDown = false; break;}
    }
    for (int i = korI; i > korI - 5 ; i--)
    {
        if (field[i, korJ] == 0 || field[i, korJ] == 2) {testUp = true; break;}
        if (field[i, korJ] == 1) {testUp = false; break;}
    }
    for (int j = korJ; j > korJ - 5 ; j--)
    {
        if (field[korI, j] == 0 || field[korI, j] == 2) {testLeft = true; break;}
        if (field[korI, j] == 1) {testLeft = false; break;}
    }
    for (int j = korJ; j < korJ + 5 ; j++)
    {
        if (field[korI, j] == 0 || field[korI, j] == 2) {testRight = true; break;}
        if (field[korI, j] == 1) {testRight = false; break;}
    }
    if (testUp == true && testDown == true && testLeft == true && testRight == true) return true;
    else return false;
}

void dieShip (int[,] field, int korI, int korJ)
{
    for (int i = korI; i < korI + 5 ; i++)
    {
        if ( field[i, korJ] == 2 ) {field[i , korJ - 1] = 2; field[i, korJ + 1] = 2; break;}
        if (field[i, korJ] == -1) 
            { 
                if (field[i , korJ + 1 ]  == 0) field[ i, korJ + 1 ]  = 2;
                if (field[i + 1, korJ ]  == 0) field[i + 1, korJ  ]  = 2;
                if (field[i , korJ - 1 ]  == 0) field[ i, korJ - 1 ]  = 2;
            }
    }
    for (int i = korI; i > korI - 5 ; i--)
    {
        if (field[i, korJ] == 2)  {field[i , korJ - 1] = 2; field[i, korJ + 1] = 2; break;}
        if (field[i, korJ] == -1) 
        { 
            if (field[i , korJ + 1 ]  == 0) field[ i, korJ + 1 ]  = 2;
            if (field[i - 1, korJ ]  == 0) field[ i - 1, korJ ]  = 2;
            if (field[i , korJ - 1 ]  == 0) field[ i, korJ - 1 ]  = 2;
        }
    }
    for (int j = korJ; j > korJ - 5 ; j--)
    {
        if (field[korI, j] == 2) { field[korI - 1, j] = 2; field[korI + 1, j] = 2; break;}
        if (field[korI, j] == -1) 
            {
                if (field[korI - 1, j  ]  == 0) field[korI - 1, j  ]  = 2;
                if (field[korI, j - 1 ]  == 0) field[korI , j - 1 ]  = 2;
                if (field[korI + 1, j  ]  == 0) field[korI + 1, j  ]  = 2;
            }
    }
    for (int j = korJ; j < korJ + 5 ; j++)
    {
        if (field[korI, j] == 2) { field[korI - 1, j] = 2; field[korI + 1, j] = 2; break;}
        if (field[korI, j] == -1) 
            {
                if (field[korI - 1, j  ]  == 0) field[korI - 1, j  ]  = 2;
                if (field[korI, j + 1]  == 0) field[korI , j + 1 ]  = 2;
                if (field[korI + 1, j  ]  == 0) field[korI + 1, j ]  = 2;
            }
    }
}

void Play(int[,] field, int i = 6, int j = 5, int n = 20, int m = 12 )
{
    PrintFieldGame(field);
    if (player == true) Console.WriteLine("Player first ");
    if (player == false)Console.WriteLine("Player second ");
    while(true)
        {
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
                        if (player == true) countOne++;
                        if (player == false) countTwo++;
                        bool test = TestDieShip (field, i, j);
                        if (test == true)  dieShip (field, i, j);
                    }
                }
            
            Console.Clear();
            PrintFieldGame(field);
        }
}

Console.WriteLine("Player first ");
TrafficShip(fieldPlayerOne);
Console.Clear();

Console.WriteLine("Player second ");
countFourDeck = 1;  countThreeDeck = 2;  countTwoDeck = 3;  countOneDeck = 4;
TrafficShip(fieldPlayerTwo);
Console.Clear();

while (countOne < 20 && countTwo < 20)
{
    Console.Clear();
    if (player == true) Play(fieldPlayerOne);
    Console.Clear();
    if (player == false) Play(fieldPlayerTwo);
}

if (countOne == 20) Console.WriteLine("Win player first");
if (countTwo == 20) Console.WriteLine("Win player second");