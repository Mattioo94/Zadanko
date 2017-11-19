namespace Fabryka.Models
{
    class Truck : Vehicle
    {
        public Truck(int time = 15, int expense = 2000)
        {
            Time = time;
            Expense = expense;
        }
    }
}
