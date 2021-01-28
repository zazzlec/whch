

import axios from '@/libs/api.request'

export const getChrunlistListAll = () => {
  return axios.request({
    url:  'Dncchrunlist' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getChrunlistList = (data) => {
  return axios.request({
    url:  'Dncchrunlist' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createChrunlist = (data) => {
  return axios.request({
    url:  'Dncchrunlist' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadChrunlist = (data) => {
  return axios.request({
    url: 'Dncchrunlist' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editChrunlist = (data) => {
  return axios.request({
    url: 'Dncchrunlist' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteChrunlist = (ids) => {
  return axios.request({
    url: 'Dncchrunlist'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncchrunlist'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateChrunlist = (data) => {
  return axios.request({
    url:  'Dncchrunlist' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

