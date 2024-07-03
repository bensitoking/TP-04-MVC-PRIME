public static class ORTWorld 
{
    public static List<string> ListaDestinos {get; private set;} = new List<string>  {"Roma", "Barcelona", "Madrid", "CABA", "Venecia", "Tokio", "Hong Kong", "Moscu", "Brujas", "New York"};
    public static List<string> ListaHoteles {get; private set;} = new List<string> {"Sheraton", "Hilton", "The Peninsula", "Waldorf-Astoria", "Savoy"};
    public static List<string> ListaAereos {get; private set;} = new List<string> {"aereo1.png", "aereo2.png", "aereo3.png", "aereo4.png", "aereo5.png"};
    public static List<string> ListaExcursiones {get; private set;} = new List<string> {"excursion1.jpg", "excursion2.jpg", "excursion3.jpg", "excursion4.jpg", "excursion5.jpg"};
    public static Dictionary<string, Paquete> Paquetes {get; private set;} = new Dictionary<string, Paquete>();

public static bool IngresarPaquete(string destinoSeleccionado, Paquete paquete)
{
    bool exito = false;
    if (ListaDestinos.Contains(destinoSeleccionado))
    {
        Paquetes.Add(destinoSeleccionado, paquete);
        exito = true;
    }
    return exito;
}

}

