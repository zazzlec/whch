

import axios from '@/libs/api.request'

export const getWinddataListAll = () => {
  return axios.request({
    url:  'Dncwinddata' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getWinddataList = (data) => {
  return axios.request({
    url:  'Dncwinddata' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createWinddata = (data) => {
  return axios.request({
    url:  'Dncwinddata' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadWinddata = (data) => {
  return axios.request({
    url: 'Dncwinddata' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editWinddata = (data) => {
  return axios.request({
    url: 'Dncwinddata' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteWinddata = (ids) => {
  return axios.request({
    url: 'Dncwinddata'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncwinddata'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateWinddata = (data) => {
  return axios.request({
    url:  'Dncwinddata' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

