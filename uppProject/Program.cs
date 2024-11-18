using Frame;
using uppProject;
bool f1 = false;
ResearchTeam team = new ResearchTeam();
while(true)
{
    try
    {
        Console.Write("1 - Создать публикацию\n2 - Добавить стнаницу\n3 - Самая поздняя публиакция\n4 - Сравнение операций с массивами\n5 - Посмотреть всю публикацию\n6 - Сравнение времени проведения исследований\n0 - Выход\nПункт: ");
        int punct = Convert.ToInt32(Console.ReadLine());
        switch (punct)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                string title, org;
                int regNumber;
                TimeFrame time;
                Console.Write("Название публикации: ");
                title = Console.ReadLine();
                Console.Write("Организация, проводившая исследование: ");
                org = Console.ReadLine();
                Console.Write("Номер: ");
                regNumber = Convert.ToInt32(Console.ReadLine());
                int t = -1;
                do
                {
                    Console.Write("Как долго проводились исследования?\n1 - Год\n2 - Два года\n3 - Долго\nПункт: ");
                    t = Convert.ToInt32(Console.ReadLine());
                } while (t < 1 || t > 3);
                time = t switch
                {
                    1 => TimeFrame.Year,
                    2 => TimeFrame.TwoYears,
                    3 => TimeFrame.Long
                };
                team = new ResearchTeam(title, org, regNumber, time);
                f1 = true;
                break;
            case 2:
                if (f1 == false)
                {
                    throw new Exception("Сначала надо создать публикацию.");
                }
                string publication;
                string name, surname;
                int year, month, day;
                int year1, month1, day1;
                Console.Write("Название исследования: ");
                publication = Console.ReadLine();
                Console.Write("Имя автора: ");
                name = Console.ReadLine();
                Console.Write("Фамилия автора: ");
                surname = Console.ReadLine();
                Console.Write("Год рождения автора: ");
                year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Месяц рождения автора: ");
                month = Convert.ToInt32(Console.ReadLine());
                Console.Write("День рождения автора: ");
                day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Год выпуска исследования: ");
                year1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Месяц выпуска исследования: ");
                month1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("День выпуска исследования: ");
                day1 = Convert.ToInt32(Console.ReadLine());
                Paper pap = new Paper(publication, new Person(name, surname, new DateTime(year, month, day)), new DateTime(year1, month1, day1));
                team.AddPapers(pap);
                break;
            case 3:
                if (f1 == false)
                {
                    throw new Exception("Сначала надо создать публикацию.");
                }
                Console.WriteLine($"Самая поздняя публикация:\n{team.Search()}");
                break;
            case 4:
                Paper[] paper1 = new Paper[1000000];
                for (int i = 0; i < paper1.Length; i++) paper1[i] = new Paper();
                int a1 = Environment.TickCount;
                for (int i = 0; i < paper1.Length; i++)
                    paper1[i].Date = DateTime.Now;
                int a2 = Environment.TickCount;
                Console.WriteLine($"Время затраченноет на операцию с одномерным массивом: {a2 - a1}");
                Paper[,] paper2 = new Paper[1000, 1000];
                for (int i = 0; i < paper2.GetLength(0); i++)
                    for (int j = 0; j < paper2.GetLength(1); j++)
                        paper2[i, j] = new Paper();
                a1 = Environment.TickCount;
                for (int i = 0; i < paper2.GetLength(0); i++)
                    for (int j = 0; j < paper2.GetLength(1); j++)
                        paper2[i, j].Date = DateTime.Now;
                a2 = Environment.TickCount;
                Console.WriteLine($"Время затраченноет на операцию с двумерным массивом: {a2 - a1}");
                Paper[][] paper3 = new Paper[1000][];
                for (int i = 0; i < paper3.GetLength(0); i++)
                {
                    paper3[i] = new Paper[1000];
                    for (int j = 0; j < paper3[i].Length; j++)
                        paper3[i][j] = new Paper();
                }
                a1 = Environment.TickCount;
                for (int i = 0; i < paper3.GetLength(0); i++)
                    for (int j = 0; j < paper3[i].Length; j++)
                        paper3[i][j].Date = DateTime.Now;
                a2 = Environment.TickCount;
                Console.WriteLine($"Время затраченноет на операцию с двумерным ступенчатым массивом: {a2 - a1}");
                break;
            case 5:
                if (f1 == false)
                {
                    throw new Exception("Сначала надо создать публикацию.");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(team.Show());
                Console.ResetColor();
                break;
            case 6:
                if (f1 == false)
                {
                    throw new Exception("Сначала надо создать публикацию.");
                }
                int pp = 0;
                do
                {
                    Console.Write("Как долго проводились исследования?\n1 - Год\n2 - Два года\n3 - Долго\nПункт: ");
                    pp = Convert.ToInt32(Console.ReadLine());
                } while (pp < 1 || pp > 3);
                TimeFrame temp = pp switch
                {
                    1 => TimeFrame.Year,
                    2=>TimeFrame.TwoYears,
                    3=>TimeFrame.Long
                };
                Console.WriteLine(team[temp]);
                break;
            default:
                Console.WriteLine("Такого пункта нет.");
                break;
        }
    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine(ex.ParamName);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.ParamName);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
