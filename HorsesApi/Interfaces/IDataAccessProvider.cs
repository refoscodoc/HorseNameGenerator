using HorsesApi.Models;

namespace HorsesApi.Interfaces;

public interface IDataAccessProvider
{
    // Task<HorseName> AddHorse(HorseName horseName);
    // Task UpdateHorse(long dataEventRecordId, HorseName horseName);
    // Task DeleteHorse(long horseId);
    Task<EngWord?> GetHorse(string? type);
    // Task<List<HorseName>> GetAllHorses();
}