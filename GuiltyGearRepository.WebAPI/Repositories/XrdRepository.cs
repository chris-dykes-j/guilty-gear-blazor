using GuiltyGearRepository.WebAPI.Contexts;
using GuiltyGearRepository.WebAPI.Entities;
using GuiltyGearRepository.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GuiltyGearRepository.WebAPI.Repositories;

public class XrdRepository 
{
    private readonly GuiltyGearDb _context;

    public XrdRepository(GuiltyGearDb context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task<IEnumerable<XrdCharacterSimple>> GetAllCharactersAsync()
    {
        return await _context.XrdCharacters
            .Select(x => new XrdCharacterSimple
            {
                Id = x.Id,
                CharacterName = x.CharacterName
            })
            .OrderBy(character => character.Id)
            .ToListAsync();
    }

    public async Task<XrdCharacterDetailed?> GetCharacterByNameAsync(string characterName)
    {
        var moves = await GetMovesForCharacterAsync(characterName);
        
        return await (from character in _context.XrdCharacters
            where characterName.ToUpper() == character.CharacterName.ToUpper()
            select new XrdCharacterDetailed
            {
                Id = character.Id,
                CharacterName = character.CharacterName,
                Defense = character.Defense,
                Guts = character.Guts,
                PreJump = character.PreJump,
                Weight = character.Weight,
                BackDash = character.BackDash,
                ForwardDash = character.ForwardDash,
                RiscGainRate = character.RiscGainRate,
                WakeUpFaceUp = character.WakeUpFaceUp,
                WakeUpFaceDown = character.WakeUpFaceDown,
                UniqueMovement = character.UniqueMovement,
                MoveList = moves.ToList()
            })
            .FirstOrDefaultAsync();
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

    #region Helper Methods

    private async Task<IEnumerable<XrdMoveSimple?>> GetMovesForCharacterAsync(string characterName)
    {
        return await (from character in _context.XrdCharacters
                join move in _context.XrdMoves
                    on character.Id equals move.CharacterId
                where character.CharacterName.ToUpper() == characterName.ToUpper()
                select new XrdMoveSimple
                {
                    Id = move.Id,
                    Input = move.Input,
                    MoveName = move.MoveName
                })
            .ToListAsync();
    }
    
    #endregion
}