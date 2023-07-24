using TVShows.Domain.Entities;

namespace TVShows.Application.DTOs
{
    public class TVShowHandlerResultDTO
    {
        public List<TVShowDTO>? TVShows { get; set; }
        public string? Message { get; set; }
    }
}
