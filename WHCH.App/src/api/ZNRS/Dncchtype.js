

import axios from '@/libs/api.request'

export const getChtypeListAll = () => {
  return axios.request({
    url:  'Dncchtype' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getChtypeList = (data) => {
  return axios.request({
    url:  'Dncchtype' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createChtype = (data) => {
  return axios.request({
    url:  'Dncchtype' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadChtype = (data) => {
  return axios.request({
    url: 'Dncchtype' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editChtype = (data) => {
  return axios.request({
    url: 'Dncchtype' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteChtype = (ids) => {
  return axios.request({
    url: 'Dncchtype'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncchtype'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateChtype = (data) => {
  return axios.request({
    url:  'Dncchtype' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

