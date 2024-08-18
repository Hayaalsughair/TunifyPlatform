using TunifyPlatform.Models;

namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IPlayList
    {
        Task<Playlists> CreatePlaylists(Playlists playlists);
        Task<Playlists> GetPlaylistsById(int id);
        Task<List<Playlists>> GetAllPlaylists();
        Task<Playlists> UpdatePlaylists(int id, Playlists playlists);
        Task DeletePlaylists(int id);
        Task AddSongToPlaylist(int playlistId, int songId);
        //Task<List<Songs>> GetSongsForPlayList(int playlistId);
    }
}
