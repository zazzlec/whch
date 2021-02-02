

import axios from '@/libs/api.request'

export const getFuelparaListAll = () => {
  return axios.request({
    url:  'Dncfuelpara' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getFuelparaList = (data) => {
  return axios.request({
    url:  'Dncfuelpara' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createFuelpara = (data) => {
  return axios.request({
    url:  'Dncfuelpara' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadFuelpara = (data) => {
  return axios.request({
    url: 'Dncfuelpara' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editFuelpara = (data) => {
  return axios.request({
    url: 'Dncfuelpara' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteFuelpara = (ids) => {
  return axios.request({
    url: 'Dncfuelpara'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncfuelpara'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateFuelpara = (data) => {
  return axios.request({
    url:  'Dncfuelpara' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

