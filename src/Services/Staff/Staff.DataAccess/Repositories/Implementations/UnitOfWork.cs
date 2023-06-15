using Staff.DataAccess.Contexts;
using Staff.DataAccess.Repositories.Interfaces;

namespace Staff.DataAccess.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StaffsDbContext _dbContext;
        private IFilmRepository _filmRepository;
        private IPositionRepository _positionRepository;
        private IStaffPersonRepository _staffPersonRepository;
        private IStaffPersonPositionRepository _staffPersonPositionRepository;

        public UnitOfWork(StaffsDbContext dbContext,
            IFilmRepository filmRepository,
            IPositionRepository positionRepository,
            IStaffPersonRepository staffPersonRepository,
            IStaffPersonPositionRepository staffPersonPositionRepository)
        {
            _dbContext = dbContext;
            _filmRepository = filmRepository;
            _positionRepository = positionRepository;
            _staffPersonRepository = staffPersonRepository;
            _staffPersonPositionRepository = staffPersonPositionRepository;
        }

        public IFilmRepository FilmRepository
        {
            get
            {
                return _filmRepository = _filmRepository ?? new FilmRepository(_dbContext);
            }
        }

        public IStaffPersonRepository StaffPersonRepository
        {
            get
            {
                return _staffPersonRepository = _staffPersonRepository ?? new StaffPersonRepository(_dbContext);
            }
        }

        public IPositionRepository PositionRepository
        {
            get
            {
                return _positionRepository = _positionRepository ?? new PositionRepository(_dbContext);
            }
        }

        public IStaffPersonPositionRepository StaffPersonPositionRepository
        {
            get
            {
                return _staffPersonPositionRepository = _staffPersonPositionRepository ?? new StaffPersonPositionRepository(_dbContext);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
