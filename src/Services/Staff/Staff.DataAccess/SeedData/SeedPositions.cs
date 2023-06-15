using Staff.DataAccess.Entities;

namespace Staff.DataAccess.SeedData
{
    public static class SeedPositions
    {
        public static Position ActorPosition { get; } = new() { Id = new Guid(), Name = "Actor" };
        public static Position RegisseurPosition { get; } = new() { Id = new Guid(), Name = "Regisseur" };
        public static Position ProducerPosition { get; } = new() { Id = new Guid(), Name = "Producer" };
        public static Position OperatorPosition { get; } = new() { Id = new Guid(), Name = "Operator" };
        public static Position ComposerPosition { get; } = new() { Id = new Guid(), Name = "Composer" };
        public static Position ArtistPosition { get; } = new() { Id = new Guid(), Name = "Artist" };
        public static Position MontagePosition { get; } = new() { Id = new Guid(), Name = "Montage" };
    }
}
