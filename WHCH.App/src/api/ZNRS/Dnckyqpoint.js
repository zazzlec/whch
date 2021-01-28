

import axios from '@/libs/api.request'

export const getKyqpointListAll = () => {
  return axios.request({
    url:  'Dnckyqpoint' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getKyqpointList = (data) => {
  return axios.request({
    url:  'Dnckyqpoint' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createKyqpoint = (data) => {
  return axios.request({
    url:  'Dnckyqpoint' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadKyqpoint = (data) => {
  return axios.request({
    url: 'Dnckyqpoint' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editKyqpoint = (data) => {
  return axios.request({
    url: 'Dnckyqpoint' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteKyqpoint = (ids) => {
  return axios.request({
    url: 'Dnckyqpoint'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnckyqpoint'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateKyqpoint = (data) => {
  return axios.request({
    url:  'Dnckyqpoint' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

