

import axios from '@/libs/api.request'

export const getFireerror_adviceListAll = () => {
  return axios.request({
    url:  'Dncfireerror_advice' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getFireerror_adviceList = (data) => {
  return axios.request({
    url:  'Dncfireerror_advice' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createFireerror_advice = (data) => {
  return axios.request({
    url:  'Dncfireerror_advice' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadFireerror_advice = (data) => {
  return axios.request({
    url: 'Dncfireerror_advice' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editFireerror_advice = (data) => {
  return axios.request({
    url: 'Dncfireerror_advice' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteFireerror_advice = (ids) => {
  return axios.request({
    url: 'Dncfireerror_advice'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncfireerror_advice'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateFireerror_advice = (data) => {
  return axios.request({
    url:  'Dncfireerror_advice' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

export const batchok = (data) => {
  return axios.request({
    url:  'Dncfireerror_advice' +'/batchok',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}
