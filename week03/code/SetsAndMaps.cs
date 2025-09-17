using System.Runtime.InteropServices;
using System.Text.Json;
using System.Windows.Markup;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // create hashset
        // create a return of pairs array with 1/2 the count of words
        // run through each set of two digit characters in the list of words
        // add the items only once
        // retrieve the opposing annogram
        // compare to make sure they are not identical for duplicate characters and there is an opposing match
        // add pairs to the pairs array

        var items = new HashSet<string>();
        var pairs = new string[(int)words.Length / 2];
        var count = 0;

        foreach (var two_didit in words)
        {
            if (items.Add(two_didit))
            {
                string opposing = two_didit[1].ToString() + two_didit[0].ToString();
                if (opposing != two_didit && items.Contains(opposing))
                {
                    pairs[count++] += (two_didit + " & " + opposing);
                }

                items.Add(two_didit);
            }
        }

        Array.Resize(ref pairs, count);
        return pairs;
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            // retrieve the degree and count them adding to the value of each match
            var degree = fields[3];
            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // Trim the spaces from the words
        // Count the length of the strings if they are != return False
        // else Build two dictionarys, sort the dictionarys compare letters if different return false
        // at the end return true 

        var firstWord = word1.ToUpper().Replace(" ","").Trim();
        var secondWord = word2.ToUpper().Replace(" ","").Trim();

        if (firstWord.Length != secondWord.Length)
            return false;

        var letterCounter = new Dictionary<char, int>();

        foreach (var c in firstWord)
        {
            if (letterCounter.ContainsKey(c))
                letterCounter[c]++;
            else
                letterCounter[c] = 1;
        }

        foreach (var d in secondWord)
        {
            if (!letterCounter.ContainsKey(d) || letterCounter[d] == 0)
                return false;

            letterCounter[d]--;
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // Define list of events array
        // run through each event in the the retreived JSON file
        // if there are no properties in an  event return
        // grab the location and trhe magnitude converting to a formatted string
        // create the string of a single event thenn add it to the list of eventsa
        // when conmpleted return the event list AS AN ARRAY
        var eventList = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            var properties = feature.Properties;
            if (properties == null)
                continue;

            // grab place and magnitude
            string location = properties.Place;
            string magnitude = properties.Mag.HasValue ? properties.Mag.Value.ToString("0.0") : "N/A";

            string singleEvent = $"{location} - Mag {magnitude}";
            eventList.Add(singleEvent);
        }

        return eventList.ToArray();
        
    }
}