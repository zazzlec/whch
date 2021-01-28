import * as THREE from 'three';

let path = "/";
let urls = [
  // path + "px.png", path + "nx.png",
  // path + "py.png", path + "ny.png",
  // path + "pz.png", path + "nz.png"
  path + "2.png", path + "2.png",
  path + "2.png", path + "2.png",
  path + "2.png", path + "2.png"
];

let textureCube = new THREE.CubeTextureLoader().load(urls);
textureCube.encoding = THREE.sRGBEncoding;
// let materialColor = new THREE.Color();
// materialColor.setRGB(10, 10, 10);
//let material = new THREE.MeshPhongMaterial({ color: materialColor, envMap: textureCube, side: THREE.DoubleSide })




let material = new THREE.MeshPhysicalMaterial({
  color:0xffffff,
  // 材质像金属的程度. 非金属材料，如木材或石材，使用0.0，金属使用1.0，中间没有（通常）.
  // 默认 0.5. 0.0到1.0之间的值可用于生锈的金属外观
  metalness: 1.0,
  // 材料的粗糙程度. 0.0表示平滑的镜面反射，1.0表示完全漫反射. 默认 0.5
  roughness: 0.1,
  // 设置环境贴图
  envMap: textureCube,
  // 反射程度, 从 0.0 到1.0.默认0.5.
  // 这模拟了非金属材料的反射率。 当metalness为1.0时无效
  // reflectivity: 0.5,
})


