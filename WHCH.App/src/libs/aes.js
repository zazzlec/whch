import * as CryptoJS from 'crypto-js';

let AuthTokenKey = "11111111111111111111111111111112"; //AES密钥
let AuthTokenIv = '1234567890000000'; //AES向量

/*AES加密*/
export const Encrypt = (source) => {
    var key = CryptoJS.enc.Utf8.parse(AuthTokenKey);//32位
    var iv = CryptoJS.enc.Utf8.parse(AuthTokenIv);//16位
    var srcs = CryptoJS.enc.Utf8.parse(source);
    var encrypted = CryptoJS.AES.encrypt(srcs, key, {
        iv: iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7
    });
    return encrypted.ciphertext.toString();   
}

