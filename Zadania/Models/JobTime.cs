using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zadania.Models;

public partial class JobTime
{
    [Key]
    public int Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int JobId { get; set; }

    [ForeignKey("JobId")]
    [InverseProperty("JobTimes")]
    public virtual Job Job { get; set; } = null!;
}
