export async function getServerDetails(ipAddress, port, game) {
  function getServiceUrl() {
    const gameUrls = {
      "quake3arena": "quake3arena"
    };
  
    return `http://localhost:58806/api/${gameUrls[game]}/${ipAddress}/${port}`;
  }

  return await fetch(getServiceUrl(), {
    method: "GET",
    mode: "cors",
    headers: {
      "Content-Type": "application/json"
    }
  })
  .then(res => res.json());
}