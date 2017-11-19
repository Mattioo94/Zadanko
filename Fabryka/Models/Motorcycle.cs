namespace Fabryka.Models
{
    class Motorcycle : Vehicle
    {
        public Motorcycle(int time = 5, int expense = 600)
        {
            Time = time;
            Expense = expense;
        }
    }
}
