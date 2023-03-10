using GuiltyGearRepository.WebAPI.Contexts;
using GuiltyGearRepository.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuiltyGearRepository.WebAPI.Services;

public class XrdRepository 
{
    private readonly GuiltyGearDb _context;

    public XrdRepository(GuiltyGearDb context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<IEnumerable<XrdCharacter>> GetAllCharactersAsync()
    {
        return await _context.XrdCharacters
            .OrderBy(character => character.Id)
            .ToListAsync();
    }

    public async Task<XrdCharacter?> GetCharacterByNameAsync(string characterName)
    {
        return await _context.XrdCharacters
            .Where(c => characterName.ToUpper() == c.CharacterName.ToUpper()) 
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<XrdMove>?> GetMovesForCharacterAsync(string characterName)
    {
        return await (from character in _context.XrdCharacters
                      join move in _context.XrdMoves 
                          on character.Id equals move.CharacterId
                      where character.CharacterName.ToUpper() == characterName.ToUpper()
                      select move)
            .ToListAsync();
    }

    public async Task<XrdMove?> GetMoveDataForCharacterAsync(string characterName, string moveName)
    {
        return await (from character in _context.XrdCharacters
                      join move in _context.XrdMoves
                          on character.Id equals move.CharacterId
                      where character.CharacterName.ToUpper() == characterName.ToUpper()
                      where move.MoveName.ToUpper() == moveName.ToUpper()
                      select move)
            .FirstOrDefaultAsync();
    }
}