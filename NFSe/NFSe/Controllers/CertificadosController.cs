using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NFSe.Data;
using NFSe.Models;
using NFSe.Services;

namespace NFSe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificadosController : ControllerBase
    {
        private readonly NotaContext _context = new NotaContext();

        // GET: api/Certificados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificadoModel>>> GetCertificado()
        {
            return await _context.Certificado.ToListAsync();
        }

        // GET: api/Certificados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificadoModel>> GetCertificado(int id)
        {
            var certificado = await _context.Certificado.FindAsync(id);

            if (certificado == null)
            {
                return NotFound();
            }

            return certificado;
        }

        // PUT: api/Certificados/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificado(int id, CertificadoModel certificado)
        {
            if (id != certificado.Id)
            {
                return BadRequest();
            }

            _context.Entry(certificado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Certificados
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CertificadoModel>> PostCertificado(CertificadoModel certificado)
        {
            X509Certificate2 cert = new X509Certificate2();
            CertificadoService certificadoService = new CertificadoService();
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles\Certificado\SOCIEDADE EDUCACIONAL DE RONDONOPOLIS LTDA24773186000180.pfx");
            try
            {
                cert = certificadoService.GetCertificado(fullPath, certificado.Senha);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            certificado = certificadoService.GetCertificadoToInsert(cert, certificado);
            _context.Certificado.Add(certificado);
            try
            {
                await _context.SaveChangesAsync();
                System.IO.File.Delete(fullPath);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction("GetCertificado", new { id = certificado.Id }, certificado);
        }

        // DELETE: api/Certificados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CertificadoModel>> DeleteCertificado(int id)
        {
            var certificado = await _context.Certificado.FindAsync(id);
            if (certificado == null)
            {
                return NotFound();
            }

            _context.Certificado.Remove(certificado);
            await _context.SaveChangesAsync();

            return certificado;
        }

        private bool CertificadoExists(int id)
        {
            return _context.Certificado.Any(e => e.Id == id);
        }
    }
}
