using Staff.DataAccess.Entities;

namespace Staff.DataAccess.SeedData
{
    public static class SeedPositions
    {
        public static Position ActorPosition { get; } = new() { Id = Guid.NewGuid(), Name = "Actor" };
        public static Position RegisseurPosition { get; } = new() { Id = Guid.NewGuid(), Name = "Regisseur" };
        public static Position ProducerPosition { get; } = new() { Id = Guid.NewGuid(), Name = "Producer" };
        public static Position OperatorPosition { get; } = new() { Id = Guid.NewGuid(), Name = "Operator" };
        public static Position ComposerPosition { get; } = new() { Id = Guid.NewGuid(), Name = "Composer" };
        public static Position ArtistPosition { get; } = new() { Id = Guid.NewGuid(), Name = "Artist" };
        public static Position MontagePosition { get; } = new() { Id = Guid.NewGuid(), Name = "Montage" };
    }
}
