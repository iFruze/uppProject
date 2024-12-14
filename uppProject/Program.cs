using Frame;
using System.Text.RegularExpressions;
using System.Collections;
using uppProject;


Console.WriteLine("Создать два объекта типа Team с совпадающими данными и проверить, что ссылки на объекты не равны, а объекты равны, вывести значения хэш-кодов для объектов:");
Team team1 = new Team();
Team team2 = new Team();
Console.WriteLine(team1);
Console.WriteLine(team2);
Console.WriteLine($"Равенство ссылок: {(object)team1 == (object)team2}\nРавенство объектов: {team1 == team2}");
Console.WriteLine();
try
{
    team1.RegisterNumber = -1;
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine();
ResearchTeam team = new ResearchTeam();
team.AddMembers(new Person(), new Person(), new Person(), new Person());
team.AddPapers(null, new Paper(), new Paper(), new Paper());
Console.WriteLine(team);
Console.WriteLine("Родительский класс:");
Console.WriteLine(team.Base);


INameAndCopy temp = team;
ResearchTeam copyTeam = (temp.DeepCopy()) as ResearchTeam;
team.AddPapers(null, new Paper(), new Paper());
team.Title = "Team Project";
Console.WriteLine("\nИзменённый оригинал:");
Console.WriteLine(team);
Console.WriteLine("Копия:");
Console.WriteLine(copyTeam);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Участники команды:");
foreach (var t in team.Persons) Console.WriteLine($"{t}\n");
Console.ResetColor();
Console.WriteLine("\nУчастники без публикаций:");
foreach(var t in team.PersonsWithoutPublications()) Console.WriteLine(t);

Console.WriteLine("\nПубликации за последние два года:");
foreach (int t in team.PublicationsFromNYears(2)) Console.WriteLine(team.Papers[t]);

Console.WriteLine("\nУчастники у которых есть публикации:");
team.AddPapers(team.Persons[0] as Person, new Paper(), new Paper());
foreach (var t in team) Console.WriteLine(t);


Console.WriteLine("\nУчастники у которых больше 1 публикации:");
foreach (var t in team.PersonsWhithMoreThanOnePublications()) Console.WriteLine(t);

Console.WriteLine("\nПубликации за последний год:");
foreach (int t in team.PublicationsFromNYears(1)) Console.WriteLine(team.Papers[t]);


Console.ForegroundColor= ConsoleColor.Red;
Console.WriteLine("\nИССЛЕДОВАНИЕ:\n");
Console.WriteLine(team);
Console.ResetColor();






//while(true)
//{
//    try
//    {
//        Console.Write("1 - Создать публикацию\n2 - Добавить стнаницу\n3 - Самая поздняя публиакция\n4 - Сравнение операций с массивами\n5 - Посмотреть всю публикацию\n6 - Сравнение времени проведения исследований\n7 - Добавить автора\n0 - Выход\nПункт: ");
//        int punct = Convert.ToInt32(Console.ReadLine());
//        switch (punct)
//        {
//            case 0:
//                Environment.Exit(0);
//                break;
//            case 1:
//                //string title, org;
//                //int regNumber;
//                //TimeFrame time;
//                //Console.Write("Название публикации: ");
//                //title = Console.ReadLine();
//                //Console.Write("Организация, проводившая исследование: ");
//                //org = Console.ReadLine();
//                //Console.Write("Номер: ");
//                //regNumber = Convert.ToInt32(Console.ReadLine());
//                //int t = -1;
//                //do
//                //{
//                //    Console.Write("Как долго проводились исследования?\n1 - Год\n2 - Два года\n3 - Долго\nПункт: ");
//                //    t = Convert.ToInt32(Console.ReadLine());
//                //} while (t < 1 || t > 3);
//                //time = t switch
//                //{
//                //    1 => TimeFrame.Year,
//                //    2 => TimeFrame.TwoYears,
//                //    3 => TimeFrame.Long
//                //};
//                //team = new ResearchTeam(title, org, regNumber, time);
//                f1 = true;
//                break;
//            case 2:
//                if (f1 == false)
//                {
//                    throw new Exception("Сначала надо создать публикацию.");
//                }
//                if (authors == false) throw new Exception("Сначала надо добавить хотя бы одного автора.");
//                //string publication;
//                //string name, surname;
//                //int year, month, day;
//                //int year1, month1, day1;
//                //Console.Write("Название исследования: ");
//                //publication = Console.ReadLine();
//                //Console.Write("Имя автора: ");
//                //name = Console.ReadLine();
//                //Console.Write("Фамилия автора: ");
//                //surname = Console.ReadLine();
//                //bool f = true;
//                //DateTime dataB;
//                //do
//                //{
//                //    f = true;
//                //    Console.WriteLine("Введите дату рождения автора в формате: yyyy.mm.dd");
//                //    string date1 = Console.ReadLine();
//                //    if (!DateTime.TryParse(date1, out dataB))
//                //    {
//                //        Console.WriteLine("Ошибка ввода, повторите.");
//                //        f = false;
//                //    }

//                //} while (f == false);
//                //DateTime dataP;
//                //do
//                //{
//                //    f = true;
//                //    Console.WriteLine("Введите дату выпска исследования в формате: yyyy.mm.dd");
//                //    string date1 = Console.ReadLine();
//                //    if (!DateTime.TryParse(date1, out dataP))
//                //    {
//                //        Console.WriteLine("Ошибка ввода, повторите.");
//                //        f = false;
//                //    }
//                //} while (!f);
//                //Paper pap = new Paper(publication, new Person(name, surname, dataB), dataP);
//                //team.AddPapers(pap);
//                //Paper paper = new Paper();
//                team.AddPapers(new Paper(), new Paper(), new Paper(), new Paper(), new Paper(), new Paper(), new Paper());
//                break;
//            case 3:
//                if (f1 == false)
//                {
//                    throw new Exception("Сначала надо создать публикацию.");
//                }
//                Console.WriteLine($"Самая поздняя публикация:\n{team.LastPublication}");
//                break;
//            case 4:

//                Paper[] paper1 = new Paper[10000];
//                for (int i = 0; i < paper1.Length; i++) paper1[i] = new Paper();
//                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
//                sw.Start();
//                int a1 = Environment.TickCount;
//                for (int i = 0; i < paper1.Length; i++)
//                    paper1[i].Date = DateTime.Now;
//                int a2 = Environment.TickCount;
//                sw.Stop();
//                Console.WriteLine(sw.ElapsedMilliseconds);
//                //Console.WriteLine(  sw.ElapsedTicks);
//                Paper[,] paper2 = new Paper[100, 100];
//                for (int i = 0; i < paper2.GetLength(0); i++)
//                    for (int j = 0; j < paper2.GetLength(1); j++)
//                        paper2[i, j] = new Paper();
//                sw.Reset();
//                sw.Start();
//                for (int i = 0; i < paper2.GetLength(0); i++)
//                    for (int j = 0; j < paper2.GetLength(1); j++)
//                        paper2[i, j].Date = DateTime.Now;
//                sw.Stop();
//                Console.WriteLine(sw.ElapsedMilliseconds);
//                Paper[][] paper3 = new Paper[100][];
//                for (int i = 0; i < paper3.GetLength(0); i++)
//                {
//                    paper3[i] = new Paper[100];
//                    for (int j = 0; j < paper3[i].Length; j++)
//                        paper3[i][j] = new Paper();
//                }
//                sw.Reset();
//                sw.Start();
//                for (int i = 0; i < paper3.GetLength(0); i++)
//                    for (int j = 0; j < paper3[i].Length; j++)
//                        paper3[i][j].Date = DateTime.Now;
//                sw.Stop();
//                Console.WriteLine(sw.ElapsedMilliseconds);
//                break;
//            case 5:
//                if (f1 == false)
//                {
//                    throw new Exception("Сначала надо создать публикацию.");
//                }
//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine(team);
//                Console.ResetColor();
//                break;
//            case 6:
//                if (f1 == false)
//                {
//                    throw new Exception("Сначала надо создать публикацию.");
//                }
//                int pp = 0;
//                do
//                {
//                    Console.Write("Как долго проводились исследования?\n1 - Год\n2 - Два года\n3 - Долго\nПункт: ");
//                    pp = Convert.ToInt32(Console.ReadLine());
//                } while (pp < 1 || pp > 3);
//                TimeFrame temp = pp switch
//                {
//                    1 => TimeFrame.Year,
//                    2 => TimeFrame.TwoYears,
//                    3 => TimeFrame.Long
//                };
//                Console.WriteLine(team[temp]);
//                break;
//            case 7:
//                team.AddMembers(new Person(), new Person(), new Person());
//                authors = true;
//                break;
//            default:
//                Console.WriteLine("Такого пункта нет.");
//                break;
//        }
//    }
//    catch (ArgumentNullException ex)
//    {
//        Console.WriteLine(ex.ParamName);
//    }
//    catch (ArgumentException ex)
//    {
//        Console.WriteLine(ex.ParamName);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}
