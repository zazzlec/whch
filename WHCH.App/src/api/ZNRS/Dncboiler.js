

import axios from '@/libs/api.request'

export const getBoilerListAll = () => {
  return axios.request({
    url:  'Dncboiler' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getBoilerList = (data) => {
  return axios.request({
    url:  'Dncboiler' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createBoiler = (data) => {
  return axios.request({
    url:  'Dncboiler' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadBoiler = (data) => {
  return axios.request({
    url: 'Dncboiler' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editBoiler = (data) => {
  return axios.request({
    url: 'Dncboiler' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteBoiler = (ids) => {
  return axios.request({
    url: 'Dncboiler'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncboiler'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateBoiler = (data) => {
  return axios.request({
    url:  'Dncboiler' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

