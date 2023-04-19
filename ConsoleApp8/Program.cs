Console.WriteLine("Task 1 \n");
Console.WriteLine(String.Join(" ", NaturalNumbers(5)));
Console.WriteLine(String.Join(" ", NaturalNumbers(8)));
Console.WriteLine("\nTask 2 \n");
Console.WriteLine(SumOfNumbersBetween(1,15));
Console.WriteLine(SumOfNumbersBetween(4,8));
Console.WriteLine("\nTask 3 \n");
Console.WriteLine(Ackermann(2, 3));
Console.WriteLine(Ackermann(3, 2
    ));


uint[] NaturalNumbers(uint N)
{
    if (N == 1)
    {
        return new uint[] { 1 };
    }
    else
    {
        uint[] result = new uint[N];
        result[0] = N;
        Array.Copy(NaturalNumbers(N - 1), 0, result, 1, N - 1);
        return result;
    }
}


uint SumOfNumbersBetween(uint M, uint N)
{
    if (M > N)
    {
        return 0;
    }
    else if (M == N)
    {
        return M;
    }
    else
    {
        return M + SumOfNumbersBetween(M + 1, N);
    }
}


uint Ackermann(uint m, uint n)
{
    if (m == 0)
    {
        return n + 1;
    }
    else if (n == 0)
    {
        return Ackermann(m - 1, 1);
    }
    else
    {
        return Ackermann(m - 1, Ackermann(m, n - 1));
    }
}