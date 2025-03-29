using BE_WebApi_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_WebApi_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiswaController : ControllerBase
    {
        private readonly SiswaContext _siswacontext;
        public SiswaController(SiswaContext siswacontext)
        {
            _siswacontext = siswacontext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiswaModel>>> GetSiswas() 
        {
            if (_siswacontext.SiswaModels == null) 
            {
                return NotFound();
            }
            return await _siswacontext.SiswaModels.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SiswaModel>> GetSiswa(int id)
        {
            if (_siswacontext.SiswaModels == null)
            {
                return NotFound();
            }
            var siswa = await _siswacontext.SiswaModels.FindAsync(id);
            if (siswa == null) 
            {
                return NotFound();
            }
            return siswa;
        }

        [HttpPost]
        public async Task<ActionResult<SiswaModel>> PostSiswa(SiswaModel siswa)
        {
            _siswacontext.SiswaModels.Add(siswa);
            await _siswacontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSiswa), new { id = siswa.ID }, siswa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutSiswa(int id, SiswaModel siswa)
        {
           if (id != siswa.ID)
            {
                return BadRequest();
            }

           _siswacontext.Entry(siswa).State = EntityState.Modified;
            try
            {
                await _siswacontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSiswa(int id)
        {
            if(_siswacontext.SiswaModels == null)
            {
                return NotFound();
            }
            var siswa = await _siswacontext.SiswaModels.FindAsync(id);
            if (siswa == null)
            {
                return NotFound();
            }
            _siswacontext.SiswaModels.Remove(siswa);
            await _siswacontext.SaveChangesAsync();

            return Ok();
        }

    }
}
