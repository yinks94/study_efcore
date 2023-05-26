using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DgeHrm3.DAL.Model;

public enum SubjectKind
{
    교과,
    전문교과,
    비교과,
    특수
}

[Table("subject")]
public class Subject
{
    [Key]
    [Column("subject_id")]
    public int SubjectId
    {
        get; set;
    }

    [Column("short_name")]
    public string ShortName { get; set; } = string.Empty;

    [Column("full_name")]
    public string FullName { get; set; } = string.Empty;

    [Column("kind")]
    public string Kind { get; set; } = string.Empty;

    [Column("neis_code")]
    public string NeisCode { get; set; } = string.Empty;

    [Column("neis_middle")]
    public string NeisMiddle { get; set; } = string.Empty;

    [Column("neis_high")]
    public string NeisHigh { get; set; } = string.Empty;

    [Column("enable")]
    public bool Enable { get; set; } = false;

    [Column("apply_cho")]
    public bool ApplyCho { get; set; } = false;

    [Column("can_transfer")]
    public bool CanTransfer { get; set; } = false;

    [Column("want_count")]
    public int WantCount { get; set; } = 4;

    [Column("sort")]
    public int Sort { get; set; } = int.MaxValue;

    public override string ToString() => $"{nameof(SubjectId)}: {SubjectId}, {nameof(ShortName)}: {ShortName}, {nameof(FullName)}: {FullName}, {nameof(Kind)}: {Kind}, {nameof(NeisCode)}: {NeisCode}, {nameof(NeisMiddle)}: {NeisMiddle}, {nameof(NeisHigh)}: {NeisHigh}, {nameof(Enable)}: {Enable}, {nameof(ApplyCho)}: {ApplyCho}, {nameof(CanTransfer)}: {CanTransfer}, {nameof(WantCount)}: {WantCount}, {nameof(Sort)}: {Sort}";
}