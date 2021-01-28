

import axios from '@/libs/api.request'

export const getChhzpointListAll = () => {
  return axios.request({
    url:  'Dncchhzpoint' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getChhzpointList = (data) => {
  return axios.request({
    url:  'Dncchhzpoint' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createChhzpoint = (data) => {
  return axios.request({
    url:  'Dncchhzpoint' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadChhzpoint = (data) => {
  return axios.request({
    url: 'Dncchhzpoint' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editChhzpoint = (data) => {
  return axios.request({
    url: 'Dncchhzpoint' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteChhzpoint = (ids) => {
  return axios.request({
    url: 'Dncchhzpoint'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncchhzpoint'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateChhzpoint = (data) => {
  return axios.request({
    url:  'Dncchhzpoint' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

