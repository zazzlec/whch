

import axios from '@/libs/api.request'

export const getExpandgroupListAll = () => {
  return axios.request({
    url:  'Dncexpandgroup' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getExpandgroupList = (data) => {
  return axios.request({
    url:  'Dncexpandgroup' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createExpandgroup = (data) => {
  return axios.request({
    url:  'Dncexpandgroup' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadExpandgroup = (data) => {
  return axios.request({
    url: 'Dncexpandgroup' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editExpandgroup = (data) => {
  return axios.request({
    url: 'Dncexpandgroup' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteExpandgroup = (ids) => {
  return axios.request({
    url: 'Dncexpandgroup'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncexpandgroup'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateExpandgroup = (data) => {
  return axios.request({
    url:  'Dncexpandgroup' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

