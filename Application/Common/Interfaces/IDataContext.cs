
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IDataContext
{
    DbSet<Domain.Entities.Building> Buildings { get; }
    DbSet<Domain.Entities.TypeChapitre> Chapitres { get; }
    DbSet<Domain.Entities.Observation> Observations { get; }

}
