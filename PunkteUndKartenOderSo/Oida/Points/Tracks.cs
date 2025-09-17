namespace Oida.Points;

public class Track : Point
{
    public Track(int x, int y) :base(x,y) { }
    public override Point GenerateTrack()
    {
        return this;
    }
}

public class Bridge : Point
{
    public Bridge(int x, int y) :base(x,y) { }
    public override Point GenerateTrack()
    {
        return this;
    }
}

public class Tunnel : Point
{
    public Tunnel(int x, int y) :base(x,y) { }
    public override Point GenerateTrack()
    {
        return this;
    }
}