bool isPalindrome(string data)
{
    int len = data.Length;
    for (int i = 0; i < len / 2; i++)
    {
        if (data[i] != data[len - i - 1])
        {
            return false;
        }
    }
    return true;
}

double Distance3D(double[] A, double[] B)
{
    double dx = B[0] - A[0];
    double dy = B[1] - A[1];
    double dz = B[2] - A[2];
    double distance = Math.Sqrt(dx * dx + dy * dy + dz * dz);
    return distance;
}

string cubesArr(int N) {
    int sign = Math.Sign(N);
    int[] ret = new int[N];
    for (int i = 0; i < N; i++) {
        ret[i] = (int)Math.Pow(sign * (i + 1),3);
    }
    return String.Join(", ",ret);
}


Console.WriteLine(isPalindrome("12321"));
Console.WriteLine(isPalindrome("1221"));
Console.WriteLine(isPalindrome("1222"));
double[] A = { 1.0, 2.0, 3.0 };
double[] B = { 4.0, 5.0, 6.0 };
Console.WriteLine(Distance3D(A,B));
Console.WriteLine(cubesArr(3));
Console.WriteLine(cubesArr(5));


