/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // add all players to the Dictionary 
            // accumilating points as a player is added
            //  
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
                players[playerId] = points;
        }

        //Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        // Move the dictionary to an Array
        // Sort the array if the next value is > current value 
        // run through top 10 items in the array
        var topPlayers = players.ToArray();

        Array.Sort(topPlayers, (part1, part2) => part2.Value - part1.Value);

        for (var i = 0; i < 10; i++)
            Console.WriteLine("Player #{0} {1} with {2} points", i + 1, topPlayers[i].Key, topPlayers[i].Value);




    }
}