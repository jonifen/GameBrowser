import React, { useState } from "react";
import { getServerList, saveServerList } from "../repositories/server-list-repository";
import ServerDetails from "./server-details.jsx";

function ServerList() {
  const [ serverList, setServerList ] = useState(getServerList());
  const [ editingServerList, setEditingServerList ] = useState(JSON.stringify(serverList));
  const [ rawDataVisible, setRawDataVisible ] = useState(false);

  const rawDataStyles = rawDataVisible ? {} : { display: "none" };

  const handleViewStoredDataClick = function() {
    setRawDataVisible(true);
  };

  const handleServerListDataChange = function(event) {
    setEditingServerList(event.target.value);
  }

  const handleSaveServerListClick = function() {
    const data = JSON.parse(editingServerList);

    if (data) {
      saveServerList(data);
      setServerList(data);
      setRawDataVisible(false);
    }
  }

  return (
    <div data-testid="server-list">
      <strong>Server List</strong><br />
      {
        serverList.map((server, index) => {
          return (
            <div key={`${server.ipAddress}-${index}`}>
              <ServerDetails {...server} />
            </div>
          )
        })
      }
      <hr />
      <div>
        <button onClick={handleViewStoredDataClick}>View Stored Data</button>
      </div>
      <div style={rawDataStyles}>
        <textarea value={editingServerList} onChange={handleServerListDataChange} />
        <button onClick={handleSaveServerListClick}>Save Server List Data</button>
      </div>
    </div>
  );
}

export default ServerList;