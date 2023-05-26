
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DgeHrm3.DAL.Model;

public enum SchoolKind
{
    교육부,
    타시도,
    시교육청,
    교육지원청,
    파견부서,
    중학교,
    초등학교,
    일반고,
    특수목적고,
    각종학교,
    특성화고,
    특수학교,
    대학교
}

public enum SchoolEstablish
{
    기관,
    국립,
    공립,
    사립
}


[Table("school")]
public class School
{
    [Key]
    [Column("school_id")]
    public int SchoolId
    {
        get; set;
    }

    [Column("short_name")]
    public string ShortName { get; set; } = string.Empty;

    [Column("full_name")]
    public string FullName { get; set; } = string.Empty;

    [Column("parent_id")]
    public int? ParentId
    {
        get; set;
    }

    public School? Parent
    {
        get; set;
    }

    [Column("neis_code")]
    public string NeisCode { get; set; } = string.Empty;

    [Column("enable")]
    public bool Enable { get; set; } = false;

    [Column("has_child")]
    public bool HasChild { get; set; } = false;

    [Column("can_transfer")]
    public bool CanTransfer { get; set; } = false;

    [Column("kind")]
    public SchoolKind Kind { get; set; } = SchoolKind.일반고;

    [Column("establish")]
    public SchoolEstablish Establish { get; set; } = SchoolEstablish.공립;

    [Column("period")]
    public int Period { get; set; } = 4;

    [Column("memo")]
    public string Memo { get; set; } = string.Empty;

    [Column("sort")]
    public int Sort { get; set; } = int.MaxValue;

    public override string ToString() => $"{nameof(SchoolId)}: {SchoolId}, {nameof(ShortName)}: {ShortName}, {nameof(FullName)}: {FullName}, {nameof(Parent)}: {Parent}, {nameof(NeisCode)}: {NeisCode}, {nameof(Enable)}: {Enable}, {nameof(HasChild)}: {HasChild}, {nameof(CanTransfer)}: {CanTransfer}, {nameof(Period)}: {Period}, {nameof(Memo)}: {Memo}, {nameof(Sort)}: {Sort}";
}