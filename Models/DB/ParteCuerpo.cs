using System;
using System.Collections.Generic;

namespace MedExploraAPI.Models.DB;

// parte del cuerpo en la base de datos
public partial class ParteCuerpo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? EnfermedadesAsociadas { get; set; }
}
