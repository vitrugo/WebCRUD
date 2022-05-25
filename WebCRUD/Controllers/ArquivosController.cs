using Microsoft.AspNetCore.Mvc;
using WebCRUD.Models;

namespace WebCRUD.Controllers
{
    public class ArquivosController : Controller
    {
        private readonly Contexto _context;

        public ArquivosController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var arquivos = _context.Arquivos.ToList();
            return View(arquivos);
        }

        [HttpPost]
        public IActionResult UploadImagem(IList<IFormFile> arquivos)
        {
            IFormFile imagemCarregada = arquivos.FirstOrDefault();

            if (imagemCarregada != null)
            {
                MemoryStream ms = new MemoryStream();
                imagemCarregada.OpenReadStream().CopyTo(ms);

                Arquivos arqui = new Arquivos()
                {
                    Descricao = imagemCarregada.FileName,
                    Dados = ms.ToArray(),
                    ContentType = imagemCarregada.ContentType
                };

                _context.Arquivos.Add(arqui);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Visualizar(int id)
        {
            var arquivosBanco = _context.Arquivos.FirstOrDefault(a => a.Id == id);

            return File(arquivosBanco.Dados, arquivosBanco.ContentType);
        }
    }
}
