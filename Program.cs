Main main = new Main();

main.MainProgram();
internal class Main
{
  Tasks t = new Tasks();
  Methods m = new Methods();
  public void MainProgram()
  {
    Console.Clear();
    bool isWork = true;

    while (isWork)
    {
      Console.WriteLine($"Данная программа отсортирует ваш массив по длине, до 3 символов включительно.{Environment.NewLine}"
                      + $"Для начала напишите \"Start\"{Environment.NewLine}"
                      + $"Для выхода напишите \"Exit\"");
      
      string s = m.ReadString("ваш выбор").ToLower();
      if (s == "start" || s == "s" || s == "ы")
      {
        t.MainTask();
      }
      else if (s == "exit" || s == "e" || s == "у")
      {
        isWork = m.ToExit();
      }
      else
      {
        Console.WriteLine("Команда не распознана, нажмите любую клавишу для повтора");
        Console.ReadKey();
      }
    }
  }
}
internal class Methods
{
  #region MethodsForTasks
    public string ReadString(string argument)
    {
      Console.Write($"Введите {argument}: ");
      return Console.ReadLine();
    }

    public int ReadInt(string argument)
    {
      int i;
      Console.Write($"Введите {argument}: ");

      while(!int.TryParse(Console.ReadLine(), out i))
      {
        Console.Write("Не смогли получить целое число, повторите");
      }

      return i;
    }

    public void PrintArray(string[] array, string arg)
    {
      Console.Write($"{arg} ");

      for (int i = 0; i < array.Length; i++)
      {
        if (i == array.Length - 1)
        {
          Console.WriteLine($"{array[i]}");
        }
        else
        {
          Console.Write($"{array[i]}, ");
        }
      }
    }

    public string[] GetFilledArrayOfString(int length)
    {
      string[] array = new string[length];

      for (int i = 0; i < length; i++)
      {
        array[i] = ReadString("элемент массива");
      }

      return array;
    }

    public string[] GetRandomlyFilledArray(int length)
    {
      string[] array = new string[length];

      for (int i = 0; i < length; i++)
      {
        array[i] = GetRandomWord();
      }

      return array;
    }

    public string GetRandomWord()
    {
      Random random = new Random();
      string word = String.Empty;
      string[] array = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", 
                                     "j", "k", "l", "m", "n", "o", "p", "q", "r", 
                                     "s", "t", "u", "v", "w", "x", "y", "z", "0", 
                                     "1", "2", "3", "4", "5", "6", "7", "8", "9"};
      int minRandom = 1;
      int maxRandom = 7;

      for(int i = 0; i < random.Next(minRandom, maxRandom); i++)
      {
        word += array[random.Next(0, array.Length)];
      }

      return word;
    }

    public string[] GetArrayOfStringLessThanLength(int length, string[] arr)
    {
      string[] array = new string[GetCountOfWordLessThanLength(length, arr)];
      int k = 0;

      for (int j = 0; j < arr.Length; j++)
      {
        if (arr[j].Length < length)
        {
          array[k] = arr[j];
          k++;
        }
      }

      return array;
    }

    public int GetCountOfWordLessThanLength(int length, string[] arr)
    {
      int count = 0;

      for (int i = 0; i < arr.Length; i++)
      {
        if (arr[i].Length < length) count++;
      }

      return count;
    }
  #endregion

  #region MethodsForProgram

  public bool ToExit()
  {
    return false;
  }

  #endregion
}
internal class Tasks
{
Methods m = new Methods();

  public void MainTask()
  {
    Console.WriteLine($"{Environment.NewLine}Как хотите заполнить массив:{Environment.NewLine}"
                    + $"1. Вручную{Environment.NewLine}"
                    + $"2. Случайным образом");
    string number = m.ReadString("номер варианта");

    if (number == "1" || number == "2")
    {
      switch (number)
      {
        case "1":
          TaskManualy();
          Console.ReadKey();
          break;

        case "2":
          TaskRandomly();
          Console.ReadKey();
          break;
      }
    }
    else
    {
      Console.WriteLine("Нет такого значения, поэтому заполним случайным образом");

      TaskRandomly();
      Console.ReadKey();
    }
  }

  public void TaskManualy()
  {
    Console.WriteLine();
    int maxLength = 4;
    
    string[] array = m.GetFilledArrayOfString(m.ReadInt("длину массива"));
    m.PrintArray(array, "Изначальный массив:");

    string[] arr = m.GetArrayOfStringLessThanLength(maxLength, array);
    m.PrintArray(arr, "Итоговый массив:");
    Console.WriteLine();
  }

  public void TaskRandomly()
  {
    Console.WriteLine();
    int maxLength = 4;

    string[] array = m.GetRandomlyFilledArray(m.ReadInt("длину массива"));
    m.PrintArray(array, "Изначальный массив:");

    string[] arr = m.GetArrayOfStringLessThanLength(maxLength, array);
    m.PrintArray(arr, "Итоговый массив:");
    Console.WriteLine();
  }
}