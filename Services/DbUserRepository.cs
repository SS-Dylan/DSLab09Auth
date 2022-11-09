﻿using DSLab09Auth.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSLab09Auth.Services;

public class DbUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;
    public DbUserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ApplicationUser?> ReadByUsernameAsync(string username)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);
    }
}
