using System;
using System.Collections.Generic;

namespace Code_Generator_Web_App.Models;

public partial class Status
{
    public int Id { get; set; }

    public string State { get; set; } = null!;

    public virtual ICollection<Code> Codes { get; set; } = new List<Code>();
}
