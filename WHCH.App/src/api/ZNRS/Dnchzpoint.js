

import axios from '@/libs/api.request'

export const getHzpointListAll = () => {
  return axios.request({
    url:  'Dnchzpoint' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getHzpointList = (data) => {
  return axios.request({
    url:  'Dnchzpoint' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createHzpoint = (data) => {
  return axios.request({
    url:  'Dnchzpoint' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadHzpoint = (data) => {
  return axios.request({
    url: 'Dnchzpoint' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editHzpoint = (data) => {
  return axios.request({
    url: 'Dnchzpoint' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteHzpoint = (ids) => {
  return axios.request({
    url: 'Dnchzpoint'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnchzpoint'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateHzpoint = (data) => {
  return axios.request({
    url:  'Dnchzpoint' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

