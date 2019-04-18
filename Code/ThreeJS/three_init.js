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