const wsServer = require("ws").Server;

const loginServer = new wsServer({ port: 8484 }, () => {
    console.log("login server is running port 8484");
});
// const registServer = new wsServer({port: 8585}, () => {
//     console.log("Resistration server is running port 8585");
// });



loginServer.on('connection', (ws, request) => {
    const ip = request.headers['x-forwarded-for'] || request.connection.remoteAddress;
    console.log(`새로운 클라이언트 [${ip}] 접속`);

    ws.on('message', (msg) => {
        console.log("client :", msg);
        console.log(msg.userID);
    })

    // ws.send(JSON.stringify(data));


});

// registServer.on('connection', (ws, request) => {
//     ws.on('message', (msg) => {
//         ws.send(Buffer.from(msg, "base64").toString("utf-8"));
//         console.log("client :", msg);
//     })
// })