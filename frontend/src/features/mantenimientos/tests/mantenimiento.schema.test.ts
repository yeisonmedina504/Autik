import { describe, expect, it } from "vitest";
import { MantenimientoSchema } from "../schemas/mantenimiento.schema";

describe("MantenimientoSchema", () => {
  const datosValidos = {
    tipo: "Preventivo",
    marcaModelo: "Toyota Corolla",
    placa: "ABC-1234",
    anio: "2020",
  };

  it("acepta un año de cuatro dígitos", () => {
    expect(MantenimientoSchema.safeParse(datosValidos).success).toBe(true);
  });

  it("rechaza un año con letras", () => {
    const resultado = MantenimientoSchema.safeParse({
      ...datosValidos,
      anio: "20A0",
    });

    expect(resultado.success).toBe(false);
  });
});