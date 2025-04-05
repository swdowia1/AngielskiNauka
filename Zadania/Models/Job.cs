using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zadania.Models;

public partial class Job
{
    [Key]
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public bool Completed { get; set; }

    [InverseProperty("Job")]
    public virtual ICollection<JobTime> JobTimes { get; set; } = new List<JobTime>();
}
