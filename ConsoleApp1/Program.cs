using System.Runtime.InteropServices;

int getMax2(int a, int b) {
    return (a > b) ? a : b; 
}

int getMax3(int a, int b, int c) {
    return getMax2(getMax2(a,b), getMax2(b,c));
}

bool isEven(int num) {
    return (num % 2)==0;
}

int[] getAllEvenToN(int N) {
    if (Math.Abs(N) >= 2) {
        int arrSize = Math.Abs(N) / 2;
        int[] ret = new int[arrSize];
        int inc = Math.Sign(N) * 2;
        for (int i = 0; i < arrSize; i++)
        {
            ret[i] = i * inc + inc;
        }
        return ret;
    }
    else{
        return Array.Empty<int>();
    }

}



Console.WriteLine(getMax2(3,5));
Console.WriteLine(getMax3(3,5,11));
Console.WriteLine(isEven(5));
Console.WriteLine(isEven(4));
Console.WriteLine(isEven(-4));
Console.WriteLine(string.Join(", ",getAllEvenToN(-9)));
Console.WriteLine(string.Join(", ",getAllEvenToN(10)));
