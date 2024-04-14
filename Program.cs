namespace DoubleForLoop;

internal class Program
{
    static object o = new();
    static void Main(string[] args)
    {
        using var f0 = new StreamWriter("f0.txt");
        using var f1 = new StreamWriter("f1.txt");
        using var f2 = new StreamWriter("f2.txt");
        int h = 25;
        int w = 80;
        for (int y = 0; y < h; y++)
        {
            for(int x = 0; x < w; x++)
            {
                f0.WriteLine($"x={x},y={y}");
            }
        }

        for(int v = 0; v < h * w; v++)
        {
            int y = v / w;
            int x = v % w;
            f1.WriteLine($"x={x},y={y}");
        }

        Parallel.For(0, h * w, v =>
        {
            int y = v / w;
            int x = v % w;
            lock (o)
            {
                f2.WriteLine($"x={x},y={y}");
            }

        });
    }
}
