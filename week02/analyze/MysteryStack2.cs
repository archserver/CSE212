public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);
    }

    public static float Run(string text) {
        //  this takes a string splits it and then adds numbers to a stack as an operand is encountered it does the mathmatics with the nunmbers in the stack then adds the result back in and then keeps computing until all items from stack are gone or all operands are gone
        /* for "5 3 7 + *" it takes 7 and adds it to 3 for 10 pushes it to the stack them multiplies 5 and 10 to get a total of 50
        for "6 2 + 5 3 - /" first it would add 6 and 2 for 8 push 8 5 3 to the stack then 3 from 5 ius 2 then would divide 8 by 2 resulting in 4  
        for "3 4 0 * /" add to stack 3 4 0  first multiply 0 and 4 = 0 then divide 3 by 0 error 3 
        reasons to use this might be to not have to use the ( ) for calculation order
        invalid case 1 would be if there were less then 2 items on the stack after encountering a operand
        invalid case 2 would be for a divide by 0 error
        invalid case 3 would be if the item is the stack was not a number operand or empty, more then likely a special character or a char
        invalid case 4 is if there are additional items on the stack when there are not more operands to computer 
        */

        var stack = new Stack<float>();
        foreach (var item in text.Split(' ')) {
            if (item == "+" || item == "-" || item == "*" || item == "/") {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+") {
                    res = op1 + op2;
                }
                else if (item == "-") {
                    res = op1 - op2;
                }
                else if (item == "*") {
                    res = op1 * op2;
                }
                else {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item)) {
                stack.Push(float.Parse(item));
            }
            else if (item == "") {
            }
            else {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}