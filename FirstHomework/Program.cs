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


      Console.WriteLine("Добрый день, сегодня будем практиковаться \"слепой печати.\" \n Твой первый текст:");
      text.firstText();
      Menu();

      static void Menu()
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