namespace CW2;

public class LiquidContainer : Container, IHazardNotifier{
    public bool IsHazardous { get; }

    public LiquidContainer(
        ContainerType type,
        double maxCapacity,
        double weight,
        double height,
        double depth,
        bool isHazardous
    ) : base(type, maxCapacity, weight, height, depth){
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double mass){
        double limit = IsHazardous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;

       if (mass > limit){
            NotifyHazard("Proba przeladowania kontenera z plynami!", SerialNumber);
            throw new InvalidOperationException($"Ladunek {mass}kg przekracza dopuszczalny limit kontenera {SerialNumber}");
        }
        Load = mass;
    }

    public override void UnloadCargo(){
        Load = 0;
    }

    public void NotifyHazard(string message, string serialNumber){
        Console.WriteLine($"[HAZARD] {message} (Container: {serialNumber})");
    }
}