using Shared.Enums;

namespace Staff.BusinessLogic.DTOs
{
    public class RequestStaffPersonDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public DateOnly DateOfBirthday { get; set; }
        public Countries Country { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
