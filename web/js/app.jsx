import React, { useState } from "react";
import ServerList from "./components/server-list.jsx";

function App() {
  return (
    <div data-testid="app">
      <ServerList />
    </div>
  );
}

export default App;