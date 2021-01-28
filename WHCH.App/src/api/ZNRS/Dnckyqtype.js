

import axios from '@/libs/api.request'

export const getKyqtypeListAll = () => {
  return axios.request({
    url:  'Dnckyqtype' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getKyqtypeList = (data) => {
  return axios.request({
    url:  'Dnckyqtype' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createKyqtype = (data) => {
  return axios.request({
    url:  'Dnckyqtype' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadKyqtype = (data) => {
  return axios.request({
    url: 'Dnckyqtype' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editKyqtype = (data) => {
  return axios.request({
    url: 'Dnckyqtype' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteKyqtype = (ids) => {
  return axios.request({
    url: 'Dnckyqtype'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnckyqtype'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateKyqtype = (data) => {
  return axios.request({
    url:  'Dnckyqtype' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

