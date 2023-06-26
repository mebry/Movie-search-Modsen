using FilmCollection.DataAccess.Models;
using Mapster;
using MassTransit;
using Shared.Messages.FilmCountryMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.BusinessLogic.Mappings.MessagesConfig
{
    internal class FilmContryMessageMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreatedFilmCountryMessage, FilmCountry>()
                .Map(dest => dest.BaseFilmInfoId, src => src.FilmId);

            config.NewConfig<RemovedFilmCountryMessage, FilmCountry>()
                .Map(dest => dest.BaseFilmInfoId, src => src.FilmId);
        }
    }
}
