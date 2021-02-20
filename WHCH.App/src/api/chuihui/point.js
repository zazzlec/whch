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
export const ias = ({
  x,
  z,
  y,
  col
}) => {
  let arr = [];
  let arr2 =[];
  // let geometry = new THREE.CylinderGeometry(radiolll,radiolll, 0.003, 32);
  

  let geometry = new THREE.BoxGeometry( 0.005, 0.005, 0.005 );


  let qian=0.048;
  let hou=-0.051;

  let ia1 = new THREE.Mesh(geometry, material);
  ia1.position.set(x + 0.158, z - 0.06, y + 0.04+qian);
  ia1.rotation.x = 1.56;
  ia1.name = "ia1";
  let cc = col.clone();
  cc.position.set(x + 0.158, z - 0.06, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ia1);

  ia1 = new THREE.Mesh(geometry, material);
  ia1.position.set(x + 0.158, z - 0.06, y + 0.04+hou);
  ia1.rotation.x = 1.56;
  ia1.name = "ia1";
  arr.push(ia1);

  let ia2 = new THREE.Mesh(geometry, material);
  ia2.position.set(x + 0.158, z - 0.095, y + 0.04+qian);
  ia2.rotation.x = 1.56;
  ia2.name = "ia2";
  cc = col.clone();
  cc.position.set(x + 0.158, z - 0.095, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ia2);

  ia2 = new THREE.Mesh(geometry, material);
  ia2.position.set(x + 0.158, z - 0.095, y + 0.04+hou);
  ia2.rotation.x = 1.56;
  ia2.name = "ia2";
  arr.push(ia2);

  let ia3 = new THREE.Mesh(geometry, material);
  ia3.position.set(x + 0.158, z - 0.134, y + 0.04+qian);
  ia3.rotation.x = 1.56;
  ia3.name = "ia3";
  cc = col.clone();
  cc.position.set(x + 0.158, z - 0.134, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ia3);

  ia3 = new THREE.Mesh(geometry, material);
  ia3.position.set(x + 0.158, z - 0.134, y + 0.04+hou);
  ia3.rotation.x = 1.56;
  ia3.name = "ia3";
  arr.push(ia3);

  return [arr,arr2];
}

