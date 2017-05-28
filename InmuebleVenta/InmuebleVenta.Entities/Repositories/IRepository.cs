using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        //Metodos estandar que todas las tablas deben tener.
        //Se programan de manera generica para no duplicar codigo por cada una .


        //CREATES
        //Agregar un registro al repositorio (sql server) a la tabla TEntity
        void Add(TEntity entity);
        //Agregar un grupo de registros al repositorio (sql server) a la tabla TEntity
        void AddRange(IEnumerable<TEntity> entities);

        //READS 
        //Obtiene el registro con primary key=Id de la tabla TEntity
        TEntity Get(int Id);
        //Obtiene todos los registros de la tabla TEntity
        IEnumerable<TEntity> GetAll();
        // Obtiene todos los registros de la tabla TEntity que complan con la condicion predicate
        //predicate es una expresion lambda que tiene como parametro de entrada a TEntity
        //y deolvera una expresion booleana.Si esta expresion es True para un registro
        //entonces dicho registro se agregara a la lista de registros a devolver de la aplicacion
        IEnumerator<TEntity> Find(Expression<Func<TEntity, bool>> Predicate);

        //UPDATES
        //Actualiza un registro al repositorio (SQL server) a la tabla TEntity
        //void Update(TEntity entity);
        //Actualiza un grupo de registros al repositorio(SQL server) a la tabla TEntity
        //void UpdateRange(IEnumerable<TEntity> entities);
        //DELETES
        //Elimina un registro al repositorio (SQL server) a la tabla TEntity
        void Delete(TEntity entity);
        //Elimina un grupo de registros al repositorio(SQL server) a la tabla TEntity
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
