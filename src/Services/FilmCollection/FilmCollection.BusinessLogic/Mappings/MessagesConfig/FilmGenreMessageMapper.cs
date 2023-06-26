using FilmCollection.DataAccess.Models;
using Mapster;
using Shared.Messages.FilmCountryMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Mappings.MessagesConfig
{
    internal class FilmGenreMessageMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreatedFilmGenreMessage, FilmGenre>()
                .Map(dest => dest.BaseFilmInfoId, src => src.FilmId);

            config.NewConfig<RemovedFilmGenreMessage, FilmGenre>()
                .Map(dest => dest.BaseFilmInfoId, src => src.FilmId);
        }
    }
}
