// src/App.tsx
import { AppLayout } from "./layouts/AppLayout";
import { MantenimientoView } from "./features/mantenimientos/components/MantenimientoView";

function App() {
  return (
    <AppLayout>
      <MantenimientoView />
    </AppLayout>
  );
}

export default App;
