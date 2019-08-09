

namespace Shop.Web.Data.Entities
{
    public class Country : IEntity
    {
        public int Id { get ; set; }
        public string Name { get; set; }
        //public bool WasDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
