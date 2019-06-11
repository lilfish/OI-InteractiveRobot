// emotie scripts
/* 
om te veranderen naar een video: changeToVid

om te veranderen naar een video met 
een andere video als transitie: ChangeVidWithTransition
*/

to_neutraal();

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
    var to = 'videos/happy/smileBlinking.mp4';
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

var video_stopped = 0;
// functie om nutraal te blijven. Hij wacht hierbij ook tot de video af is gelopen zodat hij niet halverwege een knipper opeens stopt.
function stay_state(){
    
    var random_timer = (Math.floor(Math.random() * 1500) + 1)+(video.duration*1000); 
    video.play();

    if(video.currentTime >= 0 && !video.paused && !video.ended && video.readyState > 2){
        video_stopped = 0;
    } else {
        video_stopped += 1;
        if(video_stopped > 13){
            console.log("attempt to restart vid");
            video.pause();
            video.currentTime = 0;
            video.play();
        }
    }
    
    var time_out = (video.duration*1000) - (video.currentTime*1000);
    setTimeout(() => {
        video.pause();
        video.currentTime = 0;
        setTimeout(() => {
            stay_state();
        }, random_timer);
    }, time_out);

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
            } else if(current_video_name == 'blinkingAni.mp4' && to_video == 'neutraal'){
                reject("already have this playing");
            }

            // verander video als alles goed gaat
            if (current_video_name == 'smileBlinking.mp4' && to_video == 'neutraal'){
                resolve('videos/happy/smileToNeutral.mp4');
            } else if (current_video_name == 'blinkingAni.mp4' && to_video == 'happy'){
                resolve('videos/happy/neutralToSmile.mp4');
            } else {
                reject("not done playing animation");
            }
        }, delay * 1000);
        
    })
}