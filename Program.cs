namespace CW2;

class Program
{
    static void Main(string[] args){

        /*##############################################
        Chcemy, aby aplikacja wspierała następujące operacje:

        1. Stworzenie kontenera danego typu
        2. Załadowanie ładunku do danego kontenera
        3. Załadowanie kontenera na statek
        4. Załadowanie listy kontenerów na statek
        5. Usunięcie kontenera ze statku
        6. Rozładowanie kontenera
        7. Zastąpienie kontenera na statku o danym numerze innym kontenerem
        8. Możliwość przeniesienie kontenera między dwoma statkami
        9. Wypisanie informacji o danym kontenerze
        10. Wypisanie informacji o danym statku i jego ładunku
        #################################################*/

        Console.WriteLine("=== CW 2 ===");

        var Titanic = new Ship("Titanic", 25, 5, 100000);
        var Naomi = new Ship("Posejdon", 30, 3, 50000);

        // 1. Stworzenie kontenera danego typu
        var liquid = new LiquidContainer(ContainerType.Liquid, 10000, 3000, 250, 600, isHazardous: true);
        var gas = new GasContainer(ContainerType.Gas, 8000, 2500, 240, 500, pressure: 8);
        var fridge = new RefrigeratedContainer(ContainerType.Refrigerated, 7000, 2800, 260, 550, "Banany", 12);

        // 6. Rozładowanie kontenera
        var liquidNitrogen = new LiquidContainer(ContainerType.Liquid, 5000, 1000, 100, 300, isHazardous: true);
        liquidNitrogen.UnloadCargo();

        // 2. Zaladowanie ladunku do kontenera
        liquid.LoadCargo(4000);
        gas.LoadCargo(5000);
        fridge.LoadCargo(6000);

        // 3. Zaladowanie kontenera na statek
        Titanic.AddContainer(liquid);
        Titanic.AddContainer(gas);
        Titanic.AddContainer(fridge);

        // 7. Zastapienie kontenera na statku innym
        var nitrogen = new GasContainer(ContainerType.Gas, 8000, 2500, 240, 500, pressure: 8);
        nitrogen.LoadCargo(5000);
        Titanic.ReplaceContainer("KON-G-2", nitrogen);

        // 10. Wypisanie informacji o danym statku i jego ladunku
        Titanic.PrintAllContainers();

        // 5. Usuniecie kontenera ze statku
        Titanic.RemoveContainer(gas.SerialNumber);
        Console.WriteLine("\nPo usunięciu gazowego:");
        Titanic.PrintAllContainers();

        // 8. Mozliwosc przeniesienia kontenera miedzy dwoma statkami
        Titanic.TransferContainer(Naomi, liquid.SerialNumber);
        Console.WriteLine("\n=== Zawartość statku docelowego (Naomi) ===");
        Naomi.PrintAllContainers();


        Console.WriteLine("\n===============");
    }
}