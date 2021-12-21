using HorsesApi.Interfaces;
using HorsesApi.Models;
using HorsesApi.MySqlDataAccess;

namespace HorsesApi.Services;

public class BusinessProvider
{
    private readonly IDataAccessProvider _dataAccessProvider;

    public BusinessProvider(IDataAccessProvider dataAccessProvider)
    {
        _dataAccessProvider = dataAccessProvider;
    }
    
    public async Task<HorseName> GetName(string? type)
    {
        // in case of /5 the last has to change -ing verbs
        
        var first = await _dataAccessProvider.GetHorse(type);
        var last = await _dataAccessProvider.GetHorse("n.");

        var result = new HorseName
        {
            HorseId = new long(),
            FirstName = first.Word,
            LastName = last.Word,
        };
            
        return result;
    }
}