let radiolll=0.0019;
//短吹 IR 1-96
export const irs = ({
  x,
  z,
  y,
  col
}) => {
  let arr = [];
  let arr2 =[];
  let b1 = - 0.09;//最小面一排高度
  // //y 蓝色线，前后面移动
  // //z 绿色线，上下
  // //x 左右
  let geometry = new THREE.CylinderGeometry(radiolll,radiolll, 0.003, 32);
  //let material = new THREE.MeshBasicMaterial({ color: '#ffffff' });

  for (let index = 0; index < 6; index++) {
    let ir_1_6 = new THREE.Mesh(geometry, material);
    ir_1_6.position.set(x - 0.175 + index * 0.0142, z + b1, y - 0.055);
    ir_1_6.rotation.x = 1.56;
    ir_1_6.name = "ir"+(index+1);
    let cc = col.clone();
    cc.position.set(x - 0.175 + index * 0.0142, z + b1, y - 0.059);
    cc.rotation.x = 1.56;

    arr2.push(cc);
    arr.push(ir_1_6);
  }

  for (let index = 0; index < 6; index++) {
    let ir_7_12 = new THREE.Mesh(geometry, material);
    ir_7_12.position.set(x - 0.09, z + b1, y - 0.042 + index * 0.0142);
    ir_7_12.rotation.x = 1.56;
    ir_7_12.rotation.z = 1.56;
    ir_7_12.name = "ir"+(index+7);
    let cc = col.clone();
    cc.position.set(x - 0.085, z + b1, y - 0.042 + index * 0.0142);
    cc.rotation.x = 1.56;
    cc.rotation.z = 1.56;
    arr2.push(cc);
    arr.push(ir_7_12);
  }

  for (let index = 0; index < 6; index++) {
    let ir_13_18 = new THREE.Mesh(geometry, material);
    ir_13_18.position.set(x - 0.175 + 0.071 - (index * 0.0142), z + b1, y + 0.045);
    ir_13_18.rotation.x = 1.56;
    ir_13_18.name = "ir"+(index+13);
    let cc = col.clone();
    cc.position.set(x - 0.175 + 0.071 - (index * 0.0142), z + b1, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ir_13_18);
  }

  for (let index = 0; index < 6; index++) {
    let ir_19_24 = new THREE.Mesh(geometry, material);
    ir_19_24.position.set(x - 0.189, z + b1, y + 0.03 - index * 0.0142);
    ir_19_24.rotation.x = 1.56;
    ir_19_24.rotation.z = 1.56;
    ir_19_24.name = "ir"+(index+19);
    let cc = col.clone();
    cc.position.set(x - 0.193, z + b1, y + 0.03 - index * 0.0142);
    cc.rotation.x = 1.56;
    cc.rotation.z = 1.56;
    arr2.push(cc);
    arr.push(ir_19_24);
  }

  for (let i = 0; i < 3; i++) {
    let b2 = - 0.022 + i * 0.026;
    for (let index = 0; index < 6; index++) {
      let ir_1_6 = new THREE.Mesh(geometry, material);
      ir_1_6.position.set(x - 0.175 + index * 0.0142, z + b2, y - 0.055);
      ir_1_6.rotation.x = 1.56;
      ir_1_6.name = "ir"+(index+ (25 + 24*i));
      let cc = col.clone();
      cc.position.set(x - 0.175 + index * 0.0142, z + b2, y - 0.059);
      cc.rotation.x = 1.56;
      arr2.push(cc);

      arr.push(ir_1_6);
    }

    for (let index = 0; index < 6; index++) {
      let ir_7_12 = new THREE.Mesh(geometry, material);
      ir_7_12.position.set(x - 0.09, z + b2, y - 0.042 + index * 0.0142);
      ir_7_12.rotation.x = 1.56;
      ir_7_12.rotation.z = 1.56;
      ir_7_12.name = "ir"+(index+ (25+6 + 24*i));
      let cc = col.clone();
      cc.position.set(x - 0.085, z + b2, y - 0.042 + index * 0.0142);
      cc.rotation.x = 1.56;
      cc.rotation.z = 1.56;
      arr2.push(cc);
      arr.push(ir_7_12);
    }

    for (let index = 0; index < 6; index++) {
      let ir_13_18 = new THREE.Mesh(geometry, material);
      ir_13_18.position.set(x - 0.175 + 0.071 - (index * 0.0142), z + b2, y + 0.045);
      ir_13_18.rotation.x = 1.56;
      ir_13_18.name = "ir"+(index+ (25+6+6 + 24*i));
      let cc = col.clone();
      cc.position.set(x - 0.175 + 0.071 - (index * 0.0142), z + b2, y + 0.049);
      cc.rotation.x = 1.56;
      arr2.push(cc);
      arr.push(ir_13_18);
    }

    for (let index = 0; index < 6; index++) {
      let ir_19_24 = new THREE.Mesh(geometry, material);
      ir_19_24.position.set(x - 0.189, z + b2, y + 0.03 - index * 0.0142);
      ir_19_24.rotation.x = 1.56;
      ir_19_24.rotation.z = 1.56;
      ir_19_24.name = "ir"+(index+ (25+6+6+6 + 24*i));
      let cc = col.clone();
      cc.position.set(x - 0.193, z + b2, y + 0.03 - index * 0.0142);
      cc.rotation.x = 1.56;
      cc.rotation.z = 1.56;
      arr2.push(cc);
      arr.push(ir_19_24);
    }
  }
  return [arr,arr2];
}


