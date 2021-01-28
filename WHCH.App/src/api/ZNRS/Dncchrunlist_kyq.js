

import axios from '@/libs/api.request'

export const getChrunlist_kyqListAll = () => {
  return axios.request({
    url:  'Dncchrunlist_kyq' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getChrunlist_kyqList = (data) => {
  return axios.request({
    url:  'Dncchrunlist_kyq' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createChrunlist_kyq = (data) => {
  return axios.request({
    url:  'Dncchrunlist_kyq' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadChrunlist_kyq = (data) => {
  return axios.request({
    url: 'Dncchrunlist_kyq' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editChrunlist_kyq = (data) => {
  return axios.request({
    url: 'Dncchrunlist_kyq' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteChrunlist_kyq = (ids) => {
  return axios.request({
    url: 'Dncchrunlist_kyq'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncchrunlist_kyq'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateChrunlist_kyq = (data) => {
  return axios.request({
    url:  'Dncchrunlist_kyq' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

