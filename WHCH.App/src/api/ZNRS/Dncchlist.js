

import axios from '@/libs/api.request'

export const getChlistListAll = () => {
  return axios.request({
    url:  'Dncchlist' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getChlistList = (data) => {
  return axios.request({
    url:  'Dncchlist' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createChlist = (data) => {
  return axios.request({
    url:  'Dncchlist' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadChlist = (data) => {
  return axios.request({
    url: 'Dncchlist' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const dochui = (data) => {
  return axios.request({
    url: 'Dncchlist' +'/dochui/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}
export const dochui2 = (data) => {
  return axios.request({
    url: 'Dncchlist' +'/dochui2/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}
// editRole
export const editChlist = (data) => {
  return axios.request({
    url: 'Dncchlist' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteChlist = (ids) => {
  return axios.request({
    url: 'Dncchlist'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncchlist'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateChlist = (data) => {
  return axios.request({
    url:  'Dncchlist' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

