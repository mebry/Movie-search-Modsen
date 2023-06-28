using Shared.Enums;

namespace Reporting.BusinessLogic.DTOs.ConsumerDTOs
{
    public class ConsumerStaffPersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public DateTime DateOfBirthday { get; set; }
        public Countries Country { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
