using Shared.Enums;

namespace Staff.BusinessLogic.DTOs
{
    public class StaffPersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public DateOnly DateOfBirthday { get; set; }
        public Countries Country { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
