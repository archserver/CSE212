public static class MysteryStack1 {
    // this function reverses all sentences in exact order
/* for racecar it will produce racecar
for stressed it will produce desserts
for "a nut for a jar of tuna" it will produce "anut fo raj a rof tun a"
possible reasons for reversing sentences would be for possible pre encryption of a password so that non standard word dictunary may not work
another possible option is a game or brain teaser*/
    public static string Run(string text)
    {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}