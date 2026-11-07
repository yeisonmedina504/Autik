import { z } from "zod";

export const MantenimientoSchema = z.object({
  tipo: z
    .string()
    .min(3, { message: "El tipo debe tener al menos 3 caracteres" }),
  marcaModelo: z
    .string()
    .min(3, { message: "La marca y modelo deben tener al menos 3 caracteres" }),
  placa: z
    .string()
    .min(3, { message: "La placa debe tener al menos 3 caracteres" }),
  anio: z
    .string()
    .regex(/^\d{4}$/, { message: "El año debe ser un número de 4 dígitos" }),
});

export type MantenimientoSchemaType = z.infer<typeof MantenimientoSchema>;
