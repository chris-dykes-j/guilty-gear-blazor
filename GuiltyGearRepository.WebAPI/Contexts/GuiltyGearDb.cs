using GuiltyGearRepository.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuiltyGearRepository.WebAPI.Contexts;

public class GuiltyGearDb : DbContext
{
    public GuiltyGearDb(DbContextOptions<GuiltyGearDb> options) : base(options) { }
    public DbSet<XrdCharacter> XrdCharacters { get; set; } = null!;
    public DbSet<XrdMove> XrdMoves { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<XrdCharacter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("xrd_characters_pkey");

            entity.ToTable("xrd_characters");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BackDash).HasColumnName("back_dash");
            entity.Property(e => e.CharacterName).HasColumnName("character_name");
            entity.Property(e => e.Defense).HasColumnName("defense");
            entity.Property(e => e.ForwardDash).HasColumnName("forward_dash");
            entity.Property(e => e.Guts).HasColumnName("guts");
            entity.Property(e => e.PreJump).HasColumnName("pre_jump");
            entity.Property(e => e.RiscGainRate).HasColumnName("risc_gain_rate");
            entity.Property(e => e.UniqueMovement).HasColumnName("unique_movement");
            entity.Property(e => e.WakeUpFaceDown).HasColumnName("wake_up_face_down");
            entity.Property(e => e.WakeUpFaceUp).HasColumnName("wake_up_face_up");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        modelBuilder.Entity<XrdMove>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("xrd_move_list_pkey");

            entity.ToTable("xrd_move_list");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Cancel).HasColumnName("cancel");
            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Damage).HasColumnName("damage");
            entity.Property(e => e.Guard).HasColumnName("guard");
            entity.Property(e => e.Input).HasColumnName("input");
            entity.Property(e => e.Invulnerability).HasColumnName("invulnerability");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.MoveName).HasColumnName("move_name");
            entity.Property(e => e.OnBlock).HasColumnName("on_block");
            entity.Property(e => e.Prorate).HasColumnName("prorate");
            entity.Property(e => e.RecoveryFrames).HasColumnName("recovery_frames");
            entity.Property(e => e.RiscM).HasColumnName("risc_m");
            entity.Property(e => e.RiscP).HasColumnName("risc_p");
            entity.Property(e => e.Startup).HasColumnName("startup");
            entity.Property(e => e.Tension).HasColumnName("tension");

            entity.HasOne(d => d.Character).WithMany(p => p.XrdMoveLists)
                .HasForeignKey(d => d.CharacterId)
                .HasConstraintName("xrd_move_list_character_id_fkey");
        });
    }
}