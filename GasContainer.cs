namespace CW2;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }

    public GasContainer(
        ContainerType type,
        double maxCapacity,
        double weight,
        double height,
        double depth,
        double pressure
    ) : base(type, maxCapacity, weight, height, depth) {
        Pressure = pressure;
    }

    public override void LoadCargo(double mass){
        if (mass > MaxCapacity){
            NotifyHazard("Proba przeladowania gazu!", SerialNumber);
            throw new InvalidOperationException($"Gaz {mass}kg przekracza pojemnosc kontenera {SerialNumber}");
        }

        Load = mass;
    }

    public override void UnloadCargo(){
        Load *= 0.05; 
    }

    public void NotifyHazard(string message, string serialNumber){
        Console.WriteLine($"[GAZ - HAZARD] {message} ({serialNumber})");
    }
}