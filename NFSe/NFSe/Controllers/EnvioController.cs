using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;

namespace NFSe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {


        // GET: api/UrlIntegracao
        [HttpGet]
        public async Task<ActionResult<bool>> GetUrlIntegracao()
        {

            Services.CertificadoService server = new Services.CertificadoService();
            var folderName = Path.Combine("StaticFiles", "Certificado");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);


            var fileName = "40073323_snd.xml";
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);

            var xml = System.IO.File.ReadAllText(dbPath);
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var certificado = server.GetCertificado();
            var xmlDentroAssinado = server.Assinar(xml, "InfDeclaracaoPrestacaoServico", certificado);
            var fileNameXml = "XML.txt";
            var fullPathXml = Path.Combine(pathToSave, fileNameXml);
            var xmlFora = System.IO.File.ReadAllText(fullPathXml);
            var xmlCompleto = string.Format(xmlFora, xmlDentroAssinado);
            var xmlCompletoAssinado = server.Assinar(xmlCompleto, "LoteRps", certificado);
            return true;
        }
    }
}