uint[] genUArrayMod1000(uint len)
{
    uint[] arr = new uint[len];
    Random generator = new Random(1234);
    for (int i = 0; i < len; ++i)
    {
        arr[i] = (uint)generator.Next(100, 999);
    }
    return arr;
}

uint getNumOfEven(uint[] data) {
    uint ret = 0;
    foreach (uint x in data) {
        ret += (x % 2 == 0)?1U:0U;
    }
    return ret;
}

uint[] arr = genUArrayMod1000(5);
Console.WriteLine(String.Join(",", arr));
Console.WriteLine(getNumOfEven(arr));


//////////
int[] genArray(int len)
{
    int[] arr = new int[len];
    Random generator = new Random();
    for (int i = 0; i < len; ++i)
    {
        arr[i] = generator.Next(-Int32.MaxValue, Int32.MaxValue);
    }
    return arr;
}

int sumOfOddPos(int[] arr) {
    int ret = 0;
    if (arr.Length <= 0) { 
        return 0;
    }

    for (int i = 1; i < arr.Length; i+=2) {
        ret = +arr[i];
    }
    return ret;
}

int[] arr2 = genArray(5);
Console.WriteLine(String.Join(",", arr2));
Console.WriteLine(sumOfOddPos(arr2));

////////////
double difMinMax(double[] arr) {
    return arr.Max() - arr.Min();
}


double[] arrd = { 3, 7, 22, 2, 78 };
Console.WriteLine(String.Join(",", arrd));
Console.WriteLine(difMinMax(arrd));








