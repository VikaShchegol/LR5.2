using System;

interface IParent
{
    string Info();
    void Metod();
}

class Child1 : IParent
{
    private string pole1;
    private double pole2;
    private string pole3;

    public Child1(string name, string paperQuality)
    {
        pole1 = name;
        pole3 = paperQuality;
        Metod();
    }

    public string Info()
    {
        return $"{pole1}, якiсть паперу = {pole3}, цiна = {pole2:F2}";
    }

    public void Metod()
    {
        if (pole3.ToLower() == "high")
        {
            pole2 = 200;
        }
        else
        {
            pole2 = 100;
        }
    }
}

class Child2 : IParent
{
    private string pole1;
    private double pole2;
    private string pole4;
    private int pole5;

    public Child2(string name, string coverType, int pageCount)
    {
        pole1 = name;
        pole4 = coverType;
        pole5 = pageCount;
        Metod();
    }

    public string Info()
    {
        return $"{pole1}, обкладинка = {pole4}, сторiнок = {pole5}, цiна = {pole2:F2}";
    }

    public void Metod()
    {
        pole2 = pole5 * 0.2;

        if (pole4.ToLower() == "hard")
        {
            pole2 += 15;
        }
        else
        {
            pole2 += 5;
        }
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            bool isJournal = random.Next(0, 2) == 0;

            IParent obj;
            if (isJournal)
            {
                string paperQuality = random.Next(0, 2) == 0 ? "low" : "high";
                obj = new Child1("Журнал", paperQuality);
            }
            else
            {
                string coverType = random.Next(0, 2) == 0 ? "hard" : "soft";
                int pageCount = random.Next(50, 301);
                obj = new Child2("Книга", coverType, pageCount);
            }

            obj.Metod();
            Console.WriteLine(obj.Info());
            Console.WriteLine();
        }
    }
}
