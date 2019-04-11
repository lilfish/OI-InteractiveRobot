var scene = new THREE.Scene();

//camera settings
const fov = 50;
const aspect = window.innerWidth / window.innerHeight
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
var texture = new THREE.TextureLoader().load('./test.png');
texture.repeat.x = 2;
texture.repeat.y = 2;
texture.offset.x = 0.5;
texture.offset.y = 0;
texture.center.x = 0.5;
texture.center.y = 0.5;
plane = new THREE.Mesh(
    new THREE.PlaneGeometry(1920, 1080, 20, 20, true),
    new THREE.MeshBasicMaterial({
        map: texture,
        side: THREE.DoubleSide
    })
);
scene.add(plane);

modifier = new ModifierStack(plane);

var bend = new Bend(0.7, 0.5, 0);
modifier.addModifier(bend);

function addModifier(mesh) {
    modifier = new ModifierStack(mesh);

    bend = new Bend(1.5, 0.2, 0);
    bend.constraint = ModConstant.LEFT;
}

function animate() {
    requestAnimationFrame(animate);
    renderer.render(scene, camera);
    modifier && modifier.apply();
}

animate();

document.addEventListener('wheel', onDocumentMouseWheel, false);

function onDocumentMouseWheel(event) {
    console.log(event);
    var fovMAX = 160;
    var fovMIN = 1;

    camera.fov -= event.deltaY;
    console.log(camera.fov);
    camera.fov = Math.max(Math.min(camera.fov, fovMAX), fovMIN);
    camera.updateProjectionMatrix();

}