
using System.Collections;

abstract class Osoba
{
    private String Imie { get; set; }
    private String Nazwisko { get; set; }
    private String Pesel { get; set; }
    private int Age;


    public int getAge()
    {
        int year = Int32.Parse(Pesel[0].ToString()) * 10 + Int32.Parse(Pesel[1].ToString()) + ((Int32.Parse(Pesel[2].ToString()) / 2 + 1) % 5) * 100 + 1800;

        return 2022 - year;

    }
    public String getGender()
    {
        if (Int32.Parse(Pesel.Substring(9, 1)) % 2 == 0)
        {
            return "k*bieta";
        }
        else
        {
            return "mężczyzna";
        }
    }
    public virtual void GetEducationInfo()
    {
        System.Console.WriteLine("Uczy się");
    }
    public String GetFullName()
    {
        return Imie + " " + Nazwisko;
    }
    public virtual Boolean CanGoHomeAlone()
    {
        if (2022 - Age >= 12) return true;
        return false;
    }
    public virtual void Info()
    {

    }
}

class Uczen : Osoba
{
    String Szkola { get; set; }
    public void changeSchool(String szkola)
    {
        Szkola = szkola;
    }
    Boolean MozeSamWracacDoDomu { get; set; }
    public override void Info()
    {
        System.Console.WriteLine("Nie może sam wracać poniżej 12 lat chyba że ma pozwolenie");
    }

}

class Nauczyciel : Osoba
{
    private String TytulNaukowy { get; set; }
    private List<Uczen> PodwladniUczniowie = new List<Uczen>();

    public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
    {
        foreach (Uczen uczen in PodwladniUczniowie)
        {
            if (uczen.CanGoHomeAlone())
            {
                System.Console.WriteLine("Uczeń może wrócić sam do domu.");
            }
            else
            {
                uczen.Info();
            }
        }
    }
}