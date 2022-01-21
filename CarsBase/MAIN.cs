using static System.Console; //чтоб не писать постоянно Console

namespace CarsBase
{
    class MAIN
    {
        static void Main(string[] args)
        {
            Title = "CarsBase";//заголовок консольного окна
            LineUp up = new LineUp();               
            ReadKey();
        }
    }
}
