// using the Fetch API
var errors = 0;

function fetchData() {
    fetch('http://localhost:5000/', {
            mode: 'cors' // 'cors' by default
        })
        .then(function (response) {
            console.log(response.status); // returns 200
            if (errors > 0){
                to_neutraal();
                errors = 0;
            }
            return response.json();
        })
        .then(function (myJson) {
            console.log(myJson);
            if (myJson.posx && myJson.posy && myJson.my_width && myJson.my_height)
                look(myJson.posx, myJson.posy, myJson.my_width, myJson.my_height);
            if (myJson.emotion)
                changeMood(myJson.emotion);
        })
        .catch(function (error) {
            console.error(error);
            console.log('something went very very wrong');
            errors += 1;
            if (errors == 3) {
                to_error();
            }
        });
}


setInterval(() => {
        fetchData();
}, 1000);

function changeMood(mood) {
    console.log(mood);
}

function look(posx, posy, win_width, win_height) {
    console.log(posx, posy);
    var max_x = localStorage.getItem("max_offset_x");
    var max_y = localStorage.getItem("max_offset_y");
    var x_cordinate = posx;
    var y_cordinate = posy;

    var new_x_offset
    var new_y_offset

    var my_windowHeight = win_height;
    var my_windowWidth = win_width;

    // var my_windowHeight = screen.height;
    // var my_windowWidth = screen.width;

    if (x_cordinate > my_windowWidth / 2) {
        x_cordinate = x_cordinate - my_windowWidth / 2;
        var procent = 100 / (my_windowWidth / 2) * x_cordinate;
        new_x_offset = (max_x / 100 * procent) * -1;
    } else if (x_cordinate < my_windowWidth / 2) {
        var procent = 100 - (100 / (my_windowWidth / 2) * x_cordinate);
        new_x_offset = max_x / 100 * procent;
    } else {
        new_x_offset = 0;
    }

    if (y_cordinate > my_windowHeight / 2) {
        y_cordinate = y_cordinate - my_windowHeight / 2;
        var procent = 100 / (my_windowHeight / 2) * y_cordinate;
        new_y_offset = max_y / 100 * procent;
    } else if (y_cordinate < my_windowHeight / 2) {
        var procent = 100 - (100 / (my_windowHeight / 2) * y_cordinate);
        new_y_offset = (max_y / 100 * procent) * -1
    } else {
        new_y_offset = 0;
    }
    changeOffset(new_x_offset, new_y_offset);
}