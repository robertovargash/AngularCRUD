using System;
using System.Collections.Generic;

namespace BackEndApi.DTO;

public class EmpleadoDTO
{
  public int IdEmpleado { get; set; }

  public string? NombreCompleto { get; set; }

  public int IdDepartamento { get; set; }

  public string? DescripcionDepartamento { get; set; }


  public int? Sueldo { get; set; }

  public DateTime? FechaContrato { get; set; }


}
