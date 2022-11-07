using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuncionesLinq.Data;
using FuncionesLinq.Models;
using UniversidadInterfaces.Interfaces;

namespace FuncionesLinq.Controllers
{
    public class InscritosController : Controller
    {
        private readonly FuncDBContext _context;
        private readonly Iestudios _estudios;

        public InscritosController(FuncDBContext context, Iestudios estudios)
        {
            _context = context;
            _estudios = estudios;
        }

        // GET: Inscritos
        public async Task<IActionResult> Index()
        {
            var usuarios_       = _context.Usuarios.ToList();
            var alumnos_        = _context.Alumnos.ToList();
            var cursos_         = _context.Cursos.OrderBy(c => c.nIvel).ToList();
            ViewBag.usuarios    = usuarios_;
            ViewBag.alumnos     = alumnos_;
            ViewBag.cursos      = cursos_;


            var listaInscritos = from d in _context.Inscritos
            join u in _context.Usuarios on d.Addby equals u.Id
            join a in _context.Alumnos on d.Idalumno equals a.Id
            join c in _context.Cursos on d.Idcurso equals c.Id
            select new
            {
                administrador_  = u.Name,
                alumno_         = a.Name,
                cursos_         = c.CursoName,
                status_         = d.Status,
                fecha_          = d.FechaAdd
                // other assignments
            };
            ViewBag.listaInscritos = listaInscritos;

            int cantidadCursos = listaInscritos.Count();

            ViewBag.msgAlumnos = _estudios.cursosPorCategoria(cantidadCursos);

            return View(await _context.Inscritos.ToListAsync());
        }

        public async Task<IActionResult> Nivel()
        {
            var usuarios_ = _context.Usuarios.ToList();
            var alumnos_ = _context.Alumnos.ToList();
            var cursos_ = _context.Cursos.OrderBy(c => c.nIvel).ToList();
            ViewBag.usuarios = usuarios_;
            ViewBag.alumnos = alumnos_;
            ViewBag.cursos = cursos_;

            var listaInscritos = from d in _context.Inscritos
                                 join u in _context.Usuarios on d.Addby equals u.Id
                                 join a in _context.Alumnos on d.Idalumno equals a.Id
                                 join c in _context.Cursos on d.Idcurso equals c.Id
                                 select new
                                 {
                                     administrador_ = u.Name,
                                     alumno_ = a.Name,
                                     cursos_ = c.CursoName,
                                     status_ = d.Status,
                                     fecha_ = d.FechaAdd,
                                     nivel_ = c.nIvel
                                     // other assignments
                                 };

            ViewBag.listaInscritos = listaInscritos;

            return View();
        }



        public async Task<IActionResult> Categoria(int SearchCategoria)
        {
            var usuarios_ = _context.Usuarios.ToList();
            var alumnos_ = _context.Alumnos.ToList();
            var cursos_ = _context.Cursos.OrderBy(c => c.nIvel).ToList();
            ViewBag.usuarios = usuarios_;
            ViewBag.alumnos = alumnos_;
            ViewBag.cursos = cursos_;

            var listaInscritos = from d in _context.Inscritos
                                 join u in _context.Usuarios on d.Addby equals u.Id
                                 join a in _context.Alumnos on d.Idalumno equals a.Id
                                 join c in _context.Cursos on d.Idcurso equals c.Id
                                 select new
                                 {
                                     administrador_ = u.Name,
                                     alumno_ = a.Name,
                                     cursos_ = c.CursoName,
                                     status_ = d.Status,
                                     fecha_ = d.FechaAdd,
                                     nivel_ = c.nIvel,
                                     categoria_ = c.Categoria
                                     // other assignments
                                 };
            ViewBag.listaInscritos = listaInscritos;

            if (SearchCategoria >= 0)
            {
                var listaInscritos2 = from d in _context.Inscritos
                                      join c in _context.Cursos on d.Idcurso equals c.Id
                                      join u in _context.Usuarios on d.Addby equals u.Id
                                      join a in _context.Alumnos on d.Idalumno equals a.Id                                     
                                      where ((int)c.Categoria).Equals(SearchCategoria)
                                      select new
                                      {
                                          administrador_ = u.Name,
                                          alumno_ = a.Name,
                                          cursos_ = c.CursoName,
                                          status_ = d.Status,
                                          fecha_ = d.FechaAdd,
                                          nivel_ = c.nIvel,
                                          categoria_ = c.Categoria
                                          // other assignments
                                      };
                int cantidadCursos = listaInscritos2.Count();

                ViewBag.msgCursos = _estudios.cursosPorCategoria(cantidadCursos);
                ViewBag.listaInscritos = listaInscritos2;
            }


            return View();
        }


