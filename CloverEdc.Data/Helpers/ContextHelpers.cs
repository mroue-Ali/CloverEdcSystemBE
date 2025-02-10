using CloverEdc.Core.Models;
using CloverEdc.Data.Context;

namespace CloverEdc.Data.Helpers;

public class ContextHelpers
{
    private readonly ApplicationDbContext _context;

    public ContextHelpers(ApplicationDbContext context)
    {
        _context = context;
    }
    public void SoftDeleteEntity(object entity)
    {
        if (entity == null) return;

        // Mark the current entity as soft-deleted if it implements ISoftDeletable
        if (entity is EntityBase softDeletable)
        {
            softDeletable.IsDeleted = true;
            softDeletable.DateDeleted = DateTime.Now;
        }

        // Get the entity entry to inspect navigation properties
        var entry = _context.Entry(entity);
        foreach (var navigation in entry.Navigations)
        {
            // If the navigation property is not loaded, you might want to load it explicitly
            if (!navigation.IsLoaded)
            {
                navigation.Load();
            }

            // Check if the navigation is a collection or a single entity
            if (navigation.CurrentValue is IEnumerable<object> children)
            {
                foreach (var child in children)
                {
                    SoftDeleteEntity(child);
                }
            }
            else if (navigation.CurrentValue != null)
            {
                SoftDeleteEntity(navigation.CurrentValue);
            }
        }
    }

}