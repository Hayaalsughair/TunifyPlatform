using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlayList _playList;

        public PlaylistsController(IPlayList context)
        {
            _playList = context;
        }

        // GET: api/Playlists
        [Route("/playList/GetAllPlayLists")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlists>>> Getplaylists()
        {
            return Ok(await _playList.GetAllPlaylists());

        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlists>> GetPlaylists(int id)
        {
            var playList = await _playList.GetPlaylistsById(id);

            if (playList == null)
            {
                return NotFound($" PlayList [{id}] not found.");
            }

            return Ok(playList);
        }

        // PUT: api/Playlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylists(int id, Playlists playlists)
        {

            var updatedPlayList = await _playList.UpdatePlaylists(id, playlists);
            //Check the user
            if (updatedPlayList == null)
            {
                return NotFound($" PlayList [{id}] not found.");
            }
            return Ok(updatedPlayList);
        }

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlists>> PostPlaylists(Playlists playlists)
        {
            var newPlayList = await _playList.CreatePlaylists(playlists);
            return Ok(newPlayList);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylists(int id)
        {
            var playList = await _playList.GetPlaylistsById(id);
            if (playList == null)
            {
                return NotFound($"PlayList [{id}] not found");
            }

            await _playList.DeletePlaylists(id);
            return NoContent();
        }
        //[HttpGet("{id}/allSongs")]
        //public async Task<ActionResult<List<Songs>>>GetSongsForPlayList(int id)
        //{
        //    var songs= await _playList.GetSongsForPlayList(id);
        //    return Ok(songs);
        //}
        [HttpPost]
        [Route("playlists/{playlistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            await _playList.AddSongToPlaylist(playlistId, songId);
            return Ok();
        }
    }
}
