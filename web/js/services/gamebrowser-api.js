export async function getServerDetails(ipAddress, port, game) {
  function getServiceUrl() {
    const gameUrls = {
      "quake3arena": "quake3arena"
    };
  
    return `${process.env.API_URL}api/${gameUrls[game]}/${ipAddress}/${port}`;
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