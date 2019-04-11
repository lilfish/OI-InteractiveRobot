var socket = io.connect('http://192.168.1.101:1337')

socket.on('connect', function(){
    console.log("Connected");
});
socket.on('event', function(data){
    console.log(data);
});
socket.on('disconnect', function(){});