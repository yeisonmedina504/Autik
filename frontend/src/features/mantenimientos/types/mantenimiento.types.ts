// 1. Contrato de Lectura / Salida (Entidad que viene desde PostgreSQL con su Primary Key)
export interface Mantenimiento {
  id: number;
  tipo: string;
  marcaModelo: string;
  placa: string;
  anio: string;
}

// 2. Contrato de Escritura / Entrada (Payload que enviamos en el POST hacia .NET)
export interface CrearMantenimientoDto {
  tipo: string;
  marcaModelo: string;
  placa: string;
  anio: string;
}

// 3. Contrato de Error de FluentValidation (.NET ValidationFailure)
export interface FluentValidationError {
  propertyName: string;
  errorMessage: string;
  attemptedValue?: unknown;
  errorCode?: string;
}
