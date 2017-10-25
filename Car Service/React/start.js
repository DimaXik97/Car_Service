var http = require('http');
var express = require('express');

const app = express();

 
app.use(express.static('./../App_Data/'));


app.get('*',(req, res) => {
  return res.send(f());
});

function f() {
  return `
    <!DOCTYPE html>
    <html>
    <head>
        <title>React</title>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width">
        <link rel="stylesheet" type="text/css" href="/css/style.css">
		<script src='https://www.google.com/recaptcha/api.js'></script>
    </head>
    <body >
        <div id="app">

        </div>
        <script src="/js/bundle.js"></script>
    </body>
    
  `;
}

const PORT = process.env.PORT || 8080;

app.listen(PORT, () => {
  console.log(`Server listening on: ${PORT}`);
});
