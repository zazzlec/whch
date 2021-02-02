

import axios from '@/libs/api.request'

export const getChqpointListAll = () => {
  return axios.request({
    url:  'Dncchqpoint' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getChqpointList = (data) => {
  return axios.request({
    url:  'Dncchqpoint' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createChqpoint = (data) => {
  return axios.request({
    url:  'Dncchqpoint' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadChqpoint = (data) => {
  return axios.request({
    url: 'Dncchqpoint' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editChqpoint = (data) => {
  return axios.request({
    url: 'Dncchqpoint' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteChqpoint = (ids) => {
  return axios.request({
    url: 'Dncchqpoint'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncchqpoint'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateChqpoint = (data) => {
  return axios.request({
    url:  'Dncchqpoint' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

