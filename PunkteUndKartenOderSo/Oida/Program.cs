using System.Diagnostics;
using Oida.Points;


namespace Oida;

class Program
{
    static void Main(string[] args)
    {
        Map m = new Map();
        char c = 'a';
        while (c != 'x')
        {
            Console.Clear();
            PrintMap(m);
            Console.WriteLine(@"
Create Station: s
Create Tracks: t
Exit: x
");
            c = Console.ReadKey().KeyChar;
            switch (c)
            {
                case 's':
                {
                    int x = 0;
                    int y = 0;
                    try
                    {
                        Console.WriteLine();
                        Console.Write("X:");
                        x = int.Parse(Console.ReadLine());
                        Console.Write("Y:");
                        y = int.Parse(Console.ReadLine());
                        m.AddStation(x,y);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oops, something went wrong!");
                    }
                } break;
                case 't':
                {
                    List<Point> l = new List<Point>();
                    foreach (var point in m.Data)
                    {
                        if(point is Station)
                            l.Add(point);
                    }

                    if (l.Count <= 1)
                    {
                        Console.WriteLine("Not enough stations!");
                    }
                    else
                    {
                        m.GenerateTracks();
                        Console.Clear();
                        PrintMap(m);
                        c = 'x';
                    }
                } break;
                case 'x': break;
                default: Console.WriteLine("Try something else!"); break;
            }
        }
        
    }

    static void PrintMap(Map m)
    {
        for (int x = 0; x < 32; x++)
        {
            for (int y = 0; y < 32; y++)
            {
                Console.Write(GetPointChar(m.Data[x,y]));
            }
            Console.WriteLine();
        }
    }
    static char GetPointChar(Point p)
    {
        switch (p)
        {
            case Water: return 'w';
            case Hill: return 'm';
            case Wood: return 't';
            case Station: return 'A';
            case Track: return '=';
            case Bridge: return 'Y';
            case Tunnel: return 'O';
            default: return '-';
        } 
    }
}