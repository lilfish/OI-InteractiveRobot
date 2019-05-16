// change video functie
function changeToVid(vid) {
  console.log("changetovid: ", vid);
  video.src = vid;
  video.load();
  video.play();
}

function doesFileExist(urlToFile) {
  var xhr = new XMLHttpRequest();
  xhr.open('HEAD', urlToFile, false);
  xhr.send();

  if (xhr.status == "404") {
      return false;
  } else {
      return true;
  }
}

// change video met een transitie video functie
function ChangeVidWithTransition(transitionVid, lastVid) {
  return new Promise((resolve, reject) => {

    if (doesFileExist(transitionVid) == false){
      reject('tansition video does not exist');
    }
    if (doesFileExist(lastVid) == false){
      reject('last video does not exist');
    }
    video.src = transitionVid;
    video.load();
    video.play();
  
    var contains_video = transitionVid.split(/[\s/]+/);
    video.onloadeddata = function () {
      if (video.src.includes(contains_video[contains_video.length - 1])) {
        setTimeout(() => {
          video.src = lastVid;
          video.load();
          video.play();
          resolve('video transition done');
          console.log("LOL?");
        }, video.duration * 1000);
      }
    }
  })
  
  
}

// verander de positie van de video met een smooth animatie
function changeOffset(x, y) {
  var offset = { x : smiley.offset.x, y: smiley.offset.y };
  var target = { x : x, y: y };  
  var tween = new TWEEN.Tween(offset)
  .to({ x: target.x, y: target.y }, 500) 
  .easing(TWEEN.Easing.Quadratic.InOut) 
  .onUpdate(function() { 
      smiley.offset.x = offset.x;
      smiley.offset.y = offset.y;
  })
  .start();
}
