using Microsoft.AspNetCore.Mvc;
using AmbienteAPI.Service;
using WebAPI.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AmbienteAPI.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ApiService _apiService;

        public ProdutoController(ApiService apiService)
        {
            _apiService = apiService;
        }


        public async Task<IActionResult> Index()
        {
            var produtos = await _apiService.GetAllProdutosAsync();
            return View(produtos);
        }

        //CREATE ----
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categorias = await _apiService.GetAllCategoriasAsync();
            ViewBag.Categorias = new SelectList(categorias, "CategoriasId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var response = await _apiService.PostProdutoAsync(produto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao criar o produto.");
            }
            var categorias = await _apiService.GetAllCategoriasAsync();
            ViewBag.Categorias = new SelectList(categorias, "CategoriasId", "Nome", produto.FK_CategoriaId);
            return View(produto);
        }

        //details
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _apiService.GetProdutoAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _apiService.GetProdutoAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            // Carregar categorias para o dropdown
            ViewBag.Categorias = new SelectList(await _apiService.GetAllCategoriasAsync(), "CategoriasId", "Nome", produto.FK_CategoriaId);

            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var response = await _apiService.PutProdutoAsync(id, produto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao atualizar o produto.");
            }

            // Recarregar categorias para o dropdown em caso de falha
            ViewBag.Categorias = new SelectList(await _apiService.GetAllCategoriasAsync(), "CategoriasId", "Nome", produto.FK_CategoriaId);

            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _apiService.GetProdutoAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _apiService.DeleteProdutoAsync(id);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }

        ModelState.AddModelError(string.Empty, "Ocorreu um erro ao excluir o produto.");
        var produto = await _apiService.GetProdutoAsync(id);
        return View(produto);
        }



    }
}
