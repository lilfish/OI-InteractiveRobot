
        var camera, scene, renderer;
        var modifier, prevMod, mixer, mesh;
        var noise, bend, cloth, twist, taper, bloat, breaks, userDefined;

        init();
        function init() {
            initScene();
            initLights();
            initMesh();
           
            initGUI();
            animate();
        }

        function initScene() {
            camera = new THREE.PerspectiveCamera(70, window.innerWidth / window.innerHeight, 1, 1000);
            camera.position.z = 500;
            scene = new THREE.Scene();
            scene.fog = new THREE.Fog(0xffffff, 1, 10000);

            renderer = new THREE.WebGLRenderer();
            renderer.setPixelRatio(window.devicePixelRatio);
            renderer.setSize(window.innerWidth, window.innerHeight);
            renderer.setClearColor(0xaaccff);

            document.body.appendChild(renderer.domElement);
            window.addEventListener('resize', onWindowResize, false);
        }

        function initLights() {
            var ambientLight = new THREE.AmbientLight(0x101010);
            scene.add(ambientLight);

            var pointLight = new THREE.PointLight(0xffffff, 2, 1000, 1);
            pointLight.position.set(0, 200, 200);
            scene.add(pointLight);
        }

        

        function initMesh() {
            //plane
            var texture = new THREE.TextureLoader().load('./images/map2.jpg');
            plane = new THREE.Mesh(
                new THREE.PlaneGeometry(600, 430, 20, 20, true),
                new THREE.MeshBasicMaterial({ map: texture, side: THREE.DoubleSide })
            );

            //plane.rotation.x = - Math.PI / 2;
            scene.add(plane);

            addModifier(plane);
        }

        function addModifier(mesh) {
            modifier = new ModifierStack(mesh);

            bend = new Bend(1.5, 0.2, 0);
            bend.constraint = ModConstant.LEFT;

            cloth = new Cloth(1, 0);
            //modifier.addModifier(cloth);
            cloth.setForce(0.2, -0.2, -0.2);


            twist = new Twist(0);
            twist.vector = new Vector3(0, 1, 0);

            taper = new Taper(1);
            taper.setFalloff(0.1, 0.5);

            bloat = new Bloat();
            bloat.center = mesh.position.clone();
            bloat.radius = 300;

            breaks = new Break(0.7, 5);

            var angle = 0;
            userDefined = new UserDefined();
            userDefined.renderVector = function (vec, i, length) {
                vec.setValue(ModConstant.Z, vec.z + Math.sin(i * .2 + angle) * 10);
                vec.setValue(ModConstant.Y, vec.y + Math.sin(i * .2 + angle) * 10);
            }
            userDefined.addEventListener("CHANGE", function () {
                angle += 0.2;
            });
        }

        function changeModifier(mod) {
            if (prevMod) {
                modifier.removeModifier(prevMod);
                TweenMax.killTweensOf(prevMod);
            }
            modifier.reset();
            modifier.addModifier(mod);

            prevMod = mod;
        }

        function initGUI() {
            var params = {
                Bend: function () {
                    changeModifier(bend);
                    TweenMax.fromTo(bend, 2,
                        {
                            force: -2
                        }, {
                            force: 2,
                            ease: Cubic.easeInOut,
                            yoyo: true,
                            repeat: 999
                        }
                    );
                },
                Cloth: function () {
                    changeModifier(cloth);
                    cloth.lockXMin(0);
                },
                Twist: function () {
                    changeModifier(twist);
                    TweenMax.fromTo(twist, 2, { angle: -Math.PI / 2 }, {
                        angle: Math.PI / 2,
                        ease: Cubic.easeInOut,
                        yoyo: true,
                        repeat: 999
                    })
                },
                Bloat: function () {
                    changeModifier(bloat);
                    TweenMax.fromTo(bloat, 1, {
                        radius: 0,
                    }, {
                            radius: 200,
                            yoyo: true,
                            repeat: 999
                        });
                },
                UserDefined: function () {
                    changeModifier(userDefined);
                },
                computeNormals: false
            };

            var gui = new dat.GUI();
            gui.add(params, 'Bend');
            gui.add(params, 'Twist');
            gui.add(params, 'Bloat');
            gui.add(params, 'Cloth');
            gui.add(params, 'UserDefined');
        }

        function animate() {
            requestAnimationFrame(animate);
            renderer.render(scene, camera);
            modifier && modifier.apply();
        }

        function onWindowResize() {
            renderer.setSize(window.innerWidth, window.innerHeight);
            camera.aspect = window.innerWidth / window.innerHeight;
            camera.updateProjectionMatrix();
        }
    