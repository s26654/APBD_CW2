namespace CW2;

public class RefrigeratedContainer : Container{
    public string ProductType { get; }
    public double Temperature { get; }

    private static readonly Dictionary<string, double> RequiredTemperatures = new(){
        { "Banany", 13.3 },
        { "Czekolada", 18.0 },
        { "Lody", -18.0 },
        { "Mleko", 4.0 }
    };

    public RefrigeratedContainer(
        ContainerType type,
        double maxCapacity,
        double weight,
        double height,
        double depth,
        string productType,
        double temperature
    ) : base(type, maxCapacity, weight, height, depth){
        ProductType = productType;
        Temperature = temperature;
    }

    public override void LoadCargo(double mass){
        if (mass > MaxCapacity){
            throw new InvalidOperationException($"Przeładowanie kontenera {SerialNumber}");
        }

        if (RequiredTemperatures.TryGetValue(ProductType, out var requiredTemp)){
            if (Temperature > requiredTemp){
                throw new InvalidOperationException(
                    $"Zbyt wysoka temperatura! {ProductType} wymaga maks. {requiredTemp}°C, a jest {Temperature}°C"
                );
            }
        }

        Load = mass;
    }

    public override void UnloadCargo(){
        Load = 0;
    }
}