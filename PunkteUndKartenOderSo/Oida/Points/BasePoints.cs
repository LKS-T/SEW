namespace Oida.Points;


public class Field : Point
{
    public Field(int x, int y) :base(x,y) { }
    public override Point GenerateTrack()
    {
        return new Track(X, Y);
    }
}

public class Water : Point
{
    public Water(int x, int y) :base(x,y) { }
    public override Point GenerateTrack()
    {
        return new Bridge(X, Y);
    }
}

public class Hill : Point
{
    public Hill(int x, int y) :base(x,y) { }
    public override Point GenerateTrack()
    {
        return new Tunnel(X, Y);
    }
}

public class Wood : Point
{
    public Wood(int x, int y) :base(x,y) { }
    public override Point GenerateTrack()
    {
        return new Track(X,Y);
    }
}

public class Station : Point
{
    public Station(int x, int y) :base(x,y) { }
    public override Point GenerateTrack()
    {
        return this;
    }
}