export const forEach = (arr, fn) => {
  if (!arr.length || !fn) return
  let i = -1
  let len = arr.length
  while (++i < len) {
    let item = arr[i]
    fn(item, i, arr)
  }
}

/**
 * @param {Array} arr1
 * @param {Array} arr2
 * @description 得到两个数组的交集, 两个数组的元素为数值或字符串
 */
export const getIntersection = (arr1, arr2) => {
  let len = Math.min(arr1.length, arr2.length)
  let i = -1
  let res = []
  while (++i < len) {
    const item = arr2[i]
    if (arr1.indexOf(item) > -1) res.push(item)
  }
  return res
}

/**
 * @param {Array} arr1
 * @param {Array} arr2
 * @description 得到两个数组的并集, 两个数组的元素为数值或字符串
 */
export const getUnion = (arr1, arr2) => {
  return Array.from(new Set([...arr1, ...arr2]))
}

/**
 * @param {Array} target 目标数组
 * @param {Array} arr 需要查询的数组
 * @description 判断要查询的数组是否至少有一个元素包含在目标数组中
 */
export const hasOneOf = (targetarr, arr) => {
  return targetarr.some(_ => arr.indexOf(_) > -1)
}

/**
 * @param {String|Number} value 要验证的字符串或数值
 * @param {*} validList 用来验证的列表
 */
export function oneOf (value, validList) {
  for (let i = 0; i < validList.length; i++) {
    if (value === validList[i]) {
      return true
    }
  }
  return false
}

/**
 * @param {Number} timeStamp 判断时间戳格式是否是毫秒
 * @returns {Boolean}
 */
const isMillisecond = timeStamp => {
  const timeStr = String(timeStamp)
  return timeStr.length > 10
}

/**
 * @param {Number} timeStamp 传入的时间戳
 * @param {Number} currentTime 当前时间时间戳
 * @returns {Boolean} 传入的时间戳是否早于当前时间戳
 */
const isEarly = (timeStamp, currentTime) => {
  return timeStamp < currentTime
}

/**
 * @param {Number} num 数值
 * @returns {String} 处理后的字符串
 * @description 如果传入的数值小于10，即位数只有1位，则在前面补充0
 */
const getHandledValue = num => {
  return num < 10 ? '0' + num : num
}

/**
 * @param {Number} timeStamp 传入的时间戳
 * @param {Number} startType 要返回的时间字符串的格式类型，传入'year'则返回年开头的完整时间
 */
export const getDate = (timeStamp, startType) => {
  const d = new Date(timeStamp * 1000)
  const year = d.getFullYear()
  const month = getHandledValue(d.getMonth() + 1)
  const date = getHandledValue(d.getDate())
  const hours = getHandledValue(d.getHours())
  const minutes = getHandledValue(d.getMinutes())
  const second = getHandledValue(d.getSeconds())
  let resStr = ''
  if (startType === 'year') resStr = year + '-' + month + '-' + date + ' ' + hours + ':' + minutes + ':' + second
  else resStr = month + '-' + date + ' ' + hours + ':' + minutes
  return resStr
}

/**
 * @param {String|Number} timeStamp 时间戳
 * @returns {String} 相对时间字符串
 */
export const getRelativeTime = timeStamp => {
  // 判断当前传入的时间戳是秒格式还是毫秒
  const IS_MILLISECOND = isMillisecond(timeStamp)
  // 如果是毫秒格式则转为秒格式
  if (IS_MILLISECOND) Math.floor(timeStamp /= 1000)
  // 传入的时间戳可以是数值或字符串类型，这里统一转为数值类型
  timeStamp = Number(timeStamp)
  // 获取当前时间时间戳
  const currentTime = Math.floor(Date.parse(new Date()) / 1000)
  // 判断传入时间戳是否早于当前时间戳
  const IS_EARLY = isEarly(timeStamp, currentTime)
  // 获取两个时间戳差值
  let diff = currentTime - timeStamp
  // 如果IS_EARLY为false则差值取反
  if (!IS_EARLY) diff = -diff
  let resStr = ''
  const dirStr = IS_EARLY ? '前' : '后'
  // 少于等于59秒
  if (diff <= 59) resStr = diff + '秒' + dirStr
  // 多于59秒，少于等于59分钟59秒
  else if (diff > 59 && diff <= 3599) resStr = Math.floor(diff / 60) + '分钟' + dirStr
  // 多于59分钟59秒，少于等于23小时59分钟59秒
  else if (diff > 3599 && diff <= 86399) resStr = Math.floor(diff / 3600) + '小时' + dirStr
  // 多于23小时59分钟59秒，少于等于29天59分钟59秒
  else if (diff > 86399 && diff <= 2623859) resStr = Math.floor(diff / 86400) + '天' + dirStr
  // 多于29天59分钟59秒，少于364天23小时59分钟59秒，且传入的时间戳早于当前
  else if (diff > 2623859 && diff <= 31567859 && IS_EARLY) resStr = getDate(timeStamp)
  else resStr = getDate(timeStamp, 'year')
  return resStr
}

