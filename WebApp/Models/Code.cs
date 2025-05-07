using System;
using System.Collections.Generic;

namespace Code_Generator_Web_App.Models;

public partial class Code
{
    public int Id { get; set; }

    public string TheCode { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public int Duration { get; set; }

    public int Status { get; set; }

    public virtual Status StatusNavigation { get; set; } = null!;
}
