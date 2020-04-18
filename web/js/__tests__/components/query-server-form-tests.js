import React from "react";
import { render } from "@testing-library/react";
import QueryServerForm from "../../components/query-server-form";

describe("<QueryServerForm />", () => {
  it("should render component without error", () => {
    const { component } = render(<QueryServerForm />);
  });
});