// See https://aka.ms/new-console-template for more information
/* Потому что он был очень серьёзный и самостоятельный. \n " +
      "У одних родителей мальчик был. Звали его дядя Фёдор. 
      Он в четыре года читать научился, а в шесть уже сам себе суп варил. В общем, он был очень хороший мальчик. \n " +
      "И родители были хорошие – папа и мама. И всё было бы хорошо, только мама его зверей не любила. Особенно всяких кошек.\n " +
      "А дядя Фёдор зверей любил, и у него с мамой всегда были разные споры. \n " +
      "А однажды было так. Идёт себе дядя Фёдор по лестнице и бутерброд ест. \n " +
      "Видит – на окне кот сидит. Большой-пребольшой, полосатый. Кот говорит дяде Фёдору: \n " +
      "– Неправильно ты, дядя Фёдор, бутерброд ешь. Ты его колбасой кверху держишь, а его надо колбасой на язык класть. \n" +
      " Тогда вкуснее получится. \n" +
      "Дядя Фёдор попробовал – так и вправду вкуснее. Он кота угостил и спрашивает: \n" +
      "– А откуда ты знаешь, что меня дядей Фёдором звать? \n " +
      "Кот отвечает \n" 
      */

using FirstHomework;

public static class Program
{
    private static List<Attempt> _attempts = new List<Attempt>();
    private static Languages language = Languages.Russian;

    public static void Main()
    {
        Console.WriteLine("Добрый день, сегодня будем практиковаться \"слепой печати.\" \n На выбор есть 4 текста.");
        Menu();

    }


    static void Start()
    {
        var textNumber = Text.GetRandomTextNumber(language);
        var text = Text.GetText(textNumber, language);
        Console.WriteLine("Введите следующий текст: ");
        Console.WriteLine(text);
        DateTime startedAt = DateTime.Now;
        string userInput = Console.ReadLine();
        TimeSpan span = DateTime.Now - startedAt;
        Console.WriteLine($"Ваше время состовило {span}");
        var count = LevenshteinDistance(text, userInput);
        Console.WriteLine($"Кол-во опечаток {count}");
        var attempt = new Attempt(errorCount: count, duration: span, textNumber: textNumber, language: language);
        _attempts.Add(attempt);
    }

    static void Menu()
    {
        //  Console.ReadLine();
        while (true)
        {
            Console.WriteLine("Выберите пункт меню: ");
            Console.WriteLine("0 - Exit ");
            Console.WriteLine($"1 - Start {language}");
            Console.WriteLine("2 - Select language");
            Console.WriteLine("3 - Статистика");
            string? choice = Console.ReadLine();

            if ("0".Equals(choice))
            {
                return;
            }

            if ("1".Equals(choice))
            {
                Start();
                continue;
            }      if ("2".Equals(choice))
            {
                SelectLanguage();
                continue;
            }
          if ("3".Equals(choice))
                  {
                      ShowStat();
                      continue;
                  }

            Console.WriteLine("Невернный ввод.");
        }
    }

    private static void ShowStat()
    {
        var (avg, max, min) = CountStat();
        Console.WriteLine($"у вас было {_attempts.Count} попыток, средняя скорость - {avg} зн/сек, лучшая - {max} зн/сек, худшая {min} зн/сек");
    }

    private static (int avg, int max, int min) CountStat()
    {
        var avg = (int) _attempts.Average(a => a.typingSpeed);
        var max = _attempts.Max(a => a.typingSpeed);
        var min = _attempts.Min(a => a.typingSpeed);

        return (avg, max, min);
    }

    private static void SelectLanguage()
    {
        while (true)
        {
                Console.WriteLine("Выберите язык ");
                Console.WriteLine("1 - Russian");
                Console.WriteLine("2 - English");
                string? choice = Console.ReadLine();
                if ("1".Equals(choice))
                {
                    language = Languages.Russian;
                    return;
                }      if ("2".Equals(choice))
                {
                    language = Languages.English;
                    return;
                }

                Console.WriteLine("Невернный ввод.");
        }
        
    
    }


    static void MenuLanguage()
    {
        Console.ReadLine();
        DateTime startedAt = DateTime.Now;
        string userInput = Console.ReadLine();
        TimeSpan span = DateTime.Now - startedAt;
        Console.WriteLine(span);
        Console.WriteLine(userInput);
        Console.WriteLine("Хотите попробовать еще? Д / Н ");
        string choice = Console.ReadLine();
        try
        {
            if (choice.Equals("Д"))
            {
                Console.WriteLine("Введите тест снова:");
                Menu();
            }
            else if (choice.Equals("Н"))
            {
                Console.WriteLine("Спасибо за труд!");
            }
            else
            {
                Console.WriteLine("Выбор. Д / Н. Попробовать еще?");
                Menu();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("u");
            throw;
        }
    }

    static void CheckGramma(string a, string b)
    {
        CheckGramma(a.Split(" "), b.Split(" "));
    }

    static void CheckGramma(string[] a, string[] b)
    {
        var count = 0;
        if (a.Length == b.Length)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!a[i].Equals(b[i]))
                {
                    count++;
                }
            }

            return;
        }
    }

    public static int LevenshteinDistance(string string1, string string2)
    {
        if (string1 == null) throw new ArgumentNullException("string1");
        if (string2 == null) throw new ArgumentNullException("string2");
        int diff;
        int[,] m = new int[string1.Length + 1, string2.Length + 1];

        for (int i = 0; i <= string1.Length; i++)
        {
            m[i, 0] = i;
        }

        for (int j = 0; j <= string2.Length; j++)
        {
            m[0, j] = j;
        }

        for (int i = 1; i <= string1.Length; i++)
        {
            for (int j = 1; j <= string2.Length; j++)
            {
                diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
            }
        }

        return m[string1.Length, string2.Length];
    }
}