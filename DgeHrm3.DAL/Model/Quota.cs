using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DgeHrm3.DAL.Model;

[Table("quota")]
public class Quota
{
    [Key]
    [Column("quota_id")]
    public int QutoaId
    {
        get; set;
    }

    [Column("year")]
    public int Year
    {
        get; set;
    }

    [Column("school_id")]
    public int SchoolId
    {
        get; set;
    }

    public School? School
    {
        get; set;
    }

    [Column("subject_id")]
    public int SubjectId
    {
        get; set;
    }

    public Subject? Subject
    {
        get; set;
    }

    [Column("current_count")]
    public decimal CurrentCount { get; set; } = decimal.Zero;

    [Column("current_up")]
    public decimal? CurrentUp { get; set; } = decimal.Zero;

    [Column("current_etc")]
    public decimal? CurrentEtc { get; set; } = decimal.Zero;

    [Column("next_count")]
    public decimal NextCount { get; set; } = decimal.Zero;

    [Column("next_up")]
    public decimal? NextUp { get; set; } = decimal.Zero;

    [Column("next_etc")]
    public decimal? NextEtc { get; set; } = decimal.Zero;

    [Column("memo")]
    public string? Memo
    {
        get; set;
    }

    public decimal Current => decimal.Add(CurrentCount, CurrentUp ?? decimal.Zero);

    public decimal CurrentAll => decimal.Add(Current, CurrentEtc ?? decimal.Zero);

    public decimal Next => decimal.Add(NextCount, NextUp ?? decimal.Zero);

    public decimal NextAll => decimal.Add(Next, NextEtc ?? decimal.Zero);

    public override string ToString() => $"{nameof(QutoaId)}: {QutoaId}, {nameof(Year)}: {Year}, {nameof(SchoolId)}: {SchoolId}, {nameof(School)}: {School?.ShortName}, {nameof(SubjectId)}: {SubjectId}, {nameof(Subject)}: {Subject?.ShortName}, {nameof(CurrentCount)}: {CurrentCount}, {nameof(CurrentUp)}: {CurrentUp}, {nameof(CurrentEtc)}: {CurrentEtc}, {nameof(NextCount)}: {NextCount}, {nameof(NextUp)}: {NextUp}, {nameof(NextEtc)}: {NextEtc}, {nameof(Memo)}: {Memo}, {nameof(Current)}: {Current}, {nameof(CurrentAll)}: {CurrentAll}, {nameof(Next)}: {Next}, {nameof(NextAll)}: {NextAll}";
}