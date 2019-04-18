var connection = new WebSocket('ws://192.168.202.1:1337');

connection.onopen = function () {
    console.log("ON OPEN WORKED?");
    connection.send('Ping'); // Send the message 'Ping' to the server
};

// Log errors
connection.onerror = function (error) {
    console.log('WebSocket Error ' + error);
};

// Log messages from the server
connection.onmessage = function (e) {
    var max_x = smiley1.offset.x;
    var max_y = smiley1.offset.y;
    var cordinates = e.data.split(",");
    var x_cordinate = cordinates[0];
    var y_cordinate = cordinates[1];
    var new_x_offset
    var new_y_offset
    
    var my_windowHeight = 1080;
    var my_windowWidth = 1920;

    if(x_cordinate > my_windowWidth/2){
        x_cordinate = x_cordinate - my_windowWidth/2;
        var procent = 100/(my_windowWidth/2)*x_cordinate;
        new_x_offset = max_x/100*procent;
        new_x_offset = new_x_offset*-1
    } else if(x_cordinate < my_windowWidth/2) {
        var procent = 100/(my_windowWidth/2)*x_cordinate;
        new_x_offset = max_x/100*procent;
    } else {
        new_x_offset = 0;
    }

    if(y_cordinate > my_windowHeight/2){
        y_cordinate = y_cordinate - my_windowHeight/2;
        var procent = 100/(my_windowHeight/2)*y_cordinate;
        new_y_offset = max_y/100*procent;
        new_y_offset = new_y_offset*-1
    } else if(y_cordinate < my_windowHeight/2) {
        var procent = 100/(my_windowHeight/2)*y_cordinate;
        new_y_offset = max_y/100*procent;
    } else {
        new_y_offset = 0;
    }
    changeOffset(new_x_offset, new_y_offset);

};