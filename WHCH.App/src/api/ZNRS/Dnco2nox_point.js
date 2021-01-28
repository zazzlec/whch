

import axios from '@/libs/api.request'

export const getO2nox_pointListAll = () => {
  return axios.request({
    url:  'Dnco2nox_point' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getO2nox_pointList = (data) => {
  return axios.request({
    url:  'Dnco2nox_point' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createO2nox_point = (data) => {
  return axios.request({
    url:  'Dnco2nox_point' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadO2nox_point = (data) => {
  return axios.request({
    url: 'Dnco2nox_point' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editO2nox_point = (data) => {
  return axios.request({
    url: 'Dnco2nox_point' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteO2nox_point = (ids) => {
  return axios.request({
    url: 'Dnco2nox_point'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnco2nox_point'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateO2nox_point = (data) => {
  return axios.request({
    url:  'Dnco2nox_point' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

