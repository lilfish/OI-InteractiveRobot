// var socket = io('http://192.168.1.101:1337');
// var socket = new io.Socket();


var scene = new THREE.Scene();

//camera settings
const fov = 41;
const aspect = window.innerWidth / window.innerHeight;
const near = 0.1;
const far = 1000;
const camera = new THREE.PerspectiveCamera(fov, aspect, near, far);
camera.position.z = 400;

var modifier;
var modifier, prevMod, mixer, mesh;
var noise, bend, cloth, twist, taper, bloat, breaks, userDefined;

//opzetten van een redner
var renderer = new THREE.WebGLRenderer();
renderer.setClearColor(0xff0000, 1);
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

//plane maken met een smiley texture
var video = document.getElementById('video');

var smiley1 = new THREE.VideoTexture(video);

//eerste smiley texture attributen vast zetten (deze worden ook door de andere textures gebruikt)
smiley1.minFilter = THREE.LinearFilter;
smiley1.magFilter = THREE.LinearFilter;
smiley1.format = THREE.RGBFormat;
smiley1.repeat.x = 5;
smiley1.repeat.y = 5;
smiley1.offset.x = 0.8;
smiley1.offset.y = 0.8;
smiley1.center.x = 0.5;
smiley1.center.y = 0.5;

// een plane aanmaken om de texture op te laten zien
plane = new THREE.Mesh(
  new THREE.PlaneGeometry(1920, 500, 20, 20, true),
  new THREE.MeshBasicMaterial({
    map: smiley1,
    side: THREE.DoubleSide
  })
);
plane.material.map.needsUpdate = true;
scene.add(plane);

// de "plane" benden zodat het gezicht een horizontale warp heeft wat we wouden om het warping van de sphere tegen te gaan.
modifier = new ModifierStack(plane);

var bend = new Bend(1, 0.5, 0);
modifier.addModifier(bend);

function addModifier(mesh) {
  modifier = new ModifierStack(mesh);
}

// start animatie functie
function animate() {
  requestAnimationFrame(animate);
  renderer.render(scene, camera);
  modifier && modifier.apply();
  TWEEN.update();
}
video.src = "./videos/testmp4.mp4";
video.play();
animate();

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
