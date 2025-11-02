using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Edad { get; set; }
}
