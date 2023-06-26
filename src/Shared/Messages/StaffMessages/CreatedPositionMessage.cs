namespace Shared.Messages.StaffMessages
{
    public class CreatedPositionMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
