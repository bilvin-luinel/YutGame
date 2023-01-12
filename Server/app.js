const wsServer = require("ws").Server;

const loginServer = new wsServer({ port: 8484 }, () => {
    console.log("login server is running port 8484");
});
const registServer = new wsServer({ port: 8585 }, () => {
    console.log("Resistration server is running port 8585");
});



loginServer.on('connection', (ws, request) => {
    const ip = request.headers['x-forwarded-for'] || request.connection.remoteAddress;
    console.log(`로그인 서버에 새로운 클라이언트 [${ip}] 접속`);

    ws.on('message', (msg) => {
        let userInfo = JSON.parse(msg);
        console.log(userInfo);
        console.log(userInfo.userID);

        if (userInfo.userID == "admin") {
            if (userInfo.userPW == "admin") {
                ws.send("OK");
            } else {
                ws.send("NO");
            }
        } else {
            ws.send("NO");
        }
    })


});

registServer.on('connection', (ws, request) => {
    const ip = request.headers['x-forwarded-for'] || request.connection.remoteAddress;
    console.log(`회원가입 서버에 새로운 클라이언트 [${ip}] 접속`);

    ws.on('message', (msg) => {
        let userInfo = JSON.parse(msg);
        console.log(userInfo);
        console.log(userInfo.userID);

    })
})