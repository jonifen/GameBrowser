import React from "react";
import { render } from "@testing-library/react";
import ServerDetails from "../../components/server-details";

describe("<ServerDetails />", () => {
  it("should render component without error", () => {
    const { component } = render(<ServerDetails />);
  });
});