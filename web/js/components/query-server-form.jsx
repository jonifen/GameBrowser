import React, { useState } from "react";
import { getServerDetails } from "../services/gamebrowser-api";

function QueryServerForm(props) {
  const [error, setError] = useState("");
  const [ipAddress, setIpAddress] = useState("");
  const [port, setPort] = useState("");
  const [game, setGame] = useState("quake3arena");

  const handleIpAddressChange = function(event) {
    setIpAddress(event.target.value);
  };

  const handlePortChange = function(event) {
    const port = event.target.value;
    const validPort = new RegExp(/^[0-9]*$/).test(port);

    if (validPort) {
      setPort(Number(port));
    }
  };

  const handleGameChange = function(event) {
    setGame(event.target.value);
  }

  const validateForm = function() {
    setError("");

    if (!game || game.length === 0)
      setError("Game not selected");

    if (!port || port.length === 0)
      setError("Port not specified");
    
    if (!ipAddress || ipAddress.length === 0)
      setError("IP address not specified");

    return error.length === 0;
  }

  const handleSubmitClick = async function() {
    if (validateForm())
      props.setServerDetails(await getServerDetails(ipAddress, port, game));
  };

  return (
    <div data-testid="query-server-form">
      <div>
        <label htmlFor="ipAddress">IP Address</label>
        <input type="text" name="ipAddress" value={ipAddress} onChange={handleIpAddressChange} />
      </div>
      <div>
        <label htmlFor="port">Port</label>
        <input type="text" name="port" value={port} onChange={handlePortChange} />
      </div>
      <div>
        <label htmlFor="game">Game</label>
        <select name="game" onChange={handleGameChange} value={game}>
          <option value="">Select a game</option>
          <option value="quake3arena">Quake III Arena</option>
        </select>
      </div>
      <div>
        <button onClick={handleSubmitClick}>Query</button>
        <p>{error}</p>
      </div>
    </div>
  );
}

export default QueryServerForm;