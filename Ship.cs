namespace CW2;

public class Ship{
    public string Name { get; }
    public double MaxSpeed { get; } 
    public int MaxContainers { get; } 
    public double MaxWeight { get; }

    private List<Container> containers;

    public Ship(string name, double maxSpeed, int maxContainers, double maxWeight){
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        containers = new List<Container>();
    }

    public List<Container> GetContainers(){
        return containers;
    }

    public double GetTotalWeight(){
        double total = 0;

        foreach (var container in containers){
            total += container.Weight + container.Load;
        }

        return total;
    }

    public void AddContainer(Container container){
        if (containers.Count >= MaxContainers){
            throw new InvalidOperationException("Statek osiągnął maksymalną liczbę kontenerów.");
        }

        if (GetTotalWeight() + container.Weight + container.Load > MaxWeight){
            throw new InvalidOperationException("Statek nie może uniesc wiecej ladunku.");
        }

        containers.Add(container);
    }

    public void RemoveContainer(string serialNumber){
        Container containerToRemove = null;
        foreach (var c in containers){
            if (c.SerialNumber == serialNumber){
                containerToRemove = c;
                break;
            }
        }

        if (containerToRemove == null){
            throw new InvalidOperationException($"Kontener o numerze {serialNumber} nie istnieje na statku {Name}.");
        }

        containers.Remove(containerToRemove);
        Console.WriteLine($"Kontener {serialNumber} zostal usuniety ze statku {Name}.");
    }

    public void ReplaceContainer(string serialNumber, Container newContainer){
        Container oldContainer = null;

        foreach (var container in containers){
            if (container.SerialNumber == serialNumber){
                oldContainer = container;
                break;
            }
        
        }
        if (oldContainer == null){
            throw new InvalidOperationException($"Kontener o numerze {serialNumber} nie zostal znaleziony.");
        }

        double currentTotalWeight = GetTotalWeight();
        double oldWeight = oldContainer.Weight + oldContainer.Load;
        double newWeight = newContainer.Weight + newContainer.Load;

        if ((currentTotalWeight - oldWeight + newWeight) > MaxWeight){
           throw new InvalidOperationException("Zamiana spowodowalaby przekroczenie maksymalnej wagi statku.");
        }

        int index = containers.IndexOf(oldContainer);
        containers[index] = newContainer;

        Console.WriteLine($"Kontener {serialNumber} zostal zastapiony przez {newContainer.SerialNumber}");
    }

    public void TransferContainer(Ship targetShip, string serialNumber){
        Container containerToMove = null;

        foreach (var c in containers){
            if (c.SerialNumber == serialNumber){
                containerToMove = c;
                break;
            }
        }

        if (containerToMove == null){
            throw new InvalidOperationException($"Kontener {serialNumber} nie istnieje na statku {Name}.");
        }

        containers.Remove(containerToMove);

        try{
            targetShip.AddContainer(containerToMove);
            Console.WriteLine($"Kontener {serialNumber} zostal przeniesiony ze statku {Name} na {targetShip.Name}.");
        } catch (Exception ex){
            containers.Add(containerToMove);
            throw new InvalidOperationException($"Nie udalo sie przeniesc kontenera: {ex.Message}");
        }
    }

    public void PrintAllContainers(){
        Console.WriteLine($"\n=== Zawartosc statku {Name} ===");

        if (containers.Count == 0){
        Console.WriteLine("Brak kontenerów.");
        return;
        }

    foreach (var container in containers){
        Console.WriteLine($"Typ: {container.GetType().Name}");
        Console.WriteLine($"Numer seryjny: {container.SerialNumber}");
        Console.WriteLine($"Waga wlasna: {container.Weight} kg");
        Console.WriteLine($"Ładunek: {container.Load} kg");
        Console.WriteLine($"Pojemnosc maks.: {container.MaxCapacity} kg");

        switch (container){
            case GasContainer gas:
                Console.WriteLine($"Cisnienie: {gas.Pressure} bar");
                break;
            case LiquidContainer liquid:
                Console.WriteLine($"Towar niebezpieczny: {(liquid.IsHazardous ? "Tak" : "Nie")}");
                break;
            case RefrigeratedContainer fridge:
                Console.WriteLine($"Produkt: {fridge.ProductType}, Temp: {fridge.Temperature}°C");
                break;
            default: 
                Console.WriteLine("Brak dodatkowych informacji.");
                break;
        }


        }

        Console.WriteLine("-------------------------------");
    }
}
    
