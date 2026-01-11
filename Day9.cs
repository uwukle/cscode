int[] array = [.. Enumerable.Range(0, 10).Reverse()];

(int left, int top) = Console.GetCursorPosition();

for (int i = 0; i < array.Length - 1; i++)
{
    for (int j = 0; j < array.Length - 1 - i; j++)
    {
        if (array[j] > array[j + 1])
        {
            (array[j], array[j + 1]) = (array[j + 1], array[j]);
            Console.SetCursorPosition(left, top);
            Console.WriteLine("[{0}]", string.Join(", ", array));
            await Task.Delay(256);
        }
    }
}
