using System.Linq;

string GetDesiredDigit(int num, int digit) {
    string numStr = num.ToString();
    if (digit <= 0) {
        return "digit has to be integer positive > 0";
    }
    if (numStr.Length >= digit) {
        return numStr[digit-1].ToString();
    }
    return String.Join("lenthg is less than",digit);
}

string isWeekend(uint day) {
    if (day > 7) {
        return "only 7 days in week, OK?";
    }
    if (day >= 6)
    {
        return "Hooray, weekend day!";
    }
    else {
        return "opyat rabota?";
    }
}


Console.WriteLine(GetDesiredDigit(325,1));
Console.WriteLine(isWeekend(5));
Console.WriteLine(isWeekend(6));
