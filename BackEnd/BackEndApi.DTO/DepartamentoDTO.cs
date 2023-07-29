using System;
using System.Collections.Generic;

namespace BackEndApi.DTO;

public class DepartamentoDTO
{
  public int IdDepartamento { get; set; }

  public string? Nombre { get; set; }

  public virtual ICollection<EmpleadoDTO> Empleados { get; set; } = new List<EmpleadoDTO>();
}
