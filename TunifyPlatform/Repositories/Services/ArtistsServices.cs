﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Repositories.Services
{
    public class ArtistsServices : IArtists
    {
        private readonly TunifyDbContext _context;

        public ArtistsServices(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task<Artists> CreateArtist(Artists artist)
        {
            _context.artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task DeleteArtists(int id)
        {
            var artist = await GetArtistById(id);
            if (artist != null)
            {
                _context.artists.Remove(artist);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Artist with ID {id} not found.");
            }
        }

        public async Task<List<Artists>> GetAllArtists()
        {
            return await _context.artists.ToListAsync();
        }

        public async Task<Artists> GetArtistById(int id)
        {
            var artist = await _context.artists.FindAsync(id);
            if (artist == null)
            {
                throw new KeyNotFoundException($"Artist with ID {id} not found.");
            }
            return artist;
        }

        public async Task<Artists> UpdateArtists(int id, Artists artist)
        {
            var exsitingArtist = await _context.artists.FindAsync(id);
            exsitingArtist = artist;
            await _context.SaveChangesAsync();
            return artist;
        }
        public async Task AddSongToArtist(int artistId, int songId)
        {
            var artist = await _context.artists.FindAsync(artistId);
            if (artist == null)
            {
                throw new KeyNotFoundException("Artist not found.");
            }

            var song = await _context.songs.FindAsync(songId);
            if (song == null)
            {
                throw new KeyNotFoundException("Song not found.");
            }

            // Associate the song with the artist
            song.ArtistId = artistId;
            song.Artist = artist;

            // Save the changes in the context
            await _context.SaveChangesAsync();
        }
    }
}
