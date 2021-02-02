

import axios from '@/libs/api.request'

export const getChareahisListAll = () => {
  return axios.request({
    url:  'Dncchareahis' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getChareahisList = (data) => {
  return axios.request({
    url:  'Dncchareahis' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createChareahis = (data) => {
  return axios.request({
    url:  'Dncchareahis' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadChareahis = (data) => {
  return axios.request({
    url: 'Dncchareahis' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editChareahis = (data) => {
  return axios.request({
    url: 'Dncchareahis' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteChareahis = (ids) => {
  return axios.request({
    url: 'Dncchareahis'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncchareahis'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateChareahis = (data) => {
  return axios.request({
    url:  'Dncchareahis' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

