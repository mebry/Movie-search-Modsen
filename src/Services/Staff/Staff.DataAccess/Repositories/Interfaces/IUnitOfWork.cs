namespace Staff.DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IFilmRepository FilmRepository { get; }
        public IStaffPersonRepository StaffPersonRepository { get; }
        public IPositionRepository PositionRepository { get; }
        public IStaffPersonPositionRepository StaffPersonPositionRepository { get; }
        public Task SaveChangesAsync();
    }
}
