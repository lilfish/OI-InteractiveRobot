var connection = new WebSocket('ws://localhost:1337');

connection.onopen = function () {
    connection.send('give_data'); // Send the message 'Ping' to the server
};

// Log errors
connection.onerror = function (error) {
    console.log('WebSocket Error ');
    console.log(error);
};

// Log messages from the server
connection.onmessage = function (event) {
    console.log(event.data);
    var data = JSON.parse(event.data);
    if (data.posx == true && data.posy == true){
        look(data.posx,data.posy);
    }
}
// connection.onmessage = function (e) {
//     console.log("HxOI");
//     console.log(e);
//     var this_message = JSON.parse(e);
//     console.log(this_message);
//     // look(e);
//     // changeToVid(something);
//     // ChangeVidWithTransition(transitionVid, lastVid);
// };

function look(message){
    var max_x = localStorage.getItem("max_offset_x");
    var max_y = localStorage.getItem("max_offset_y");
    var cordinates = message.split(",");
    var x_cordinate = cordinates[0];
    var y_cordinate = cordinates[1];
    
    var new_x_offset
    var new_y_offset
    
    // var my_windowHeight = 1080;
    // var my_windowWidth = 1920;
    
    var my_windowHeight = screen.height;
    var my_windowWidth = screen.width;

    if(x_cordinate > my_windowWidth/2){
        x_cordinate = x_cordinate - my_windowWidth/2;
        var procent = 100/(my_windowWidth/2)*x_cordinate;
        new_x_offset = (max_x/100*procent)*-1;
    } else if(x_cordinate < my_windowWidth/2) {
        var procent = 100-(100/(my_windowWidth/2)*x_cordinate);
        new_x_offset = max_x/100*procent;
    } else {
        new_x_offset = 0;
    }

    if(y_cordinate > my_windowHeight/2){
        y_cordinate = y_cordinate - my_windowHeight/2;
        var procent = 100/(my_windowHeight/2)*y_cordinate;
        new_y_offset = max_y/100*procent;
    } else if(y_cordinate < my_windowHeight/2) {
        var procent = 100-(100 / (my_windowHeight/2) * y_cordinate);
        new_y_offset = (max_y/100*procent)*-1
    } else {
        new_y_offset = 0;
    }
    changeOffset(new_x_offset, new_y_offset);
}

