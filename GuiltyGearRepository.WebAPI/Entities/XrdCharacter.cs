namespace GuiltyGearRepository.WebAPI.Entities;

public class XrdCharacter
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

    public virtual ICollection<XrdMove> XrdMoveLists { get; } = new List<XrdMove>();
}
