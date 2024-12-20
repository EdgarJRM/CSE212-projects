using System.Text.Json;

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

        HashSet<string> tracker = new HashSet<string>(); // To track words seen
        List<string> result = new List<string>(); // List of results for storing pairs

        foreach (string word in words)
        {
            // Generate the reverse word
            string reversed = new string(new char[] { word[1], word[0] });

            // Check if the symmetrical pair is in the set
            if (tracker.Contains(reversed))
            {
                result.Add($"{reversed} & {word}"); // Add the pair to the result
            }
            else
            {
                tracker.Add(word); // Add the current word to the set
            }
        }

        return result.ToArray();
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

            // Extract the title assuming it is in the fourth column
            string degree = fields[3];

            // Update the dictionary
            if (degrees.ContainsKey(degree)) // Check if the title already exists in the dictionary.
            {
                degrees[degree]++; // If it exists, increment the count by 1
            }
            else
            {
                degrees[degree] = 1; // If it doesn't exist, it adds it to the dictionary with an initial count of 1.
            }

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

        // Convert to lowercase and remove spaces
        word1 = word1.ToLower().Replace(" ", "");
        word2 = word2.ToLower().Replace(" ", "");

        // Create dictionaries to count letters
        var charCount1 = new Dictionary<char, int>();
        var charCount2 = new Dictionary<char, int>();

        // Count the letters in the first word
        foreach (char c in word1)
        {
            if (charCount1.ContainsKey(c))
            {
                charCount1[c]++;
            }
            else
            {
                charCount1[c] = 1;
            }
        }

        // Count the letters in the second word
        foreach (char c in word2)
        {
            if (charCount2.ContainsKey(c))
            {
                charCount2[c]++;
            }
            else
            {
                charCount2[c] = 1;
            }
        }

        // Compare dictionaries
        
        if (charCount1.Count != charCount2.Count)
        {
            return false; // Different number of unique characters
        }

        foreach (var kvp in charCount1)
        {
            if (!charCount2.ContainsKey(kvp.Key) || charCount2[kvp.Key] != kvp.Value)
            {
                return false; // Characters or quantity does not match
            }
        }

        return true; // Dictionaries are equivalent
        
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


        // Deserialization and data validation
        if (featureCollection == null || featureCollection.Features == null)
        {
            throw new InvalidOperationException("No se pudo obtener los datos de terremotos.");
        }

        // Create the formatted result
        var result = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            if (feature.Properties?.Place != null && feature.Properties.Mag.HasValue)
            {
                result.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag:F1}");
            }
        }

        return result.ToArray();
    }
}