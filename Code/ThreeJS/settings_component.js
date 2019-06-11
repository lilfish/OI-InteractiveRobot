// check if database items exist, otherwhise make
function resetSettings(){
    if(!localStorage.getItem("center_x"))
        localStorage.setItem("center_x", 0.5);
    if(!localStorage.getItem("center_y"))
        localStorage.setItem("center_y", 0.575);
    if(!localStorage.getItem("repeat_x"))
        localStorage.setItem("repeat_x", 10);
    if(!localStorage.getItem("repeat_y"))
        localStorage.setItem("repeat_y", 10);
    if(!localStorage.getItem("camera_position_z"))
        localStorage.setItem("camera_position_z", 50);
    if(!localStorage.getItem("camera_position_y"))
        localStorage.setItem("camera_position_y", 5.5);
    if(!localStorage.getItem("fov"))
        localStorage.setItem("fov", 32);
    if(!localStorage.getItem("offset_x"))
        localStorage.setItem("offset_x", 0.0);
    if(!localStorage.getItem("offset_y"))
        localStorage.setItem("offset_y", 0.0);
    if(!localStorage.getItem("sphere_size"))
        localStorage.setItem("sphere_size", JSON.stringify({x: 1, y: 1, z: 1}));
    if(!localStorage.getItem("max_offset_x"))
        localStorage.setItem("max_offset_x", 0.8);
    if(!localStorage.getItem("max_offset_y"))
        localStorage.setItem("max_offset_y", 0.8);
}
resetSettings();

// inzoemen & uitzoemen met scrollen. Op het moment dat je klikt veranderd de positie van het gezicht
document.addEventListener("wheel", onDocumentMouseWheel, false);
document.addEventListener("click", onclick, true);
document.onkeydown = checkKey;

function onDocumentMouseWheel(event) {
    console.log(event);
    var fovMAX = 160;
    var fovMIN = 1;

    camera.fov -= event.deltaY;
    console.log(camera.fov);
    camera.fov = Math.max(Math.min(camera.fov, fovMAX), fovMIN);
    camera.updateProjectionMatrix();
    localStorage.setItem("fov", camera.fov);
}

//onclick (muisknop ingeklikt) verander video
function onclick() {
    // console.log(screen.height,screen.width);
    var x = event.clientX;
    var y = event.clientY;
    // console.log(x,y);
    look(x,y, 1920, 1080);
}

function checkKey(e) {
    e = e || window.event;

    if (e.keyCode == '38') {
        // ↑ - stel y center in
        smiley.center.y += 0.005;
        localStorage.setItem("center_y", smiley.center.y);
    } else if (e.keyCode == '40') {
        // ↓ - stel y center in
        smiley.center.y -= 0.005;
        localStorage.setItem("center_y", smiley.center.y);
    } else if (e.keyCode == '37') {
        // ← - stel x center in
        smiley.center.x -= 0.005;
        localStorage.setItem("center_x", smiley.center.x);
    } else if (e.keyCode == '39') {
        // → - stel x center in
        smiley.center.x += 0.005;
        localStorage.setItem("center_x", smiley.center.x);
    } else if (e.keyCode == '83') {
        // s - camera naar links
        camera.position.y -= 0.1;
        localStorage.setItem("camera_position_y", camera.position.y);
    } else if (e.keyCode == '87') {
        // w - camera naar boven
        camera.position.y += 0.1;
        localStorage.setItem("camera_position_y", camera.position.y);
    } else if (e.keyCode == '90') {
        // z - zoom in
        camera.position.z += 0.1;
        localStorage.setItem("camera_position_z", camera.position.z);
    } else if (e.keyCode == '88') {
        // x - zoom uit
        camera.position.z -= 0.1;
        localStorage.setItem("camera_position_z", camera.position.z);
    } else if (e.keyCode == '61') {
        // + - sphere groter maken
        console.log(sphere.scale);
        sphere.scale.set((sphere.scale.x + 0.1),(sphere.scale.y + 0.1),(sphere.scale.z + 0.1));
        localStorage.setItem("sphere_size", JSON.stringify(sphere.scale));
    } else if (e.keyCode == '173') {
        // - - sphere kleiner maken
        sphere.scale.set((sphere.scale.x - 0.1),(sphere.scale.y - 0.1),(sphere.scale.z - 0.1));
        localStorage.setItem("sphere_size", JSON.stringify(sphere.scale));
    } else if (e.keyCode == '79') {
        // o - sphere smaller maken
        sphere.scale.set((sphere.scale.x - 0.1),sphere.scale.y,sphere.scale.z);
        localStorage.setItem("sphere_size", JSON.stringify(sphere.scale));
    } else if (e.keyCode == '80') {
        // p - sphere breeder maken
        sphere.scale.set((sphere.scale.x + 0.1),sphere.scale.y,sphere.scale.z);
        localStorage.setItem("sphere_size", JSON.stringify(sphere.scale));
    } else if (e.keyCode == '75') {
        // k - sphere hoger maken
        sphere.scale.set(sphere.scale.x,(sphere.scale.y + 0.1),sphere.scale.z);
        localStorage.setItem("sphere_size", JSON.stringify(sphere.scale));
    } else if (e.keyCode == '76') {
        // l - sphere minder hoog maken
        sphere.scale.set(sphere.scale.x,(sphere.scale.y - 0.1),sphere.scale.z);
        localStorage.setItem("sphere_size", JSON.stringify(sphere.scale));
    } else if (e.keyCode == '78') {
        // n - sphere langer maken
        sphere.scale.set(sphere.scale.x,sphere.scale.y,(sphere.scale.z + 0.1));
        localStorage.setItem("sphere_size", JSON.stringify(sphere.scale));
    } else if (e.keyCode == '77') {
        // m - sphere hoger maken
        sphere.scale.set(sphere.scale.x,sphere.scale.y,(sphere.scale.z - 0.1));
        localStorage.setItem("sphere_size", JSON.stringify(sphere.scale));
    } else if (e.keyCode == '85') {2
        // u - max offset x kleiner
        var current_max = Number(localStorage.getItem("max_offset_x"))
        console.log(current_max);
        localStorage.setItem("max_offset_x", (current_max - 0.05));
    } else if (e.keyCode == '73') {
        // i - max offset x groter
        var current_max = Number(localStorage.getItem("max_offset_x"))
        console.log(current_max);
        localStorage.setItem("max_offset_x", (current_max + 0.05));
    } else if (e.keyCode == '72') {
        // h - max offset y kleiner
        var current_max = Number(localStorage.getItem("max_offset_y"))
        console.log(current_max);
        localStorage.setItem("max_offset_y", (current_max - 0.05));
    } else if (e.keyCode == '74') {
        // j - max offset y groter
        var current_max = Number(localStorage.getItem("max_offset_y"))
        console.log(current_max);
        localStorage.setItem("max_offset_y", (current_max + 0.05));
    } else if (e.keyCode == '46') {
        // Deleta - reset all default variables
        localStorage.clear();
        resetSettings();
        location.reload(); 
    } 
    // 83 & 87
    console.log(e.keyCode);
    if (e.keyCode == '49'){
        // 1 - verander naar neutraal
        to_neutraal();
    } else if (e.keyCode == '50'){
        // 2 - verander naar smiley
        to_happy()
    } else if (e.keyCode == '51'){
        // 3 - verander naar neutraal
    }

}