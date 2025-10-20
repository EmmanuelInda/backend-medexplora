using System;
using System.Collections.Generic;

namespace APIprueba.Models.DB;

public partial class Animale
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Especie { get; set; }

    public int? Edad { get; set; }

    public decimal? Peso { get; set; }

    public string? Color { get; set; }
}
