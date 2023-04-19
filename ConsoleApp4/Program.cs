int Power(int powBase, int power) {
    int pow = 1;
    for (int i = 0; i < power; i++) { 
        pow *= powBase;
    }
    return pow;
}

int sumOfDigits(int num) {
    int ret = 0;
    while (num > 0) {
        ret += num % 10;
        num /= 10;
    }
    return ret;
}

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


Console.WriteLine(Power(255,3));
Console.WriteLine(Power(12,2));
Console.WriteLine(sumOfDigits(123456));
Console.WriteLine(String.Join(",", genArray(5)));

