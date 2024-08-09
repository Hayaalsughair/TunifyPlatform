using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface ISong
    {
        Task<Songs> CreateSong(Songs song);
        Task<Songs> GetSongById(int id);
        Task<List<Songs>> GetAllSongs();
        Task<Songs> UpdateSong(int id, Songs song);
        Task DeleteSong(int id);
    }
}
