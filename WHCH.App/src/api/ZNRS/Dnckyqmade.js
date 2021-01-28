

import axios from '@/libs/api.request'

export const getKyqmadeListAll = () => {
  return axios.request({
    url:  'Dnckyqmade' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getKyqmadeList = (data) => {
  return axios.request({
    url:  'Dnckyqmade' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createKyqmade = (data) => {
  return axios.request({
    url:  'Dnckyqmade' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadKyqmade = (data) => {
  return axios.request({
    url: 'Dnckyqmade' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editKyqmade = (data) => {
  return axios.request({
    url: 'Dnckyqmade' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteKyqmade = (ids) => {
  return axios.request({
    url: 'Dnckyqmade'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnckyqmade'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateKyqmade = (data) => {
  return axios.request({
    url:  'Dnckyqmade' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

