// inzoemen & uitzoemen met scrollen. Op het moment dat je klikt veranderd de texture
document.addEventListener("wheel", onDocumentMouseWheel, false);
document.addEventListener("click", onclick, true);

function onDocumentMouseWheel(event) {
  console.log(event);
  var fovMAX = 160;
  var fovMIN = 1;

  camera.fov -= event.deltaY;
  console.log(camera.fov);
  camera.fov = Math.max(Math.min(camera.fov, fovMAX), fovMIN);
  camera.updateProjectionMatrix();
}

var nmr = 1;

//onclick (muisknop ingeklikt) verander video
function onclick() {
  nmr += 1;
  if (nmr == 3) {
    nmr = 1;
  }
  if (nmr == 1) {
    changeToVid("./videos/test.mp4")
  } else if (nmr == 2) {
    ChangeVidWithTransition("./videos/test.mp4", "./videos/testmp4.mp4");
  }

}

// change video functie
function changeToVid(vid) {
  console.log("changetovid: ", vid);
  video.src = vid;
  video.load();
  video.play();
}

// change video met een transitie video functie
function ChangeVidWithTransition(transitionVid, lastVid) {
  console.log("ChangeVidWithTransition");
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
      }, video.duration * 1000);
    }
  }
}

// verander de positie van de video met een smooth animatie
function changeOffset(x, y) {
  var offset = { x : smiley1.offset.x, y: smiley1.offset.y };
  var target = { x : x, y: y };  
  var tween = new TWEEN.Tween(offset)
  .to({ x: target.x, y: target.y }, 500) 
  .easing(TWEEN.Easing.Quadratic.InOut) 
  .onUpdate(function() { 
      smiley1.offset.x = offset.x;
      smiley1.offset.y = offset.y;
  })
  .start();
}
