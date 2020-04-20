import React, { useState } from "react";
import { getServerDetails } from "../services/gamebrowser-api";

function ServerDetails(server) {
  const [ serverDetails, setServerDetails ] = useState({});
  const [ requestFailed, setRequestFailed ] = useState(false);

  const serverReceived = typeof server === "object" ? Object.keys(server).length > 0 : false;
  if (!serverReceived) {
    return (
      <div>
        No server details specified
      </div>
    );
  }

  const queryServer = function() {
    getServerDetails(server.ipAddress, server.port, server.game)
      .then(data => {
        setServerDetails(data);
      })
      .catch(err => {
        setServerDetails({});
        setRequestFailed(true);
      });
  }

  const serverDetailsExist = typeof serverDetails === "object" ? Object.keys(serverDetails).length > 0 : false;
  if (serverDetailsExist) {
    const allDetailKeys = Object.keys(serverDetails.allDetails);

    return (
      <div data-testid="server-details">
        <h2>Results for {serverDetails.ipAddress}</h2>
        <h3>{serverDetails.name}</h3>
        <p>Game Name: {serverDetails.gameName}</p>

        {
          serverDetails.mapName &&
            <img src={`/img/${serverDetails.mapName}.jpg`} />
        }
        
        <div>
          <strong>Players ({serverDetails.players.length}/{serverDetails.maxClients})</strong>
          <table>
            <thead>
              <tr>
                <td>Name</td>
                <td>Score</td>
                <td>Ping</td>
              </tr>
            </thead>
            <tbody>
              {
                serverDetails.players.map((player, index) => {
                  return (
                    <tr key={`${player.name}${index}`}>
                      <td>{player.name}</td>
                      <td>{player.score}</td>
                      <td>{player.ping}</td>
                    </tr>
                  );
                })
              }
            </tbody>
          </table>
        </div>

        <h4>Server Info</h4>
        <table>
          <thead>
            <tr>
              <td>Key</td>
              <td>Value</td>
            </tr>
          </thead>
          <tbody>
            {
              allDetailKeys.map((detailKey, index) => {
                return (
                  <tr key={`${detailKey}${index}`}>
                    <td>{detailKey}</td>
                    <td>{serverDetails.allDetails[detailKey]}</td>
                  </tr>
                );
              })
            }
          </tbody>
        </table>
        <button onClick={queryServer}>Refresh</button>
      </div>
    );
  }

  if (!requestFailed) {
    return (
      <div>
        {server.ipAddress}:{server.port}
        <button onClick={queryServer}>Query</button>
      </div>
    );
  }

  return (
    <div>
      <p>Server request failed</p>
      <button onClick={queryServer}>Refresh</button>
    </div>
  );
}

export default ServerDetails;