import React from "react";
import { render } from "@testing-library/react";
import ServerList from "../../components/server-list";

describe("<ServerList />", () => {
  it("should render without crashing", () => {
    const { container } = render(<ServerList />);
  });
});