/**
 * @returns {String} 当前浏览器名称
 */
export const getExplorer = () => {
  const ua = window.navigator.userAgent
  const isExplorer = (exp) => {
    return ua.indexOf(exp) > -1
  }
  if (isExplorer('MSIE')) return 'IE'
  else if (isExplorer('Firefox')) return 'Firefox'
  else if (isExplorer('Chrome')) return 'Chrome'
  else if (isExplorer('Opera')) return 'Opera'
  else if (isExplorer('Safari')) return 'Safari'
}

/**
 * @description 绑定事件 on(element, event, handler)
 */
export const on = (function () {
  if (document.addEventListener) {
    return function (element, event, handler) {
      if (element && event && handler) {
        element.addEventListener(event, handler, false)
      }
    }
  } else {
    return function (element, event, handler) {
      if (element && event && handler) {
        element.attachEvent('on' + event, handler)
      }
    }
  }
})()

/**
 * @description 解绑事件 off(element, event, handler)
 */
export const off = (function () {
  if (document.removeEventListener) {
    return function (element, event, handler) {
      if (element && event) {
        element.removeEventListener(event, handler, false)
      }
    }
  } else {
    return function (element, event, handler) {
      if (element && event) {
        element.detachEvent('on' + event, handler)
      }
    }
  }
})()

/**
 * 判断一个对象是否存在key，如果传入第二个参数key，则是判断这个obj对象是否存在key这个属性
 * 如果没有传入key这个参数，则判断obj对象是否有键值对
 */
export const hasKey = (obj, key) => {
  if (key) return key in obj
  else {
    let keysArr = Object.keys(obj)
    return keysArr.length
  }
}

/**
 * @param {*} obj1 对象
 * @param {*} obj2 对象
 * @description 判断两个对象是否相等，这两个对象的值只能是数字或字符串
 */
export const objEqual = (obj1, obj2) => {
  const keysArr1 = Object.keys(obj1)
  const keysArr2 = Object.keys(obj2)
  if (keysArr1.length !== keysArr2.length) return false
  else if (keysArr1.length === 0 && keysArr2.length === 0) return true
  /* eslint-disable-next-line */
  else return !keysArr1.some(key => obj1[key] != obj2[key])
}


/**
 * @param {*} data 传入json
 * @param {Number} type 0去T ,1 只要 年月日,2 小时分钟秒
 * @param {*} jtime 处理的时间字段
 */
export const getDateMore = (data, type, jtime) => {
  let o=[];
  for (let index = 0; index < data.length; index++) {
    const element = data[index];
    for (let i = 0; i < jtime.length; i++) {
      const et = jtime[i];
      if (et != ""){
        if (type === -1){
          if(element[et])
          {
            element[et] = element[et].substr(0,19).replace("T"," ")
          }else{
            element[et] = '0001-01-01'
          }
        } 
        else if (type === -2){
          if(element[et])
          {
            element[et] = element[et].substr(0,19).replace("T"," ")
          }else{
            element[et] = ''
          }
        } 
        else if (type === 0){
          if(element[et])
          {
            element[et] = element[et].substr(0,16).replace("T"," ")
          }else{
            element[et] = '0001-01-01'
          }
        } 
        else if (type === 1){
          if(element[et])
          {
            element[et] = element[et].substr(0,10)
          }else{
            element[et] = '0001-01-01'
          }
        } 
        else if (type === 2){
          if(element[et])
          {
            element[et] = element[et].substr(5,14).replace("T"," ")
          }else{
            element[et] = ''
          }
        } 
        else if (type === 3){
          if(element[et])
          {
            element[et] = element[et].substr(5,11).replace("T"," ")
          }else{
            element[et] = ''
          }
        } 
        else if (type === 5){
          if(element[et])
          {
            element[et] = element[et].substr(11,8)
          }else{
            element[et] = ''
          }
        } 
        else if (type === 6){
          if(element[et])
          {
            element[et] = element[et].substr(11,5)
          }else{
            element[et] = ''
          }
        } 
      }
    }
    o.push(element);
  }
  return o;
}