//长吹 ib 1-46
export const ibs = ({
  x,
  z,
  y,
  col
}) => {
  let arr = [];
  let arr2 =[];
  // let geometry = new THREE.CylinderGeometry(radiolll,radiolll, 0.003, 32);
  

  let geometry = new THREE.BoxGeometry( 0.005, 0.005, 0.005 );


  let qian=0.048;
  let hou=-0.051;

  let ib1 = new THREE.Mesh(geometry, material);
  ib1.position.set(x + 0.038, z + 0.166, y + 0.04+qian);
  ib1.rotation.x = 1.56;
  ib1.name = "ib1";
  let cc = col.clone();
  cc.position.set(x + 0.038, z + 0.166, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib1);

  ib1 = new THREE.Mesh(geometry, material);
  ib1.position.set(x + 0.038, z + 0.166, y + 0.04+hou);
  ib1.rotation.x = 1.56;
  ib1.name = "ib1";
  arr.push(ib1);



  let ib2 = new THREE.Mesh(geometry, material);
  ib2.position.set(x + 0.073, z + 0.166, y + 0.04+qian);
  ib2.rotation.x = 1.56;
  ib2.name = "ib2";
  cc = col.clone();
  cc.position.set(x + 0.073, z + 0.166, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib2);

  ib2 = new THREE.Mesh(geometry, material);
  ib2.position.set(x + 0.073, z + 0.166, y + 0.04+hou);
  ib2.rotation.x = 1.56;
  ib2.name = "ib2";
  arr.push(ib2);



  let ib3 = new THREE.Mesh(geometry, material);
  ib3.position.set(x + 0.038, z + 0.136, y + 0.04+qian);
  ib3.rotation.x = 1.56;
  ib3.name = "ib3";
  cc = col.clone();
  cc.position.set(x + 0.038, z + 0.136, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib3);

  ib3 = new THREE.Mesh(geometry, material);
  ib3.position.set(x + 0.038, z + 0.136, y + 0.04+hou);
  ib3.rotation.x = 1.56;
  ib3.name = "ib3";
  arr.push(ib3);

  let ib4 = new THREE.Mesh(geometry, material);
  ib4.position.set(x + 0.073, z + 0.136, y + 0.04+qian);
  ib4.rotation.x = 1.56;
  ib4.name = "ib4";
  cc = col.clone();
  cc.position.set(x + 0.073, z + 0.136, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib4);

  ib4 = new THREE.Mesh(geometry, material);
  ib4.position.set(x + 0.073, z + 0.136, y + 0.04+hou);
  ib4.rotation.x = 1.56;
  ib4.name = "ib4";
  arr.push(ib4);

  let ib5 = new THREE.Mesh(geometry, material);
  ib5.position.set(x + 0.038, z + 0.106, y + 0.04+qian);
  ib5.rotation.x = 1.56;
  ib5.name = "ib5";
  cc = col.clone();
  cc.position.set(x + 0.038, z + 0.106, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib5);

  ib5 = new THREE.Mesh(geometry, material);
  ib5.position.set(x + 0.038, z + 0.106, y + 0.04+hou);
  ib5.rotation.x = 1.56;
  ib5.name = "ib5";
  arr.push(ib5);

  let ib6 = new THREE.Mesh(geometry, material);
  ib6.position.set(x + 0.073, z + 0.106, y + 0.04+qian);
  ib6.rotation.x = 1.56;
  ib6.name = "ib6";
  cc = col.clone();
  cc.position.set(x + 0.073, z + 0.106, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib6);

  ib6 = new THREE.Mesh(geometry, material);
  ib6.position.set(x + 0.073, z + 0.106, y + 0.04+hou);
  ib6.rotation.x = 1.56;
  ib6.name = "ib6";
  arr.push(ib6);

  let ib7 = new THREE.Mesh(geometry, material);
  ib7.position.set(x + 0.083, z + 0.066, y + 0.04+qian);
  ib7.rotation.x = 1.56;
  ib7.name = "ib7";
  cc = col.clone();
  cc.position.set(x + 0.083, z + 0.066, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib7);

  ib7 = new THREE.Mesh(geometry, material);
  ib7.position.set(x + 0.083, z + 0.066, y + 0.04+hou);
  ib7.rotation.x = 1.56;
  ib7.name = "ib7";
  arr.push(ib7);

  let ib8 = new THREE.Mesh(geometry, material);
  ib8.position.set(x + 0.083, z + 0.036, y + 0.04+qian);
  ib8.rotation.x = 1.56;
  ib8.name = "ib8";
  cc = col.clone();
  cc.position.set(x + 0.083, z + 0.036, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib8);

  ib8 = new THREE.Mesh(geometry, material);
  ib8.position.set(x + 0.083, z + 0.036, y + 0.04+hou);
  ib8.rotation.x = 1.56;
  ib8.name = "ib8";
  arr.push(ib8);

  let ib9 = new THREE.Mesh(geometry, material);
  ib9.position.set(x + 0.033, z + 0.006, y + 0.04+qian);
  ib9.rotation.x = 1.56;
  ib9.name = "ib9";
  cc = col.clone();
  cc.position.set(x + 0.033, z + 0.006, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib9);

  ib9 = new THREE.Mesh(geometry, material);
  ib9.position.set(x + 0.033, z + 0.006, y + 0.04+hou);
  ib9.rotation.x = 1.56;
  ib9.name = "ib9";
  arr.push(ib9);

  let ib10 = new THREE.Mesh(geometry, material);
  ib10.position.set(x + 0.033, z - 0.024, y + 0.04+qian);
  ib10.rotation.x = 1.56;
  ib10.name = "ib10";
  cc = col.clone();
  cc.position.set(x + 0.033, z - 0.024, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib10);

  ib10 = new THREE.Mesh(geometry, material);
  ib10.position.set(x + 0.033, z - 0.024, y + 0.04+hou);
  ib10.rotation.x = 1.56;
  ib10.name = "ib10";
  arr.push(ib10);

  let ib11 = new THREE.Mesh(geometry, material);
  ib11.position.set(x + 0.058, z - 0.134, y + 0.04+qian);
  ib11.rotation.x = 1.56;
  ib11.name = "ib11";
  cc = col.clone();
  cc.position.set(x + 0.058, z - 0.134, y + 0.04+qian);
  cc.rotation.x = 1.56;
  arr2.push(cc);
  arr.push(ib11);

  ib11 = new THREE.Mesh(geometry, material);
  ib11.position.set(x + 0.058, z - 0.134, y + 0.04+hou);
  ib11.rotation.x = 1.56;
  ib11.name = "ib11";
  arr.push(ib11);

  // let ia1 = new THREE.Mesh(geometry, material);
  // ia1.position.set(x + 0.158, z - 0.06, y + 0.04+qian);
  // ia1.rotation.x = 1.56;
  // ia1.name = "ia1";
  // cc = col.clone();
  // cc.position.set(x + 0.158, z - 0.06, y + 0.04+qian);
  // cc.rotation.x = 1.56;
  // arr2.push(cc);
  // arr.push(ia1);

  // ia1 = new THREE.Mesh(geometry, material);
  // ia1.position.set(x + 0.158, z - 0.06, y + 0.04+hou);
  // ia1.rotation.x = 1.56;
  // ia1.name = "ia1";
  // arr.push(ia1);

  // let ia2 = new THREE.Mesh(geometry, material);
  // ia2.position.set(x + 0.158, z - 0.095, y + 0.04+qian);
  // ia2.rotation.x = 1.56;
  // ia2.name = "ia2";
  // cc = col.clone();
  // cc.position.set(x + 0.158, z - 0.095, y + 0.04+qian);
  // cc.rotation.x = 1.56;
  // arr2.push(cc);
  // arr.push(ia2);

  // ia2 = new THREE.Mesh(geometry, material);
  // ia2.position.set(x + 0.158, z - 0.095, y + 0.04+hou);
  // ia2.rotation.x = 1.56;
  // ia2.name = "ia2";
  // arr.push(ia2);

  // let ia3 = new THREE.Mesh(geometry, material);
  // ia3.position.set(x + 0.158, z - 0.134, y + 0.04+qian);
  // ia3.rotation.x = 1.56;
  // ia3.name = "ia3";
  // cc = col.clone();
  // cc.position.set(x + 0.158, z - 0.134, y + 0.04+qian);
  // cc.rotation.x = 1.56;
  // arr2.push(cc);
  // arr.push(ia3);

  // ia3 = new THREE.Mesh(geometry, material);
  // ia3.position.set(x + 0.158, z - 0.134, y + 0.04+hou);
  // ia3.rotation.x = 1.56;
  // ia3.name = "ia3";
  // arr.push(ia3);

  return [arr,arr2];
}
