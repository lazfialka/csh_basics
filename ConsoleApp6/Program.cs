class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            task41 in1 = new task41();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            task43 in2 = new task43();
            System.Console.Write("введите ext чтобы завершить программу или иное, чтобы продолжить >> ");
            string extc = Console.ReadLine();
            if(extc == "ext")
            {
                Environment.Exit(0);
            }
            Console.Clear();
        }
        
    }
}



class task41
{
    public int Prompt(string msg){
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

    public int[] AskForArray(int len)
    {
        int[] arr = new int[len];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Prompt($"Введите {i + 1}-й элемент массива >> ");
        }
        return arr;
    }

    public void PrintArray(int[] arr)
    {
        Console.WriteLine(String.Join(", ", arr));
    }

    public int CountPositive(int[] arr)
    {
        int cnt = 0;
        foreach (int i in arr)
        {
            if (i > 0) cnt++;
        }
        return cnt;
    }

    public task41()
    {
        int len = Prompt("Введите количество элементов >> ");
        int[] arr = AskForArray(len);
        PrintArray(arr);
        Console.WriteLine($"Число положительных элементов в массиве: {CountPositive(arr)}");
    }
}

class task43
{
    public task43()
    {
        Lines lns = RequestLines();
        if (CanIntersect(lns))
        {
            double[] point = FindIntersect(lns);
            lns.PrintLines();
            Console.WriteLine($"пересекаются в точке с координатами x = {point[0]},y = {point[1]}");
        }
    }

    public double Prompt(string msg)
    {
        do
        {
            System.Console.Write(msg);
            string value = Console.ReadLine();
            if (double.TryParse(value, out double result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Чот ты фигню ввёл. Давай снова.");
                //Console.ReadKey();
                //Console.Clear();
            }
        } while (true);
    }

    struct Lines{
        public double[] l1 = new double[2];
        public double[] l2 = new double[2];
        public Lines(double[] l1, double[] l2) { 
            this.l1 = l1;
            this.l2 = l2;
        }
        public Lines() { 
        }

        public void PrintLines()
        {
            Console.WriteLine($"Линия 1: {l1[0]}x+{l1[1]}");
            Console.WriteLine($"Линия 2: {l2[0]}x+{l2[1]}");
        }
    };

    Lines RequestLines() {
        Lines lns = new Lines();
        lns.l1[0] = Prompt("введите k для первой линии >> ");
        lns.l1[1] = Prompt("введите b для первой линии >> ");
        lns.l2[0] = Prompt("введите k для второй линии >> ");
        lns.l2[1] = Prompt("введите b для второй линии >> ");
        return lns;
    }

    double[] FindIntersect(Lines lns)
    {
        double[] coord = new double[2];
        coord[0] = (lns.l1[1] - lns.l2[1])/(lns.l2[0] - lns.l1[0]);
        coord[1] = lns.l1[1] * coord[0] + lns.l1[1];
        return coord;
    }
    bool CanIntersect(Lines lns)
    {
        if (lns.l1[0] == lns.l2[0])
        {
            if(lns.l1[1] == lns.l2[1]){
                Console.WriteLine("прямые совпадают");
            }else{
                Console.WriteLine("прямые параллеьны");
            }
            return false;
        }
        return true;
    }


}