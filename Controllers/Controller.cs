using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using personalAPI.Data;
using personalAPI.Models;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public abstract class Controller<TModel, TRepo> : ControllerBase
    where TModel : class , IModel
    where TRepo: IRepo<TModel>
    {
        private readonly TRepo _repo;

        public Controller(TRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TModel>> GetAll(){
            return Ok(_repo.GetAll());
        }

        [HttpGet("{Id}")]
        public ActionResult<TModel> Get(int id){
            var entity = _repo.Get(id);

            if(entity!=null){
                return Ok(entity);
            }

            return NotFound();
        }
        [HttpPost]
        public ActionResult Add(TModel entity){
            _repo.Add(entity);
            return CreatedAtRoute(nameof(Add), new {Id = entity.Id});
        }

        [HttpDelete("{id}")]
        public ActionResult deleteCommand(int id)
        {
            var entity = _repo.Get(id);

            if (entity != null)
            {
                _repo.Delete(entity);
                _repo.SaveChanges();
                return NoContent();
            }

            return NotFound();
        }
    }
}