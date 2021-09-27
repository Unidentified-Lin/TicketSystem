# TicketSystem

## Task 1

> Please write down all the use cases either in text or diagram you can think for Phase I and Phase II requirement separately.

Please see pdf document: `TicketSystem Task1 Flow.pdf` and `TicketSystem Task1 Swimlane.pdf`.

## Task 2

> Please implement the A. Phase I Requirement by .NET Core MVC/Java Spring MVC/PHP Laravel 8/ Python Django. For front-end, you can use any framework you like, but we prefer Vue XDD.

This project.

## Task 3

> Think of yourself as an architect. How will you design this system, please write down the design document at least to include data model, class diagram and UI mock up.

Please see pdf document: `TicketSystem Task3 Schema.pdf`

### class diagram

```mermaid
classDiagram
    class IGenericRepository~TEntity~{
        Entity() IQueryable~TEntity~
        Get(filter, includePropertie) IEnumerable~TEntity~
        GetById(object id) TEntity
        Insert(TEntity entity) void
        Update(TEntity entity) void
        Delete(object id) void
        Delete(TEntity entity) void
    }
    <<interface>> IGenericRepository

    class IUnitOfWorks{
        RepositoryT() IGenericRepository~T~
        BeginTransaction() void
        Commit() void
        Rollback() void
        SaveChange() void
    }
    <<interface>> IUnitOfWorks

    class GenericRepository~TEntity~{
        -Context _context
        Entity() IQueryable~TEntity~
        Get(filter, includePropertie) IEnumerable~TEntity~
        GetById(object id) TEntity
        Insert(TEntity entity) void
        Update(TEntity entity) void
        Delete(object id) void
        Delete(TEntity entity) void
    }

    class UnitOfWorks{
        -Context _context
        -Transaction _transaction
        +RepositoryT() IGenericRepository~T~
        +BeginTransaction() void
        +Commit() void
        +Rollback() void
        +SaveChange() void
    }

    IUnitOfWorks ..> IGenericRepository~TEntity~ : Dependency
    IUnitOfWorks <|.. UnitOfWorks : Realization
    IGenericRepository~TEntity~ <|.. GenericRepository~TEntity~ : Realization
```

```mermaid
classDiagram
    class IService~T~{
        GetListToViewModel(filter,includes) List~TViewModel~
        GetSpecificDetailToViewModel(filter,includes) TViewModel
        CreateViewModelToDatabase(TViewModel viewModel) void
        UpdateViewModelToDatabase(TViewModel viewModel, object id) void
        Delete(filter) void
    }
    <<interface>> IService~T~

    class GenericService~T~{
        -IUnitOfWorks _unitOfWorks
        +GetListToViewModel(filter,includes) List~TViewModel~
        +GetSpecificDetailToViewModel(filter,includes) TViewModel
        +CreateViewModelToDatabase(TViewModel viewModel) void
        +UpdateViewModelToDatabase(TViewModel viewModel, object id) void
        +Delete(filter) void
    }

    class ITicketService~Ticket~{
        GetTickets() IEnumerable<TicketViewModel>
        AddTicket(TicketViewModel vm, user) string
        Resolve(Guid id, user) string

    }
    <<interface>>ITicketService~Ticket~

    class TicketService{
        -IUnitOfWorks _unitofWorks
        +GetTickets() IEnumerable<TicketViewModel>
        +AddTicket(TicketViewModel vm, user) string
        +Resolve(Guid id, user) string
    }

    IService <|.. GenericService~T~ : Realization
    IService <|-- ITicketService~Ticket~ : Inheritance
    GenericService~T~ <|-- TicketService : Inheritance
    ITicketService~Ticket~ <|.. TicketService : Realization
```

## Task 4

> If we are going to open the system for 3rd party to use, can you please design the Web API(Json format) and api document?
