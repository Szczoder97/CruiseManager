namespace CruiseManager.Modules.Boats.Core.Entities
{
    internal class Boat
    {
        public Guid Id { get; set; }
        public Guid ShipOwnerId { get; set; }
        public ShipOwner Owner { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string Banner { get; set; }
        public string RegistrationNumber { get; set; }
        public string HomePort { get; set; }
        public float LOA { get; set; }
        public float EngineKW { get; set; }
        public byte Cabins { get; set; }
        public byte Berths { get; set; }
        public IEnumerable<Accessory> Accessories { get; set; }
    }
}
