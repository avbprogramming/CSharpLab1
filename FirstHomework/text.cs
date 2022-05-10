using System.Runtime.InteropServices;

namespace FirstHomework;

public class Text
{
    private static string[] russianStrings = {
        "У одних родителей мальчик был. Звали его дядя Фёдор.",
        "Зорко одно лишь сердце. Самого главного глазами не увидишь.",
        "Если в мире все бессмысленно, что мешает выдумать какой-нибудь смысл?",
        "Раз у тебя есть лучший друг, его нельзя бросать.",
        "Главное верить. Если веришь, то всё обязательно будет хорошо - даже лучше, чем ты сам можешь устроить."
    };
    private static string[] englishStrings = {
        "Hello world!",
        "Hello people!"
    };

    private static Dictionary<Languages, string[]> languages = new(){{Languages.Russian, russianStrings},
        {Languages.English, englishStrings}};
    public static int GetRandomTextNumber(Languages language)
    {
        var r = new Random();
        var i = r.Next(languages[language].Length);
        //  Console.WriteLine(i);
        return i;
    }

    public static string GetText(int n, Languages language)
    {
        return languages[language][n];
    }
}