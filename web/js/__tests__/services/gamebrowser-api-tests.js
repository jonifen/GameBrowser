import { getServerDetails } from '../../services/gamebrowser-api';

describe('GameBrowser API Service tests', () => {
  it('expect fetch to have been called with a specified payload', () => {
    const fetchSpy = jest.spyOn(global, 'fetch');
    let response = getServerDetails("127.0.0.1", 27960, "quake3arena");
    const url = `${process.env.API_URL}api/quake3arena/127.0.0.1/27960`;

    expect(fetchSpy).toBeCalledWith(url, {
      method: 'GET',
      headers: {
        "Content-Type": "application/json",
      },
      mode: "cors"
    });
  });
});