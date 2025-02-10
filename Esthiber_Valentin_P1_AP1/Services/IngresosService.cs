using Esthiber_Valentin_P1_AP1.DAL;
using Esthiber_Valentin_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Esthiber_Valentin_P1_AP1.Services
{
    public class IngresosService(IDbContextFactory<Context> Dbfactory)
    {
        public async Task<bool> Guardar(Ingresos ingreso)
        {
            if (await Existe(ingreso.IngresoId))
                return await Modificar(ingreso);
            else
                return await Insert(ingreso);
        }

        public async Task<bool> Existe(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Ingresos.AnyAsync(i => i.IngresoId == id);
        }

        public async Task<bool> Insert(Ingresos modelo)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Ingresos.Add(modelo);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Ingresos modelo)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Entry(modelo).State = EntityState.Modified;
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Ingresos?> Buscar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Ingresos.FirstOrDefaultAsync(i => i.IngresoId == id);
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Ingresos
                .AsNoTracking()
                .Where(i => i.IngresoId == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Ingresos>> Listar(Expression<Func<Ingresos,bool>> criterio)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            return await contexto.Ingresos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
