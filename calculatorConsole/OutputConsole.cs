using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace calculatorConsole
{
    class OutputConsole
    {

        // Поле.
        static int countnumber = 0;

        // метод для вывода информации для калькулятора.
        public void OutputConsoleText()
        {
            Console.Write("--------------------\r\n");
            Console.Write("   del / \r\n");
            Console.Write(" 7 8 9 * \r\n");
            Console.Write(" 4 5 6 - \r\n");
            Console.Write(" 1 2 3 + \r\n");
            Console.Write("     0 , \r\n");
            Console.Write("--------------------\r\n");
        }

        // метод для ввода информации с калькулятора.
        public int ReadConsoleText()
        {
            for(; ; )
            {
                string readnumber = Console.ReadLine();
                readnumber = readnumber.ToUpper();
                char[] charreadnumber = readnumber.ToCharArray();
                char[] tumlatenumber = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',', '+', '-', '*', '/' };
                char[] clearcharreadnumber = new char[charreadnumber.Length];
                // Ведёной строке ищем символы для калькулятора и перезаписываем в другой массив.
                for (int i = 0; i < charreadnumber.Length; i++)
                {
                    for (int y = 0; y < tumlatenumber.Length; y++)
                    {
                        if (charreadnumber[i] == tumlatenumber[y])
                        {
                            clearcharreadnumber[i] = charreadnumber[i];
                        }
                    }
                }
                // В массиве ищем символы плюс, минус, умножить, делить.
                ArrayList arraylistcountchars = new ArrayList();
                for (int i = 0; i < clearcharreadnumber.Length; i++)
                {
                    if (clearcharreadnumber[i] == '+')
                    {
                        arraylistcountchars.Add(i);
                        arraylistcountchars.Add("+");
                    }
                    if (clearcharreadnumber[i] == '-')
                    {
                        arraylistcountchars.Add(i);
                        arraylistcountchars.Add("-");
                    }
                    if (clearcharreadnumber[i] == '*')
                    {
                        arraylistcountchars.Add(i);
                        arraylistcountchars.Add("*");
                    }
                    if (clearcharreadnumber[i] == '/')
                    {
                        arraylistcountchars.Add(i);
                        arraylistcountchars.Add("/");
                    }
                }
                // Собираем символы в текстовые строки.
                string numberstring = "";
                ArrayList arraylistnumber = new ArrayList();
                for (int i = 0; i < clearcharreadnumber.Length; i++)
                {
                    numberstring = numberstring + clearcharreadnumber[i].ToString();
                }
                string[] arraynumberstring = numberstring.Split(new char[] { '+', '-', '*', '/' });
                // Преобразуем текстовые строки в double.
                for (int i = 0; i < arraynumberstring.Length; i++)
                {
                    try
                    {
                        arraylistnumber.Add(Convert.ToDouble(arraynumberstring[i]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"ислючение:   {ex.Message}");
                    }
                }
                // Собираем массивы.
                bool boolvariantunion = arraylistcountchars[0].Equals(0);
                if (boolvariantunion == false)
                {
                    for (int i = 0; i < arraylistcountchars.Count; i += 2)
                    {
                        arraylistnumber.Insert(i + 1, arraylistcountchars[i + 1]);
                    }
                }
                if (boolvariantunion == true)
                {
                    arraylistnumber.Insert(0, 0);
                    for (int i = 0; i < arraylistcountchars.Count; i += 2)
                    {
                        arraylistnumber.Insert(i + 1, arraylistcountchars[i + 1]);
                    }
                }
                // Удаляем лишние символы + - * /
                bool booldeletechars = arraylistnumber[arraylistnumber.Count - 1].Equals("+") ||
                    arraylistnumber[arraylistnumber.Count - 1].Equals("-") ||
                    arraylistnumber[arraylistnumber.Count - 1].Equals("*") ||
                    arraylistnumber[arraylistnumber.Count - 1].Equals("/");
                if (booldeletechars == true)
                {
                    arraylistnumber.RemoveAt(arraylistnumber.Count - 1);
                }
                // Выводим на экран.
                Console.Write("--------------------\r\n");
                for (int i = 0; i < arraylistnumber.Count; i++)
                {
                    Console.Write("{0}", arraylistnumber[i]);
                }
                Console.Write("\r\n");
                Console.Write("--------------------\r\n");
                double resultcalc = Calc(arraylistnumber);
                Console.Write("Результат =   {0}\r\n", resultcalc);
                Console.Write("--------------------\r\n");
                Console.Write("Нажмите <Esc> для выхода и дважды <Enter> для продолжения...\r\n");
                for(; ; )
                {
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return 1;
                    if (Console.ReadKey().Key == ConsoleKey.Enter) break;
                }
            }
        }
        
        // Метод для расчёта.
        public double Calc(ArrayList arraylistcalc)
        {
            // Расчёт.
            ArrayList arraylistcalccopy = new ArrayList();
            arraylistcalccopy.AddRange(arraylistcalc);
            for( int i = 0; i < arraylistcalccopy.Count; i++ )
            {
                if( arraylistcalccopy[i].ToString() == "+" )
                {
                    arraylistcalccopy.Insert((i + 1), Convert.ToDouble(arraylistcalccopy[i - 1]) + Convert.ToDouble(arraylistcalccopy[i + 1]));
                    arraylistcalccopy.RemoveAt(i + 2);
                }
                if (arraylistcalccopy[i].ToString() == "-")
                {
                    arraylistcalccopy.Insert((i + 1), Convert.ToDouble(arraylistcalccopy[i - 1]) - Convert.ToDouble(arraylistcalccopy[i + 1]));
                    arraylistcalccopy.RemoveAt(i + 2);
                }
                if (arraylistcalccopy[i].ToString() == "*")
                {
                    arraylistcalccopy.Insert((i + 1), Convert.ToDouble(arraylistcalccopy[i - 1]) * Convert.ToDouble(arraylistcalccopy[i + 1]));
                    arraylistcalccopy.RemoveAt(i + 2);
                }
                if (arraylistcalccopy[i].ToString() == "/")
                {
                    arraylistcalccopy.Insert((i + 1), Convert.ToDouble(arraylistcalccopy[i - 1]) / Convert.ToDouble(arraylistcalccopy[i + 1]));
                    arraylistcalccopy.RemoveAt(i + 2);
                }
            }
            return Convert.ToDouble(arraylistcalccopy[arraylistcalccopy.Count - 1]);
        }

        // Метод для вывода экранной заставки.
        public void ScreenSaverCalculator(Object obj)
        {
            Console.Beep(8000, 1000);
            string[] stringdata = new string[] { "К", "А", "Л", "Ь", "К", "У", "Л", "Я", "Т", "О", "Р", " ", "в", "е", "р", "с", "и", "я", " ", "1", ".", "0", "\r\n" };
            if(stringdata.Length > countnumber) Console.Write(stringdata[countnumber]);
            countnumber++;
        }

        // Метод для настройки таймера.
        public void SetTimer()
        {
            Timer timer = new Timer(ScreenSaverCalculator, null, 0, 2000);
            int stringdatalength = 23;
            while(countnumber <= stringdatalength)
            {
                Task.Delay(1000).Wait();
            }
            timer.Dispose();
        }
    }
}
