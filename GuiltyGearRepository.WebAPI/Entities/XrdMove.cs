namespace GuiltyGearRepository.WebAPI.Entities;

public class XrdMove
{
    public int Id { get; set; }

    public int? CharacterId { get; set; }

    public string? Input { get; set; }

    public string? MoveName { get; set; }

    public string? Damage { get; set; }

    public string? RiscP { get; set; }

    public string? RiscM { get; set; }

    public string? Prorate { get; set; }

    public string? Guard { get; set; }

    public string? Level { get; set; }

    public string? Cancel { get; set; }

    public string? Tension { get; set; }

    public string? Startup { get; set; }

    public string? Active { get; set; }

    public string? RecoveryFrames { get; set; }

    public string? OnBlock { get; set; }

    public string? Invulnerability { get; set; }
}
