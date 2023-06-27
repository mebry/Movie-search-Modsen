﻿using Reporting.DataAccess.Entities;

namespace Reporting.DataAccess.Repositories.StaffPersonPositironRepositories
{
    public interface ISatffPersonPositionRepository
    {
        public void Create(StaffPersonPosition staffPerson);
        public void Delete(Guid filmId, Guid staffPersonId, Guid positionId);

        /// <summary>
        /// Saves changes asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        public Task SaveChangesAsync();
    }
}
