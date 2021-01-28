

import axios from '@/libs/api.request'

export const getGwfspointListAll = () => {
  return axios.request({
    url:  'Dncgwfspoint' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getGwfspointList = (data) => {
  return axios.request({
    url:  'Dncgwfspoint' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createGwfspoint = (data) => {
  return axios.request({
    url:  'Dncgwfspoint' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadGwfspoint = (data) => {
  return axios.request({
    url: 'Dncgwfspoint' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editGwfspoint = (data) => {
  return axios.request({
    url: 'Dncgwfspoint' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteGwfspoint = (ids) => {
  return axios.request({
    url: 'Dncgwfspoint'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncgwfspoint'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateGwfspoint = (data) => {
  return axios.request({
    url:  'Dncgwfspoint' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

