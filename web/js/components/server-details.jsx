import React from "react";

function ServerDetails({ serverDetails }) {
  const serverDetailsReceived = typeof serverDetails === "object" ? Object.keys(serverDetails).length > 0 : false;
  if (!serverDetailsReceived) {
    return null;
  }

  const allDetailKeys = Object.keys(serverDetails.allDetails);

  return (
    <div data-testid="server-details">
      <h2>Results for {serverDetails.ipAddress}</h2>
      <h3>{serverDetails.name}</h3>
      <p>Game Name: {serverDetails.gameName}</p>
      <img src={`/img/${serverDetails.mapName}.jpg`} />
      
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
    </div>
  );
}

export default ServerDetails;