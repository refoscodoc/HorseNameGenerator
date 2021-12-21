using HorsesApi.Interfaces;
using HorsesApi.Models;

namespace HorsesApi.MySqlDataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly DomainModelMySqlContext _context;
        private readonly ILogger _logger;

        public DataAccessProvider(DomainModelMySqlContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessProvider");
        }

        // public async Task<EngWord> AddHorse(HorseName horseName)
        // {
        //     _context.EnglishDictionary.Add(horseName);
        //     await _context.SaveChangesAsync();
        //     return horseName;
        // }

        // public Task UpdateHorse(long dataEventRecordId, HorseName horseName)
        // {
        //     throw new NotImplementedException();
        // }
        //
        // public async Task UpdateDataEventRecord(long dataEventRecordId, HorseName horseName)
        // {
        //     _context.EnglishDictionary.Update(horseName);
        //     await _context.SaveChangesAsync();
        // }
        //
        // public async Task DeleteHorse(long horseId)
        // {
        //     var entity = _context.EnglishDictionary.First(t => t.HorseId == horseId);
        //     _context.EnglishDictionary.Remove(entity);
        //     await _context.SaveChangesAsync();
        // }

        public async Task<EngWord?> GetHorse(string? type)
        {
            int total = _context.EnglishDictionary.Count();
            Random r = new Random();
            
            int offset = r.Next(0, total);

            return await Task.Run(() => _context.EnglishDictionary.Skip(offset).FirstOrDefault(t => t.WordType == type));
        }

        // public async Task<List<EngWord>> GetAllHorses()
        // {
        //     // Using the shadow property EF.Property<DateTime>(dataEventRecord)
        //     return await _context.EnglishDictionary
        //         // .Include(s => s.SourceInfo)
        //         .OrderByDescending(dataEventRecord => EF.Property<DateTime>(dataEventRecord, "UpdatedTimestamp"))
        //         .ToListAsync();
        // }

        // public async Task<List<SourceInfo>> GetSourceInfos(bool withChildren)
        // {
        //     // Using the shadow property EF.Property<DateTime>(srcInfo)
        //     if (withChildren)
        //     {
        //         return await _context.SourceInfos.Include(s => s.DataEventRecords).OrderByDescending(srcInfo => EF.Property<DateTime>(srcInfo, "UpdatedTimestamp")).ToListAsync();
        //     }
        //
        //     return await _context.SourceInfos.OrderByDescending(srcInfo => EF.Property<DateTime>(srcInfo, "UpdatedTimestamp")).ToListAsync();
        // }
        //
        // public async Task<bool> DataEventRecordExists(long id)
        // {
        //     var filteredDataEventRecords = _context.DataEventRecords
        //         .Where(item => item.HorseId == id);
        //
        //     return await filteredDataEventRecords.AnyAsync();
        // }
        //
        // public async Task<SourceInfo> AddSourceInfo(SourceInfo sourceInfo)
        // {
        //     _context.SourceInfos.Add(sourceInfo);
        //     await _context.SaveChangesAsync();
        //     return sourceInfo;
        // }
        //
        // public async Task<bool> SourceInfoExists(long id)
        // {
        //     var filteredSourceInfoRecords = _context.SourceInfos
        //         .Where(item => item.SourceInfoId == id);
        //
        //     return await filteredSourceInfoRecords.AnyAsync();
        // }
    }
}
