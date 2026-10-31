import MantenimientoCard, {
  type MantenimientoProps,
} from "./features/mantenimientos/components/MantenimientoCard";
import { useState, useEffect } from "react";
import { AppLayout } from "./layouts/AppLayout";
// src/App.tsx

function App() {
  return (
    <AppLayout>
      <MantenimientoView />
    </AppLayout>
  );
}

export default App;
