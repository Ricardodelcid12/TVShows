using MediatR;
using TVShows.Application.DTOs;
using TVShows.Application.Extensions;
using TVShows.Domain.Repositories;
using TVShows.Infrastructure;

namespace TVShows.Application.Features
{
    /// <summary>
    /// GetTVShows is a class feature to retrieve all tv shows.
    /// The class uses MediatR Query/Command to handle the retrieve tv shows logic.
    /// </summary>
    /// <return param="List<TVShowDTO>">
    /// Returns a tv shows DTO list.
    /// </return>
    public class GetTVShows
    {
        public class GetTVShowsQuery : IRequest<List<TVShowDTO>> { }
        public class GetTVShowsHandler : IRequestHandler<GetTVShowsQuery, List<TVShowDTO>>
        {
            private readonly ITVShowRepository _tvShowRepository;

            public GetTVShowsHandler(ITVShowRepository tvShowRepository)
            {
                _tvShowRepository = tvShowRepository;
            }

            public async Task<List<TVShowDTO>> Handle(GetTVShowsQuery request, CancellationToken cancellationToken)
            {
                //Get all tv shows 
                var tvShowsList = await _tvShowRepository.Get();
                if (tvShowsList == null)
                    throw new ExceptionHandler("Something went wrong trying to retrieve all the TV Shows.");

                //Map tv shows to representation list through an extension method
                var tvShowsDtoList = tvShowsList.ToTVShowDtoList();
                if (tvShowsDtoList == null)
                    throw new ExceptionHandler("Something went wrong trying to retrieve all the TV Shows.");

                return tvShowsDtoList;
            }
        }
    }
}
