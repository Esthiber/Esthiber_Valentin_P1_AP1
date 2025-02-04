using Esthiber_Valentin_P1_AP1.DAL;
using Esthiber_Valentin_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Esthiber_Valentin_P1_AP1.Services
{
    public class ModeloService(IDbContextFactory<Context> Dbfactory)
    {
        public async Task<bool> Guardar(Modelos modelo)
        {
            if (await Existe(modelo.Id))
                return await Modificar(modelo);
            else
                return await Insert(modelo);
        }

        public async Task<bool> Existe(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Modelo.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(Modelos modelo)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Modelo.Add(modelo);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Modelos modelo)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Entry(modelo).State = EntityState.Modified;
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Modelos?> Buscar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Modelo.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Modelo
                .AsNoTracking()
                .Where(m => m.Id == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Modelos>> Listar(Expression<Func<Modelos,bool>> criterio)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Modelo
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
