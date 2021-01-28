

import axios from '@/libs/api.request'

export const getScrpointdataListAll = () => {
  return axios.request({
    url:  'Dncscrpointdata' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getScrpointdataList = (data) => {
  return axios.request({
    url:  'Dncscrpointdata' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createScrpointdata = (data) => {
  return axios.request({
    url:  'Dncscrpointdata' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadScrpointdata = (data) => {
  return axios.request({
    url: 'Dncscrpointdata' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editScrpointdata = (data) => {
  return axios.request({
    url: 'Dncscrpointdata' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteScrpointdata = (ids) => {
  return axios.request({
    url: 'Dncscrpointdata'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncscrpointdata'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateScrpointdata = (data) => {
  return axios.request({
    url:  'Dncscrpointdata' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

