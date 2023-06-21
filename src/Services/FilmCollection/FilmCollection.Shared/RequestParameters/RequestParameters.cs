using FilmCollection.Shared.Constants.RequestParametersConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCollection.Shared.RequestParameters
{
    public abstract class RequestParameters
    {
        public int MaxPageSize { get; init; } = RequestParametersConstants.DEFAULT_MAX_PAGE_SIZE;

        public int PageNumber { get; set; } = RequestParametersConstants.DEFAULT_PAGE_NUMBER;

        private int _pageSize = RequestParametersConstants.DEFAULT_PAGE_SIZE;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string OrderBy { get; set; }
    }
}
