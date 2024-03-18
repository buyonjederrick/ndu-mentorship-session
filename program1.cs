using System;

public class Shipment
{
    public string TrackingNumber { get; set; }
    public string Status { get; set; }
}

public class TrackLoader
{
    public Shipment LoadShipment(string trackingNumber)
    {
        // Logic to load shipment details from database or external API
        // Dummy implementation for demonstration
        return new Shipment { TrackingNumber = trackingNumber, Status = "In Transit" };
    }

    public void UpdateStatus(Shipment shipment, string newStatus)
    {
        // Logic to update shipment status
        shipment.Status = newStatus;
    }
}

class Program
{
    static void Main(string[] args)
    {
        TrackLoader trackLoader = new TrackLoader();
        Shipment shipment = trackLoader.LoadShipment("ABC123");
        Console.WriteLine($"Tracking Number: {shipment.TrackingNumber}, Status: {shipment.Status}");
        
        trackLoader.UpdateStatus(shipment, "Delivered");
        Console.WriteLine($"Updated Status: {shipment.Status}");
    }
}