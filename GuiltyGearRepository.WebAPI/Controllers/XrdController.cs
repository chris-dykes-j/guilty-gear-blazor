using GuiltyGearRepository.WebAPI.Entities;
using GuiltyGearRepository.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuiltyGearRepository.WebAPI.Controllers;

[Route("xrd")]
[ApiController]
public class XrdController : ControllerBase
{
    private readonly XrdRepository _repository;

    public XrdController(XrdRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<XrdController>>> GetCharacters() => Ok (await _repository.GetAllCharactersAsync());

    [HttpGet]
    [Route("{name}")]
    public async Task<ActionResult<XrdController>> GetCharacterByName(string name)
    {
        var characterEntity = await _repository.GetCharacterByNameAsync(name);
        if (characterEntity == null)
            return NotFound();
        return Ok(characterEntity);
    }

    [HttpGet]
    [Route("{characterName}/moves")]
    public async Task<ActionResult<IEnumerable<XrdMove>>> GetMoveListNoData(string characterName)
    {
        var characterMoves = await _repository.GetMovesForCharacterAsync(characterName);
        if (characterMoves == null)
            return NotFound();
        return Ok(characterMoves);
    }
    
    [HttpGet]
    [Route(template: "{characterName}/moves/{moveName}")]
    public async Task<ActionResult<IEnumerable<XrdMove>>> GetMoveData(string characterName, string moveName)
    {
        var move = await _repository.GetMoveDataForCharacterAsync(characterName, moveName);
        if (move == null)
            return NotFound();
        return Ok(move);
    }
}