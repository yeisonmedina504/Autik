import { useState, useEffect } from "react";
import type { Mantenimiento } from "../types/mantenimiento.types";
import { obtenerMantenimientosAsync } from "../api/mantemientoApi";
import { MantenimientoCard } from "./MantenimientoCard";
import { CrearMantenimientoForm } from "./CrearMantenimientoForm";

export function MantenimientoView() {
  const [mantenimientos, setMantenimientos] = useState<Mantenimiento[]>([]);
  const [cargando, setCargando] = useState<boolean>(true);
  const [busqueda, setBusqueda] = useState<string>("");
  const [errorRed, setErrorRed] = useState<string | null>(null);
  const [mostrarFormulario, setMostrarFormulario] = useState<boolean>(false);

  useEffect(() => {
    // Disparamos la petición HTTP GET real hacia .NET al montar el componente
    obtenerMantenimientosAsync()
      .then((datosDesdePostgres) => {
        setMantenimientos(datosDesdePostgres);
        setErrorRed(null);
      })
      .catch((error) => {
        console.error("Fallo en la comunicación HTTP con .NET:", error);
        setErrorRed(
          "La comunicación fue rechazada o bloqueada por políticas de seguridad (CORS). Revisa la consola del navegador (F12) y verifica que el Backend autorice al origen http://localhost:5159.",
        );
      })
      .finally(() => {
        // Apaga el estado de carga tanto si hubo éxito como si ocurrió un error
        setCargando(false);
      });
  }, []);

  //
  const manejarMantenimientoCreado = (
    nuevoMantenimientoDesdeBD: Mantenimiento,
  ) => {
    setMantenimientos((prevMantenimientos) => [
      ...prevMantenimientos,
      nuevoMantenimientoDesdeBD,
    ]);
  };

  //
  const mantenimientosFiltrados = mantenimientos.filter((mantenimiento) =>
    mantenimiento.tipo.toLowerCase().includes(busqueda.toLowerCase()),
  );

  return (
    <div>
      {/* Barra Superior de Título y Acción Principal */}
      <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 pb-6 mb-6 border-b border-slate-800">
        <div>
          <h1 className="text-2xl md:text-3xl font-bold text-white">
            Catálogo Global de Mantenimientos
          </h1>
          <p className="text-slate-400 text-sm mt-1">
            Conectado en tiempo real vía HTTP/CORS con{" "}
            <code className="text-indigo-400 font-mono">PostgreSQL</code>.
          </p>
        </div>
        {!mostrarFormulario && (
          <button
            onClick={() => setMostrarFormulario(true)}
            className="bg-indigo-600 hover:bg-indigo-500 text-white font-medium text-sm px-4 py-2.5 rounded-lg transition-colors shadow-sm self-start sm:self-auto cursor-pointer"
          >
            + Nuevo Mantenimiento
          </button>
        )}
      </div>
      {/* Renderizado condicional del Formulario POST */}
      {mostrarFormulario && (
        <CrearMantenimientoForm
          onMantenimientoCreado={manejarMantenimientoCreado}
          onCancelar={() => setMostrarFormulario(false)}
        />
      )}

      {/* Buscador Reactivo */}
      <div className="mb-6 flex flex-col sm:flex-row sm:items-center justify-between gap-4">
        <input
          type="text"
          placeholder="🔍 Filtrar mantenimientos en el catálogo..."
          value={busqueda}
          onChange={(e) => setBusqueda(e.target.value)}
          className="w-full sm:max-w-md bg-slate-950 border border-slate-800 rounded-lg px-4 py-2.5 text-sm text-white placeholder-slate-500 focus:outline-none focus:border-indigo-500 transition-colors"
        />
        <span className="text-xs text-slate-400">
          Mostrando{" "}
          <strong className="text-white">
            {mantenimientosFiltrados.length}
          </strong>{" "}
          de {mantenimientos.length} registros en la BD
        </span>
      </div>
      {/* Renderizado Condicional y Rejilla */}
      {/*1. estado de carga*/}
      {cargando && (
        <div className="bg-slate-800/50 border border-slate-800 rounded-xl p-12 text-center">
          <p className="text-indigo-400 font-semibold animate-pulse text-lg">
            ⏳ Consultando enpoint GET /api/mantenimientos en el Backend .NET
            (PostgreSQL)...
          </p>
        </div>
      )}
      {/*2. estado de error de Red o bloqueo CORS*/}
      {!cargando && errorRed && (
        <div className="bg-red-950/40 border border-red-500/40 rounded-xl p-6 text-center">
          <p className="text-red-400 font-bold text-base mb-1">
            🚨Error de comunicacion Fullstack
          </p>
          <p className="text-slate-300 text-sm">{errorRed}</p>
        </div>
      )}
      {/*3. Estado de exito: renderizado de las filas reales de Postgres*/}
      {!cargando && !errorRed && (
        <section className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">
          {mantenimientosFiltrados.map((mantenimiento) => (
            <MantenimientoCard
              key={mantenimiento.id}
              id={mantenimiento.id}
              tipo={mantenimiento.tipo}
              marcaModelo={mantenimiento.marcaModelo}
              placa={mantenimiento.placa}
              anio={mantenimiento.anio}
            />
          ))}
        </section>
      )}
    </div>
  );
}
