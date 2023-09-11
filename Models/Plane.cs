namespace Airport.Models
{
    internal class Plane
    {
        public string Id { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public uint Capacity { get; private set; }
        public int YearManufactured { get; private set; }
        public bool IsServiced { get; private set; }
        public bool IsReady { get; private set; }

        public Plane(string id, string brand, string model, uint capacity, int yearManufactured, bool isServiced = false, bool isReady = false) 
        { 
            Id = id;
            Brand = brand;
            Model = model;
            Capacity = capacity;
            YearManufactured = yearManufactured;
            IsServiced = isServiced;
            IsReady = isReady;
        }

        public void ChangeCapacity(uint capacity) => 
            Capacity = capacity;

        public void DoService()
        {
            if (!IsServiced)
                IsServiced = true;
        }

        public void MakeReady()
        {
            if (IsServiced && !IsReady )
                IsReady=true;
        }

        public void SendToService() =>
            IsServiced = false;

        public void SetNotReady() => 
            IsReady = false;
    }
}
