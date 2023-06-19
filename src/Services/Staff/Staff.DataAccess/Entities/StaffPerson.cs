using Shared.Enums;

namespace Staff.DataAccess.Entities
{
    public class StaffPerson
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public DateTime DateOfBirthday { get; set; }
        public Countries Country { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<StaffPersonPosition> StaffPersonPositions { get; set; }
    }
}
