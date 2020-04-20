import { saveServerList, getServerList, clearServerList } from "../../repositories/server-list-repository";

describe("Server List Repository tests", () => {
  it("saveServerList() should call localStorage.setItem with a payload", () => {
    const testServerList = [
      { "ipAddress": "127.0.0.1", "port": 27960, "game": "quake3arena" }
    ];
    const testServerListString = JSON.stringify(testServerList);

    const setItemMock = jest.spyOn(window.localStorage.__proto__, "setItem")
      .mockImplementation((serverList) => {});

    saveServerList(testServerList);

    expect(setItemMock).toBeCalledWith("serverList", testServerListString);
  });

  it("getServerList() should call localStorage.getItem and receive payload", () => {
    const expected = [
      { "ipAddress": "127.0.0.1", "port": 27960, "game": "quake3arena" }
    ];
    const expectedString = JSON.stringify(expected);

    const getItemMock = jest.spyOn(window.localStorage.__proto__, "getItem")
      .mockImplementation(() => { return expectedString });

    const actual = getServerList();

    expect(getItemMock).toBeCalled();
    expect(actual).toStrictEqual(expected)
  });

  it("clearServerList() should call localStorage.removeItem", () => {
    const removeItemMock = jest.spyOn(window.localStorage.__proto__, "removeItem")
      .mockImplementation(() => {});

    clearServerList();

    expect(removeItemMock).toBeCalled();
  });
});