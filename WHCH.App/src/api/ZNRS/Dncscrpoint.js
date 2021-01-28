

import axios from '@/libs/api.request'

export const getScrpointListAll = () => {
  return axios.request({
    url:  'Dncscrpoint' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getScrpointList = (data) => {
  return axios.request({
    url:  'Dncscrpoint' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createScrpoint = (data) => {
  return axios.request({
    url:  'Dncscrpoint' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadScrpoint = (data) => {
  return axios.request({
    url: 'Dncscrpoint' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editScrpoint = (data) => {
  return axios.request({
    url: 'Dncscrpoint' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

export const Debugbug = (data) => {
  return axios.request({
    url: 'Dncscrpoint' +'/Debugbug',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}



// delete role
export const deleteScrpoint = (ids) => {
  return axios.request({
    url: 'Dncscrpoint'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncscrpoint'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateScrpoint = (data) => {
  return axios.request({
    url:  'Dncscrpoint' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

