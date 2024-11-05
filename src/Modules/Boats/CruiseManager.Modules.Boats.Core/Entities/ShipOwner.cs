namespace CruiseManager.Modules.Boats.Core.Entities
{
    internal class ShipOwner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public IEnumerable<Boat> Boats { get; set; }
    }
}
