var CopyWebpackPlugin = require("copy-webpack-plugin");
var MiniCssExtractPlugin = require("mini-css-extract-plugin");
var path = require("path");
var Dotenv = require("dotenv-webpack");

module.exports = {
  entry: "./js/index.js",
  output: {
    path: path.resolve(__dirname, "./dist"),
    filename: "js/gamebrowser.js"
  },
  module: {
    rules: [
      {
        test: /(\.js$|\.jsx$)/,
        loader: "babel-loader",
        exclude: /node_modules/,
      },
      {
        test: /\.s[ac]ss$/i,
        use: [
          MiniCssExtractPlugin.loader,
          //'style-loader',
          'css-loader',
          'sass-loader',
        ],
      }
    ],
  },
  plugins: [
    new Dotenv({
      path: getDotEnvFilePath(process.env.NODE_ENV)
    }),
    new CopyWebpackPlugin([
      {
        from: "./public",
      },
    ]),
    new CopyWebpackPlugin([
      {
        from: "./img",
        to: "img",
      },
    ]),
    new CopyWebpackPlugin([
      {
        from: "./css",
        to: "css",
      },
    ]),
    new MiniCssExtractPlugin({
      // Options similar to the same options in webpackOptions.output
      // both options are optional
      filename: 'css/[name].css',
      chunkFilename: 'css/[id].css',
    }),
  ],
};

function getDotEnvFilePath(stage) {
  switch (stage) {
    case "production":
      return "./.env.production";

    default:
      return "./.env.development";
  }
}