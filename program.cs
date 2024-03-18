using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Define a list to store track details
        List<Track> tracks = new List<Track>();

        // Prompt the user to input track details until they decide to stop
        while (true)
        {
            Console.WriteLine("Enter track details (weight and destination), or type 'stop' to finish:");
            string input = Console.ReadLine();

            // Check if the user wants to stop inputting track details
            if (input.ToLower() == "stop")
                break;

            // Split the input by space to get weight and destination
            string[] parts = input.Split(' ');

            // Check if the input is in the correct format
            if (parts.Length != 2)
            {
                Console.WriteLine("Invalid input format. Please enter weight and destination separated by space.");
                continue;
            }

            // Parse weight from input
            if (!int.TryParse(parts[0], out int weight))
            {
                Console.WriteLine("Invalid weight. Please enter a valid integer.");
                continue;
            }

            // Create a new Track object and add it to the list
            tracks.Add(new Track(weight, parts[1]));
        }

        // Calculate total weight of all tracks
        int totalWeight = 0;
        foreach (Track track in tracks)
        {
            totalWeight += track.Weight;
        }

        // Display summary of loaded tracks
        Console.WriteLine($"Summary of Loaded Tracks:");
        Console.WriteLine($"Total number of tracks: {tracks.Count}");
        Console.WriteLine($"Total weight of tracks: {totalWeight}");
        Console.WriteLine($"Destinations:");

        // Group tracks by destination and display destination-wise summary
        Dictionary<string, int> destinationWeights = new Dictionary<string, int>();
        foreach (Track track in tracks)
        {
            if (destinationWeights.ContainsKey(track.Destination))
                destinationWeights[track.Destination] += track.Weight;
            else
                destinationWeights[track.Destination] = track.Weight;
        }

        // Display destination-wise summary
        foreach (var entry in destinationWeights)
        {
            Console.WriteLine($"- {entry.Key}: {entry.Value}");
        }
    }
}

// Define a class to represent a track
class Track
{
    public int Weight { get; set; }
    public string Destination { get; set; }

    // Constructor to initialize weight and destination
    public Track(int weight, string destination)
    {
        Weight = weight;
        Destination = destination;
    }
}

//We define a Track class to represent each track with properties for weight and destination.
//We utilize a List<Track> to store the track details entered by the user.
//We use built-in functions like Console.WriteLine() and Console.ReadLine() for input and output operations.
//We perform error handling using int.TryParse() to validate user input for weight.
//We calculate the total weight of all tracks using a foreach loop.
//We use a Dictionary<string, int> to group tracks by destination and calculate the total weight for each destination.
//Finally, we display a summary of the loaded tracks including the total number of tracks, total weight, and destination-wise summary.