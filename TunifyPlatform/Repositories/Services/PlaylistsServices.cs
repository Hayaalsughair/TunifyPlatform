using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class PlaylistsServices : IPlayList
    {
        private readonly TunifyDbContext _context;

        public PlaylistsServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Playlists> CreatePlaylists(Playlists playlists)
        {
            _context.playlists.Add(playlists);
            await _context.SaveChangesAsync();
            return playlists;
        }

        public async Task DeletePlaylists(int id)
        {
            var getPlayList = await GetPlaylistsById(id);
            _context.playlists.Remove(getPlayList);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Playlists>> GetAllPlaylists()
        {
            var allPlaylists = await _context.playlists.ToListAsync();
            return allPlaylists;
        }

        public async Task<Playlists> GetPlaylistsById(int id)
        {
            var specificPlayList = await _context.playlists.FindAsync(id);
            return specificPlayList;
        }

        public async Task<Playlists> UpdatePlaylists(int id, Playlists playList)
        {
            var exsitingPlaylist = await _context.playlists.FindAsync(id);
            exsitingPlaylist = playList;
            await _context.SaveChangesAsync();
            return playList;
        }
        //public async Task<List<Songs>> GetSongsForPlayList(int playlistId)
        //{
        //    var songsForPlayList = await _context.playlistSongs
        //        .Where(ps => ps.Playlist_Id == playlistId) 
        //        .Select(ps => ps.Song) 
        //        .ToListAsync();
        //    return songsForPlayList;
        //}
        public async Task AddSongToPlaylist(int playlistId, int songId)
        {
            var playlist = await _context.playlists
                .Include(p => p.PlaylistSongs)
                .FirstOrDefaultAsync(x => x.PlaylistsId == playlistId);

            if (playlist == null)
            {
                throw new Exception("Playlist not found");
            }

            var song = await _context.songs.FindAsync(songId);
            if (song == null)
            {
                throw new Exception("Song not found");
            }

            if (playlist.PlaylistSongs == null)
            {
                playlist.PlaylistSongs = new List<PlaylistSongs>();
            }

            // Check if the song is already in the playlist
            if (playlist.PlaylistSongs.Any(ps => ps.Song_Id == songId))
            {
                throw new Exception("Song is already in the playlist");
            }

            playlist.PlaylistSongs.Add(new PlaylistSongs
            {
                Playlist_Id = playlistId,
                Song_Id = songId
            });

            _context.Entry(playlist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
