import React from "react";

export default function ServerDetailsSummary({ server, serverDetails, queryServer }) {
  const players = serverDetails.players ? `${serverDetails.players.length}/${serverDetails.maxClients}` : "0/0";
  return (
    <div className="server-details-summary">
      <div className="ipAddress">{server.ipAddress}:{server.port}</div>
      <div className="players">{players}</div>
      <div className="gameName">{serverDetails.gameName || "Unknown"}</div>
      <div className="mapName">{serverDetails.mapName || "Unknown"}</div>
      <div>
        <button onClick={queryServer}>Refresh</button>
      </div>
    </div>
  );
}