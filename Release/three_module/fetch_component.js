// using the Fetch API
var errors = 0;

function fetchData() {
    fetch('http://localhost:5000/', {
            mode: 'cors' // 'cors' by default
        })
        .then(function (response) {
            console.log(response.status); // returns 200
            if (errors > 0) {
                to_neutraal();
                errors = 0;
            }
            return response.json();
        })
        .then(function (myJson) {
            console.log(myJson.id);
            if (myJson.posx && myJson.posy && myJson.my_width && myJson.my_height)
                look(myJson.posx, myJson.posy, myJson.my_width, myJson.my_height);
            if (myJson.emotion, myJson.id)
                changeMood(myJson.emotion, myJson.id);
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

/*
Emotions:
    to_neutraal
    to_happy
    to_sad
    to_ultraSad
    to_angry
    to_surprised
Moods:
    neutral
    happy
    sad
    surprise
    anger
*/
// variable om een id te onthouden en te kijken hoevaak iemand is gedetecteerd
var old_id = "empty";
var times_detected = 0;

function changeMood(mood, person) {
    console.log(times_detected);
    // om een random animatie te kiezen op een emotie
    var random3 = Math.floor(Math.random() * 3);
    var random2 = Math.floor(Math.random() * 2);

    // kijken hoevaak iemand als is gedetecteerd (1x = 1 seconde)
    if (person == '-1') {
        old_id = "empty";
        if(times_detected > 0){
            times_detected = 0;
            to_neutraal();
        }
    } else if (old_id == person) {
        times_detected += 1;
    } else {
        old_id = person;
        times_detected = 1;
    }
    console.log(old_id, person);

    if(person != '-1'){
    // mood neutraal
        if (mood == "neutral" && times_detected < 5) {
            switch (random3) {
                case 1:
                    //neutraal blijven
                    to_neutraal();
                    break;
                case 2:
                    //suprised kijken
                    to_surprised();
                    break;
                default:
                    //blij kijken
                    to_happy();
            }
        }

        // mood blij
        if (mood == "happy" && times_detected < 5) {
            if (random2 == 0) {
                to_surprised();
            } else if (random2 == 1) {
                to_happy();
            }
        }

        // mood boos
        if (mood == "anger" && times_detected < 5) {
            switch (random3) {
                case 1:
                    //neutraal blijven
                    to_sad();
                    break;
                case 2:
                    //suprised kijken
                    to_surprised();
                    break;
                default:
                    //blij kijken
                    to_happy();
            }
        }

        // mood surprise
        if (mood == "surprise" && times_detected < 5) {
            if (random2 == 0) {
                to_surprised();
            } else if (random2 == 1) {
                to_happy();
            }
        }

        // mood sad
        if (mood == "sad" && times_detected < 5){
            to_ultraSad();
        }

        // robot word ongemakkelijk
        if (times_detected > 15) {
            to_ultraSad();
        } else if (times_detected > 5) {
            to_neutraal();
        }
    }
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