// src/features/habitos/api/habitosApi.ts

import type { Mantenimiento } from "../types/mantenimiento.types";

// Función asíncrona que retorna una Promesa con el arreglo de hábitos
export const obtenerMantenimientosAsync = (): Promise<Mantenimiento[]> => {
  return new Promise((resolve) => {
    setTimeout(() => {
      const datosCatalogo: Mantenimiento[] = [
        {
          Id: 1,
          Tipo: "Reparacion de caja",
          MarcaModelo: "Toyota Hilux 2025",
          Placa: "2026HJ",
          Anio: "2027",
        },
        {
          Id: 1,
          Tipo: "Reparacion de caja",
          MarcaModelo: "Toyota Hilux 2025",
          Placa: "2026HJ",
          Anio: "2027",
        },
        {
          Id: 1,
          Tipo: "Reparacion de caja",
          MarcaModelo: "Toyota Hilux 2025",
          Placa: "2026HJ",
          Anio: "2027",
        },
        {
          Id: 1,
          Tipo: "Reparacion de caja",
          MarcaModelo: "Toyota Hilux 2025",
          Placa: "2026HJ",
          Anio: "2027",
        },
        {
          Id: 1,
          Tipo: "Reparacion de caja",
          MarcaModelo: "Toyota Hilux 2025",
          Placa: "2026HJ",
          Anio: "2027",
        },
        {
          Id: 1,
          Tipo: "Reparacion de caja",
          MarcaModelo: "Toyota Hilux 2025",
          Placa: "2026HJ",
          Anio: "2027",
        },
        {
          Id: 1,
          Tipo: "Reparacion de caja",
          MarcaModelo: "Toyota Hilux 2025",
          Placa: "2026HJ",
          Anio: "2027",
        },
        {
          Id: 1,
          Tipo: "Reparacion de caja",
          MarcaModelo: "Toyota Hilux 2025",
          Placa: "2026HJ",
          Anio: "2027",
        },
        {
          Id: 1,
          Tipo: "Reparacion de caja",
          MarcaModelo: "Toyota Hilux 2025",
          Placa: "2026HJ",
          Anio: "2027",
        },
        {
          Id: 1,
          Tipo: "Reparacion de caja",
          MarcaModelo: "Toyota Hilux 2025",
          Placa: "2026HJ",
          Anio: "2027",
        },
      ];
      resolve(datosCatalogo);
    }, 1000);
  });
};
