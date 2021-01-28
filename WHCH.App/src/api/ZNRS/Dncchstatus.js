

import axios from '@/libs/api.request'

export const getChstatusListAll = () => {
  return axios.request({
    url:  'Dncchstatus' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getChstatusList = (data) => {
  return axios.request({
    url:  'Dncchstatus' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createChstatus = (data) => {
  return axios.request({
    url:  'Dncchstatus' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadChstatus = (data) => {
  return axios.request({
    url: 'Dncchstatus' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editChstatus = (data) => {
  return axios.request({
    url: 'Dncchstatus' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteChstatus = (ids) => {
  return axios.request({
    url: 'Dncchstatus'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dncchstatus'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateChstatus = (data) => {
  return axios.request({
    url:  'Dncchstatus' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

