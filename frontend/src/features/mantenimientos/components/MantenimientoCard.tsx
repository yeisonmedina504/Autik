import type { Mantenimiento } from "../types/mantenimiento.types";

export function MantenimientoCard({
  Id,
  Tipo,
  MarcaModelo,
  Placa,
  Anio,
}: Mantenimiento) {
  // --- ZONA 3: EL CEREBRO (LÓGICA) ---
  // (Vacío por los momentos, este componente es puramente presentacional)

  // --- ZONA 4: EL RENDERIZADO (JSX) ---
  return (
    <article
      className="habit-card"
      style={{
        border: "1px solid #ccc",
        padding: "1rem",
        margin: "1rem",
        borderRadius: "8px",
      }}
    >
      <small style={{ color: "gray" }}>ID Mantenimiento: {Id}</small>
      <h3>{Tipo}</h3>
      <h3>{MarcaModelo}</h3>
      <h3>{Placa}</h3>
      <h3>{Anio}</h3>
      {/* 
               En la Unidad 3, cuando tengamos sistema de Usuarios (IAM), 
               este botón llamará a la tabla transaccional para adoptar el hábito.
            */}
      {/* Botón de Acción (Se habilitará cuando implementemos Usuarios en la Unidad 3) */}
      <button
        disabled
        className="w-full bg-slate-900/80 text-slate-400 text-sm font-medium py-2.5 px-4 rounded-lg cursor-not-allowed border border-slate-700"
      >
        🔒 Marcar {Tipo} completado (Requiere Sesión)
      </button>
    </article>
  );
}
