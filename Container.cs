namespace CW2;

public abstract class Container{
    private static int ID = 1;

    public string SerialNumber {get; protected set;}
    public double Load {get; protected set;} //Zawartosc ladujemy pozniej
    public double MaxCapacity {get;}
    public double Weight {get;}
    public double Height {get;}
    public double Depth {get;}

    protected Container(ContainerType type, double maxCapacity, 
                double weight, double height, double depth){
                    MaxCapacity = maxCapacity;
                    Weight = weight;
                    Height = height;
                    Depth = depth;

                    string typeCode = GetTypeCode(type);
                    SerialNumber = $"KON-{typeCode}-{ID++}";
    }

    private string GetTypeCode(ContainerType type){
        switch (type){
            case ContainerType.Liquid:
                return "L";
            case ContainerType.Gas:
                return "G";
            case ContainerType.Refrigerated:
                return "C";
            default:
                return "X";
        }
    }

    public abstract void LoadCargo(double mass);
    public abstract void UnloadCargo();

}