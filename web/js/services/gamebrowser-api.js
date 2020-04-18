export async function getServerDetails(ipAddress, port, game) {
  const payload = {
    ipAddress,
    port
  };

  return await fetch(getServiceUrl(game), {
    method: "POST",
    mode: "cors",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(payload)
  })
  .then(res => res.json());
}

function getServiceUrl(game) {
  const gameUrls = {
    "quake3arena": "quake3arena"
  };

  return `http://localhost:58806/api/${gameUrls[game]}`;
}