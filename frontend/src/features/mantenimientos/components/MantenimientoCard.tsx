import type { Mantenimiento } from "../types/mantenimiento.types";

export function MantenimientoCard({
  id,
  tipo,
  marcaModelo,
  placa,
  anio,
}: Mantenimiento) {
  return (
    <article className="bg-slate-800 border border-slate-700 rounded-xl p-5 flex flex-col justify-between hover:border-indigo-500 transition-colors shadow-sm">
      <div>
        <div className="flex items-center justify-between mb-3">
          <span className="bg-indigo-500/10 text-indigo-400 text-xs font-semibold px-2.5 py-1 rounded-md border border-indigo-500/20">
            ID Mantenimiento #{id}
          </span>
          <span className="text-xs text-slate-400 font-medium">
            Catálogo Mantenimientos
          </span>
        </div>

        <h3 className="text-lg font-bold text-white mb-5">{tipo}</h3>
        <h3 className="text-lg font-bold text-white mb-5">{marcaModelo}</h3>
        <h3 className="text-lg font-bold text-white mb-5">{placa}</h3>
        <h3 className="text-lg font-bold text-white mb-5">{anio}</h3>
      </div>

      <button
        disabled
        className="w-full bg-slate-900/80 text-slate-400 text-sm font-medium py-2.5 px-4 rounded-lg cursor-not-allowed border border-slate-700"
      >
        🔒 Marcar Mantenimiento completado (Requiere Sesión)
      </button>
    </article>
  );
}
