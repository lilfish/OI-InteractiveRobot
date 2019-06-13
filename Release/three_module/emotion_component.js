// emotie scripts
/*
om te veranderen naar een video: changeToVid

om te veranderen naar een video met
een andere video als transitie: ChangeVidWithTransition
*/

to_neutraal();

function to_neutraal() {
    var to = 'videos/blinkingAni.mp4';
    getTransitionVid('neutraal').then((message) => {
        var trans_vid = message;
        ChangeVidWithTransition(trans_vid, to).then((message) => {
            stay_state();
        }).catch((error) => {
            console.log(error);
        })
    }).catch((error) => {
        console.log(error);
    })

}

function to_happy() {
    var to = 'videos/happy/smileBlinking.mp4';
    getTransitionVid('happy').then((message) => {
        var trans_vid = message;
        ChangeVidWithTransition(trans_vid, to).then((message) => {
            stay_state();
        }).catch((error) => {
            console.log(error);
        })
    }).catch((error) => {
        console.log(error);
    })

}

function to_sad() {
    var to = 'videos/sad/sadBlink.mp4';
    getTransitionVid('sad').then((message) => {
        var trans_vid = message;
        ChangeVidWithTransition(trans_vid, to).then((message) => {
            stay_state();
        }).catch((error) => {
            console.log(error);
        })
    }).catch((error) => {
        console.log(error);
    })

}

function to_ultraSad() {
    var to = 'videos/ultrasad/ultraSad.mp4';
    getTransitionVid('ultaSad').then((message) => {
        var trans_vid = message;
        ChangeVidWithTransition(trans_vid, to).then((message) => {
            stay_state();
        }).catch((error) => {
            console.log(error);
        })
    }).catch((error) => {
        console.log(error);
    })

}

function to_angry() {
    var to = 'videos/angry/angry.mp4';
    getTransitionVid('angry').then((message) => {
        var trans_vid = message;
        ChangeVidWithTransition(trans_vid, to).then((message) => {
            stay_state();
        }).catch((error) => {
            console.log(error);
        })
    }).catch((error) => {
        console.log(error);
    })

}

function to_surprised() {
    var to = 'videos/surprised/surprisedBlink.mp4';
    getTransitionVid('surprised').then((message) => {
        var trans_vid = message;
        ChangeVidWithTransition(trans_vid, to).then((message) => {
            stay_state();
        }).catch((error) => {
            console.log(error);
        })
    }).catch((error) => {
        console.log(error);
    })

}

function to_error() {
    var to = 'videos/ErrorFace.mp4';
    changeToVid(to).then((message) => {
        console.log(video.duration);
        setTimeout(() => {
            video.pause();
        }, (video.duration * 1000)-20);

    }).catch((error) => {
        console.log(error);
    })

}

var video_stopped = 0;
// functie om nutraal te blijven. Hij wacht hierbij ook tot de video af is gelopen zodat hij niet halverwege een knipper opeens stopt.
function stay_state() {

    var random_timer = (Math.floor(Math.random() * 1500) + 1) + (video.duration * 1000);
    video.play();

    if (video.currentTime >= 0 && !video.paused && !video.ended && video.readyState > 2) {
        video_stopped = 0;
    } else {
        video_stopped += 1;
        if (video_stopped > 13) {
            console.log("attempt to restart vid");
            video.pause();
            video.currentTime = 0;
            video.play();
        }
    }

    var time_out = (video.duration * 1000) - (video.currentTime * 1000);
    setTimeout(() => {
        video.pause();
        video.currentTime = 0;
        setTimeout(() => {
            stay_state();
        }, random_timer);
    }, time_out);

}

function getTransitionVid(to_video) {
    return new Promise((resolve, reject) => {
        var current_video_name = video.src.split(/[\s/]+/);
        current_video_name = current_video_name[current_video_name.length - 1];
        var delay = 0;
        // als er een transitie video word afgespeeld, wacht een halve seconde.
        if (current_video_name.includes("To")) {
            delay = video.duration;
        }
        setTimeout(() => {
            var current_video_name = video.src.split(/[\s/]+/);
            current_video_name = current_video_name[current_video_name.length - 1];
            // check of video al word afgespeeld
            if (current_video_name == 'smileBlinking.mp4' && to_video == 'happy') {
                reject("already have this playing");
            } else if (current_video_name == 'blinkingAni.mp4' && to_video == 'neutraal') {
                reject("already have this playing"); //hieronder nieuw
            } else if (current_video_name == 'sadBlink.mp4' && to_video == 'sad') {
                reject("already have this playing");
            } else if (current_video_name == 'ultraSad.mp4' && to_video == 'ultaSad') {
                reject("already have this playing");
            } else if (current_video_name == 'angry.mp4' && to_video == 'angry') {
                reject("already have this playing");
            } else if (current_video_name == 'surprisedBlink.mp4' && to_video == 'surprised') {
                reject("already have this playing");
            }

            // verander video als alles goed gaat
            if (current_video_name == 'smileBlinking.mp4' && to_video == 'neutraal') {
                resolve('videos/happy/smileToNeutral.mp4');
            } else if (current_video_name == 'blinkingAni.mp4' && to_video == 'happy') {
                resolve('videos/happy/neutralToSmile.mp4');
            } else if (current_video_name == 'blinkingAni.mp4' && to_video == 'surprised') {
                resolve('videos/surprised/neutralToSurprised.mp4');
            } else if (current_video_name == 'blinkingAni.mp4' && to_video == 'sad') {
                resolve('videos/sad/neutralToSad.mp4');
            } else if (current_video_name == 'blinkingAni.mp4' && to_video == 'ultaSad') {
                resolve('videos/ultrasad/neutralToUltraSad.mp4');
            } else if (current_video_name == 'blinkingAni.mp4' && to_video == 'angry') {
                resolve('videos/angry/neutralToAngry.mp4');
            } else if (current_video_name == 'blinkingAni.mp4' && to_video == 'surprised') {
                resolve('videos/surprised/neutralToSurprised.mp4');
            } else if (current_video_name == 'sadBlink.mp4' && to_video == 'neutraal') {
                resolve('videos/sad/sadToNeutral.mp4');
            } else if (current_video_name == 'ultraSad.mp4' && to_video == 'neutraal') {
                resolve('videos/ultrasad/ultraSadToNeutral.mp4');
            } else if (current_video_name == 'surprisedBlink.mp4' && to_video == 'neutraal') {
                resolve('videos/surprised/surprisedToNeutral.mp4');
            } else if (current_video_name == 'angry.mp4' && to_video == 'neutraal') {
                resolve('videos/angry/angryToNeutral.mp4');
            } else if (current_video_name == 'ErrorFace.mp4') {
                resolve('videos/surprised/surprisedToNeutral.mp4');
            } else {
                reject("not done playing animation");
            }
        }, delay * 1000);

    })
}