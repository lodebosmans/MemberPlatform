using MemberPlatformDAL.UoW;

namespace MemberPlatformDAL.Entities
{
    public class OptionTypeEntity : IEntity
    {
        // Attributes
        public int Id { get; set; }

        public string Name { get; set; }

        //Navigation properties
        public ICollection<OptionEntity> Options { get; set; } //OptionType can be related to 0 or more option (1 to many relationShip)
    }
}
