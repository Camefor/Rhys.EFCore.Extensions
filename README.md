# Rhys.EFCore.Extensions


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
