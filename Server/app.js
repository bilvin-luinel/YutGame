const wsServer = require("ws").Server;
const wss = new wsServer({ port: 3000 });



wss.on('connection', (ws, request) => {
    console.log("client connected");
    ws.on('message', (msg) => {
        console.log("client: %s", msg);
    })

    // client.send("hello!");

    const ip = request.headers['x-forwarded-for'] || request.connection.remoteAddress;

    console.log(`새로운 클라이언트 [${ip}] 접속`);
});