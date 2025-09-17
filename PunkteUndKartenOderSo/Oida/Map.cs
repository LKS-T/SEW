using Oida.Points;

namespace Oida;

public class Map : AMap
{
    protected override Point GeneratePoint(int x, int y)
    {
        Random rand = new Random();
        
        //Water chances
        if (x >= 1 && Data[x-1, y] is Water && rand.Next(1, 6) == 1)
            return new Water(x,y);
        if (y >= 1 && Data[x, y - 1] is Water && rand.Next(1, 6) == 1)
            return new Water(x,y);
        if (rand.Next(1, 11) == 1)
            return new Water(x, y);
            
        //Hill Chances
        if (x <= 0)
            return new Hill(x,y);
        if (Data[x-1, y] is Hill && rand.Next(1, 3) == 1)
            return new Hill(x,y);
        if (y >= 1 && Data[x, y - 1] is Hill && rand.Next(1, 6) == 1)
            return new Hill(x,y);
        if (rand.Next(1, 20) == 1)
            return new Hill(x,y);

        //Wood Chances
        if (Data[x-1, y] is Hill && rand.Next(1, 3) == 1)
            return new Wood(x,y);
        if (Data[x - 1, y] is Wood && rand.Next(1, 4) == 1)
            return new Wood(x, y);
        if (y >= 1 && Data[x, y - 1] is Wood && rand.Next(1, 4) == 1)
            return new Wood(x,y);
        if (rand.Next(1, 5) == 1)
            return new Wood(x,y);
        
        //Default
        return new Field(x,y);
        
    }

    public override void AddStation(int x, int y)
    {
        if(x < 32 && x >= 0 && y < 31 && y >= 0)
            Data[x, y] = new Station(x,y);
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    public override void GenerateTracks()
    {
        List<Point> l = new List<Point>();
        foreach (var point in Data)
        {
            if(point is Station)
                l.Add(point);
        }

        for (int i = 0; i < l.Count-1; i++)
        {
            var current = l[i];
            var next = l[i + 1];
            if(current.X < next.X)
                for (int x = current.X+1;  x <= next.X; x++)
                {
                    Data[x, current.Y] = Data[x, current.Y].GenerateTrack();
                }
            else if (current.X > next.X)
                for (int x = current.X-1;  x <= next.X; x--)
                {
                    Data[x, current.Y] = Data[x, current.Y].GenerateTrack();
                }
            if(current.Y < next.Y)
                for (int y = current.Y+1; y < next.Y; y++)
                {
                    Data[next.X, y] = Data[next.X, y].GenerateTrack();
                }
            else if (current.Y > next.Y)
                for (int y = current.Y-1; y > next.Y; y--)
                {
                    Data[next.X, y] = Data[next.X, y].GenerateTrack();
                }
        }
    }
}