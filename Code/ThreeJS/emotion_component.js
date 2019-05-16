// emotie scripts
/* 
om te veranderen naar een video: changeToVid

om te veranderen naar een video met 
een andere video als transitie: ChangeVidWithTransition
*/

// Neutrale staat functie
to_neutraal('videos/test.mp4');

function to_neutraal(from){
    var to = 'videos/blinkingAni.mp4';
    ChangeVidWithTransition(from, to).then((message) => {
        // delay het knipperen
        console.log(message);
        stay_neutraal();
    }).catch((error) => {
        console.log(error);
    })
}

// functie om nutraal te blijven. Hij wacht hierbij ook tot de video af is gelopen zodat hij niet halverwege een knipper opeens stopt.
function stay_neutraal(){
    var random_timer = video.duration + Math.floor(Math.random() * 1500) + 1;
    
    video.play();
    if (video.currentTime != video.duration){
        var time_out = video.duration - video.currentTime;
        setTimeout(() => {
            video.pause();
            setTimeout(() => {
                stay_neutraal();
            }, random_timer);
        }, time_out * 1000);
    }
}

// blijheid functie
function happy(){

} 

// verdrietig functie
function sad(){

} 

// :O functie
function suprised(){

} 

// knipook functie
function wink(){

}