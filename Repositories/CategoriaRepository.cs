﻿using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    public IEnumerable<Categoria> GetCategorias()
    {
        throw new NotImplementedException();
    }
}

