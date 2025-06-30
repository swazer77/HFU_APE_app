﻿using Core.Models;

namespace Core.Services;
public class PersonService : IPersonService
{
    private readonly ILocalStorage _localStorage;
    public PersonService(ILocalStorage localStorage)
    {
        _localStorage = localStorage;
    }
    public async Task Save(Person person)
    {
        if (person == null)
        {
            throw new ArgumentNullException(nameof(person));
        }

        await _localStorage.Save(person);
    }

    public async Task<List<Person>> Load()
    {
        await _localStorage.Initialize();
        return await _localStorage.LoadAll();
    }
}
