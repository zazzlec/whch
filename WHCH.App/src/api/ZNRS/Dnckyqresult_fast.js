

import axios from '@/libs/api.request'

export const getKyqresult_fastListAll = () => {
  return axios.request({
    url:  'Dnckyqresult_fast' +'/list',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

export const getKyqresult_fastList = (data) => {
  return axios.request({
    url:  'Dnckyqresult_fast' +'/list',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// createRole
export const createKyqresult_fast = (data) => {
  return axios.request({
    url:  'Dnckyqresult_fast' +'/create',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

//loadRole
export const loadKyqresult_fast = (data) => {
  return axios.request({
    url: 'Dnckyqresult_fast' +'/edit/' + data.code,
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/"
  })
}

// editRole
export const editKyqresult_fast = (data) => {
  return axios.request({
    url: 'Dnckyqresult_fast' +'/edit',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    data
  })
}

// delete role
export const deleteKyqresult_fast = (ids) => {
  return axios.request({
    url: 'Dnckyqresult_fast'+'/delete/' + ids,
    withPrefix: false,
    prefix:"api/WHCH1/",
    method: 'get'
  })
}

// batch command
export const batchCommand = (data) => {
  return axios.request({
    url: 'Dnckyqresult_fast'+'/batch',
    method: 'get',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params: data
  })
}


export const batchCreateKyqresult_fast = (data) => {
  return axios.request({
    url:  'Dnckyqresult_fast' +'/batchcreate',
    method: 'post',
    withPrefix: false,
    prefix:"api/WHCH1/",
    params:data
  })
}

