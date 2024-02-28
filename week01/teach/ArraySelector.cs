using System.Globalization;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var lv_rtv = new int [select.Length];
        int i1 = 0, i2 = 0;

        for(int i = 0; i < select.Length; i++)
        {
            
            if(select[i] == 1)
            {
                lv_rtv[i] = list1[i1++];
            }
            else
            {
                lv_rtv[i] = list2[i2++];
            }
        } 
        return lv_rtv;
    }
}