//长吹 IK 1-46
export const iks = ({
  x,
  z,
  y,
  col
}) => {
  let arr = [];
  let arr2 =[];
  let geometry = new THREE.CylinderGeometry(radiolll,radiolll, 0.003, 32);
  //let material = new THREE.MeshBasicMaterial({ color: '#ffffff' });

  let ik1 = new THREE.Mesh(geometry, material);
  ik1.position.set(x - 0.143, z + 0.086, y - 0.055);
  ik1.rotation.x = 1.56;
  ik1.name = "ik1";
  let cc = col.clone();
  cc.position.set(x - 0.143, z + 0.086, y - 0.059);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ik1);

  let ik2 = new THREE.Mesh(geometry, material);
  ik2.position.set(x - 0.143, z + 0.086, y + 0.045);
  ik2.rotation.x = 1.56;
  ik2.name = "ik2";
  cc = col.clone();
  cc.position.set(x - 0.143, z + 0.086, y + 0.049);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ik2);

  let ik3 = new THREE.Mesh(geometry, material);
  ik3.position.set(x - 0.143, z + 0.066, y - 0.055);
  ik3.rotation.x = 1.56;
  ik3.name = "ik3";
  cc = col.clone();
  cc.position.set(x - 0.143, z + 0.066, y - 0.059);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ik3);

  let ik4 = new THREE.Mesh(geometry, material);
  ik4.position.set(x - 0.143, z + 0.066, y + 0.045);
  ik4.rotation.x = 1.56;
  ik4.name = "ik4";
  cc = col.clone();
  cc.position.set(x - 0.143, z + 0.066, y + 0.049);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ik4);


  for (let index = 0; index < 4; index++) {
    let ik5 = new THREE.Mesh(geometry, material);
    ik5.position.set(x - 0.117, z + 0.126 - index * 0.015, y - 0.055);
    ik5.rotation.x = 1.56;
    ik5.name = "ik"+(5+index*2);
    cc = col.clone();
    cc.position.set(x - 0.117, z + 0.126 - index * 0.015, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik5);

    let ik6 = new THREE.Mesh(geometry, material);
    ik6.position.set(x - 0.117, z + 0.126 - index * 0.015, y + 0.045);
    ik6.rotation.x = 1.56;
    ik6.name = "ik"+(6+index*2);
    cc = col.clone();
    cc.position.set(x - 0.117, z + 0.126 - index * 0.015, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik6);
  }

  for (let index = 0; index < 3; index++) {
    let ik5 = new THREE.Mesh(geometry, material);
    ik5.position.set(x - 0.089, z + 0.12 - index * 0.015, y - 0.055);
    ik5.rotation.x = 1.56;
    ik5.name = "ik"+(13+index*2);
    cc = col.clone();
    cc.position.set(x - 0.089, z + 0.12 - index * 0.015, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik5);

    let ik6 = new THREE.Mesh(geometry, material);
    ik6.position.set(x - 0.089, z + 0.12 - index * 0.015, y + 0.045);
    ik6.rotation.x = 1.56;
    ik6.name = "ik"+(14+index*2);
    cc = col.clone();
    cc.position.set(x - 0.089, z + 0.12 - index * 0.015, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik6);
  }

  for (let index = 0; index < 2; index++) {
    let ik5 = new THREE.Mesh(geometry, material);
    ik5.position.set(x - 0.063, z + 0.126 - index * 0.015, y - 0.055);
    ik5.rotation.x = 1.56;
    ik5.name = "ik"+(19+index*2);
    cc = col.clone();
    cc.position.set(x - 0.063, z + 0.126 - index * 0.015, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik5);

    let ik6 = new THREE.Mesh(geometry, material);
    ik6.position.set(x - 0.063, z + 0.126 - index * 0.015, y + 0.045);
    ik6.rotation.x = 1.56;
    ik6.name = "ik"+(20+index*2);
    cc = col.clone();
    cc.position.set(x - 0.063, z + 0.126 - index * 0.015, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik6);
  }

  //IK 23-28
  for (let index = 0; index < 3; index++) {
    let ik5 = new THREE.Mesh(geometry, material);
    ik5.position.set(x - 0.033, z + 0.126 - index * 0.015, y - 0.055);
    ik5.rotation.x = 1.56;
    ik5.name = "ik"+(23+index*2);
    cc = col.clone();
    cc.position.set(x - 0.033, z + 0.126 - index * 0.015, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik5);

    let ik6 = new THREE.Mesh(geometry, material);
    ik6.position.set(x - 0.033, z + 0.126 - index * 0.015, y + 0.045);
    ik6.rotation.x = 1.56;
    ik6.name = "ik"+(24+index*2);
    cc = col.clone();
    cc.position.set(x - 0.033, z + 0.126 - index * 0.015, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik6);
  }

  // IK 29-40
  for (let index = 0; index < 3; index++) {
    let h = 0.048;
    let jx = 0.02;
    let ik5 = new THREE.Mesh(geometry, material);
    ik5.position.set(x - 0.033, z + h - index * jx, y - 0.055);
    ik5.rotation.x = 1.56;
    ik5.name = "ik"+(29+index*4);
    cc = col.clone();
    cc.position.set(x - 0.033, z + h - index * jx, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik5);

    let ik6 = new THREE.Mesh(geometry, material);
    ik6.position.set(x - 0.033, z + h - index * jx, y + 0.045);
    ik6.rotation.x = 1.56;
    ik6.name = "ik"+(30+index*4);
    cc = col.clone();
    cc.position.set(x - 0.033, z + h - index * jx, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik6);

    let ik55 = new THREE.Mesh(geometry, material);
    ik55.position.set(x - 0.023, z + h - index * jx, y - 0.055);
    ik55.rotation.x = 1.56;
    ik55.name = "ik"+(31+index*4);
    cc = col.clone();
    cc.position.set(x - 0.023, z + h - index * jx, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik55);

    let ik66 = new THREE.Mesh(geometry, material);
    ik66.position.set(x - 0.023, z + h - index * jx, y + 0.045);
    ik66.rotation.x = 1.56;
    ik66.name = "ik"+(32+index*4);
    cc = col.clone();
    cc.position.set(x - 0.023, z + h - index * jx, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik66);
  }

  // IK 41-46
  for (let index = 0; index < 2; index++) {
    let h = 0.048;
    let jx = 0.02;
    if (index == 1) {
      let ik5 = new THREE.Mesh(geometry, material);
      ik5.position.set(x - 0.008, z + h - index * jx, y - 0.055);
      ik5.rotation.x = 1.56;
      ik5.name = "ik"+43;
      cc = col.clone();
      cc.position.set(x - 0.008, z + h - index * jx, y - 0.059);
      cc.rotation.x = 1.56;
      arr2.push(cc);
      arr.push(ik5);

      let ik6 = new THREE.Mesh(geometry, material);
      ik6.position.set(x - 0.008, z + h - index * jx, y + 0.045);
      ik6.rotation.x = 1.56;
      ik6.name = "ik"+44;
      cc = col.clone();
      cc.position.set(x - 0.008, z + h - index * jx, y + 0.049);
      cc.rotation.x = 1.56;
      arr2.push(cc);
      arr.push(ik6);
    }

    let ik55 = new THREE.Mesh(geometry, material);
    ik55.position.set(x + 0.003, z + h - index * jx, y - 0.055);
    ik55.rotation.x = 1.56;
    ik55.name = "ik"+(41+index*4);
    cc = col.clone();
    cc.position.set(x + 0.003, z + h - index * jx, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik55);

    let ik66 = new THREE.Mesh(geometry, material);
    ik66.position.set(x + 0.003, z + h - index * jx, y + 0.045);
    ik66.rotation.x = 1.56;
    ik66.name = "ik"+(42+index*4);
    cc = col.clone();
    cc.position.set(x + 0.003, z + h - index * jx, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik66);
  }
  return [arr,arr2];
}


