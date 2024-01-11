namespace CarApp.WebApp;

public class EndPoints
{
    public Car Car { get; set; }
    public Feature Feature { get; set; }
}

public class Car
{
    public string GetCar { get; set; }
    public string CreateCar { get; set; }
    public string UpdateCar { get; set; }

}

public class Feature
{
    public string GetFeature { get; set; }
}