        public async Task<IActionResult> SoloCursos(int SearchCurso)
        {
            var usuarios_ = _context.Usuarios.ToList();
            var alumnos_ = _context.Alumnos.ToList();
            var cursos_ = _context.Cursos.OrderBy(c => c.nIvel).ToList();
            ViewBag.usuarios = usuarios_;
            ViewBag.alumnos = alumnos_;
            ViewBag.cursos = cursos_;
            int cursosQty = cursos_.Count;
            ViewBag.cursosQty = cursosQty;

            if (SearchCurso >= 0)
            {
                var listaInscritos2 = from d in _context.Inscritos
                                      join c in _context.Cursos on d.Idcurso equals c.Id
                                      join u in _context.Usuarios on d.Addby equals u.Id
                                      join a in _context.Alumnos on d.Idalumno equals a.Id
                                      where (c.Id).Equals(SearchCurso)
                                      select new
                                      {
                                          administrador_ = u.Name,
                                          alumno_ = a.Name,
                                          cursos_ = c.CursoName,
                                          status_ = d.Status,
                                          fecha_ = d.FechaAdd,
                                          nivel_ = c.nIvel,
                                          categoria_ = c.Categoria
                                          // other assignments
                                      };

                ViewBag.listaInscritos = listaInscritos2;
            }

            return View();
        }



        // GET: Inscritos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inscritos == null)
            {
                return NotFound();
            }

            var inscritos = await _context.Inscritos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscritos == null)
            {
                return NotFound();
            }

            return View(inscritos);
        }

        // GET: Inscritos/Create
        public IActionResult Create()
        {
            var usuarios_       = _context.Usuarios.ToList();
            var alumnos_        = _context.Alumnos.ToList();
            var cursos_         = _context.Cursos.OrderBy(c => c.nIvel).ToList();
            ViewBag.usuarios    = usuarios_;
            int usuariosQty     = usuarios_.Count;
            ViewBag.usuariosQty = usuariosQty;
            ViewBag.alumnos     = alumnos_;
            int alumnosQty      = alumnos_.Count;
            ViewBag.alumnosQty  = alumnosQty;           
            ViewBag.cursos      = cursos_;            
            int cursosQty       = cursos_.Count;
            ViewBag.cursosQty   = cursosQty;


            return View();
        }

        // POST: Inscritos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Addby,Idalumno,Idcurso,Status,FechaAdd")] Inscritos inscritos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscritos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inscritos);
        }

        // GET: Inscritos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inscritos == null)
            {
                return NotFound();
            }

            var inscritos = await _context.Inscritos.FindAsync(id);
            if (inscritos == null)
            {
                return NotFound();
            }
            return View(inscritos);
        }

        // POST: Inscritos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Addby,Idalumno,Idcurso,Status,FechaAdd")] Inscritos inscritos)
        {
            if (id != inscritos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscritos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscritosExists(inscritos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(inscritos);
        }

        // GET: Inscritos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inscritos == null)
            {
                return NotFound();
            }

            var inscritos = await _context.Inscritos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscritos == null)
            {
                return NotFound();
            }

            return View(inscritos);
        }

        // POST: Inscritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inscritos == null)
            {
                return Problem("Entity set 'FuncDBContext.Inscritos'  is null.");
            }
            var inscritos = await _context.Inscritos.FindAsync(id);
            if (inscritos != null)
            {
                _context.Inscritos.Remove(inscritos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscritosExists(int id)
        {
          return _context.Inscritos.Any(e => e.Id == id);
        }
    }
}
