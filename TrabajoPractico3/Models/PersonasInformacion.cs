using System;
using System.Collections.Generic;

namespace TrabajoPractico3.Models;

public partial class PersonasInformacion
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Nacionalidad { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;
}
