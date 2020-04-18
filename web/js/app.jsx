import React, { useState } from "react";
import QueryServerForm from "./components/query-server-form.jsx";
import ServerDetails from "./components/server-details.jsx";

function App() {
  const [serverDetails, setServerDetails] = useState({});

  return (
    <div data-testid="app">
      <QueryServerForm setServerDetails={setServerDetails} />
      <ServerDetails serverDetails={serverDetails} />
    </div>
  );
}

export default App;