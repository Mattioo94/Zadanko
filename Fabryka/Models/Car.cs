namespace Fabryka.Models
{
    class Car : Vehicle
    {
        public Car(int time = 10, int expense = 1000)
        {
            Time = time;
            Expense = expense;
        }
    }
}
