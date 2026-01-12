Console.Clear();
Console.CursorVisible = false;

while (true)
{
    await Spiral('█');
    await Spiral(' ');
}

static async Task Spiral(char chr)
{
    int width = Console.WindowWidth, height = Console.WindowHeight,
        left = 0, top = 0,
        right = width - 1, bottom = height - 1,
        x = left, y = top,
        dir = 0;

    while (left <= right && top <= bottom)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(chr);
            await Task.Delay(2);
        }

        switch (dir)
        {
            case 0:
                x++;
                if (x > right)
                {
                    top++;
                    x--;
                    y++;
                    dir = 1;
                }
                break;
            case 1:
                y++;
                if (y > bottom)
                {
                    right--;
                    y--;
                    x++;
                    dir = 2;
                }
                break;
            case 2:
                x--;
                if (x < left)
                {
                    bottom--;
                    x++;
                    y--;
                    dir = 3;
                }
                break;
            case 3:
                y--;
                if (y < top)
                {
                    left++;
                    y++;
                    x++;
                    dir = 0;
                }
                break;
        }
    }
}
