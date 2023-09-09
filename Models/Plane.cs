namespace Airport.Models
{
    internal class Plane
    {
        private string _id;
        private string _brand;
        private string _model;
        private uint _capacity;
        private int _yearManufactured;
        private bool _isServiced;
        private bool _isReady;

        public string Id { get => _id; }
        public string Brand { get => _brand; }
        public string Model { get => _model; }
        public uint Capacity { get => _capacity; }
        public int YearManufactured { get => _yearManufactured; }
        public bool IsServiced { get => _isServiced; }
        public bool IsReady { get => _isReady; }

        public Plane( string id, string brand, string model, uint capacity, int yearManufactured, bool isServiced = false, bool isReady = false) 
        { 
            _id = id;
            _brand = brand;
            _model = model;
            _capacity = capacity;
            _yearManufactured = yearManufactured;
            _isServiced = isServiced;
            _isReady = isReady;
        }

        public void ChangeCapacity(uint capacity) => 
            _capacity = capacity;

        public void DoService()
        {
            if (!_isServiced)
                _isServiced = true;
        }

        public void MakeReady()
        {
            if (_isServiced && !_isReady )
                _isReady=true;
        }

        public void SendToService() =>
            _isServiced = false;

        public void SetNotReady() => 
            _isReady = false;
    }
}
