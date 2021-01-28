

import axios from '@/libs/api.request'

export const getWindgroupListAll = () => {
  return axios.request({
    url:  'Dncwindgroup' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getWindgroupList = (data) => {
  return axios.request({
    url:  'Dncwindgroup' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createWindgroup = (data) => {
  return axios.request({
    url:  'Dncwindgroup' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadWindgroup = (data) => {
  return axios.request({
    url: 'Dncwindgroup' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editWindgroup = (data) => {
  return axios.request({
    url: 'Dncwindgroup' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteWindgroup = (ids) => {
  return axios.request({
    url: 'Dncwindgroup'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncwindgroup'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateWindgroup = (data) => {
  return axios.request({
    url:  'Dncwindgroup' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

