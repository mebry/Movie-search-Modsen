namespace Staff.DataAccess.Entities
{
    public class StaffPerson
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public string StaffSurname { get; set; }
        public string ImgUrl { get; set; }
        public DateTimeOffset DateOfBirthday { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }

    }
}
