using MediatR;
using TVShows.Application.DTOs;
using TVShows.Application.Extensions;
using TVShows.Domain.Repositories;
using TVShows.Infrastructure;

namespace TVShows.Application.Features
{
    /// <summary>
    /// UpdateIsFavoriteQuery is a class feature to update the IsFavorite tv show state property.
    /// The class uses MediatR Query/Command to handle the update IsFavorite tv show state property logic.
    /// </summary>
    public class UpdateIsFavorite
    {
        public class UpdateIsFavoriteQuery : IRequest<List<TVShowDTO>> 
        {
            public int Id { get; set; }
        }
        public class UpdateIsFavoriteRequest : IRequestHandler<UpdateIsFavoriteQuery, List<TVShowDTO>>
        {
            private readonly ITVShowRepository _tvShowRepository;

            public UpdateIsFavoriteRequest(ITVShowRepository tvShowRepository)
            {
                _tvShowRepository = tvShowRepository;
            }

            public async Task<List<TVShowDTO>> Handle(UpdateIsFavoriteQuery request, CancellationToken cancellationToken)
            {
                //Update IsFavorite tv show state.
                var tvShowsList = await _tvShowRepository.UpdateIsFavorite(request.Id);
                if (tvShowsList == null)
                    throw new ExceptionHandler($"Something went wrong trying to update the {request.Id} TV Shows.");

                //Map tv shows  to representation list through an extension method
                var updatedTvShowsList = tvShowsList.ToTVShowDtoList();
                if (updatedTvShowsList == null)
                    throw new ExceptionHandler($"Something went wrong trying to update the {request.Id} TV Shows.");

                return updatedTvShowsList;
            }
        }
    }
}
