using Esthiber_Valentin_P1_AP1.DAL;
using Esthiber_Valentin_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;

namespace Esthiber_Valentin_P1_AP1.Services
{
    public class ModeloService(IDbContextFactory<Context> Dbfactory)
    {
        public async Task<bool> Insert(Modelo modelo)
        {
            await using var contexto = await Dbfactory.CreateDbContextAsync();
            contexto.Modelos.Add(modelo);
            return await contexto.SaveChangesAsync() > 0;
        }
    }
}
