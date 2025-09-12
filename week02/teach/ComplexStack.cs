public static class ComplexStack {
    public static bool DoSomethingComplicated(string line) {
        var stack = new Stack<char>();
        foreach (var item in line) {
            // check for opening and closing brackets
            if (item is '(' or '[' or '{')
            {
                stack.Push(item);
            }
            // validate that brackets match up to closes in order
            // Input: (a == 3 or (b == 5 and c == 6))
            // Input: (students]i].Grade > 80 and students[i].Grade < 90)
            // Input:(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))
            // 
            else if (item is ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']')
            {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}')
            {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}