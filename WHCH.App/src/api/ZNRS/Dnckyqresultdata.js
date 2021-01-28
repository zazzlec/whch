

import axios from '@/libs/api.request'

export const getKyqresultdataListAll = () => {
  return axios.request({
    url:  'Dnckyqresultdata' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getKyqresultdataList = (data) => {
  return axios.request({
    url:  'Dnckyqresultdata' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createKyqresultdata = (data) => {
  return axios.request({
    url:  'Dnckyqresultdata' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadKyqresultdata = (data) => {
  return axios.request({
    url: 'Dnckyqresultdata' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editKyqresultdata = (data) => {
  return axios.request({
    url: 'Dnckyqresultdata' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteKyqresultdata = (ids) => {
  return axios.request({
    url: 'Dnckyqresultdata'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnckyqresultdata'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateKyqresultdata = (data) => {
  return axios.request({
    url:  'Dnckyqresultdata' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