/**
 * @param {*} data 传入json 
 */
export const upperKey = (data) => {
  return  Object.keys(data).reduce((newData, key) => {
    let newKey = key.replace(key[0],key[0].toUpperCase())
    newData[newKey] = data[key]
    return newData
  }, {})
}



export const sortBy = (array, key) => {
  return array.sort(function(a, b) {
      var x = a[key]; var y = b[key];
      return ((x < y) ? -1 : ((x > y) ? 1 : 0));
  });
}


/*
 // startColor：开始颜色hex
 // endColor：结束颜色hex
 // step:几个阶级（几步）
 */
export const  gradientColor = (startColor,endColor,step)=>{
  let startRGB = colorRgb(startColor);//转换为rgb数组模式
  let startR = startRGB[0];
  let startG = startRGB[1];
  let startB = startRGB[2];
  let endRGB = colorRgb(endColor);
  let endR = endRGB[0];
  let endG = endRGB[1];
  let endB = endRGB[2];
  let sR = (endR-startR)/step;//总差值
  let sG = (endG-startG)/step;
  let sB = (endB-startB)/step;
  var colorArr = [];
  for(var i=0;i<step;i++){
  //计算每一步的hex值 
  let hex = colorHex('rgb('+parseInt((sR*i+startR))+','+parseInt((sG*i+startG))+','+parseInt((sB*i+startB))+')');
   colorArr.push(hex);
  }
  return colorArr;
}


 // 将hex表示方式转换为rgb表示方式(这里返回rgb数组模式)
export const  colorRgb = (sColor) =>{
  let reg = /^#([0-9a-fA-f]{3}|[0-9a-fA-f]{6})$/;
  sColor = sColor.toLowerCase();
  if(sColor && reg.test(sColor)){
   if(sColor.length === 4){
    let sColorNew = "#";
    for(let i=1; i<4; i+=1){
     sColorNew += sColor.slice(i,i+1).concat(sColor.slice(i,i+1));
    }
    sColor = sColorNew;
   }
   //处理六位的颜色值
   let sColorChange = [];
   for(let i=1; i<7; i+=2){
    sColorChange.push(parseInt("0x"+sColor.slice(i,i+2)));
   }
   return sColorChange;
  }else{
   return sColor;
  }
 }

 // 将rgb表示方式转换为hex表示方式
 export const  colorHex = (rgb) => {
  var _this = rgb;
  var reg = /^#([0-9a-fA-f]{3}|[0-9a-fA-f]{6})$/;
  if(/^(rgb|RGB)/.test(_this)){
   var aColor = _this.replace(/(?:(|)|rgb|RGB)*/g,"").split(",");
   var strHex = "#";
   for(var i=0; i<aColor.length; i++){
    var hex = Number(aColor[i]).toString(16);
    hex = hex<10 ? 0+''+hex :hex;// 保证每个rgb的值为2位
    if(hex === "0"){
     hex += hex;
    }
    strHex += hex;
   }
   if(strHex.length !== 7){
    strHex = _this;
   }
   return strHex;
  }else if(reg.test(_this)){
   var aNum = _this.replace(/#/,"").split("");
   if(aNum.length === 6){
    return _this;
   }else if(aNum.length === 3){
    var numHex = "#";
    for(var i=0; i<aNum.length; i+=1){
     numHex += (aNum[i]+aNum[i]);
    }
    return numHex;
   }
  }else{
   return _this;
  }
 }

 export const eqarr = (a,b) => {

  return a.sort().toString()==b.sort().toString();
    
}