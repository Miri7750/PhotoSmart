﻿using System;
using System.Collections.Generic;

namespace PhotoSmart.Core.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Photo> Files { get; set; } = new List<Photo>();
}
