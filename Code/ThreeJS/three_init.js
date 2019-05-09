var scene = new THREE.Scene();

//camera settings
const fov = 32;
const aspect = window.innerWidth / window.innerHeight;
const near = 0.1;
const far = 1000;
const camera = new THREE.PerspectiveCamera(fov, aspect, near, far);
camera.position.z = 50;
camera.position.y = 5.5;

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
smiley1.repeat.x = 50;
smiley1.repeat.y = 50;
smiley1.offset.x = 0.0;
smiley1.offset.y = -0.5;
smiley1.center.x = 0.5;
smiley1.center.y = 0.5;

// een plane aanmaken om de texture op te laten zien
sphere = new THREE.Mesh(
  new THREE.SphereGeometry( 30, 32, 32, (Math.PI /2 * -1) ),  
  new THREE.MeshBasicMaterial({
    map: smiley1,
    side: THREE.DoubleSide
  })
);
sphere.material.map.needsUpdate = true;
scene.add(sphere);

// start animatie functie
function animate() {
  requestAnimationFrame(animate);
  renderer.render(scene, camera);
  TWEEN.update();
}
video.src = "./videos/neutraal.mp4";
video.play();
animate();