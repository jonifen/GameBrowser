export function getServerList() {
  if (!checkStorageSupport())
    return [];
  
  const storedData = localStorage.getItem("serverList");

  if (storedData)
    return JSON.parse(storedData);

  return [];
}

export function saveServerList(serverList) {
  if (!checkStorageSupport())
    return;

  const dataToStore = JSON.stringify(serverList);
  localStorage.setItem("serverList", dataToStore);
}

export function clearServerList() {
  if (!checkStorageSupport())
    return;

  localStorage.removeItem("serverList");
}

function checkStorageSupport() {
  return typeof(Storage) !== "undefined";
}