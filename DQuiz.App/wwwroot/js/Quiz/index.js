var hubConn = new signalR.HubConnectionBuilder()
    .withUrl("/poolhub")
    .build();
hubConn.on('startcontest',
    function () {
        window.location.href = '/yarisma';
    });
hubConn.start();