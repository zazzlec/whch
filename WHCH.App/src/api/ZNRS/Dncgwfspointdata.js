

import axios from '@/libs/api.request'

export const getGwfspointdataListAll = () => {
  return axios.request({
    url:  'Dncgwfspointdata' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const batchok = (data) => {
  return axios.request({
    url:  'Dncgwfspointdata' +'/batchok',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

export const Reset = (data) => {
  return axios.request({
    url:  'Dncgwfspointdata' +'/Reset',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

export const ChangeBaseAgle = (data) => {
  return axios.request({
    url:  'Dncgwfspointdata' +'/ChangeBaseAgle',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

export const getGwfspointdataList = (data) => {
  return axios.request({
    url:  'Dncgwfspointdata' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createGwfspointdata = (data) => {
  return axios.request({
    url:  'Dncgwfspointdata' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadGwfspointdata = (data) => {
  return axios.request({
    url: 'Dncgwfspointdata' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editGwfspointdata = (data) => {
  return axios.request({
    url: 'Dncgwfspointdata' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteGwfspointdata = (ids) => {
  return axios.request({
    url: 'Dncgwfspointdata'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncgwfspointdata'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateGwfspointdata = (data) => {
  return axios.request({
    url:  'Dncgwfspointdata' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

