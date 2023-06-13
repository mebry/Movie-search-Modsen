using Shared.Enums;

namespace Staff.DataAccess.Entities
{
    public class StaffPerson
    {
        public Guid Id { get; set; }
        public string StaffName { get; set; }
        public string StaffSurname { get; set; }
        public string ImgUrl { get; set; }
        public DateOnly DateOfBirthday { get; set; }
        public Countries Country { get; set; }
        public string Description { get; set; }

        public ICollection<StaffPersonPosition> StaffPersonPositions { get; set; }
    }
}
