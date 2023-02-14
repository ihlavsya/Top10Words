using System.Text;

namespace Top10Words;

public static class Utils
{
    public static string RemoveSpecialCharacters(string str)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            if ((str[i] == ' ') 
                || (str[i] >= 'A' && str[i] <= 'z')
                || (str[i] >= '0' && str[i] <= '9'))
            {
                sb.Append(str[i]);
            }
        }

        return sb.ToString();
    }
}