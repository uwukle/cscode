int width = Console.WindowWidth, height = Console.WindowHeight,
    x = width / 2, y = height / 2;

Random r = new();

Console.Clear();
Console.CursorVisible = false;

byte d = (byte)r.Next(4), p = d;

while (true)
{
    if (r.Next(10) < 1) d = (byte)((d + (r.Next(2) == 0 ? 1 : 3)) % 4);

    int nx = x + (d == 1 ? 1 : d == 3 ? -1 : 0),
        ny = y + (d == 0 ? -1 : d == 2 ? 1 : 0);

    if (nx < 0 || nx >= width || ny < 0 || ny >= height)
    {
        d = (byte)((d + 2) % 4);
        continue;
    }

    char c = p != d ? (p, d) switch
    {
        (0, 1) or (3, 2) => '┌',
        (1, 2) or (0, 3) => '┐',
        (2, 3) or (1, 0) => '┘',
        (3, 0) or (2, 1) => '└',
        _ => '+'
    } : d % 2 == 0 ? '│' : '─';

    Console.SetCursorPosition(x, y);
    Console.Write(c);

    (x, y, p) = (nx, ny, d);
    await Task.Delay(1);
}
