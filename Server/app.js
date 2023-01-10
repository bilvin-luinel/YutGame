const wsServer = require("ws").Server;

const loginServer = new wsServer({ port: 8484 }, () => {
    console.log("login server is running port 8484");
});


let data = {
    type: "message",
    id: "admin",
    pw: "adminpw"
}

loginServer.on('connection', (ws, request) => {
    const ip = request.headers['x-forwarded-for'] || request.connection.remoteAddress;
    console.log(`새로운 클라이언트 [${ip}] 접속`);

    ws.on('message', (msg) => {
        console.log("client: %s", msg);
    })

    ws.send(JSON.stringify(data));


});