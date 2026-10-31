import { useState, useEffect } from "react";
import type { Mantenimiento } from "../types/mantenimiento.types";
import { obtenerMantenimientosAsync } from "../api/mantemientoApi";
import { MantenimientoCard } from "./MantenimientoCard";


 

export function MantenimientoView() {
  const [mantenimientos, setMantenimientos] = useState<Mantenimiento[]>(
    [],
  );
  const [cargando, setCargando] = useState<boolean>(true);
  const [busqueda, setBusqueda] = useState<string>("");


    useEffect(() => {
    // Consumimos nuestra capa de servicio (api/habitosApi.ts)
    obtenerMantenimientosAsync().then((datos) => {
      setMantenimientos(datos)
      setCargando(false)
    })
  }, [])

   //
  const mantenimientosFiltrados = mantenimientos.filter((mantenimiento) => {
    mantenimiento.Tipo.toLowerCase().includes(busqueda.toLocaleLowerCase());
  });

  return (
    {/* Buscador Reactivo: Cada tecla ejecuta setBusqueda(), guarda en el Almacén y refresca App() */}
        <div className="mb-6 flex flex-col sm:flex-row sm:items-center justify-between gap-4">
          <input
            type="text"
            placeholder="🔍 Filtrar hábitos en el catálogo..."
            value={busqueda}
            onChange={(e) => setBusqueda(e.target.value)}
            className="w-full sm:max-w-md bg-slate-950 border border-slate-800 rounded-lg px-4 py-2.5 text-sm text-white placeholder-slate-500 focus:outline-none focus:border-indigo-500 transition-colors"
          />
          <span className="text-xs text-slate-400">
            Mostrando{" "}
            <strong className="text-white">
              {mantenimientosFiltrados.length}
            </strong>{" "}
            de {mantenimientos.length} registros en memoria
          </span>
        </div>
        {/* RENDERIZADO CONDICIONAL: Vuelta 1 (cargando = true) vs Vuelta 2 (cargando = false) */}
        {cargando ? (
          <div className="bg-slate-800/50 border border-slate-800 rounded-xl p-12 text-center">
            <p className="text-indigo-400 font-semibold animate-pulse text-lg">
              ⏳ Sincronizando catálogo desde el Almacén de Estado...
            </p>
            <p className="text-slate-500 text-xs mt-2">
              Ejecutando Vuelta 1 (Montaje inicial y disparo de useEffect)
            </p>
          </div>
        ) : (
          /* MAPEO DINÁMICO AL DOM: Recorremos los datos re-inyectados en la variable 'habitosFiltrados' */
          <section className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
            {mantenimientosFiltrados.map((mantenimiento) => (
              <MantenimientoCard
                key={mantenimiento.Id}
                Id={mantenimiento.Id}
                Tipo={mantenimiento.Tipo}
                MarcaModelo={mantenimiento.MarcaModelo}
                Placa={mantenimiento.Placa}
                Anio={mantenimiento.Anio}
              />
            ))}
          </section>
          <div className="min-h-screen bg-slate-900 text-slate-100 flex flex-col md:flex-row">
      {/* =====================================================================
          3. ÁREA CENTRAL DE CONTENIDO (WORKSPACE)
         ===================================================================== */}
      <main className="flex-1 p-6 md:p-10 overflow-y-auto">
        {/* Barra Superior de Título y Acción Principal */}
        <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 pb-6 mb-8 border-b border-slate-800">
          <div>
            <h1 className="text-2xl md:text-3xl font-bold text-white">
              Catálogo Global de Autik
            </h1>
            <p className="text-slate-400 text-sm mt-1">
              Explora los servicios y resgistros en la tabla{" "}
              <code className="text-indigo-400 font-mono">Mantenimientos</code>.
            </p>
          </div>

          {/* Botón preparado para el Laboratorio de Integración POST */}
          <button className="bg-indigo-600 hover:bg-indigo-500 text-white font-medium text-sm px-4 py-2.5 rounded-lg transition-colors shadow-sm self-start sm:self-auto cursor-pointer">
            + Nuevo Mantenimiento
          </button>
        </div>
      </main>
    </div>
        )}
  )
}
