using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1

{

    class chekIt
    {

        public int[] daysOfMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };     
        public bool chekOnDayInWeek(int day, int month, int year, bool exit)
        {
            if (day != daysOfMonth[month - 1] && month != 2)  
            {
                return exit = true;
            }
            if (day == daysOfMonth[month - 1])                //якщо це останній день місяця, перевірити збіг
            {
                return exit = true;
            }
            else if ((month == 2) && (year % 4 == 0) && (day == 29))  // якщо це останній день лютого високосного року, то всі норми
            {
                return exit = true;
            }
            else
            {
                Console.WriteLine("Дані введені неправильно, спробуйте знову ввести!"); // інакше, запропонувати ввести знову
                return exit = false;
            }
        }

        public int output(int day, int month, int year, int week)
        {
            int count = 1;
            Console.WriteLine("ПН\tВТ\tСР\tЧТ\tПТ\tСБ\tВС");
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                    if (count - 1 == daysOfMonth[month - 1])
                    {
                        break;
                    }
                    if (count == day)
                    {
                        Console.Write("[{0}]\t", count);
                        count++;
                        continue;
                    }
                    Console.Write(" {0}\t", count);
                    count++;
                }
                Console.WriteLine("\n");

            }
            return 0;
        }

        public int dayOfWeek(int day, int month, int year)              // просто формула знаходження дня тижня за датою
        {
            int a = (14 - month) / 12;
            int y = year - a;
            int m = month + 12 * a - 2;
            return ((7000 + (day + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12)) % 7) + 1;
        }

    }



    class Program
    {

        
        static void Main(string[] args)
        {
            Meeting m1 = new Meeting("12.30", "13.30");
            Birthday m2 = new Birthday("+3802124356");
            Console.WriteLine("Введіть подію 1-Meeting, 2-Birthday");
            int eventType = Int32.Parse(Console.ReadLine());

            if (eventType == 1)
            {
                Console.WriteLine($"{m1.beginTime} {m1.endTime}");
            }
            else if (eventType == 2) 
            {
                Console.WriteLine(m2.Contacts);
            }

            chekIt e = new chekIt();
            string input = " ";      //Вхідні дані
            int day, month, year;    //Тут будуть зберігатися значення наведені в інт.
            bool chek = false;       //Вихід із циклу, отже введені дані вірні.

            Console.WriteLine("Введіть день, місяць та рік потрібної дати, розділений пробілом у форматі dd mm yyyy:");

            while (!chek)            // Перевіряємо рядок на коректність, якщо пройшли – йдемо далі.
            {
                input = Console.ReadLine();

                // Ділимо рядок на 3 числа

                string[] massSplit = input.Split(' ');


                if (massSplit.Length != 3)
                {
                    Console.WriteLine("Введено не всі дані або занадто багато, повторіть введення у форматі dd mm yyyy!");
                    continue;
                }

                if (massSplit[0] == "")
                {
                    Console.WriteLine("Перший символ не може бути пробілом!");
                    continue;
                }
                // Наводимо наш інпут у цілі числа
                try
                {
                    day = Convert.ToInt32(massSplit[0]);
                    month = Convert.ToInt32(massSplit[1]);
                    year = Convert.ToInt32(massSplit[2]);
                }
                catch
                {
                    Console.WriteLine("Введений символ або символи не є числами, повторіть введення!");
                    continue;
                }
                // Перевіряємо коректність даних
                if (day <= 0 || day > 31)
                {
                    Console.WriteLine("Значення дня може бути від 1 до 31, повторіть введення!");
                    continue;
                }
                if (month <= 0 || month > 12)
                {
                    Console.WriteLine("Значення місяця може бути числом від 1 до 12, повторіть введення!");
                    continue;
                }
                if (year < 1600 || year > 2400)
                {
                    Console.WriteLine("Значення року може бути від 1600 до 2400, повторіть введення!");
                    continue;
                }


                chek = e.chekOnDayInWeek(day, month, year, chek);
                if (chek != true)
                {
                    continue;
                }
                // Дізнаємося день неділи


                int week = e.dayOfWeek(day, month, year);

                switch (week)
                {
                    case 1:
                        {
                            Console.WriteLine("Цього дня неділя!");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Цього дня понеділок!");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Цього дня вівторок!");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Цього дня середа!");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Цього дня четвер!");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Цього дня п'ятниця!");
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Цього дня субота!");
                            break;
                        }
                }
                e.output(day, month, year, week);
                int[,] arrDayOfWeek = new int[7, 7];
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        arrDayOfWeek[i, j] = 0; 
                    }
                }
            }

            Console.ReadKey();
        }
    }


}