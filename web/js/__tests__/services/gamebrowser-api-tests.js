import { getServerDetails } from '../../services/gamebrowser-api';

describe('GameBrowser API Service tests', () => {
  it('expect fetch to have been called with a specified payload', () => {
    const fetchSpy = jest.spyOn(global, 'fetch');
    let response = getServerDetails("127.0.0.1", 27960, "quake3arena");

    expect(fetchSpy).toBeCalledWith("http://localhost:58806/api/quake3arena", {
      method: 'POST',
      body: "{\"ipAddress\":\"127.0.0.1\",\"port\":27960}",
      headers: {
        "Content-Type": "application/json",
      },
      mode: "cors"
    });
  });
});