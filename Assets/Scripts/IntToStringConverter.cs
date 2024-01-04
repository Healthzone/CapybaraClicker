using System.Collections.Generic;
using System.Numerics;
using System.Text;

public static class IntToStringConverter
{
    private static List<string> nStringFormat = new List<string>()
    {
        "",
        "���.",
        "���.",
        "����.",
        "����."
    };

    public static string Int2String(ulong value)
    {
        int num = 0;
        ulong mod = 0;
        while (value >= 1000)
        {
            num++;
            mod = value % 1000 / 10;
            value /= 1000;
        }
        if (num == 0)
            return new StringBuilder(value.ToString("D1"))
                .Append(nStringFormat[num]).ToString();
        else
            return new StringBuilder(value.ToString("D1"))
                .Append(".")
                .Append(mod.ToString("D2"))
                .Append(nStringFormat[num]).ToString();
        //return value.ToString("D1") + nStringFormat[num];
    }
}
