var CopyWebpackPlugin = require('copy-webpack-plugin');
var path = require('path');

module.exports = {
  entry: './js/index.js',
  output: {
    path: path.resolve(__dirname, './dist'),
    filename: 'js/gamebrowser.js'
  },
  module: {
    rules: [
      {
        test: /(\.js$|\.jsx$)/,
        loader: 'babel-loader',
        exclude: /node_modules/
      }
    ]
  },
  plugins: [
    new CopyWebpackPlugin([
      {
        from: './public'
      }
    ]),
    new CopyWebpackPlugin([
      {
        from: './img',
        to: 'img'
      }
    ]),
    new CopyWebpackPlugin([
      {
        from: './css',
        to: 'css'
      }
    ])
  ]
};