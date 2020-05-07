import React, { useState } from "react";
import { getServerDetails } from "../services/gamebrowser-api";
import ServerDetailsSummary from "./server-details-summary.jsx";

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
        <ServerDetailsSummary server={server} serverDetails={serverDetails} />

        <div className="server-details-verbose">
          <div className="server-details-section">
            <h3>{serverDetails.name}</h3>
            <p>Game Name: {serverDetails.gameName}</p>

            {
              serverDetails.mapName &&
                <img src={`/img/${serverDetails.mapName}.jpg`} />
            }

            <div>
              <button onClick={queryServer}>Refresh</button>
            </div>
          </div>

          <div className="server-details-section">
            <h4>Players ({serverDetails.players.length}/{serverDetails.maxClients})</h4>
            <table className="details-table">
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

          <div className="server-details-section">
            <h4>Server Info</h4>
            <table className="details-table">
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
          </div>
        </div>
      </div>
    );
  }

  if (!requestFailed) {
    return (
      <ServerDetailsSummary server={server} serverDetails={serverDetails} queryServer={queryServer} />
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