

import axios from '@/libs/api.request'

export const getHzpointnowListAll = () => {
  return axios.request({
    url:  'Dnchzpointnow' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getHzpointnowList = (data) => {
  return axios.request({
    url:  'Dnchzpointnow' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createHzpointnow = (data) => {
  return axios.request({
    url:  'Dnchzpointnow' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadHzpointnow = (data) => {
  return axios.request({
    url: 'Dnchzpointnow' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editHzpointnow = (data) => {
  return axios.request({
    url: 'Dnchzpointnow' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteHzpointnow = (ids) => {
  return axios.request({
    url: 'Dnchzpointnow'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnchzpointnow'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateHzpointnow = (data) => {
  return axios.request({
    url:  'Dnchzpointnow' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

