

import axios from '@/libs/api.request'

export const getFireerror_midListAll = () => {
  return axios.request({
    url:  'Dncfireerror_mid' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getFireerror_midList = (data) => {
  return axios.request({
    url:  'Dncfireerror_mid' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createFireerror_mid = (data) => {
  return axios.request({
    url:  'Dncfireerror_mid' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadFireerror_mid = (data) => {
  return axios.request({
    url: 'Dncfireerror_mid' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editFireerror_mid = (data) => {
  return axios.request({
    url: 'Dncfireerror_mid' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteFireerror_mid = (ids) => {
  return axios.request({
    url: 'Dncfireerror_mid'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncfireerror_mid'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateFireerror_mid = (data) => {
  return axios.request({
    url:  'Dncfireerror_mid' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

