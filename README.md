# Rhys.EFCore.Extensions

This is an extension tool for EF Core that generates table comments based on the annotations of entity classes in code-first mode.

Usage:
```c#
in MyContext.cs 

using  Rhys.EFCore.Extensions;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Your Entity>()
            //todo other
            .TryConfigureEntityComment()
            ;
    }
```
