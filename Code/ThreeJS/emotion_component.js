// emotie scripts
/* 
om te veranderen naar een video: changeToVid

om te veranderen naar een video met 
een andere video als transitie: ChangeVidWithTransition
*/

function to_neutraal(){
    var to = 'videos/blinkingAni.mp4';
    getTransitionVid('neutraal').then((message) => {
        var trans_vid = message;
        ChangeVidWithTransition(trans_vid, to).then((message) => {
            stay_state();
        }).catch((error) => {
            console.log(error);
        })
    }).catch((error) =>{
        console.log(error);
    })
    
}

function to_happy(){
    var to = 'videos/smileBlinking.mp4';
    getTransitionVid('happy').then((message) => {
        var trans_vid = message;
        ChangeVidWithTransition(trans_vid, to).then((message) => {
            stay_state();
        }).catch((error) => {
            console.log(error);
        })
    }).catch((error) =>{
        console.log(error);
    })
    
}

// functie om nutraal te blijven. Hij wacht hierbij ook tot de video af is gelopen zodat hij niet halverwege een knipper opeens stopt.
function stay_state(){
    var random_timer = video.duration + Math.floor(Math.random() * 1500) + 1; 
    video.play();
    if (video.currentTime != video.duration){
        var time_out = video.duration - video.currentTime;
        setTimeout(() => {
            video.pause();
            setTimeout(() => {
                stay_state();
            }, random_timer);
        }, time_out * 1000);
    }
}

function getTransitionVid(to_video){
    return new Promise((resolve, reject) => {
        var current_video_name = video.src.split(/[\s/]+/);
        current_video_name = current_video_name[current_video_name.length - 1];
        
        var delay = 0;
        // als er een transitie video word afgespeeld, wacht een halve seconde.
        if(current_video_name.includes("To")){
            delay = video.duration;
        }

        setTimeout(() => {
            var current_video_name = video.src.split(/[\s/]+/);
            current_video_name = current_video_name[current_video_name.length - 1];
            // check of video al word afgespeeld
            if(current_video_name == 'smileBlinking.mp4' && to_video == 'happy'){
                reject("already have this playing");
            } else if(current_video_name == 'blinkingAni.mp4' && to_video == 'neutraal'){
                reject("already have this playing");
            }

            // verander video als alles goed gaat
            if (current_video_name == 'smileBlinking.mp4' && to_video == 'neutraal'){
                resolve('videos/smileToNeutral.mp4');
            } else if (current_video_name == 'blinkingAni.mp4' && to_video == 'happy'){
                resolve('videos/neutralToSmile.mp4');
            } else {
                reject("not done playing animation");
            }
        }, delay * 1000);
        
    })
}