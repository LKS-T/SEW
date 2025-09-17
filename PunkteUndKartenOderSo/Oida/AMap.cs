namespace Oida;

public abstract class AMap {
    /*
     Die GeneratePoint Methode generiert fuer
     die gegebenen Koordinaten einen Punkt.
     Was fuer eine Art von Punkt generiert
     wird ist abhaengig von der Implementierung der Kindklasse.
     */
    protected abstract Point GeneratePoint( int x, int y);

    /*
     Die AddStation Methode, fügt auf der Map
     an einer beliebigen Position auf der Map
     eine neue Station ein. Verwalten Sie alle
     Stations in einem Array
     */
    public abstract void AddStation( int x, int y);

    /*
     Die SetTrack Methode generiert Schienen,
     Brücken oder Tunnel zwischen allen
     Stationen.
     */
    public abstract void GenerateTracks( );


    /*
    Die Data Property verwaltet ein 2D
    Point Array. Das Array stellt die
        eigentliche Karte dar.
    */
    public Point[,] Data { get; set; } = new Point[32, 32];

    /*
     Im Konstruktor wird das Data Array
     direkt Initialisiert. Dazu wird jeder
     Stelle im Array ein Punkt mit den ent-
     sprechenden Koordinaten zugeordnet.
     Der Punkt wird dabei durch den Auf-
     ruf der GeneratePoint Methode erzeugt
     */
    public AMap() {
        for (int x = 0; x < Data.GetLength(0); x++) {
            for (int y = 0; y < Data.GetLength(1); y++) {
                Data[x, y] = GeneratePoint(x, y);
            }
        }
    }


}