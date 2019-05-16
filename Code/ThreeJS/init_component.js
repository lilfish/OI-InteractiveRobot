var scene = new THREE.Scene();

//camera settings
const fov = Number(localStorage.getItem("fov"));
const aspect = window.innerWidth / window.innerHeight;
const near = 0.1;
const far = 1000;
const camera = new THREE.PerspectiveCamera(fov, aspect, near, far);
camera.position.z = Number(localStorage.getItem("camera_position_z"));
camera.position.y = Number(localStorage.getItem("camera_position_y"));

//opzetten van een redner
var renderer = new THREE.WebGLRenderer();
renderer.setClearColor(0xff0000, 1);
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

//plane maken met een smiley texture
var video = document.getElementById('video');

var smiley = new THREE.VideoTexture(video);

//eerste smiley texture attributen vast zetten (deze worden ook door de andere textures gebruikt)
smiley.repeat.x = Number(localStorage.getItem("repeat_x"));
smiley.repeat.y = Number(localStorage.getItem("repeat_y"));
smiley.offset.x = Number(localStorage.getItem("offset_x"));
smiley.offset.y = Number(localStorage.getItem("offset_y"));
smiley.center.x = Number(localStorage.getItem("center_x"));
smiley.center.y = Number(localStorage.getItem("center_y"));

// een plane aanmaken om de texture op te laten zien
sphere = new THREE.Mesh(
  new THREE.SphereGeometry( 30, 32, 32, (Math.PI /2 * -1) ),  
  new THREE.MeshBasicMaterial({
    map: smiley,
    side: THREE.DoubleSide
  })
);
sphere.material.map.needsUpdate = true;

scene.add(sphere);

sphere.scale.x = JSON.parse(localStorage.getItem("sphere_size")).x
sphere.scale.y = JSON.parse(localStorage.getItem("sphere_size")).y
sphere.scale.z = JSON.parse(localStorage.getItem("sphere_size")).z

// start animatie functie
function animate() {
  requestAnimationFrame(animate);
  renderer.render(scene, camera);
  TWEEN.update();
}
video.src = "./videos/blinkingAni.mp4";
video.play();
animate();