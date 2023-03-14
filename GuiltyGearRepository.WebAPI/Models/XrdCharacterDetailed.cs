namespace GuiltyGearRepository.WebAPI.Models;

public class XrdCharacterDetailed
{
    public int Id { get; set; }

    public string CharacterName { get; set; } = null!;

    public string? Defense { get; set; }

    public string? Guts { get; set; }

    public string? PreJump { get; set; }

    public string? Weight { get; set; }

    public string? BackDash { get; set; }

    public string? ForwardDash { get; set; }

    public string? RiscGainRate { get; set; }

    public string? WakeUpFaceUp { get; set; }

    public string? WakeUpFaceDown { get; set; }

    public string? UniqueMovement { get; set; }
    
    public List<XrdMoveSimple> MoveList { get; set; }
}