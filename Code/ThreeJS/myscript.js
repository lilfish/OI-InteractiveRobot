// var socket = io('http://192.168.1.101:1337');
// var socket = new io.Socket();


var scene = new THREE.Scene();

//camera settings
const fov = 50;
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

var textureLoader = new THREE.TextureLoader();
// var smiley2 = textureLoader.VideoTexture( "face2.png" );
// var smiley3 = textureLoader.VideoTexture( "face3.png" );
// var smiley4 = textureLoader.VideoTexture( "face4.png" );
// var smiley5 = textureLoader.VideoTexture( "giftest.gif" );



//eerste smiley texture attributen vast zetten (deze worden ook door de andere textures gebruikt)
smiley1.minFilter = THREE.LinearFilter;
smiley1.magFilter = THREE.LinearFilter;
smiley1.format = THREE.RGBFormat;
// smiley1.repeat.x = 2;
// smiley1.repeat.y = 2;
// smiley1.offset.x = 0.4;
// smiley1.offset.y = 0;
// smiley1.center.x = 0.5;
// smiley1.center.y = 0.5;



// een plane aanmaken om de texture op te laten zien
plane = new THREE.Mesh(
  new THREE.PlaneGeometry(1920, 1080, 20, 20, true),
  new THREE.MeshBasicMaterial({
    map: smiley1,
    side: THREE.DoubleSide
  })
);
plane.material.map.needsUpdate = true;
scene.add(plane);

// video.load();
// video.play();

// de "plane" benden zodat het gezicht een horizontale warp heeft wat we wouden om het warping van de sphere tegen te gaan.
modifier = new ModifierStack(plane);

var bend = new Bend(0.7, 0.5, 0);
modifier.addModifier(bend);

function addModifier(mesh) {
  modifier = new ModifierStack(mesh);

  bend = new Bend(1.5, 0.2, 0);
  bend.constraint = ModConstant.LEFT;
}

// start animatie functie
function animate() {
  requestAnimationFrame(animate);
  renderer.render(scene, camera);
  modifier && modifier.apply();
  
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
// function onclick() {
//     nmr = nmr + 1
//     if (nmr == 6){
//         nmr = 1;
//     }
//     eval("smiley" + nmr).repeat.x = plane.material.map.repeat.x
//     eval("smiley" + nmr).repeat.y = plane.material.map.repeat.y
//     eval("smiley" + nmr).offset.x = plane.material.map.offset.x
//     eval("smiley" + nmr).offset.y = plane.material.map.offset.y
//     eval("smiley" + nmr).center.x = plane.material.map.center.x
//     eval("smiley" + nmr).center.y = plane.material.map.center.y
    
//     // console.log(plane.material.map.repeat.x);
//     // console.log(texture.repeat.x);
//     plane.material.map.dispose();
    
    
//     plane.material.map = eval("smiley" + nmr);
//     plane.material.map.needsUpdate = true;
    
    
// }