//半长吹 IL 1-16
export const ils = ({
  x,
  z,
  y,
  col
}) => {
  let arr = [];
  let arr2 =[];
  let geometry = new THREE.CylinderGeometry(radiolll,radiolll, 0.003, 32);
  //let material = new THREE.MeshBasicMaterial({ color: '#ffffff' });

  let h = -0.013;
  let ik5 = new THREE.Mesh(geometry, material);
  ik5.position.set(x - 0.033, z + h, y - 0.055);
  ik5.rotation.x = 1.56;
  ik5.name = "il"+1;
  let cc = col.clone();
  cc.position.set(x - 0.033, z + h, y - 0.059);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ik5);

  let ik6 = new THREE.Mesh(geometry, material);
  ik6.position.set(x - 0.033, z + h, y + 0.045);
  ik6.rotation.x = 1.56;
  ik6.name = "il"+2;
  cc = col.clone();
  cc.position.set(x - 0.033, z + h, y + 0.049);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ik6);

  let ik55 = new THREE.Mesh(geometry, material);
  ik55.position.set(x - 0.023, z + h, y - 0.055);
  ik55.rotation.x = 1.56;
  ik55.name = "il"+3;
  cc = col.clone();
  cc.position.set(x - 0.023, z + h, y - 0.059);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ik55);

  let ik66 = new THREE.Mesh(geometry, material);
  ik66.position.set(x - 0.023, z + h, y + 0.045);
  ik66.rotation.x = 1.56;
  ik66.name = "il"+4;
  cc = col.clone();
  cc.position.set(x - 0.023, z + h, y + 0.049);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ik66);


  for (let index = 0; index < 2; index++) {
    let h1 = 0;
    let jx = 0.02;
    let ik5 = new THREE.Mesh(geometry, material);
    ik5.position.set(x - 0.008, z + h1 - index * jx, y - 0.055);
    ik5.rotation.x = 1.56;
    ik5.name = "il"+(5+index*4);
    cc = col.clone();
    cc.position.set(x - 0.008, z + h1 - index * jx, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik5);

    let ik6 = new THREE.Mesh(geometry, material);
    ik6.position.set(x - 0.008, z + h1 - index * jx, y + 0.045);
    ik6.rotation.x = 1.56;
    ik6.name = "il"+(6+index*4);
    cc = col.clone();
    cc.position.set(x - 0.008, z + h1 - index * jx, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik6);

    let ik55 = new THREE.Mesh(geometry, material);
    ik55.position.set(x + 0.003, z + h1 - index * jx, y - 0.055);
    ik55.rotation.x = 1.56;
    ik55.name = "il"+(7+index*4);
    cc = col.clone();
    cc.position.set(x + 0.003, z + h1 - index * jx, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik55);

    let ik66 = new THREE.Mesh(geometry, material);
    ik66.position.set(x + 0.003, z + h1 - index * jx, y + 0.045);
    ik66.rotation.x = 1.56;
    ik66.name = "il"+(8+index*4);
    cc = col.clone();
    cc.position.set(x + 0.003, z + h1 - index * jx, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik66);
  }

  for (let index = 0; index < 1; index++) {
    let h1 = -0.055;
    let jx = 0.02;
    let ik5 = new THREE.Mesh(geometry, material);
    ik5.position.set(x + 0.145, z + h1 - index * jx, y - 0.055);
    ik5.rotation.x = 1.56;
    ik5.name = "il13";
    cc = col.clone();
    cc.position.set(x + 0.145, z + h1 - index * jx, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik5);

    let ik6 = new THREE.Mesh(geometry, material);
    ik6.position.set(x + 0.145, z + h1 - index * jx, y + 0.045);
    ik6.rotation.x = 1.56;
    ik6.name = "il14";
    cc = col.clone();
    cc.position.set(x + 0.145, z + h1 - index * jx, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik6);

    let ik55 = new THREE.Mesh(geometry, material);
    ik55.position.set(x + 0.155, z + h1 - index * jx, y - 0.055);
    ik55.rotation.x = 1.56;
    ik55.name = "il15";
    cc = col.clone();
    cc.position.set(x + 0.155, z + h1 - index * jx, y - 0.059);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik55);

    let ik66 = new THREE.Mesh(geometry, material);
    ik66.position.set(x + 0.155, z + h1 - index * jx, y + 0.045);
    ik66.rotation.x = 1.56;
    ik66.name = "il16";
    cc = col.clone();
    cc.position.set(x + 0.155, z + h1 - index * jx, y + 0.049);
    cc.rotation.x = 1.56;
    arr2.push(cc);
    arr.push(ik66);
  }
  return [arr,arr2];
}


//预热器 IA 1-2
export const ias = ({
  x,
  z,
  y,
  col
}) => {
  let arr = [];
  let arr2 =[];
  let geometry = new THREE.CylinderGeometry(radiolll,radiolll, 0.003, 32);


  let h1 = -0.105;
  let jx = 0.02;
  let ik5 = new THREE.Mesh(geometry, material);
  ik5.position.set(x + 0.15, z + h1, y - 0);
  ik5.rotation.x = 1.56;
  ik5.name = "ia1";
  let cc = col.clone();
  cc.position.set(x + 0.15, z + h1, y + 0.005);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ik5);

  let ik6 = new THREE.Mesh(geometry, material);
  ik6.position.set(x + 0.15, z + h1 - 0.039, y - 0);
  ik6.rotation.x = 1.56;
  ik6.name = "ia2";
  cc = col.clone();
  cc.position.set(x + 0.15, z + h1 - 0.039, y + 0.005);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ik6);
  return [arr,arr2];
}