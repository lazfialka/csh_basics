class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Matrix mt = new Matrix();
            mt.Print();
            Console.WriteLine("запрос элемента");
            Console.WriteLine(mt.FindElement((uint)Matrix.Prompt("введите искомый столбец >> "), (uint)Matrix.Prompt("введите искомую строку >> ")));
            Console.WriteLine("вывод среднего значения столбцов: ");
            Console.WriteLine(String.Join("\t",mt.ColumnMeans()));
            Console.WriteLine("произведение матриц: ");
            Matrix mt2 = new Matrix();
            mt2.Print();
            Console.WriteLine("вывод произведения: ");
            Matrix.Mult(mt,mt2).Print();
            Console.WriteLine("заполнение спиралью: ");
            mt.FillSpiralCons().Print();



            System.Console.Write("введите ext чтобы завершить программу или иное, чтобы продолжить >> ");
            string extc = Console.ReadLine();
            if (extc == "ext")
            {
                Environment.Exit(0);
            }
            Console.Clear();
        }

    }
}


class Matrix
{
    public Matrix(int rw, int cn)
    {
        mt = new int[rw, cn];
        Random generator = new Random();
        for (int i = 0; i < rw; ++i)
        {
            for (int j = 0; j < cn; ++j)
                mt[i, j] = generator.Next(-Int32.MaxValue, Int32.MaxValue) % 1000;
        }
    }
    public Matrix(int[,] inp)
    {
        mt = inp;
    }
    public Matrix() :
        this(Prompt("введите число столбцов матрицы >> "), Prompt("введите число строк матрицы >> "))
    { }
    public void Print()
    {
        int rw = mt.GetUpperBound(0) + 1;
        int cn = mt.GetUpperBound(1) + 1;
        for (int i = 0; i < rw; ++i)
        {
            for (int j = 0; j < cn; ++j)
            {
                Console.Write($"{mt[i, j]}\t");
            }
            Console.Write("\n");
        }
    }

    public double FindElement(uint r, uint c) {
        int rw = mt.GetUpperBound(0) + 1;
        int cn = mt.GetUpperBound(1) + 1;
        if (c > cn || r > rw) return double.NaN;
        return (double)mt[c-1, r-1];
    }
    public int[] ColumnMeans()
    {
        int rw = mt.GetUpperBound(0) + 1;
        int cn = mt.GetUpperBound(1) + 1;
        int[] ret = new int[cn];
        for (int j = 0; j < cn; ++j)
        {
            for (int i = 0; i < rw; ++i)
            {
                ret[j] += mt[i, j];
            }
            ret[j] /= rw;
        }
        return ret;
    }

    public Matrix SortRows() {
        int rw = mt.GetUpperBound(0) + 1;
        int cn = mt.GetUpperBound(1); // sic!
        int[,] ret = mt;
        int ovr;
        for (int j = 0; j < rw; ++j)
        {
            ovr = 0;
            do
            {
                for (int i = 0; i < cn; ++i) {
                    if (ret[i, j] > ret[i + 1, j]) {
                        ret[i, j]     += ret[i+1, j];
                        ret[i+1, j]   -= ret[i, j];
                        ret[i, j]     -= ret[i+1, j];
                    }
                }
            } while (ovr > 0);
        }
        return new Matrix(ret);
    }

    public int FindMinSumRow()
    {
        int rw = mt.GetUpperBound(0) + 1;
        int cn = mt.GetUpperBound(1) + 1;
        int ret = 0;
        int cmp = 0;
        for (int i = 0; i < rw; ++i) 
        {
            cmp = 0;
            for (int j = 0; j < cn; ++j)
            {
                cmp += mt[i, j];
            }
            ret = (cmp > ret) ? cmp : ret;
        }
        return ret;
    }

    public static Matrix Mult(Matrix amp, Matrix inp)
    {
        int mrw = amp.mt.GetUpperBound(0) + 1;
        int mcn = amp.mt.GetUpperBound(1) + 1;
        int irw = inp.mt.GetUpperBound(0) + 1;
        int icn = inp.mt.GetUpperBound(1) + 1;
        if (mcn != irw) {
            Console.WriteLine("Wrong sizes");
            return new Matrix(new int[0, 0]);
        }
        int[,] retmt= new int[mrw, icn];
        for(int i = 0; i < mrw; ++i)    
        {
            for (int j = 0; j < icn; ++j)
            {
                for(int k = 0; k < mcn; ++k)
                {
                    retmt[i,j] += amp.mt[i, k] * inp.mt[k, j];
                }
            }
        }
        return new Matrix(retmt);
    }

    public Matrix FillSpiralCons() {
        int m = mt.GetUpperBound(0) + 1;
        int n = mt.GetUpperBound(1) + 1;
        int[,] matrix = new int[m, n];
        int value = 1;
        int top = 0;
        int bottom = n - 1;
        int left = 0;
        int right = m - 1;
        while (value <= n * m)
        {
            for (int i = left; i <= right; i++)
            {
                matrix[top, i] = value++;
            }
            top++;
            for (int i = top; i <= bottom; i++)
            {
                matrix[i, right] = value++;
            }
            right--;
            for (int i = right; i >= left; i--)
            {
                matrix[bottom, i] = value++;
            }
            bottom--;
            for (int i = bottom; i >= top; i--)
            {
                matrix[i, left] = value++;
            }
            left++;
        }
        return new Matrix(matrix);
    }

    public int[,] mt { get; }

    public static int Prompt(string msg)
    {
        do
        {
            System.Console.Write(msg);
            string value = Console.ReadLine();
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Чот ты фигню ввёл. \n Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        } while (true);
    }
}