namespace Fabryka.Models
{
    interface IVehicle
    {
        int Time { get; set; }
        int Expense { get; set; }

        void Build();
    }
}
