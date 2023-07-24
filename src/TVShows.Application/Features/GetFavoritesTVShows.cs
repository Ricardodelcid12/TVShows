using MediatR;
using TVShows.Application.DTOs;
using TVShows.Application.Extensions;
using TVShows.Domain.Repositories;
using TVShows.Infrastructure;

namespace TVShows.Application.Features
{
    /// <summary>
    /// GetFavoritesTVShows is a class feature to retrieve favorites tv shows.
    /// The class uses MediatR Query/Command to handle the retrieve favorites tv shows logic.
    /// </summary>
    public class GetFavoritesTVShows
    {
        public class GetFavoritesTVShowsQuery : IRequest<List<TVShowDTO>> { }
        public class GetFavoritesTVShowsHandler : IRequestHandler<GetFavoritesTVShowsQuery, List<TVShowDTO>>
        {
            private readonly ITVShowRepository _tvShowRepository;

            public GetFavoritesTVShowsHandler(ITVShowRepository tvShowRepository)
            {
                _tvShowRepository = tvShowRepository;
            }

            public async Task<List<TVShowDTO>> Handle(GetFavoritesTVShowsQuery request, CancellationToken cancellationToken)
            {
                //Get Favorites tv shows 
                var tvShowsList = await _tvShowRepository.GetFavorites();
                if (tvShowsList == null) 
                    throw new ExceptionHandler("Something went wrong trying to retrieve your Favorites TV Shows.");

                //Map tv shows  to representation list through an extension method
                var favoritesTvShowsList = tvShowsList.ToTVShowDtoList();
                if (favoritesTvShowsList == null)
                    throw new ExceptionHandler("Something went wrong trying to retrieve your Favorites TV Shows.");

                return favoritesTvShowsList;
            }
        }
    }
}
