namespace xxx
{
    internal class Program
    {
        static void Main()
        {
            var hmnLst = FillCorp();

            //подстановка имени если изначально было неизвестно

            var code = Console.ReadLine();
            var tmpE = new List<Human>();
            var tmp = SearchUnders(hmnLst, code, ref tmpE);
            if (tmp != null)
            {
                foreach (var item in tmp)
                {
                    Console.WriteLine($"{item.GetCode()} {item.GetName()}");
                }
            }
            Console.ReadKey();
        }

        static List<Human> FillCorp()
        {
            bool tmp = true;
            List<Human> hmnLst = new List<Human>();
            while (tmp)
            {
                string bss = Console.ReadLine();
                if (bss == "end") { tmp = false; break; }
                string uss = Console.ReadLine();

                if (bss.Contains(' ') && uss.Contains(' '))
                {
                    string[] bs = bss.Split(' ', 2);
                    string[] us = uss.Split(' ', 2);

                    if (hmnLst.Exists(e => e.GetCode() == bs[0]))
                    {
                        if (hmnLst.Find(e => e.GetCode() == bs[0]).GetName() == "Unknown name")
                        {
                            hmnLst.Find(e => e.GetCode() == bs[0]).SetName(bs[1]);
                        }
                        var tmpUs = new Human(us[0], us[1]);
                        hmnLst.Add(tmpUs);
                        hmnLst.Find(e => e.GetCode() == bs[0]).Append(tmpUs);
                    }

                    else
                    {
                        var usE = new Human(us[0], us[1]);
                        var bsE = new Human(bs[0], usE, bs[1]);
                        hmnLst.Add(bsE);
                        hmnLst.Add(usE);
                    }
                }
                else if (bss.Contains(' '))
                {
                    string[] bs = bss.Split(' ', 2);
                    if (hmnLst.Exists(e => e.GetCode() == bs[0]))
                    {
                        var tmpUs = new Human(uss);
                        hmnLst.Add(tmpUs);
                        hmnLst.Find(e => e.GetCode() == bs[0]).Append(tmpUs);
                    }

                    else
                    {
                        var usE = new Human(uss);
                        var bsE = new Human(bs[0], usE, bs[1]);
                        hmnLst.Add(bsE);
                        hmnLst.Add(usE);
                    }
                }
                else if (uss.Contains(' '))
                {
                    string[] us = uss.Split(' ', 2);
                    if (hmnLst.Exists(e => e.GetCode() == bss))
                    {
                        var tmpUs = new Human(us[0], us[1]);
                        hmnLst.Add(tmpUs);
                        hmnLst.Find(e => e.GetCode() == bss).Append(tmpUs);
                    }

                    else
                    {
                        var usE = new Human(us[0], us[1]);
                        var bsE = new Human(bss, usE);
                        hmnLst.Add(bsE);
                        hmnLst.Add(usE);
                    }
                }

                if (hmnLst.Exists(e => e.GetCode() == bss))
                {
                    var tmpUs = new Human(uss);
                    hmnLst.Add(tmpUs);
                    hmnLst.Find(e => e.GetCode() == bss).Append(tmpUs);
                }

                else
                {
                    var usE = new Human(uss);
                    var bsE = new Human(bss, usE);
                    hmnLst.Add(bsE);
                    hmnLst.Add(usE);
                }
            }

            return hmnLst;
        }

        static List<Human> SearchUnders(List<Human> hmnLst, string code, ref List<Human> list)
        {
            var boss = hmnLst.Find(e => e.GetCode() == code || e.GetName() == code);
            if (boss != null)
            {
                if (boss.GetListOfUnders().Count == 0) { Console.WriteLine("No"); return null; }

                return Moving(boss.GetListOfUnders(), ref list);
            }

            Console.WriteLine("Такого работника не существует");
            return null;
        }

        static List<Human> Moving(List<Human> hmnLst, ref List<Human> list)
        {
            foreach (var item in hmnLst)
            {
                list.Add(item);
                Moving(item.GetListOfUnders(), ref list);
            }
            return list.OrderBy(e => e.GetCode()).ToList();
        }
    }
}